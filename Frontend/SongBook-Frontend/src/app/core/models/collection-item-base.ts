import { ModelBase } from './model-base';

export class CollectionItemBase extends ModelBase {
  isDeleted: boolean;
  number: number;

  constructor() {
    super();
    this.isDeleted = false;
    this.number = 0;
  }
}
