import { ModelBase } from '../model-base';
import { WordApiModel } from './word-api.model';

export class LineApiModel extends ModelBase {
  words: WordApiModel[];

  constructor() {
    super();
    this.words = [];
  }
}
