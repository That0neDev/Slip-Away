using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform spawnPos;
    private Transform playerInstance;
    private CinemachineVirtualCamera virtualCamera;

    private void Spawn()
    {
        playerInstance = Instantiate(playerPrefab).transform;
        playerInstance.SetParent(transform, false);
        playerInstance.position = spawnPos.position;
        virtualCamera.Follow = playerInstance;
    }
    public void OnStart()
    {
        print("Started");
        Spawn();
        UITransition.FinishTransition();
    }
    public void OnDeath()
    {
        Destroy(playerInstance.gameObject);
        Spawn();
    }
    public void OnWin()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        SaveData.SaveLevel(nextLevel);
        LevelLoader.LoadLevel(nextLevel);
    }

    private void OnEnable()
    {
        virtualCamera = FindAnyObjectByType<CinemachineVirtualCamera>();
        Spawn();
    }
}
