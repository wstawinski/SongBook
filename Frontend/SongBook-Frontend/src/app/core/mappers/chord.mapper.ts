import { Injectable } from '@angular/core';
import { IMapper } from '../interfaces/mapper.interface';
import { ChordApiModel } from '../models/api/chord-api.model';
import { ChordUiModel } from '../models/ui/chord-ui.model';

@Injectable({
  providedIn: 'root'
})
export class ChordMapper implements IMapper<ChordApiModel, ChordUiModel> {
  constructor() {
    automapper.createMap('ChordUiModel', 'ChordApiModel')
      .convertToType(ChordApiModel)
      .forSourceMember('chordLocalisation', (opts: AutoMapperJs.IMemberConfigurationOptions) => {
        opts.ignore();
      });

    automapper.createMap('ChordApiModel', 'ChordUiModel')
      .convertToType(ChordUiModel)
      .forSourceMember('chordSchema', (opts: AutoMapperJs.IMemberConfigurationOptions) => {
        opts.ignore();
      });
  }

  mapToApi(source: ChordUiModel, out: ChordApiModel): ChordApiModel {
    out = automapper.map('ChordUiModel', 'ChordApiModel', source);

    for (const key in source.chordLocalisation) {
      if (source.chordLocalisation.hasOwnProperty(key)) {
        if (source.chordLocalisation[key]) {
          out.chordSchema += key.toUpperCase() + ', ';
        }
      }
    }

    return out;
  }

  mapToUi(source: ChordApiModel, out: ChordUiModel): ChordUiModel {
    out = automapper.map('ChordApiModel', 'ChordUiModel', source);

    const selectedProperties = source.chordSchema.split(', ');
    for (const property of selectedProperties) {
      if (out.chordLocalisation.hasOwnProperty(property.toLowerCase())) {
        out.chordLocalisation[property.toLowerCase()] = true;
      }
    }

    return out;
  }
}
