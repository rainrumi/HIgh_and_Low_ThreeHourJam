
using R3;
using UnityEngine;
using UnityEngine.UI;

public class ButtonView : MonoBehaviour
{
    private ButtonSettings setting;
    private float value = 0;

    [SerializeField] Button gudgeButton;

    public Observable<Unit> OnClick => _onClick;
    private readonly Subject<Unit> _onClick = new();

    public void Initialize(ButtonSettings s)
    {
        setting = s;
        Color.RGBToHSV(gudgeButton.colors.normalColor, out _, out _, out value);
    }

    public void OnClickButton()
    {
        _onClick.OnNext(Unit.Default);
    }

    public void SetButtonInteractable(bool set)
    {
        Debug.Log($"{set}‚É‚È‚Á‚½");
        gudgeButton.interactable = set;

        var colors = gudgeButton.colors;
        var color = gudgeButton.colors.normalColor;
        Color.RGBToHSV(color, out var h, out var s, out var v);
        if (set)
        {
            colors.normalColor = Color.HSVToRGB(h, s, value);
        }
        else
        {
            v = Mathf.Clamp01(value * setting.disableColorValurFactor);
            colors.normalColor = Color.HSVToRGB(h, s, v);
        }
        gudgeButton.colors = colors;
    }
}
