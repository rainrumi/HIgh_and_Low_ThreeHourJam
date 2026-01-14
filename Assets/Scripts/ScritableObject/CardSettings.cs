using System;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(CardSettings), menuName = "Settings/"+nameof(CardSettings))]
public class CardSettings : ScriptableObject
{
    [SerializeField] private int minValue;
    [SerializeField] private int maxValue;
    
    public int MinValue => minValue;
    public int MaxValue => maxValue;
}
