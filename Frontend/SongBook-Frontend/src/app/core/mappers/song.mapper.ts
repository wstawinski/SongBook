import { Injectable } from '@angular/core';
import { IMapper } from '../interfaces/mapper.interface';
import { SongApiModel } from '../models/api/song-api.model';
import { SongUiModel } from '../models/ui/song-ui.model';
import { ParagraphMapper } from './paragraph.mapper';
import { ParagraphApiModel } from '../models/api/paragraph-api.model';
import { ParagraphUiModel } from '../models/ui/paragraph-ui.model';

@Injectable({
  providedIn: 'root'
})
export class SongMapper implements IMapper<SongApiModel, SongUiModel> {
  constructor(private paragraphMapper: ParagraphMapper) {
    automapper.createMap('SongUiModel', 'SongApiModel')
    .convertToType(SongApiModel)
    .forSourceMember('paragraphs', (opts: AutoMapperJs.IMemberConfigurationOptions) => {
      opts.ignore();
    });

    automapper.createMap('SongApiModel', 'SongUiModel')
    .convertToType(SongUiModel)
    .forSourceMember('paragraphs', (opts: AutoMapperJs.IMemberConfigurationOptions) => {
      opts.ignore();
    });
  }

  mapToApi(source: SongUiModel, out: SongApiModel): SongApiModel {
    out = automapper.map('SongUiModel', 'SongApiModel', source);

    for (const paragraph of source.paragraphs) {
      out.paragraphs.push(this.paragraphMapper.mapToApi(paragraph, new ParagraphApiModel()));
    }

    return out;
  }
  mapToUi(source: SongApiModel, out: SongUiModel): SongUiModel {
    out = automapper.map('SongApiModel', 'SongUiModel', source);

    out.paragraphs.splice(0, out.paragraphs.length);
    for (const paragraph of source.paragraphs) {
      out.paragraphs.push(this.paragraphMapper.mapToUi(paragraph, new ParagraphUiModel()));
    }

    return out;
  }
}
