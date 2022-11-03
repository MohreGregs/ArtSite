import { Component, Input, OnInit } from '@angular/core';
import { AppearanceModel } from 'src/network/models/appearanceModel';

@Component({
  selector: 'app-appearance',
  templateUrl: './appearance.component.html',
  styleUrls: ['./appearance.component.scss']
})
export class AppearanceComponent implements OnInit {

  @Input()
  appearance!: AppearanceModel;

  constructor() { }

  ngOnInit(): void {
  }

}
