using UnityEngine;

[CreateAssetMenu(fileName = nameof(ButtonSettings), menuName = "Settings/" + nameof(ButtonSettings))]
public class ButtonSettings : ScriptableObject
{
    [Header("‰Ÿ‚·‚±‚Æ‚ª‚Å‚«‚È‚¢ƒ{ƒ^ƒ“‚Ì–¾“x")]
    [Range(0, 1)] public float disableColorValurFactor = 0.7f;
}
