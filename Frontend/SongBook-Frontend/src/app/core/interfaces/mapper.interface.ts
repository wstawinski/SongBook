export interface IMapper<TApiModel, TUiModel> {
  mapToApi(source: TUiModel, out: TApiModel): TApiModel;
  mapToUi(source: TApiModel, out: TUiModel): TUiModel;
}
