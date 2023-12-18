using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LegacyButtonExample : MonoBehaviour
{
    private Button legacyButton;



    public void startIntro()
    {
        
        SceneManager.LoadScene("Intro");
    }

    public void startDungeon()
    {
        SceneManager.LoadScene("Biome1_Dungeon");
    }

    public void closeGame()
    {
        Application.Quit();
    }


}