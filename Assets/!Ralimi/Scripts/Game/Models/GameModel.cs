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

public enum Result
{
    Win,
    Lose
}

public class GameModel : IDisposable
{
    public ReadOnlyReactiveProperty<int> MinCardValue => _minCardValue;
    public ReadOnlyReactiveProperty<int> MaxCardValue => _maxCardValue;

    public ReadOnlyReactiveProperty<int> OwnValue => _ownValue;
    public ReadOnlyReactiveProperty<int> PeerValue => _peerValue;

    public ReadOnlyReactiveProperty<bool> CanGudge => _canGudge;

    public ReadOnlyReactiveProperty<HighLowChoice> GudgeChoise => _gudgeChoise;

    public ReadOnlyReactiveProperty<Result> GameResult => _gameResult;

    public ReadOnlyReactiveProperty<Phase> GamePhase => _gamePhase;

    private readonly ReactiveProperty<int> _minCardValue;
    private readonly ReactiveProperty<int> _maxCardValue;

    private readonly ReactiveProperty<int> _ownValue;
    private readonly ReactiveProperty<int> _peerValue;

    private readonly ReactiveProperty<bool> _canGudge;

    private readonly ReactiveProperty<HighLowChoice> _gudgeChoise;

    private readonly ReactiveProperty<Phase> _gamePhase;

    private readonly ReactiveProperty<Result> _gameResult;

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
        SetPhase(Phase.Gudge);
    }

    // フェーズ切り替え
    public void SetPhase(Phase set)
    {
        if (set == _gamePhase.Value) return;
        _gamePhase.Value = set;
        OnChangePhase();
    }

    // 勝敗
    private void SetResultState()
    {
        bool successHigh = _ownValue.Value < _peerValue.Value;
        bool successDraw = _ownValue.Value == _peerValue.Value;
        bool successLow = _ownValue.Value > _peerValue.Value;
        bool win =
            successHigh && _gudgeChoise.Value == HighLowChoice.High ||
            successDraw && _gudgeChoise.Value == HighLowChoice.Draw ||
            successLow  && _gudgeChoise.Value == HighLowChoice.Low;
        
        if(win) _gameResult.Value = Result.Win;
        else _gameResult.Value = Result.Lose;
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
                SetCanGudge(false);
                SetPhase(Phase.Result);
                break;
            case Phase.Result:
                SetResultState();
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
        _gameResult = new ReactiveProperty<Result>(Result.Win);

        SetPhase(Phase.Start);
    }
    
    public void Dispose()
    {
        _minCardValue.Dispose();
        _maxCardValue.Dispose();
    }
}
