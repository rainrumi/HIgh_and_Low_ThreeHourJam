using System;
using UnityEngine;
using R3;

public enum HighLowChoice
{
    High,
    Low,
    Draw,
    MAX
}

//public enum 

public class GameModel : IDisposable
{
    public ReadOnlyReactiveProperty<int> OwnValue => _ownValue;
    public ReadOnlyReactiveProperty<int> EnemyValue => _enemyValue;
    //public ReadOnlyReactiveProperty<int> EnemyValue => _enemyValue;
    
    // 数字選択イベント
    public Observable<int> OnClickValueSelected => _onClickValueSelected;
    
    private ReadOnlyReactiveProperty<int> _ownValue;
    private ReadOnlyReactiveProperty<int> _enemyValue;
    private readonly Subject<int> _onClickValueSelected = new();

    //public UniTaskVoid Judge(HighLowChoice choice)
    //{
    //    
    //}
    
    public void Dispose()
    {
        
    }
}
