import { Injectable } from '@angular/core';
import { CharacterModel } from 'src/network/models/characterModel';
import { ApiService } from '../api-service/api.service';

@Injectable({
  providedIn: 'root'
})
export class CharacterService {

  constructor(private api: ApiService) { }

  getCharacters(){
    return this.api.get<CharacterModel[]>("character");
  }

  getCharacter(id: number | string){
    return this.api.get<CharacterModel>(`character/getbyid?id=${id}`)
  }
}
