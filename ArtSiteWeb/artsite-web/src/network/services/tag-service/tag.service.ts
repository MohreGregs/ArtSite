import { Injectable } from '@angular/core';
import { TagModel } from 'src/network/models/tagModel';
import { ApiService } from '../api-service/api.service';

@Injectable({
  providedIn: 'root'
})
export class TagService {

  constructor(private api: ApiService) { }

  getTags(){
    return this.api.get<TagModel[]>("tag");
  }
}
