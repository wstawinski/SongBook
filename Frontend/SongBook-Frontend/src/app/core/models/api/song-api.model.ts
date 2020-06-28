import { ModelBase } from '../model-base';
import { ParagraphApiModel } from './paragraph-api.model';

export class SongApiModel extends ModelBase {
  performer: string;
  title: string;
  paragraphs: ParagraphApiModel[];

  constructor() {
    super();
    this.performer = '';
    this.title = '';
    this.paragraphs = [];
  }
}
