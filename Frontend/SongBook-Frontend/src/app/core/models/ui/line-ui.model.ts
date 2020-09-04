import { ModelBase } from '../model-base';
import { WordUiModel } from './word-ui.model';

export class LineUiModel extends ModelBase {
  words: WordUiModel[];

  constructor() {
    super();
    this.words = [new WordUiModel()];
  }
}
