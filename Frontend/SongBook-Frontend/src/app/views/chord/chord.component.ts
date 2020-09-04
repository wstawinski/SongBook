import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-chord',
  templateUrl: './chord.component.html',
  styleUrls: ['./chord.component.scss']
})
export class ChordComponent {
  chordForm = this.formBuilder.group({
    symbol: [''],
    chordLocalisation: this.formBuilder.group({
      f1s1: [false],
      f1s2: [false],
      f1s3: [false],
      f1s4: [false],
      f1s5: [false],
      f1s6: [false],
      f2s1: [false],
      f2s2: [false],
      f2s3: [false],
      f2s4: [false],
      f2s5: [false],
      f2s6: [false],
      f3s1: [false],
      f3s2: [false],
      f3s3: [false],
      f3s4: [false],
      f3s5: [false],
      f3s6: [false]
    })
  });

  constructor(private formBuilder: FormBuilder) { }

  submitChordForm() {
    console.log(this.chordForm.getRawValue());
  }
}
