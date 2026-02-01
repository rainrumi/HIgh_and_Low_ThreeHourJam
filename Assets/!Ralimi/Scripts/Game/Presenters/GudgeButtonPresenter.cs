using System;
using R3;

public class GudgeButtonPresenter : IDisposable
{
    private readonly CompositeDisposable _disposables = new();

    public GudgeButtonPresenter(GameModel gameModel, GudgeButtonView gudgeButtonView,
        ButtonSettings buttonSettings)
    {
        // ‰Šú‰»
        gudgeButtonView.Initialize(buttonSettings);

        gameModel.CanGudge
            .Subscribe(set =>
            {
                gudgeButtonView.ButtonHighView.ButtonView.SetButtonInteractable(set);
                gudgeButtonView.ButtonDrawView.ButtonView.SetButtonInteractable(set);
                gudgeButtonView.ButtonLowView.ButtonView.SetButtonInteractable(set);
            }
            ).AddTo(_disposables);

        gudgeButtonView.ButtonHighView.ButtonView.OnClick
            .Subscribe(_ => gameModel.SetGudgeChoise(HighLowChoice.High)).AddTo(_disposables);
        gudgeButtonView.ButtonDrawView.ButtonView.OnClick
            .Subscribe(_=>gameModel.SetGudgeChoise(HighLowChoice.Draw)).AddTo(_disposables);
        gudgeButtonView.ButtonLowView.ButtonView.OnClick
            .Subscribe(_ => gameModel.SetGudgeChoise(HighLowChoice.Low)).AddTo(_disposables);
    }

    public void Dispose()
    {
        _disposables.Dispose();
    }
}
