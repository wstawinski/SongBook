import { ModelBase } from '../model-base';
import { ChordApiModel } from './chord-api.model';

export class WordApiModel extends ModelBase {
  text: string;
  chord: ChordApiModel;

  constructor() {
    super();
    this.text = '';
    this.chord = new ChordApiModel();
  }
}
