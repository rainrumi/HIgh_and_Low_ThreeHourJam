
using R3;
using UnityEngine;
using UnityEngine.UI;

public class ButtonView : MonoBehaviour
{
    private ButtonSettings setting;

    [SerializeField] Button gudgeButton;

    public Observable<Unit> OnClick => _onClick;
    private readonly Subject<Unit> _onClick = new();

    public void Initialize(ButtonSettings s)
    {
        setting = s;
    }

    public void OnClickButton()
    {
        _onClick.OnNext(Unit.Default);
    }

    public void SetButtonInteractable(bool set)
    {
        gudgeButton.interactable = set;
    }
}
