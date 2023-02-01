import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import {MatDialogModule} from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { HomeViewComponent } from './views/home-view/home-view.component';
import { CharactersViewComponent } from './views/characters-view/characters-view.component';
import { PageNotFoundComponent } from './views/page-not-found/page-not-found.component';
import { MatInputModule } from '@angular/material/input';
import { CharacterListItemComponent } from './controls/character-list-item/character-list-item.component';
import { CharacterViewComponent } from './views/character-view/character-view.component';
import { GeneralInfoComponent } from './controls/character-controls/general-info/general-info.component';
import { PersonalityComponent } from './controls/character-controls/personality/personality.component';
import { InterestsComponent } from './controls/character-controls/interests/interests.component';
import { AppearanceComponent } from './controls/character-controls/appearance/appearance.component';
import { ReferencesComponent } from './controls/character-controls/references/references.component';
import { ArtworkPreviewComponent } from './controls/character-controls/artwork-preview/artwork-preview.component';
import { DocumentPreviewComponent } from './controls/character-controls/document-preview/document-preview.component';
import { FilterDialogComponent } from './dialogs/filter-dialog/filter-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeViewComponent,
    CharactersViewComponent,
    PageNotFoundComponent,
    CharacterListItemComponent,
    CharacterViewComponent,
    GeneralInfoComponent,
    PersonalityComponent,
    InterestsComponent,
    AppearanceComponent,
    ReferencesComponent,
    ArtworkPreviewComponent,
    DocumentPreviewComponent,
    FilterDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatInputModule,
    HttpClientModule,
    FormsModule,
    MatDialogModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
