using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("FX Prefab On Player")][SerializeField] GameObject deathFX;
    [Tooltip("In Seconds")] [SerializeField] float levelLoadDelay = 1.5f;
    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("ReloadScene", levelLoadDelay);
    }

    private void StartDeathSequence()
    { 
        SendMessage("OnPlayerDeath");     
    }

    private void ReloadScene()
    {
        int sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneBuildIndex);
    }
}
