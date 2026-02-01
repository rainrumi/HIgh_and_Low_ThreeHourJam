using System;
using R3;
using RaruLib;

public enum HighLowChoice
{
    None,
    High,
    Low,
    Draw,
    MAX
}

public class GameModel : IDisposable
{
    public ReadOnlyReactiveProperty<int> MinCardValue => _minCardValue;
    public ReadOnlyReactiveProperty<int> MaxCardValue => _maxCardValue;

    public ReadOnlyReactiveProperty<int> OwnValue => _ownValue;
    public ReadOnlyReactiveProperty<int> PeerValue => _peerValue;

    public ReadOnlyReactiveProperty<bool> CanGudge => _canGudge;

    public ReadOnlyReactiveProperty<HighLowChoice> GudgeChoise => _gudgeChoise;

    private readonly ReactiveProperty<int> _minCardValue;
    private readonly ReactiveProperty<int> _maxCardValue;

    private readonly ReactiveProperty<int> _ownValue;
    private readonly ReactiveProperty<int> _peerValue;

    private readonly ReactiveProperty<bool> _canGudge;

    private readonly ReactiveProperty<HighLowChoice> _gudgeChoise;

    private readonly IRandom random;

    // カードのシャッフル
    public void CardShuffle()
    {
        var ownValue = random.Range(_minCardValue.Value, _maxCardValue.Value + 1);
        var peerValue = random.Range(_minCardValue.Value, _maxCardValue.Value + 1);

        _ownValue.Value = ownValue;
        _peerValue.Value = peerValue;
    }

    // 選択可能状態
    public void SetCanGudge(bool set)
    {
        _canGudge.Value = set;
    }

    // プレイヤーの選択
    public void SetGudgeChoise(HighLowChoice choise)
    {
        _gudgeChoise.Value = choise;
    }

    public GameModel(CardSettings settings, IRandom iRandom)
    {
        random = iRandom;
        _minCardValue = new ReactiveProperty<int>(settings.MinValue);
        _maxCardValue = new ReactiveProperty<int>(settings.MaxValue);
        _ownValue = new ReactiveProperty<int>(7);
        _peerValue = new ReactiveProperty<int>(0);
        _canGudge = new ReactiveProperty<bool>(false);
        _gudgeChoise = new ReactiveProperty<HighLowChoice>(HighLowChoice.None);

        SetCanGudge(false);
        CardShuffle();
        SetCanGudge(true);
    }
    
    public void Dispose()
    {
        _minCardValue.Dispose();
        _maxCardValue.Dispose();
    }
}
