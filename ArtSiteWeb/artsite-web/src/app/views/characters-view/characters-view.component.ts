import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { FilterDialogComponent } from 'src/app/dialogs/filter-dialog/filter-dialog.component';
import { CharacterModel } from 'src/network/models/characterModel';
import { SearchObject } from 'src/network/models/searchModels/SearchObject';
import { CharacterService } from 'src/network/services/character-service/character.service';



@Component({
  templateUrl: './characters-view.component.html',
  styleUrls: ['./characters-view.component.scss'],
  providers: [CharacterService]
})
export class CharactersViewComponent implements OnInit {

  chars: CharacterModel[] = [];
  filteredChars: CharacterModel[] =[];
  value = '';

  constructor(private charService: CharacterService, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.charService.getCharacters().subscribe((data: CharacterModel[]) => {
      this.chars = data;
      this.filteredChars = this.chars;
    });

  }

  onSearch(){
    let s = new SearchObject();

    s.nameString = this.value;

    this.charService.getSearchedCharacters(s);
  }

  onOpenFilterDialog(){
    const dialogRef = this.dialog.open(FilterDialogComponent);

    dialogRef.afterClosed().subscribe(result =>{
      if(!result) return;

      this.charService.getSearchedCharacters(result).subscribe((data: CharacterModel[]) => {
        this.filteredChars = data;
      });
    });
  }
}
