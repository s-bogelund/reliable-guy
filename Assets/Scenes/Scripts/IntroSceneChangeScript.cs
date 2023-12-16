using System.Collections;
using System.Collections.Generic;
using Scenes.Scripts;
using UnityEngine;

public class IntroSceneChangeScript : SceneChangeTrigger
{
    protected override void TriggerSceneChange()
    {
        LoadSceneByName("Town");
    }
}
