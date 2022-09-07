import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeViewComponent } from './views/home-view/home-view.component';
import { CharactersViewComponent } from './views/characters-view/characters-view.component';
import { PageNotFoundComponent } from './views/page-not-found/page-not-found.component';
import { CharacterViewComponent } from './views/character-view/character-view.component';

const routes: Routes = [
  { path: 'home', title:'Home', component: HomeViewComponent},
  { path: 'characters', title:'Characters', component: CharactersViewComponent},
  { path: 'character/:id', title:'Character', component: CharacterViewComponent},

  { path: '',   redirectTo: '/home', pathMatch: 'full' },
  { path: '**', component: PageNotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
