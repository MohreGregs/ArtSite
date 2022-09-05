import { Injectable } from '@angular/core';
import { CharacterModel } from 'src/network/models/characterModel';
import { ApiService } from '../api-service/api.service';

@Injectable({
  providedIn: 'root'
})
export class CharacterService {

  private characters: CharacterModel[] = [];

  constructor(private api: ApiService) { }

  getCharacters(){
    this.api.get<Array<CharacterModel>>("character").subscribe((data: CharacterModel[]) => this.characters = data);
    return this.characters;
  }
}
