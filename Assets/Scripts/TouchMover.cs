using UnityEngine;
using System.Collections;

public class TouchMover : MonoBehaviour {

	private float 	turnSpeed;
	private float 	goSpeed;
	private float 	thrust;
	private float	maxSpeed = 15f;
	private Vector2 touchStart;
	
	private bool 	isTap;
	private bool 	isMoving;
	
	public Rigidbody body;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.touchCount > 0) {
			
			TouchPhase phase = Input.GetTouch (0).phase;
			
			switch(phase)
			{
			case TouchPhase.Began:
				isTap 			= true;
				isMoving 		= true;
				touchStart.y 	= Input.GetTouch (0).position.y;
				touchStart.x 	= Input.GetTouch (0).position.x;
				turnSpeed 		= 0;
				break;
			case TouchPhase.Moved:
				isTap	= false;
				goSpeed = Input.GetTouch (0).position.y - touchStart.y;
				if (goSpeed < 0){
					goSpeed*=.5f;
				}
				turnSpeed = .005f * (Input.GetTouch (0).position.x - touchStart.x);
				break;
			case TouchPhase.Stationary:
				break;
			case TouchPhase.Ended:
				if (isTap)
				{
					jump ();
				}
				isMoving = false;
				Invoke("noGo",.05f);
				break;
			case TouchPhase.Canceled:
				break;
			}
			go();
		}

	}

	//movement functions
	void go (){
		transform.Rotate (0f, turnSpeed, 0f);
		if (body.velocity.y < .1 && body.velocity.y > -.1) {
			body.velocity = new Vector3 (.7f * body.velocity.x, body.velocity.y, .7f * body.velocity.z);
			body.AddForce (transform.forward * goSpeed);
			
		} else {
			body.AddForce (transform.forward * goSpeed*.01f);
		}
		capSpeed ();
	}
	
	void noGo(){
		if (!isMoving && body.velocity != new Vector3(0f,0f,0f)){
			body.angularVelocity 		= new Vector3(.9f*body.angularVelocity.x,.9f*body.angularVelocity.y,.9f*body.angularVelocity.z);
			body.velocity 				= new Vector3(.6f*body.velocity.x,body.velocity.y,.6f*body.velocity.z);
		}
	}
	
	void capSpeed(){
		if (body.velocity.x > maxSpeed)
			body.velocity = new Vector3 (maxSpeed, body.velocity.y, body.velocity.z);
		if (body.velocity.z > maxSpeed)
			body.velocity = new Vector3 (body.velocity.x, body.velocity.y, maxSpeed);
		if (body.velocity.x < -1*maxSpeed)
			body.velocity = new Vector3 (-1*maxSpeed, body.velocity.y, body.velocity.z);
		if (body.velocity.z < -1*maxSpeed)
			body.velocity = new Vector3 (body.velocity.x, body.velocity.y, -1*maxSpeed);
	}
	
	void jump(){
		if (body.velocity.y < .1 && body.velocity.y > -.1) {
			body.AddForce(new Vector3(0f,700f,0f));
			body.AddForce (transform.forward * 500f);
		}
	}
}
