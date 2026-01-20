using R3;
using System;
using UnityEngine;

public class CardPresenter : IDisposable
{
    private readonly CompositeDisposable _disposables = new();

    public CardPresenter(GameModel gameModel)
    {
        
    }

    public void Dispose()
    {
        _disposables.Dispose();
    }
}
