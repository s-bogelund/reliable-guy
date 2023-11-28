using System;
using System.Collections;
using Cinemachine;
using UnityEngine;

namespace Scenes.Scripts
{
	public class InitializeCameraPosition : MonoBehaviour
	{
		// TODO: SET TO GAMEMANAGER STATE IN START
		private bool _hasCompletedTutorial = true;
		private bool _isComingFromShop = false;

		private void Awake()
		{
			// CHECK GAME STATE FOR TUTORIAL COMPLETION AND CURRENTSCENE
			_hasCompletedTutorial = true;
			_isComingFromShop = true;
		}

		IEnumerator Start()
		{
			var mainCamera = GameObject.Find("Main Camera");
			var cineBrain = mainCamera.GetComponent<CinemachineBrain>();

			cineBrain.enabled = false;
			if (_hasCompletedTutorial)
			{
				if (_isComingFromShop)
				{
					mainCamera.transform.position = new Vector3(-2.312f, -2.93f, -10);

				}
				else
				{
					// FIND CORRECT LOCATION!
					mainCamera.transform.position = new Vector3(0.38f, -2.495f, -10);

				}

			}
			else
			{
				mainCamera.transform.position = new Vector3(6.6f, 3.92f, -10);
			}

			yield return new WaitForEndOfFrame();

			cineBrain.enabled = true;




		}

	}
}