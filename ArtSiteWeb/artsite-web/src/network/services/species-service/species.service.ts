import { Injectable } from '@angular/core';
import { SpeciesModel } from 'src/network/models/speciesModel';
import { ApiService } from '../api-service/api.service';

@Injectable({
  providedIn: 'root'
})
export class SpeciesService {

  constructor(private api: ApiService) { }

  getSpecies(){
    return this.api.get<SpeciesModel[]>("species");
  }
}
