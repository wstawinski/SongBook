import { ModelBase } from '../model-base';
import { LineUiModel } from './line-ui.model';

export class ParagraphUiModel extends ModelBase {
  lines: LineUiModel[];

  constructor() {
    super();
    this.lines = [new LineUiModel()];
  }
}
