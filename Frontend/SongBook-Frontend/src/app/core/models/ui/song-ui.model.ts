import { ModelBase } from '../model-base';
import { ParagraphUiModel } from './paragraph-ui.model';

export class SongUiModel extends ModelBase {
  performer: string;
  title: string;
  paragraphs: ParagraphUiModel[];

  constructor() {
    super();
    this.performer = '';
    this.title = '';
    this.paragraphs = [new ParagraphUiModel()];
  }
}
