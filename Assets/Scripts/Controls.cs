using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	
	public Camera playerCamera;
	public Camera observerCamera;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		NetworkView nView = GetComponent<NetworkView>();
		if ( nView.isMine )
		{
			playerCamera.enabled = true;
			observerCamera.enabled = false;
		} 
		else
		{
			playerCamera.enabled = false;
			observerCamera.enabled = true;
		}
	}
	
}
