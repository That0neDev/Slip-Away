using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    [SerializeField] private GameObject UIObject;

    private void Start()
    {
        DontDestroyOnLoad(UIObject);
        SaveHandler.Init();
        LevelLoader.LoadCurrent();
    }
}
