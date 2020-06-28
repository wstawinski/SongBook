import { CollectionItemBase } from '../collection-item-base';
import { WordApiModel } from './word-api.model';

export class LineApiModel extends CollectionItemBase {
  words: WordApiModel[];

  constructor() {
    super();
    this.words = [];
  }
}
