using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public static class UITransition
{
    public static Image fadeImage;
    const float time = 1f;
    public static void StartTransition(Action ActionAfterFinish)
    {
        if (fadeImage == null)
            Debug.LogError("Please put a fade image.");

        Sequence seq = DOTween.Sequence();
        seq.Append(fadeImage.DOColor(new(0, 0, 0, 1), time));
        seq.onComplete = () => ActionAfterFinish?.Invoke();
    }

    public static void FinishTransition()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(fadeImage.DOColor(new(0, 0, 0, 0), time));
    }

    public static void SetupFadeImage(Image f)
    {
        fadeImage = f;
    }
}
