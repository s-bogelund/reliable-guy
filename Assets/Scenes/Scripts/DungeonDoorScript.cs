
using Scenes.Scripts;

public class DungeonDoorScript : SceneChangeTrigger
{
    // Start is called before the first frame update
    protected override void TriggerSceneChange()
    {
        LoadSceneByName("Biome1_Dungeon");
    }
}
