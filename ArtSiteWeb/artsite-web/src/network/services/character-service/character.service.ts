import { Injectable } from '@angular/core';
import { CharacterModel } from 'src/network/models/characterModel';
import { SearchObject } from 'src/network/models/searchModels/SearchObject';
import { ApiService } from '../api-service/api.service';

@Injectable({
  providedIn: 'root'
})
export class CharacterService {

  constructor(private api: ApiService) { }

  getCharacters(){
    return this.api.get<CharacterModel[]>("character");
  }

  getSearchedCharacters(body: SearchObject){
    return this.api.post<CharacterModel[]>("character/search", body);
  }

  getCharacter(id: number | string){
    return this.api.get<CharacterModel>(`character/getbyid?id=${id}`)
  }
}
