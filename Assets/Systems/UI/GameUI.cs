using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static bool OnUI;

    [SerializeField] Image fadeImage;
    [SerializeField] Canvas canvas;
    [SerializeField] CanvasGroup canvasGroup;

    public void FadeOut()
    {
        void OnComplete()
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        fadeImage.DOFade(0, 1).OnComplete(OnComplete);
    }

    public void FinishLevel()
    {
        void OnComplete()
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;

            int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
            SaveHandler.LevelData.SetLastLevel(nextLevel);
            LevelLoader.LoadLevel(nextLevel);
        }
        fadeImage.DOFade(1, 0.5f).OnComplete(OnComplete);
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        FadeOut();
        canvas.worldCamera = Camera.main;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void SettingsButton()
    {

    }

    public void CustomizeButton()
    {

    }
}
