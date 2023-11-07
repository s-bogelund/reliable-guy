using System.Collections;
using System.Collections.Generic;
using Scenes.Scripts;
using UnityEngine;

public class DungeonDoorScript : SceneChangeTrigger
{
    // Start is called before the first frame update
    protected override void TriggerSceneChange()
    {
        LoadSceneByName("Biome1_Dungeon");
    }

}
