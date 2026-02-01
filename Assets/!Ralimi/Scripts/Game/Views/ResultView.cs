using System;
using TMPro;
using UnityEngine;

public class ResultView : MonoBehaviour
{
    [SerializeField] private RectTransform _resultContainer;
    [SerializeField] private ResultItemView _resultItem;
    public ResultItemView ResultItem { get; private set; }

    public void Initialize()
    {
        GenerateResultPrefab();
    }

    private void GenerateResultPrefab()
    {
        ResultItem = Instantiate(_resultItem, _resultContainer);
        ResultItem.Initialize();
    }
}
