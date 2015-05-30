using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	public float turnSpeed = 2.0f;
	public float speed = 10.0f;

	public Camera playerCamera;
	public Camera observerCamera;

	// delta time
	private float _dt;

	public CharacterController cc;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
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
			
			if ( Input.GetButton( "Horizontal" ) && Input.GetAxis( "Horizontal" ) < 0 )
			{
				TurnLeft();
			} else if ( Input.GetButton( "Horizontal" ) && Input.GetAxis( "Horizontal" ) > 0 )
			{
				TurnRight();
			} else if ( Input.GetButton( "Vertical" ) && Input.GetAxis( "Vertical" ) > .001f )
			{
				Forward();
			} else if ( Input.GetButton( "Vertical" ) )
			{
				Back();
			}
			
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

	public void Forward()
	{
		transform.Translate( 0, 0, speed * Time.deltaTime );
	}

	public void Back()
	{
		transform.Translate( 0, 0, -speed * Time.deltaTime );
	}

	public void TurnLeft()
	{
		transform.Rotate (0f, -turnSpeed, 0f);
	}
	
	public void TurnRight()
	{
		transform.Rotate (0f, turnSpeed, 0f);
	}
}
