import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ChordComponent } from './views/chord/chord.component';
import { SongComponent } from './views/song/song.component';


const routes: Routes = [
  { path: 'chord', component: ChordComponent },
  { path: 'song', component: SongComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
