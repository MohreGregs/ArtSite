import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { HomeViewComponent } from './views/home-view/home-view.component';
import { CharactersViewComponent } from './views/characters-view/characters-view.component';
import { PageNotFoundComponent } from './views/page-not-found/page-not-found.component';
import { SearchBarComponent } from './controls/search-bar/search-bar.component';
import { MatInputModule } from '@angular/material/input';
import { CharacterListItemComponent } from './controls/character-list-item/character-list-item.component';
import { CharacterViewComponent } from './views/character-view/character-view.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeViewComponent,
    CharactersViewComponent,
    PageNotFoundComponent,
    SearchBarComponent,
    CharacterListItemComponent,
    CharacterViewComponent
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
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
