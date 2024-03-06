using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelLoader
{
    private static GameObject canvas;
    private static GameObject cameras;

    private static void LevelLoaded(Scene s)
    {
        SceneManager.MoveGameObjectToScene(canvas , s);
        SceneManager.MoveGameObjectToScene(cameras, s);
        SceneManager.SetActiveScene(s);
        UITransition.FinishTransition();
    }
    public static void LoadLevel()
    {
        int index = SaveData.GetLevel();
        LoadLevel(index);
    }
    public static void LoadLevel(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }
    public static void Init()
    {
        canvas = GameObject.Find("Canvas");
        cameras = GameObject.Find("Rendering");
        Object.DontDestroyOnLoad(canvas);
        Object.DontDestroyOnLoad(cameras);

        SceneManager.activeSceneChanged += (Old,New) => LevelLoaded(New);
    }
}
