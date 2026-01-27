using R3;
using System;
using UnityEngine;

public class CardPresenter : IDisposable
{
    private readonly GameModel _gameModel;
    private readonly CardDeckView _cardDeckView;

    private readonly CompositeDisposable _disposables = new();

    public CardPresenter(GameModel gameModel, CardDeckView cardDeckView)
    {
        _gameModel = gameModel;
        _cardDeckView = cardDeckView;

        // カードデッキ初期化
        _cardDeckView.Initialize();
    }

    public void Dispose()
    {
        _disposables.Dispose();
        _gameModel.Dispose();
    }
}
