import { ModelBase } from '../model-base';
import { LineApiModel } from './line-api.model';

export class ParagraphApiModel extends ModelBase {
  lines: LineApiModel[];

  constructor() {
    super();
    this.lines = [];
  }
}
