using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    private CinemachineVirtualCamera vCam;
    private void Awake()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }
    
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelLoaded;
    }
    
    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        vCam.enabled = false;
        vCam.Follow = GameObject.FindWithTag("Player").transform;

        vCam.enabled = true; //only way I found to recenter the virtual camera on the player each time a new scene loads up
        
    }

}
