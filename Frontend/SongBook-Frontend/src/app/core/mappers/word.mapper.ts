import { Injectable } from '@angular/core';
import { IMapper } from '../interfaces/mapper.interface';
import { WordApiModel } from '../models/api/word-api.model';
import { WordUiModel } from '../models/ui/word-ui.model';
import { ChordMapper } from './chord.mapper';
import { ChordApiModel } from '../models/api/chord-api.model';
import { ChordUiModel } from '../models/ui/chord-ui.model';

@Injectable({
  providedIn: 'root'
})
export class WordMapper implements IMapper<WordApiModel, WordUiModel> {
  constructor(private chordMapper: ChordMapper) {
    automapper.createMap('WordUiModel', 'WordApiModel')
      .convertToType(WordApiModel)
      .forSourceMember('chord', (opts: AutoMapperJs.IMemberConfigurationOptions) => {
        opts.ignore();
      });

    automapper.createMap('WordApiModel', 'WordUiModel')
    .convertToType(WordUiModel)
    .forSourceMember('chord', (opts: AutoMapperJs.IMemberConfigurationOptions) => {
      opts.ignore();
    });
  }

  mapToApi(source: WordUiModel, out: WordApiModel): WordApiModel {
    out = automapper.map('WordUiModel', 'WordApiModel', source);
    out.chord = this.chordMapper.mapToApi(source.chord, new ChordApiModel());

    return out;
  }

  mapToUi(source: WordApiModel, out: WordUiModel): WordUiModel {
    out = automapper.map('WordApiModel', 'WordUiModel', source);
    out.chord = this.chordMapper.mapToUi(source.chord, new ChordUiModel());

    return out;
  }
}
