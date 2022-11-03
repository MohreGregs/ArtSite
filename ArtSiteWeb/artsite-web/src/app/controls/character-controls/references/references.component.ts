import { Component, Input, OnInit } from '@angular/core';
import { ReferenceModel } from 'src/network/models/referenceModel';

@Component({
  selector: 'app-references',
  templateUrl: './references.component.html',
  styleUrls: ['./references.component.scss']
})
export class ReferencesComponent implements OnInit {

  @Input()
  references!: ReferenceModel[];

  constructor() { }

  ngOnInit(): void {
  }

}
