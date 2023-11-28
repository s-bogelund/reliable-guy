
using Cinemachine;
using Scenes.Scripts;
using UnityEngine;

public class DungeonDoorScript : SceneChangeTrigger
{
    // private PlayerController _playerController;
    public GameObject player;
    void Start()
    {
        // _playerController = player.GetComponent<PlayerController>();
        // player = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player");

    }
    protected override void TriggerSceneChange()
    {
        Vector2 playerPosition = new Vector2(7.63139f, 1.447772f);
        player.transform.position = playerPosition; 
        LoadSceneByName("Biome1_Dungeon");
    }
}
