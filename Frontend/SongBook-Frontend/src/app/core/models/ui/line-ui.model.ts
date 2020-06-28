import { CollectionItemBase } from '../collection-item-base';
import { WordUiModel } from './word-ui.model';

export class LineUiModel extends CollectionItemBase {
  words: WordUiModel[];

  constructor() {
    super();
    this.words = [new WordUiModel()];
  }
}
