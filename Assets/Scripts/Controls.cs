using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	
	public Camera playerCamera;
	public Camera observerCamera;

	// delta time
	private float _dt;

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

			_dt = Time.deltaTime;

			#if UNITY_EDITOR || UNITY_STANDALONE
			

			
			//transform.Translate(Input.GetAxis ("Mouse X") * strafeSpeed * Time.deltaTime, 0f, 0f);
			
			#elif UNITY_ANDROID || UNITY_IPHONE
			
			//transform.Translate(Input.acceleration.x * 2f * strafeSpeed * Time.deltaTime, 0f, 0f);
			
			#endif
		} 
		else
		{
			playerCamera.enabled = false;
			observerCamera.enabled = true;
		}
	}
	
}
