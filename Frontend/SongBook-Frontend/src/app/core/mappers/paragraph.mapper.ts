import { Injectable } from '@angular/core';
import { IMapper } from '../interfaces/mapper.interface';
import { ParagraphApiModel } from '../models/api/paragraph-api.model';
import { ParagraphUiModel } from '../models/ui/paragraph-ui.model';
import { LineMapper } from './line.mapper';
import { LineApiModel } from '../models/api/line-api.model';
import { LineUiModel } from '../models/ui/line-ui.model';

@Injectable({
  providedIn: 'root'
})
export class ParagraphMapper implements IMapper<ParagraphApiModel, ParagraphUiModel> {
  constructor(private lineMapper: LineMapper) {
    automapper.createMap('ParagraphUiModel', 'ParagraphApiModel')
      .convertToType(ParagraphApiModel)
      .forSourceMember('lines', (opts: AutoMapperJs.IMemberConfigurationOptions) => {
        opts.ignore();
      });

    automapper.createMap('ParagraphApiModel', 'ParagraphUiModel')
    .convertToType(ParagraphUiModel)
    .forSourceMember('lines', (opts: AutoMapperJs.IMemberConfigurationOptions) => {
      opts.ignore();
    });
  }

  mapToApi(source: ParagraphUiModel, out: ParagraphApiModel): ParagraphApiModel {
    out = automapper.map('ParagraphUiModel', 'ParagraphApiModel', source);

    for (const line of source.lines) {
      out.lines.push(this.lineMapper.mapToApi(line, new LineApiModel()));
    }

    return out;
  }

  mapToUi(source: ParagraphApiModel, out: ParagraphUiModel): ParagraphUiModel {
    out = automapper.map('ParagraphApiModel', 'ParagraphUiModel', source);

    out.lines.splice(0, out.lines.length);
    for (const line of source.lines) {
      out.lines.push(this.lineMapper.mapToUi(line, new LineUiModel()));
    }

    return out;
  }
}
