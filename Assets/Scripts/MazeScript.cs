using UnityEngine;
using System.Collections;

public class MazeScript : MonoBehaviour {
	public GameObject player;
	public GameObject spawnPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}
