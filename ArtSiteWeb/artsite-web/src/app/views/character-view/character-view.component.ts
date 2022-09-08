import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { CharacterModel } from 'src/network/models/characterModel';
import { CharacterService } from 'src/network/services/character-service/character.service';

@Component({
  templateUrl: './character-view.component.html',
  styleUrls: ['./character-view.component.scss']
})
export class CharacterViewComponent implements OnInit {

  character!: CharacterModel;
  isCollapsed = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: CharacterService
  ) { }

  ngOnInit(): void {
     this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
      this.service.getCharacter(params.get('id')?? 0 )
      )
    ).subscribe(((data: CharacterModel) =>
      this.character = data
      ));
  }

}
