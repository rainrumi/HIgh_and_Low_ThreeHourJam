using System;
using R3;

public class ExplanationPresenter : IDisposable
{
    private readonly CompositeDisposable _disposables = new();

    public ExplanationPresenter(GameModel gameModel, ExplanationView explanationView)
    {
        gameModel.GamePhase
            .Where(set => set == Phase.Choise)
            .Subscribe(_ => explanationView.SetVisible(true))
            .AddTo(_disposables);

        gameModel.GamePhase
            .Where(set => set == Phase.Result)
            .Subscribe(_ => explanationView.SetVisible(false))
            .AddTo(_disposables);
    }

    public void Dispose()
    {
        _disposables.Dispose();
    }
}
