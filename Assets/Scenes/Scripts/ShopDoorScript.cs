using Scenes.Scripts;
using UnityEngine;


public class ShopDoorScript : SceneChangeTrigger
{
    public GameObject player;
    
    void Start()
    {
        // _playerController = player.GetComponent<PlayerController>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    protected override void TriggerSceneChange()
    {
        Vector2 playerPosition = new Vector2(6.881f, 2.397f);
        player.transform.position = playerPosition; 
        var currentSceneName = GetCurrentSceneName(); // Use the protected method from the base class
        
        if (currentSceneName == "Town")
        {
            
            LoadSceneByName("Shop");
        }
        else
        {
            playerPosition = new Vector2(-2.312f, -2.93f);
            player = GameObject.FindGameObjectWithTag("Player");
            
            // SceneController.Instance.SetNextPlayerPosition(playerPositionInNewScene);
            player.transform.position = playerPosition;
            
            LoadSceneByName("Town");
        }
    }

}
