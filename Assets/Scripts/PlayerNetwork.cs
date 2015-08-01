using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetwork : NetworkBehaviour 
{
	[SerializeField] Camera FPSCharacterCamera;
	[SerializeField] AudioListener audioListener;

	// Use this for initialization
	void Start () 
	{
		if ( isLocalPlayer )
		{
			GameObject.Find("SpectatorCamera").SetActive(false);
			GetComponent<CharacterController>().enabled = true;
			GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
			FPSCharacterCamera.enabled = true;
			audioListener.enabled = true;
		}
	}
}
