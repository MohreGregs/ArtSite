import { Component, Input, OnInit } from '@angular/core';
import { CharacterModel } from 'src/network/models/characterModel';
import { CharacterService } from 'src/network/services/character-service/character.service';



@Component({
  templateUrl: './characters-view.component.html',
  styleUrls: ['./characters-view.component.scss'],
  providers: [CharacterService]
})
export class CharactersViewComponent implements OnInit {

  chars: CharacterModel[] = [];

  constructor(private charService: CharacterService) { }

  ngOnInit(): void {
    this.charService.getCharacters().subscribe((data: CharacterModel[]) => this.chars = data);
  }

}
