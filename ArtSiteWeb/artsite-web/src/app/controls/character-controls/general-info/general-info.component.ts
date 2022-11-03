import { Component, Input, OnInit } from '@angular/core';
import { GeneralInfoModel } from 'src/network/models/generalInfoModel';

@Component({
  selector: 'app-general-info',
  templateUrl: './general-info.component.html',
  styleUrls: ['./general-info.component.scss']
})
export class GeneralInfoComponent implements OnInit {

  @Input()
  generalInfo! : GeneralInfoModel;

  constructor() { }

  ngOnInit(): void {
  }

}
