import { Component, Input, OnInit } from '@angular/core';
import { InterestsModel } from 'src/network/models/interestsModel';

@Component({
  selector: 'app-interests',
  templateUrl: './interests.component.html',
  styleUrls: ['./interests.component.scss']
})
export class InterestsComponent implements OnInit {

  @Input()
  interests! : InterestsModel;

  constructor() { }

  ngOnInit(): void {
  }

}
