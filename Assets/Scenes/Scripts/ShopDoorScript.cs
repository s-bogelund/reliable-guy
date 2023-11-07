using System.Collections;
using System.Collections.Generic;
using Scenes.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopDoorScript : SceneChangeTrigger
{




    protected override void TriggerSceneChange()
    {
        var currentSceneName = GetCurrentSceneName(); // Use the protected method from the base class
        if (currentSceneName == "Town")
        {
            LoadSceneByName("Shop");
        }
        else
        {
            LoadSceneByName("Town");
        }
    }

}
