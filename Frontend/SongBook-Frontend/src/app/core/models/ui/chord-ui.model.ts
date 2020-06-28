import { ModelBase } from '../model-base';
import { ChordLocalisationModel } from './chord-localisation.model';

export class ChordUiModel extends ModelBase {
  symbol: string;
  chordLocalisation: ChordLocalisationModel;

  constructor() {
    super();
    this.symbol = '';
    this.chordLocalisation = new ChordLocalisationModel();
  }
}
