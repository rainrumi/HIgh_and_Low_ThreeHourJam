using Cysharp.Threading.Tasks;
using RaruLib;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultItemView : MonoBehaviour
{
    [SerializeField] private UiViewAsync _uiAsyncView;
    [SerializeField] private UiViewAsync _uiAsyncHide;
    [SerializeField] private TextMeshProUGUI _resultTxt;
    [SerializeField] private ButtonView _resultRetryButton;

    public TextMeshProUGUI ResultText => _resultTxt;
    public ButtonView ResultRetryButton => _resultRetryButton;

    public void Initialize()
    {
        //SetVisible(false);
    }

    public void SetVisible(bool set)
    {
        if(set) _uiAsyncView.ViewEventAsync().Forget();
        else _uiAsyncHide.ViewEventAsync().Forget();
    }

    public void SetResult(Result set)
    {
        switch (set)
        {
            case Result.Win:
                _resultTxt.text = "‚©‚¿!";
                break;
            case Result.Lose:
                _resultTxt.text = "‚Ü‚¯!";
                break;
        }
    }
}
