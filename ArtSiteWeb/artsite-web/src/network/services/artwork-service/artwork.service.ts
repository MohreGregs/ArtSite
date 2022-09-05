import { Injectable } from '@angular/core';
import { ArtworkModel } from 'src/network/models/artworkModel';
import { ApiService } from '../api-service/api.service';

@Injectable({
  providedIn: 'root'
})
export class ArtworkService {

  constructor(private api: ApiService) { }

  getArtworks(){
    return this.api.get<ArtworkModel[]>("artwork");
  }

  getArtwork(id: number){
    return this.api.get<ArtworkModel>(`artwork/getbyid?id=${id}`)
  }
}
