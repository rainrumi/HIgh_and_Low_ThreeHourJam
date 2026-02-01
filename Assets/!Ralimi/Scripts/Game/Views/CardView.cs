using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardView : MonoBehaviour
{
    private enum State
    {
        Hidden,
        Back,
        Front
    }

    private CardAnimation _cardAnimation;
    private State _state = State.Hidden;

    [SerializeField] TextMeshProUGUI valueText;
    public void StopAllAnimations() => _cardAnimation?.Dispose();

    public void SetCardValue(int _set)
    {
        valueText.text = $"{_set:00}";
    }

    public async UniTask PlayAnimationAndDestroy()
    {
        await _cardAnimation.OnDestroyed();
        Destroy(gameObject);
    }

    public async UniTask FlipToFront()
    {
        if (_state == State.Front) return;
        await _cardAnimation.FlipToFront();
        _state = State.Front;
    }

    public async UniTask FlipToBack()
    {
        if (_state == State.Back) return;
        await _cardAnimation.FlipToBack();
        _state = State.Back;
    }

    public async UniTask FlipToHidden()
    {
        if (_state == State.Hidden) return;
        await _cardAnimation.Hide();
        _state = State.Hidden;
    }

    private async UniTaskVoid InitializeAsync()
    {
        await _cardAnimation.OnSpawned();
    }

    private void Start() => InitializeAsync().Forget();

    private void Awake()
    {
        _cardAnimation = new CardAnimation(transform,valueText);
    }

    private void OnMouseEnter()
    {
        if (_state != State.Back) return;
        _cardAnimation.Expansion();
    }
}
