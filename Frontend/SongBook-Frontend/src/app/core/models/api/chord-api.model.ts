import { ModelBase } from '../model-base';

export class ChordApiModel extends ModelBase {
  symbol: string;
  chordSchema: string;

  constructor() {
    super();
    this.symbol = '';
    this.chordSchema = 'None';
  }
}
