using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Threading;
using UnityEngine;

public class CardAnimation : IDisposable
{
    private const float FLIP_DURATION = 0.3f;

    private readonly Vector3 _initialScale;
    private readonly Vector3 _initialPosition;
    private readonly Vector3 _initialRotation;
    private readonly Transform _transform;
    private float _currentRotationY;

    private Tween _rotationTween;
    private Tween _scaleTween;
    private bool _isExpansioning;

    public CardAnimation(Transform t)
    {
        _transform = t;
        _initialScale = _transform.localScale;
        _initialPosition = _transform.localPosition;
        _initialRotation = _transform.localEulerAngles;
        _currentRotationY = _initialRotation.y;
    }

    public async UniTask FlipToFront()
    {
        CancelFlip();

        var startRotationY = _currentRotationY;
        var endRotationY = 0;

        _rotationTween = DOTween.To(
            () => _currentRotationY,
            x =>
            {
                _currentRotationY = x;
                var rot = _transform.localEulerAngles;
                rot.y = x;
                _transform.localEulerAngles = rot;
            },
            endRotationY,
            FLIP_DURATION
            ).SetEase(Ease.OutCubic);

        await _rotationTween.AsyncWaitForCompletion();
    }

    public async UniTask FlipToBack()
    {
        CancelFlip();

        var startRotationY = _currentRotationY;
        var endRotationY = -180;

        _rotationTween = DOTween.To(
            () => _currentRotationY,
            x =>
            {
                _currentRotationY = x;
                var rot = _transform.localEulerAngles;
                rot.y = x;
                _transform.localEulerAngles = rot;
            },
            endRotationY,
            FLIP_DURATION
            ).SetEase(Ease.OutCubic);

        await _rotationTween.AsyncWaitForCompletion();
    }

    public async UniTask Hide()
    {
        
    }

    public async UniTask OnSpawned()
    {

    }

    private void CancelFlip()
    {
        if(_rotationTween!=null && _rotationTween.IsActive())
        {
            _rotationTween.Complete();
            _rotationTween = null;
        }
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

    public async UniTask OnDestroyed()
    {
        
    }

    public void Dispose()
    {

    }
}