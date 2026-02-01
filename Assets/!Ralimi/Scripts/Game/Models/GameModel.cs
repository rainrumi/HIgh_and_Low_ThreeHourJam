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

public enum Phase
{
    Start,
    Shuffle,
    Choise,
    Gudge,
    Result,
    NONE
}

public class GameModel : IDisposable
{
    public ReadOnlyReactiveProperty<int> MinCardValue => _minCardValue;
    public ReadOnlyReactiveProperty<int> MaxCardValue => _maxCardValue;

    public ReadOnlyReactiveProperty<int> OwnValue => _ownValue;
    public ReadOnlyReactiveProperty<int> PeerValue => _peerValue;

    public ReadOnlyReactiveProperty<bool> CanGudge => _canGudge;

    public ReadOnlyReactiveProperty<HighLowChoice> GudgeChoise => _gudgeChoise;

    public ReadOnlyReactiveProperty<Phase> GamePhase => _gamePhase;

    private readonly ReactiveProperty<int> _minCardValue;
    private readonly ReactiveProperty<int> _maxCardValue;

    private readonly ReactiveProperty<int> _ownValue;
    private readonly ReactiveProperty<int> _peerValue;

    private readonly ReactiveProperty<bool> _canGudge;

    private readonly ReactiveProperty<HighLowChoice> _gudgeChoise;

    private readonly ReactiveProperty<Phase> _gamePhase;

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
    public void SetGudgeChoise(HighLowChoice set)
    {
        if (!_canGudge.Value) return;
        _gudgeChoise.Value = set;
    }

    // フェーズ切り替え
    public void SetPhase(Phase set)
    {
        if(set == _gamePhase.Value) return;
        _gamePhase.Value = set;
        OnChangePhase();
    }

    private void OnChangePhase()
    {
        switch(_gamePhase.Value)
        {
            case Phase.Start:
                SetPhase(Phase.Shuffle);
                break;
            case Phase.Shuffle:
                SetCanGudge(false);
                CardShuffle();
                SetPhase(Phase.Choise);
                break;
            case Phase.Choise:
                SetCanGudge(true);
                break;
            case Phase.Gudge:
                break;
            case Phase.Result:
                break;
        }
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
        _gamePhase = new ReactiveProperty<Phase>(Phase.NONE);

        SetPhase(Phase.Start);
    }
    
    public void Dispose()
    {
        _minCardValue.Dispose();
        _maxCardValue.Dispose();
    }
}
