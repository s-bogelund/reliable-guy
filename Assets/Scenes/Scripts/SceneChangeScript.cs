using System.Collections;
using System.Collections.Generic;
using Scenes.Scripts;
using UnityEngine;

public class SceneChangeScript : SceneChangeTrigger
{
    [SerializeField] private string sceneName;
    protected override void TriggerSceneChange()
    {
        LoadSceneByName(sceneName);
    }
}
