using UnityEngine;
using UnityEngine.SceneManagement;


namespace Scenes.Scripts
{
	public abstract class SceneChangeTrigger : MonoBehaviour
	{
    
    
		protected virtual void Awake()
		{
			
		}
    
		protected virtual void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag("Player"))
			{
				TriggerSceneChange();
			}
		}

		protected abstract void TriggerSceneChange();

		protected void LoadSceneByName(string sceneName)
		{
			SceneManager.LoadScene(sceneName);
		}

		protected string GetCurrentSceneName()
		{
			return SceneManager.GetActiveScene().name;
		}
		
		protected virtual void Start()
		{
			// If you need to access the scene name
			// string sceneName = CurrentScene.name;
        
		}
		
	}
}