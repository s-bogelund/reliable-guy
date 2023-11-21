using Scenes.Scripts;
using UnityEngine;


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
            Vector2 playerPosition = new Vector2(-2.312f, -2.93f);    
            // SceneController.Instance.SetNextPlayerPosition(playerPositionInNewScene);
            PlayerController.NextInitialPosition = playerPosition;
            
            LoadSceneByName("Town");
        }
    }

}
