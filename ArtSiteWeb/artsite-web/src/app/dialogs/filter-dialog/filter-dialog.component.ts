import { TaggedTemplateExpr } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { SearchObject } from 'src/network/models/searchModels/SearchObject';
import { SpeciesModel } from 'src/network/models/speciesModel';
import { TagModel } from 'src/network/models/tagModel';
import { SpeciesService } from 'src/network/services/species-service/species.service';
import { TagService } from 'src/network/services/tag-service/tag.service';

@Component({
  selector: 'app-filter-dialog',
  templateUrl: './filter-dialog.component.html',
  styleUrls: ['./filter-dialog.component.scss']
})
export class FilterDialogComponent implements OnInit {

  tags: TagModel[] = [];
  species: SpeciesModel[] = [];

  filteredTags: Map<TagModel, boolean> = new Map();
  filteredSpecies?: SpeciesModel;

  constructor(private tagService: TagService, private speciesService: SpeciesService) { }

  ngOnInit(): void {
    this.tagService.getTags().subscribe(data =>{
      this.tags = data;
    })

    this.speciesService.getSpecies().subscribe(data =>{
      this.species = data;
    })
  }

  onSearch(): SearchObject{
    var searchObject = new SearchObject();

    if(this.filteredTags.size != 0){
      var tags = new Map<number, boolean>();
      this.filteredTags.forEach( (value: boolean, key: TagModel) => {
        tags.set(key.id, value);
      });
      searchObject.tags = tags;
    }

    searchObject.species = this.filteredSpecies?.id;

    return searchObject;
  }
}
