using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] Color levelColor;
    [SerializeField] float camSize;

    private Transform playerInstance;
    private CinemachineVirtualCamera virtualCamera;

    private void Spawn()
    {
        playerInstance = Instantiate(playerPrefab).transform;
        playerInstance.SetParent(transform, false);
        playerInstance.position = FindAnyObjectByType<Spawner>().transform.position;
        virtualCamera.Follow = playerInstance;
    }
    public void OnStart()
    {
        Spawn();
    }
    public void OnDeath()
    {
        Destroy(playerInstance.gameObject);
        Spawn();
    }
    public void OnWin()
    {
        FindFirstObjectByType<GameUI>().FinishLevel();
    }

    private void OnEnable()
    {
        virtualCamera = FindAnyObjectByType<CinemachineVirtualCamera>();
        virtualCamera.m_Lens.OrthographicSize = camSize;
        Spawn();
    }
}
