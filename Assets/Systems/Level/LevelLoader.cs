using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelLoader
{
    public static void LoadCurrent()
    {
        LoadLevel(SaveHandler.Instance.levelData.currentLevel);
    }

    public static void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
