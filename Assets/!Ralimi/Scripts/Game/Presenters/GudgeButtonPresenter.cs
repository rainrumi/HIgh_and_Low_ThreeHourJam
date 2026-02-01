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
    }

    public void Dispose()
    {
        _disposables.Dispose();
    }
}
