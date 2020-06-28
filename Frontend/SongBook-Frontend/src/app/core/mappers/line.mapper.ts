import { Injectable } from '@angular/core';
import { IMapper } from '../interfaces/mapper.interface';
import { LineApiModel } from '../models/api/line-api.model';
import { LineUiModel } from '../models/ui/line-ui.model';
import { WordMapper } from './word.mapper';
import { WordApiModel } from '../models/api/word-api.model';
import { WordUiModel } from '../models/ui/word-ui.model';

@Injectable({
  providedIn: 'root'
})
export class LineMapper implements IMapper<LineApiModel, LineUiModel> {
  constructor(private wordMapper: WordMapper) {
    automapper.createMap('LineUiModel', 'LineApiModel')
      .convertToType(LineApiModel)
      .forSourceMember('words', (opts: AutoMapperJs.IMemberConfigurationOptions) => {
        opts.ignore();
      });

    automapper.createMap('LineApiModel', 'LineUiModel')
    .convertToType(LineUiModel)
    .forSourceMember('words', (opts: AutoMapperJs.IMemberConfigurationOptions) => {
      opts.ignore();
    });
  }

  mapToApi(source: LineUiModel, out: LineApiModel): LineApiModel {
    out = automapper.map('LineUiModel', 'LineApiModel', source);

    for (const word of source.words) {
      out.words.push(this.wordMapper.mapToApi(word, new WordApiModel()));
    }

    return out;
  }

  mapToUi(source: LineApiModel, out: LineUiModel): LineUiModel {
    out = automapper.map('LineApiModel', 'LineUiModel', source);

    out.words.splice(0, out.words.length);
    for (const word of source.words) {
      out.words.push(this.wordMapper.mapToUi(word, new WordUiModel()));
    }

    return out;
  }
}
