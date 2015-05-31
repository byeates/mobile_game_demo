using UnityEngine;
using System.Collections;

public class PlayerPositions : MonoBehaviour {

	// body parts
	public GameObject leftHand;
	public GameObject rightHand;
	public GameObject head;
	public GameObject body;
	public GameObject leftFoot;
	public GameObject rightFoot;
	public bool alive = true;
	private float shiftSpeed = 6f;

	// body part positions
	private Vector3 headStartPos;
	private Vector3 headTargetPos = new Vector3();

	private Vector3 bodyStartPos;
	private Vector3 bodyTargetPos = new Vector3();

	private Vector3 leftHandStartPos;
	private Vector3 leftHandTargetPos = new Vector3();
	private Vector3 rightHandStartPos;
	private Vector3 rightHandTargetPos = new Vector3();

	private Vector3 leftFootStartPos;
	private Vector3 leftFootTargetPos = new Vector3();
	private Vector3 rightFootStartPos;
	private Vector3 rightFootTargetPos = new Vector3();


	public void makeBody( GameObject hd,GameObject bd,GameObject lh,GameObject rh,GameObject lf,GameObject rf ){
		head = hd;
		body = bd;
		leftHand = lh;
		rightHand = rh;
		leftFoot = lf;
		rightFoot = rf;

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
	public void targetPosition (string position) {
		
		switch (position) 
		{
		case "stand": // stand
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
		case "grab": // stand
			leftHandStartPos 	= leftHand.transform.localPosition;
			leftHandTargetPos 	= new Vector3(-.45f,.5f,.8f) 	 ;
			rightHandStartPos 	= rightHand.transform.localPosition;
			rightHandTargetPos 	= new Vector3(.45f,.5f,.8f) 	 ;
			leftFootStartPos 	= leftFoot.transform.localPosition;
			leftFootTargetPos 	= new Vector3(-.4f,.25f,0)	 ;
			rightFootStartPos 	= rightFoot.transform.localPosition;
			rightFootTargetPos 	= new Vector3(.4f,.25f,0) 	 ;
			headStartPos 		= head.transform.localPosition;
			headTargetPos 		= new Vector3(0f,1.8f,0)	 ;
			bodyStartPos 		= body.transform.localPosition;
			bodyTargetPos 		= new Vector3(0,.85f,-.18f) 	 ;
			break;
		case "lift": // stand
			leftHandStartPos 	= leftHand.transform.localPosition;
			leftHandTargetPos 	= new Vector3(-.6f,2.5f,0) 	 ;
			rightHandStartPos 	= rightHand.transform.localPosition;
			rightHandTargetPos 	= new Vector3(.6f,2.5f,0) 	 ;
			leftFootStartPos 	= leftFoot.transform.localPosition;
			leftFootTargetPos 	= new Vector3(-.4f,.25f,0)	 ;
			rightFootStartPos 	= rightFoot.transform.localPosition;
			rightFootTargetPos 	= new Vector3(.4f,.25f,0) 	 ;
			headStartPos 		= head.transform.localPosition;
			headTargetPos 		= new Vector3(0f,1.8f,0)	 ;
			bodyStartPos 		= body.transform.localPosition;
			bodyTargetPos 		= new Vector3(0,.85f,-.18f) 	 ;
			break;
		case "windup": // stand
			leftHandStartPos 	= leftHand.transform.localPosition;
			leftHandTargetPos 	= new Vector3(-.6f,2.5f,-.3f) 	 ;
			rightHandStartPos 	= rightHand.transform.localPosition;
			rightHandTargetPos 	= new Vector3(.6f,2.5f,-.3f) 	 ;
			leftFootStartPos 	= leftFoot.transform.localPosition;
			leftFootTargetPos 	= new Vector3(-.4f,.25f,0)	 ;
			rightFootStartPos 	= rightFoot.transform.localPosition;
			rightFootTargetPos 	= new Vector3(.4f,.25f,0) 	 ;
			headStartPos 		= head.transform.localPosition;
			headTargetPos 		= new Vector3(0f,1.8f,0)	 ;
			bodyStartPos 		= body.transform.localPosition;
			bodyTargetPos 		= new Vector3(0,.85f,.2f) 	 ;
			break;
		case "toss": // stand
			leftHandStartPos 	= leftHand.transform.localPosition;
			leftHandTargetPos 	= new Vector3(-.6f,2.5f,1f) 	 ;
			rightHandStartPos 	= rightHand.transform.localPosition;
			rightHandTargetPos 	= new Vector3(.6f,2.5f,1f) 	 ;
			leftFootStartPos 	= leftFoot.transform.localPosition;
			leftFootTargetPos 	= new Vector3(-.4f,.25f,0)	 ;
			rightFootStartPos 	= rightFoot.transform.localPosition;
			rightFootTargetPos 	= new Vector3(.4f,.25f,0) 	 ;
			headStartPos 		= head.transform.localPosition;
			headTargetPos 		= new Vector3(0f,1.8f,0)	 ;
			bodyStartPos 		= body.transform.localPosition;
			bodyTargetPos 		= new Vector3(0,.85f,-.2f) 	 ;
			break;
		case "sit": // sit
			leftHandStartPos 	= leftHand.transform.localPosition;
			leftHandTargetPos 	= new Vector3(-.7f,.5f,0) 	  ;
			rightHandStartPos 	= rightHand.transform.localPosition;
			rightHandTargetPos 	= new Vector3(.7f,.5f,0) 	  ;
			leftFootStartPos 	= leftFoot.transform.localPosition;
			leftFootTargetPos 	= new Vector3(-.4f,.25f,.5f) ;
			rightFootStartPos 	= rightFoot.transform.localPosition;
			rightFootTargetPos 	= new Vector3(.4f,.25f,.5f)  ;
			bodyStartPos 		= body.transform.localPosition;
			bodyTargetPos 		= new Vector3(0,.59f,0) 	  ;
			headStartPos 		= head.transform.localPosition;
			headTargetPos 		= new Vector3(0f,1.6f,0)	  ;
			break;
		case "rightStep": // right step
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
		case "leftStep": // left step
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
		case "jump": // jump
			leftHandStartPos 	= leftHand.transform.localPosition;
			leftHandTargetPos 	= new Vector3(-.7f,1.8f,0) 	 ;
			rightHandStartPos 	= rightHand.transform.localPosition;
			rightHandTargetPos 	= new Vector3(.7f,1.8f,0) 	  ;
			leftFootStartPos 	= leftFoot.transform.localPosition;
			leftFootTargetPos 	= new Vector3(-.2f,0.25f,0)	  ;
			rightFootStartPos 	= rightFoot.transform.localPosition;
			rightFootTargetPos 	= new Vector3(.2f,.25f,0) 	  ;
			headStartPos 		= head.transform.localPosition;
			headTargetPos 		= new Vector3(0f,1.9f,0)	  ;
			bodyStartPos 		= body.transform.localPosition;
			bodyTargetPos 		= new Vector3(0,.85f,0) 	  ;
			break;
		case "jumpForward": // jump
			leftHandStartPos 	= leftHand.transform.localPosition;
			leftHandTargetPos 	= new Vector3(-.7f,1.8f,.5f) 	 ;
			rightHandStartPos 	= rightHand.transform.localPosition;
			rightHandTargetPos 	= new Vector3(.7f,1.8f,.5f) 	  ;
			leftFootStartPos 	= leftFoot.transform.localPosition;
			leftFootTargetPos 	= new Vector3(-.2f,.25f,-.5f)	  ;
			rightFootStartPos 	= rightFoot.transform.localPosition;
			rightFootTargetPos 	= new Vector3(.2f,.25f,-.5f) 	  ;
			headStartPos 		= head.transform.localPosition;
			headTargetPos 		= new Vector3(0f,1.9f,.2f)	  ;
			bodyStartPos 		= body.transform.localPosition;
			bodyTargetPos 		= new Vector3(0,.85f,0) 	  ;
			break;
		case "leftPunch": // right punch
			rightHandStartPos 	= rightHand.transform.localPosition;
			rightHandTargetPos 	= new Vector3(.7f,.7f,-.2f)  ;
			leftHandStartPos 	= leftHand.transform.localPosition;
			leftHandTargetPos 	= new Vector3(0,2f,2f) 	 ;
			rightFootStartPos 	= rightFoot.transform.localPosition;
			rightFootTargetPos 	= new Vector3(.4f,.25f,-.1f) ;
			leftFootStartPos 	= leftFoot.transform.localPosition;
			leftFootTargetPos 	= new Vector3(-.4f,.25f,0) 	 ;
			headStartPos 		= head.transform.localPosition;
			headTargetPos 		= new Vector3(0f,1.9f,.2f)	 ;
			bodyStartPos 		= body.transform.localPosition;
			bodyTargetPos 		= new Vector3(0,.85f,0) 	 ;
			break;
		case "rightPunch": // right punch
			rightHandStartPos 	= rightHand.transform.localPosition;
			rightHandTargetPos 	= new Vector3(0f,2f,2f)  ;
			leftHandStartPos 	= leftHand.transform.localPosition;
			leftHandTargetPos 	= new Vector3(-.7f,.7f,-.2f) 	 ;
			rightFootStartPos 	= rightFoot.transform.localPosition;
			rightFootTargetPos 	= new Vector3(.4f,.25f,0f) ;
			leftFootStartPos 	= leftFoot.transform.localPosition;
			leftFootTargetPos 	= new Vector3(-.4f,.25f,-.1f) 	 ;
			headStartPos 		= head.transform.localPosition;
			headTargetPos 		= new Vector3(0f,1.9f,.2f)	 ;
			bodyStartPos 		= body.transform.localPosition;
			bodyTargetPos 		= new Vector3(0,.85f,0) 	 ;
			break;
		case "rightKick": // right kick
			leftHandStartPos 	= leftHand.transform.localPosition;
			leftHandTargetPos 	= new Vector3(-.7f,.7f,.2f) ;
			rightHandStartPos 	= rightHand.transform.localPosition;
			rightHandTargetPos 	= new Vector3(.7f,.7f,-.2f) 	 ;
			leftFootStartPos 	= leftFoot.transform.localPosition;
			leftFootTargetPos 	= new Vector3(-.4f,.25f,0)	 ;
			rightFootStartPos 	= rightFoot.transform.localPosition;
			rightFootTargetPos 	= new Vector3(0,1f,1.5f)  ;
			headStartPos 		= head.transform.localPosition;
			headTargetPos 		= new Vector3(0f,1.9f,-.2f)	 ;
			bodyStartPos 		= body.transform.localPosition;
			bodyTargetPos 		= new Vector3(0,.85f,0) 	 ;
			break;
		case "leftKick": // left kick
			rightHandStartPos 	= rightHand.transform.localPosition;
			rightHandTargetPos 	= new Vector3(.7f,.7f,.2f) ;
			leftHandStartPos 	= leftHand.transform.localPosition;
			leftHandTargetPos 	= new Vector3(-.7f,.7f,-.2f) 	 ;
			rightFootStartPos 	= rightFoot.transform.localPosition;
			rightFootTargetPos 	= new Vector3(.4f,.25f,0)   ;
			leftFootStartPos 	= leftFoot.transform.localPosition;
			leftFootTargetPos 	= new Vector3(0,1f,1.5f)  ;
			headStartPos 		= head.transform.localPosition;
			headTargetPos 		= new Vector3(0f,1.9f,-.2f)	 ;
			bodyStartPos 		= body.transform.localPosition;
			bodyTargetPos 		= new Vector3(0,.85f,0) 	 ;
			break;
		case "fallDown": // die
			leftHandStartPos 	= leftHand.transform.localPosition;
			leftHandTargetPos 	= new Vector3(-.7f,.25f,0) 	  ;
			rightHandStartPos 	= rightHand.transform.localPosition;
			rightHandTargetPos 	= new Vector3(.7f,.25f,0) 	 ;
			leftFootStartPos 	= leftFoot.transform.localPosition;
			leftFootTargetPos 	= new Vector3(-.4f,.25f,.6f) ;
			rightFootStartPos 	= rightFoot.transform.localPosition;
			rightFootTargetPos 	= new Vector3(.4f,.25f,.6f)  ;
			bodyStartPos 		= body.transform.localPosition;
			bodyTargetPos 		= new Vector3(0,.5f,0) 	  ;
			headStartPos 		= head.transform.localPosition;
			headTargetPos 		= new Vector3(0f,.6f,-1f)	 ;
			break;
		
		}
	}
	public void killPositions()
	{
		alive = false;
	}

	public void setShiftSpeed(float ss) {
		shiftSpeed = ss;
	}
	public void changePosition ()
	{
		if (alive)
		{
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
		}
	}
}
