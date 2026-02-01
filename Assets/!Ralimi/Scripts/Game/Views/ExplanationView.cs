using TMPro;
using UnityEngine;

public class ExplanationView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI explanationText;

    public void SetVisible(bool set)
    {
        explanationText.enabled = set;
    }

    public void SetText(string set)
    {
        explanationText.text = set;
    }
}
