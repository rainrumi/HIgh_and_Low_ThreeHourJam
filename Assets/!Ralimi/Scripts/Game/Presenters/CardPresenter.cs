using R3;
using System;

public class CardPresenter : IDisposable
{
    private readonly CompositeDisposable _disposables = new();

    public CardPresenter(GameModel gameModel, CardDeckView cardDeckView)
    {
        // カードデッキ初期化
        cardDeckView.Initialize();

        gameModel.OwnValue
            .Subscribe(value => cardDeckView.cardOwnDeckView.CardView.SetCardValue(value))
            .AddTo(_disposables);
        gameModel.PeerValue
            .Subscribe(value => cardDeckView.cardPeerDeckView.CardView.SetCardValue(value))
            .AddTo(_disposables);
    }

    public void Dispose()
    {
        _disposables.Dispose();
    }
}
