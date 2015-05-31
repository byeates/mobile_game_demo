using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	public GameObject leftHand;
	public GameObject rightHand;
	public GameObject head;
	public GameObject body;
	public GameObject leftFoot;
	public GameObject rightFoot;
	
	private Quaternion originalRotation;
	private Vector3	originalPosition;
	private Vector3 currentPosition;
	private int cyclePos=0;

	private float shiftSpeed = 4;

	private Vector3 headStartPos;
	private Vector3 headTargetPos;
	private Vector3 bodyStartPos;
	private Vector3 bodyTargetPos;

	private Vector3 leftHandStartPos;
	private Vector3 leftHandTargetPos;
	private Vector3 rightHandStartPos;
	private Vector3 rightHandTargetPos;
	private Vector3 leftFootStartPos;
	private Vector3 leftFootTargetPos;
	private Vector3 rightFootStartPos;
	private Vector3 rightFootTargetPos;

	public bool isPlayer;

	private bool canMove = true;
	private bool walking = false;
	public float health = 10;
	private float walkSpeed = .2f;
	private float stepTime= .2f;

	// Use this for initialization
	void Start () {
		originalRotation = transform.rotation;
		originalPosition = transform.position;

		headStartPos 		= new Vector3(0f,1.9f,0)  ;
		headTargetPos 		= new Vector3(0f,1.9f,0)  ;
		bodyStartPos 		= new Vector3(0,.85f,0)   ;
		bodyTargetPos 		= new Vector3(0,.85f,0)   ;
		leftHandStartPos 	= new Vector3(-.7f,.7f,0) ;
		leftHandTargetPos 	= new Vector3(-.7f,.7f,0) ;
		rightHandStartPos 	= new Vector3(.7f,.7f,0)  ;
		rightHandTargetPos 	= new Vector3(.7f,.7f,0)  ;
		leftFootStartPos 	= new Vector3(-.4f,.25f,0);
		leftFootTargetPos 	= new Vector3(-.4f,.25f,0);
		rightFootStartPos 	= new Vector3(.4f,.25f,0) ;
		rightFootTargetPos 	= new Vector3(.4f,.25f,0) ;


	}
	
	// Update is called once per frame
	void Update () {
			foreach (char c in Input.inputString) {

				StopCoroutine ("jump");

				switch (c) {
				case 'h':
					cyclePos = 0;
					stepTime = .1f;
					StopCoroutine ("walk");
					StartCoroutine ("headBut");
					walking = false;
					break;
				case 'w':
					cyclePos = 0;
					StopCoroutine ("walk");
					stepTime = .2f;
					walkSpeed = 1f;
					shiftSpeed = 4;
					StartCoroutine ("walk");
					walking = true;
					break;
				case 'r':
					cyclePos = 0;
					StopCoroutine ("walk");
					stepTime = .1f;
					walkSpeed = 3f;
					shiftSpeed = 8;
					StartCoroutine ("walk");
					walking = true;
					break;
				case 'j':
					//walking = false;
					cyclePos = 0;
					StopCoroutine ("walk");
					shiftSpeed = 10;
					StartCoroutine (doOnce (c));
					break;
				case '.':
					transform.Rotate(new Vector3(0,+5,0));	
					break;
				case ',':
					transform.Rotate(new Vector3(0,-5,0));
					break;
				case 'a':
				case 's':
				case 'z':
				case 'x':
					walking = false;
					cyclePos = 0;
					StopCoroutine ("walk");
					shiftSpeed = 6;
					StartCoroutine (doOnce (c));
					break;
				default:
					walking = false;
					cyclePos = 0;
					StopCoroutine ("walk");
					shiftSpeed = 10;
					targetPosition (c);
					break;
				}

			}
		changePosition ();
	}



	IEnumerator walk ()
	{

		switch (cyclePos)
		{
		case 0:
			Debug.Log("step right");
			targetPosition('r');
			cyclePos=1;
			break;
		case 1:
			Debug.Log("stand");
			targetPosition('t');
			cyclePos=2;
			break;
		case 2:
			Debug.Log("step left");
			targetPosition('y');
			cyclePos=3;
			break;
		case 3:
			Debug.Log("stand");
			targetPosition('t');
			cyclePos=0;
			break;
		}
		yield return new WaitForSeconds (stepTime);
		StartCoroutine ( "walk" );
	}

	IEnumerator headBut ()
	{
		
		switch (cyclePos)
		{
		case 0:
			targetPosition('h');
			cyclePos=1;
			break;
		case 1:
			targetPosition('b');
			cyclePos=2;
			break;
		case 2:
			targetPosition('t');
			cyclePos=0;
			StopCoroutine ("headBut");
			break;
		}
		yield return new WaitForSeconds (stepTime);
		if (cyclePos > 0)
		{
			StartCoroutine ("headBut");
		}
	}

	IEnumerator doOnce (char c)
	{
		
		switch (cyclePos)
		{
		case 0:
			targetPosition(c);
			cyclePos=1;
			break;
		case 1:
			targetPosition('t');
			walking = false;
			cyclePos = 0;
			StopCoroutine ("walk");
			break;

		}
		
		yield return new WaitForSeconds (0.2f);
		if (cyclePos == 1)
		{
			StartCoroutine (doOnce('t'));
		}
	}

	public void targetPosition (char position = 't') {
		
		switch (position) 
		{
		case 't': // stand
			leftHandStartPos 	= leftHand.transform.localPosition;
			leftHandTargetPos 	= new Vector3(-.7f,.7f,0) 	 ;
			rightHandStartPos 	= rightHand.transform.localPosition;
			rightHandTargetPos 	= new Vector3(.7f,.7f,0) 	 ;
			leftFootStartPos 	= leftFoot.transform.localPosition;
			leftFootTargetPos 	= new Vector3(-.4f,.25f,0)	 ;
			rightFootStartPos 	= rightFoot.transform.localPosition;
			rightFootTargetPos 	= new Vector3(.4f,.25f,0) 	 ;
			headStartPos 		= head.transform.localPosition;
			headTargetPos 		= new Vector3(0f,1.9f,0)	 ;
			bodyStartPos 		= body.transform.localPosition;
			bodyTargetPos 		= new Vector3(0,.85f,0) 	 ;
			break;
		case 'h': // stand
			leftHandStartPos 	= leftHand.transform.localPosition;
			leftHandTargetPos 	= new Vector3(-.7f,.7f,-.13f) 	 ;
			rightHandStartPos 	= rightHand.transform.localPosition;
			rightHandTargetPos 	= new Vector3(.7f,.7f,-.13f) 	 ;
			leftFootStartPos 	= leftFoot.transform.localPosition;
			leftFootTargetPos 	= new Vector3(-.4f,.25f,0)	 ;
			rightFootStartPos 	= rightFoot.transform.localPosition;
			rightFootTargetPos 	= new Vector3(.4f,.25f,0) 	 ;
			headStartPos 		= head.transform.localPosition;
			headTargetPos 		= new Vector3(0f,1.6f,.44f)	 ;
			bodyStartPos 		= body.transform.localPosition;
			bodyTargetPos 		= new Vector3(0,.85f,-.09f) 	 ;
			break;
		case 'b': // stand
			leftHandStartPos 	= leftHand.transform.localPosition;
			leftHandTargetPos 	= new Vector3(-.7f,.7f,.13f) 	 ;
			rightHandStartPos 	= rightHand.transform.localPosition;
			rightHandTargetPos 	= new Vector3(.7f,.7f,.13f) 	 ;
			leftFootStartPos 	= leftFoot.transform.localPosition;
			leftFootTargetPos 	= new Vector3(-.4f,.25f,0)	 ;
			rightFootStartPos 	= rightFoot.transform.localPosition;
			rightFootTargetPos 	= new Vector3(.4f,.25f,0) 	 ;
			headStartPos 		= head.transform.localPosition;
			headTargetPos 		= new Vector3(0f,1.6f,-.55f)	 ;
			bodyStartPos 		= body.transform.localPosition;
			bodyTargetPos 		= new Vector3(0,.85f,.13f) 	 ;
			break;
		case 'a': // right punch
			rightHandStartPos 	= rightHand.transform.localPosition;
			rightHandTargetPos 	= new Vector3(.7f,.7f,.2f)  ;
			leftHandStartPos 	= leftHand.transform.localPosition;
			leftHandTargetPos 	= new Vector3(0,2f,-2f) 	 ;
			rightFootStartPos 	= rightFoot.transform.localPosition;
			rightFootTargetPos 	= new Vector3(.4f,.25f,.1f) ;
			leftFootStartPos 	= leftFoot.transform.localPosition;
			leftFootTargetPos 	= new Vector3(-.4f,.25f,0) 	 ;
			headStartPos 		= head.transform.localPosition;
			headTargetPos 		= new Vector3(0f,1.9f,-.2f)	 ;
			bodyStartPos 		= body.transform.localPosition;
			bodyTargetPos 		= new Vector3(0,.85f,0) 	 ;
			break;
		case 's': // left punch
			leftHandStartPos 	= leftHand.transform.localPosition;
			leftHandTargetPos 	= new Vector3(-.7f,.7f,.2f)  ;
			rightHandStartPos 	= rightHand.transform.localPosition;
			rightHandTargetPos 	= new Vector3(0,2f,-2f) 	 ;
			leftFootStartPos 	= leftFoot.transform.localPosition;
			leftFootTargetPos 	= new Vector3(-.4f,.25f,.1f) ;
			rightFootStartPos 	= rightFoot.transform.localPosition;
			rightFootTargetPos 	= new Vector3(.4f,.25f,0)    ;
			headStartPos 		= head.transform.localPosition;
			headTargetPos 		= new Vector3(0f,1.9f,-.2f)	 ;
			bodyStartPos 		= body.transform.localPosition;
			bodyTargetPos 		= new Vector3(0,.85f,0) 	 ;
			break;
		case 'z': // right kick
			leftHandStartPos 	= leftHand.transform.localPosition;
			leftHandTargetPos 	= new Vector3(-.7f,.7f,-.2f) ;
			rightHandStartPos 	= rightHand.transform.localPosition;
			rightHandTargetPos 	= new Vector3(.7f,.7f,.2f) 	 ;
			leftFootStartPos 	= leftFoot.transform.localPosition;
			leftFootTargetPos 	= new Vector3(-.4f,.25f,0)	 ;
			rightFootStartPos 	= rightFoot.transform.localPosition;
			rightFootTargetPos 	= new Vector3(0,1f,-1.5f)  ;
			headStartPos 		= head.transform.localPosition;
			headTargetPos 		= new Vector3(0f,1.9f,.2f)	 ;
			bodyStartPos 		= body.transform.localPosition;
			bodyTargetPos 		= new Vector3(0,.85f,0) 	 ;
			break;
		case 'x': // left kick
			rightHandStartPos 	= rightHand.transform.localPosition;
			rightHandTargetPos 	= new Vector3(.7f,.7f,-.2f) ;
			leftHandStartPos 	= leftHand.transform.localPosition;
			leftHandTargetPos 	= new Vector3(-.7f,.7f,.2f) 	 ;
			rightFootStartPos 	= rightFoot.transform.localPosition;
			rightFootTargetPos 	= new Vector3(.4f,.25f,0)   ;
			leftFootStartPos 	= leftFoot.transform.localPosition;
			leftFootTargetPos 	= new Vector3(0,1f,-1.5f)  ;
			headStartPos 		= head.transform.localPosition;
			headTargetPos 		= new Vector3(0f,1.9f,.2f)	 ;
			bodyStartPos 		= body.transform.localPosition;
			bodyTargetPos 		= new Vector3(0,.85f,0) 	 ;
			break;
			
		case 'r': // right step
			leftHandStartPos 	= leftHand.transform.localPosition;
			leftHandTargetPos 	= new Vector3(-.7f,.5f,.3f)  ;
			rightHandStartPos 	= rightHand.transform.localPosition;
			rightHandTargetPos 	= new Vector3(.7f,.5f,-.3f)   ;
			leftFootStartPos 	= leftFoot.transform.localPosition;
			leftFootTargetPos 	= new Vector3(-.4f,.25f,-.3f) ;
			rightFootStartPos 	= rightFoot.transform.localPosition;
			rightFootTargetPos 	= new Vector3(.4f,.25f,.3f)   ;
			headStartPos 		= head.transform.localPosition;
			headTargetPos 		= new Vector3(0f,1.6f,0)	 ;
			bodyStartPos 		= body.transform.localPosition;
			bodyTargetPos 		= new Vector3(0,.65f,0) 	  ;
			break;
		case 'y': // left step
			leftHandStartPos 	= leftHand.transform.localPosition;
			leftHandTargetPos 	= new Vector3(-.7f,.5f,-.3f) ;
			rightHandStartPos 	= rightHand.transform.localPosition;
			rightHandTargetPos 	= new Vector3(.7f,.5f,.3f) 	  ;
			leftFootStartPos 	= leftFoot.transform.localPosition;
			leftFootTargetPos 	= new Vector3(-.4f,.25f,.3f)  ;
			rightFootStartPos 	= rightFoot.transform.localPosition;
			rightFootTargetPos 	= new Vector3(.4f,.25f,-.3f)  ;
			headStartPos 		=  head.transform.localPosition;
			headTargetPos 		= new Vector3(0f,1.6f,0)	  ;
			bodyStartPos 		= body.transform.localPosition;
			bodyTargetPos 		= new Vector3(0,.65f,0) 	  ;
			break;
		case 'j': // jump
			leftHandStartPos 	= leftHand.transform.localPosition;
			leftHandTargetPos 	= new Vector3(-.7f,2.6f,0) 	 ;
			rightHandStartPos 	= rightHand.transform.localPosition;
			rightHandTargetPos 	= new Vector3(.7f,2.6f,0) 	  ;
			leftFootStartPos 	= leftFoot.transform.localPosition;
			leftFootTargetPos 	= new Vector3(-.2f,1.5f,0)	  ;
			rightFootStartPos 	= rightFoot.transform.localPosition;
			rightFootTargetPos 	= new Vector3(.2f,1.5f,0) 	  ;
			headStartPos 		= head.transform.localPosition;
			headTargetPos 		= new Vector3(0f,3.2f,0)	  ;
			bodyStartPos 		= body.transform.localPosition;
			bodyTargetPos 		= new Vector3(0,2.18f,0) 	  ;
			break;
		case 'm': // sit
			leftHandStartPos 	= leftHand.transform.localPosition;
			leftHandTargetPos 	= new Vector3(-.7f,.5f,0) 	  ;
			rightHandStartPos 	= rightHand.transform.localPosition;
			rightHandTargetPos 	= new Vector3(.7f,.5f,0) 	  ;
			leftFootStartPos 	= leftFoot.transform.localPosition;
			leftFootTargetPos 	= new Vector3(-.4f,.25f,-.5f) ;
			rightFootStartPos 	= rightFoot.transform.localPosition;
			rightFootTargetPos 	= new Vector3(.4f,.25f,-.5f)  ;
			bodyStartPos 		= body.transform.localPosition;
			bodyTargetPos 		= new Vector3(0,.59f,0) 	  ;
			headStartPos 		= head.transform.localPosition;
			headTargetPos 		= new Vector3(0f,1.6f,0)	  ;
			break;
		case 'd': // die
			leftHandStartPos 	= leftHand.transform.localPosition;
			leftHandTargetPos 	= new Vector3(-.7f,.25f,0) 	  ;
			rightHandStartPos 	= rightHand.transform.localPosition;
			rightHandTargetPos 	= new Vector3(.7f,.25f,0) 	 ;
			leftFootStartPos 	= leftFoot.transform.localPosition;
			leftFootTargetPos 	= new Vector3(-.4f,.25f,-.6f) ;
			rightFootStartPos 	= rightFoot.transform.localPosition;
			rightFootTargetPos 	= new Vector3(.4f,.25f,-.6f)  ;
			bodyStartPos 		= body.transform.localPosition;
			bodyTargetPos 		= new Vector3(0,.5f,0) 	  ;
			headStartPos 		= head.transform.localPosition;
			headTargetPos 		= new Vector3(0f,.6f,1f)	 ;
			break;
			
		}
	}

	void changePosition ()
	{
		//Debug.Log("starty " + headStartPos[1] + " endy " + headTargetPos[1] + " " + head.transform.localPosition[1]);
		rightFoot.transform.localPosition = Vector3.Lerp(rightFootStartPos, rightFootTargetPos, Time.deltaTime * shiftSpeed);
		rightFootStartPos = rightFoot.transform.localPosition;

		leftFoot.transform.localPosition = Vector3.Lerp(leftFootStartPos, leftFootTargetPos, Time.deltaTime * shiftSpeed);
		leftFootStartPos = leftFoot.transform.localPosition;

		rightHand.transform.localPosition = Vector3.Lerp(rightHandStartPos, rightHandTargetPos, Time.deltaTime * shiftSpeed);
		rightHandStartPos = rightHand.transform.localPosition;

		leftHand.transform.localPosition = Vector3.Lerp(leftHandStartPos, leftHandTargetPos, Time.deltaTime * shiftSpeed);
		leftHandStartPos = leftHand.transform.localPosition;

		head.transform.localPosition = Vector3.Lerp(headStartPos, headTargetPos, Time.deltaTime * shiftSpeed);
		headStartPos = head.transform.localPosition;

		body.transform.localPosition = Vector3.Lerp(bodyStartPos, bodyTargetPos, Time.deltaTime * shiftSpeed);
		bodyStartPos = body.transform.localPosition;


		if ( walking )
		{
			transform.position = Vector3.Lerp(transform.position, transform.position - (transform.forward * walkSpeed), Time.deltaTime);
		}
	}

	public void ApplyDamage()
	{
		health--;
		Debug.Log ("Ow! " + health);
		if ( health<1 )
		{
			Debug.Log("die!");
			targetPosition('d');
		}

	}
}
