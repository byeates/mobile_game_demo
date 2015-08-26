using UnityEngine;
using System.Collections;

public class WalkerBrain : MonoBehaviour {

	public float turnSpeed = 	2.0f;
	public float speed = 		10.0f;
	// delta time
	private float _dt;
	private float oldHorz;
	private float oldVert;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		_dt = Time.deltaTime;


		if (Input.GetAxis ( "Horizontal" ) >= .9 || Input.GetAxis ( "Horizontal" ) <= -.9 || Input.GetAxis ( "Horizontal" ) != oldHorz)
		{
			Turn ();
		}
		if (Input.GetAxis ( "Vertical" ) >= .9 || Input.GetAxis ( "Vertical" ) != oldVert)
		{
			Forward ();
		}
		if (Input.GetAxis ( "Vertical" ) <= -.9 || Input.GetAxis ( "Vertical" ) != oldVert)
		{
			Back ();
		}
		if (Input.GetButtonDown ("Jump")) {
			Jump();
		}


		Debug.Log ("turn: " + Input.GetAxis ( "Vertical" ));
		Debug.Log ("move: " + Input.GetAxis ( "Horizontal" ));





	}

	public void Forward()
	{
		transform.Translate( 0, 0, speed * Time.deltaTime );
		oldVert = Input.GetAxis ( "Vertical" );
	}
	
	public void Back()
	{
		transform.Translate( 0, 0, -speed * Time.deltaTime );
		oldVert = Input.GetAxis ( "Vertical" );
	}
	
	public void Turn()
	{
		transform.Rotate (0f, Input.GetAxis ( "Horizontal" ), 0f);
		oldHorz = Input.GetAxis ( "Horizontal" );
	}

	public void Jump()
	{
			Debug.Log ("JUMP");
		GetComponent<Rigidbody>().AddForce(0,50000f,0);

	}
}
