using System;
using R3;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultPresenter : IDisposable
{
    private readonly CompositeDisposable _disposables = new();

    public ResultPresenter(GameModel gameModel, ResultView resultView)
    {
        // ‰Šú‰»
        resultView.Initialize();

        gameModel.GamePhase
            .Where(set => set == Phase.Result)
            .Subscribe(_ => resultView.ResultItem.SetVisible(true))
            .AddTo(_disposables);

        gameModel.GameResult
            .Subscribe(set=>resultView.ResultItem.SetResult(set))
            .AddTo(_disposables);

        resultView.ResultItem.ResultRetryButton.OnClick
            .Subscribe(_ => SceneManager.LoadScene("Game"))
            .AddTo(_disposables);
    }

    public void Dispose()
    {
        _disposables.Dispose();
    }
}
