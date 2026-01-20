using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Threading;
using UnityEngine;

public class CardAnimation : IDisposable
{
    private readonly Vector3 _initialScale;
    private readonly Vector3 _initialPosition;
    private readonly Quaternion _initialRotation;
    private readonly Transform _transform;

    private Tween _flipTween;
    private Tween _expansionTween;
    private bool _isExpansioning;
    private bool _isFlipping;
    private CancellationTokenSource _flipCts;

    public CardAnimation(Transform t)
    {
        _transform = t;
        _initialScale = _transform.localScale;
        _initialPosition = _transform.localPosition;
        _initialRotation = _transform.localRotation;
    }

    public async UniTask FlipToFront()
    {
        CancelFlip();

    }

    public async UniTask FlipToBack()
    {
        CancelFlip();
    }

    public async UniTask FlipToHidden()
    {
        CancelFlip();
    }

    public async UniTask OnSpawned()
    {

    }

    private void CancelFlip()
    {
        _flipCts?.Cancel();
        _flipCts?.Dispose();
        _flipCts = null;

        if(_flipTween!=null && _flipTween.IsActive())
        {
            _flipTween.Kill();
            _flipTween = null;
        }

        _isFlipping = false;
    }

    public void Expansion()
    {
        if (_isExpansioning) return;
        _isExpansioning = true;

        ExpansionAsync().Forget();
    }

    private async UniTaskVoid ExpansionAsync()
    {
        _isExpansioning = false;
    }

    public async UniTaskVoid OnDestroyed()
    {
        
    }

    public void Dispose()
    {

    }
}