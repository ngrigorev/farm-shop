import { Component, Inject, Input } from '@angular/core';
import { IMedicament } from 'src/app/models/medicament';

@Component({
  selector: 'app-medicament',
  templateUrl: './medicament.component.html',
  styleUrls: ['./medicament.component.scss']
})
export class MedicamentComponent {
  @Input() medicament: IMedicament;
}
