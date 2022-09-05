import { Component, Input, OnInit } from '@angular/core';
import { ArtworkModel } from 'src/network/models/artworkModel';
import { CharacterModel } from 'src/network/models/characterModel';
import { ArtworkService } from 'src/network/services/artwork-service/artwork.service';

@Component({
  selector: 'app-character-list-item',
  templateUrl: './character-list-item.component.html',
  styleUrls: ['./character-list-item.component.scss'],
  providers: [ArtworkService]
})
export class CharacterListItemComponent implements OnInit {

  @Input()
  character!: CharacterModel;

  constructor(private artworkService: ArtworkService) { }

  ngOnInit(): void {
  }
}
