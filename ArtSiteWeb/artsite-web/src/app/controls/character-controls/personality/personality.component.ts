import { Component, Input, OnInit } from '@angular/core';
import { PersonalityModel } from 'src/network/models/personalityModel';

@Component({
  selector: 'app-personality',
  templateUrl: './personality.component.html',
  styleUrls: ['./personality.component.scss']
})
export class PersonalityComponent implements OnInit {

  @Input()
  personality! : PersonalityModel;

  constructor() { }

  ngOnInit(): void {
  }

}
