import { ModelBase } from '../model-base';
import { ChordUiModel } from './chord-ui.model';

export class WordUiModel extends ModelBase {
  text: string;
  chord: ChordUiModel;

  constructor() {
    super();
    this.text = '';
    this.chord = new ChordUiModel();
  }
}
