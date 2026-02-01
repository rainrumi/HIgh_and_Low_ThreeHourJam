using System;
using UnityEngine;

public class GudgeButtonView : MonoBehaviour
{
    [Serializable]
    public class GudgeButton
    {
        [SerializeField] private ButtonView gudgeBtnPrefab;

        [SerializeField] private RectTransform gudgeBtnContainer;

        public ButtonView ButtonView { get; private set; }

        public void Initialize(ButtonSettings buttonSettings)
        {
            GenerateGudgeBtnView(buttonSettings);
        }

        private void GenerateGudgeBtnView(ButtonSettings buttonSettings)
        {
            ButtonView = Instantiate(gudgeBtnPrefab, gudgeBtnContainer);
            ButtonView.Initialize(buttonSettings);
        }
    }

    [SerializeField] GudgeButton _buttonHighView;
    [SerializeField] GudgeButton _buttonDrawView;
    [SerializeField] GudgeButton _buttonLowView;

    public GudgeButton ButtonHighView => _buttonHighView;
    public GudgeButton ButtonDrawView => _buttonDrawView;
    public GudgeButton ButtonLowView => _buttonLowView;

    public void Initialize(ButtonSettings buttonSettings)
    {
        _buttonHighView.Initialize(buttonSettings);
        _buttonDrawView.Initialize(buttonSettings);
        _buttonLowView.Initialize(buttonSettings);
    }
}
