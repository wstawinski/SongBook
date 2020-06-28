import { CollectionItemBase } from '../collection-item-base';
import { ChordUiModel } from './chord-ui.model';

export class WordUiModel extends CollectionItemBase {
  text: string;
  chord: ChordUiModel;

  constructor() {
    super();
    this.text = '';
    this.chord = new ChordUiModel();
  }
}
