import { CollectionItemBase } from '../collection-item-base';
import { LineUiModel } from './line-ui.model';

export class ParagraphUiModel extends CollectionItemBase {
  lines: LineUiModel[];

  constructor() {
    super();
    this.lines = [new LineUiModel()];
  }
}
