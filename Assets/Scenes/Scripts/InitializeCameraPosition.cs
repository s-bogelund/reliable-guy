using System;
using System.Collections;
using Cinemachine;
using UnityEngine;

namespace Scenes.Scripts
{
	public class InitializeCameraPosition : MonoBehaviour
	{
		private bool _hasCompletedTutorial = false;
		private bool _isComingFromShop = false;

		private void Awake()
		{
			// CHECK GAME STATE FOR TUTORIAL COMPLETION AND CURRENTSCENE
			_hasCompletedTutorial = false;
			_isComingFromShop = true;
		}

		IEnumerator Start()
		{

			if (_hasCompletedTutorial)
			{
				if (_isComingFromShop)
				{
					var mainCamera = GameObject.Find("Main Camera");
					var cineBrain = mainCamera.GetComponent<CinemachineBrain>();
					cineBrain.enabled = false;
					mainCamera.transform.position = new Vector3(-2.312f, -2.93f, -10);

					// HandleComingFromShop(cineBrain, mainCamera, followCam);
					yield return new WaitForEndOfFrame();


					cineBrain.enabled = true;
				}

			}
			else
			{
				// do nothing
			}

		}

	}
}	