import { CollectionItemBase } from '../collection-item-base';
import { LineApiModel } from './line-api.model';

export class ParagraphApiModel extends CollectionItemBase {
  lines: LineApiModel[];

  constructor() {
    super();
    this.lines = [];
  }
}
