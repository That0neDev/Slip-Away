using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public float menuAnimSpeed;

    [SerializeField] GameObject menuCamera;

    [SerializeField] RectTransform titleImage;
    [SerializeField] RectTransform playRect;
    [SerializeField] RectTransform downRect;
    [SerializeField] Image fadeImage;
    public void OpenMenu()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(titleImage.DOLocalMove(new(0,400,0), menuAnimSpeed));
        seq.Append(playRect.DOLocalMove(new(0,-100,0), menuAnimSpeed));
        seq.Append(downRect.DOLocalMove(new(0,-520,0), menuAnimSpeed));
    }

    public void CloseMenu()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(titleImage.DOLocalMove(new(1200, 500, 0), menuAnimSpeed));
        seq.Join(playRect.DOLocalMove(new(1200, -45, 0), menuAnimSpeed));
        seq.Join(downRect.DOLocalMove(new(1200, -500,0), menuAnimSpeed));
    }


    public void PlayButton()
    {
        CloseMenu();
        UITransition.StartTransition(() => LevelLoader.LoadLevel());
    }
    public void CustomizeButton()
    {
        CloseMenu();
    }
    public void SettingsButton()
    {
        CloseMenu();
    }
    public void Quit()
    {
        UITransition.StartTransition(EndGame);
    }


    private void EndGame()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private void Start()
    {
        LevelLoader.Init();
        UITransition.SetupFadeImage(fadeImage);
        UITransition.FinishTransition();
        OpenMenu();
    }
}
