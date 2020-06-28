import { CollectionItemBase } from '../collection-item-base';
import { ChordApiModel } from './chord-api.model';

export class WordApiModel extends CollectionItemBase {
  text: string;
  chord: ChordApiModel;

  constructor() {
    super();
    this.text = '';
    this.chord = new ChordApiModel();
  }
}
