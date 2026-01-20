using System;
using R3;
using RaruLib;

public enum HighLowChoice
{
    High,
    Low,
    Draw,
    MAX
}

public class GameModel : IDisposable
{
    public ReadOnlyReactiveProperty<int> MinCardValue => _minCardValue;
    public ReadOnlyReactiveProperty<int> MaxCardValue => _maxCardValue;

    public int OwnValue { get; private set; }
    public int PeerValue { get; private set; }

    private readonly ReactiveProperty<int> _minCardValue;
    private readonly ReactiveProperty<int> _maxCardValue;

    private readonly IRandom random;

    // カードのシャッフル
    public void CardShuffle()
    {
        var ownValue = random.Range(_minCardValue.Value, _maxCardValue.Value + 1);
        var peerValue = random.Range(_minCardValue.Value, _maxCardValue.Value + 1);

        OwnValue = ownValue;
        PeerValue = peerValue;
    }

    public GameModel(CardSettings settings)
    {
        _minCardValue = new ReactiveProperty<int>(settings.MinValue);
        _maxCardValue = new ReactiveProperty<int>(settings.MaxValue);
    }
    
    public void Dispose()
    {
        _minCardValue.Dispose();
        _maxCardValue.Dispose();
    }
}
