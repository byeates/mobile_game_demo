using UnityEngine;
using System.Collections;

public class PlayerBrain : MonoBehaviour {

	public GameObject leftHand;
	public GameObject rightHand;
	public GameObject head;
	public GameObject body;
	public GameObject leftFoot;
	public GameObject rightFoot;



	public bool inputLocked;
	public bool jumpLocked;
	private bool isWalking 	= false;

	private float turning 	= 0;
	private float turnSpeed = 2f;
	private float moveSpeed = 0;
	private float walkSpeed = 2f;
	


	private float backupSpeed = -2f;

	public PlayerPositions positions;
	public PlayerAnimations animation;
	

	// Use this for initialization
	void Start () {

		positions = gameObject.AddComponent<PlayerPositions>();
		animation = gameObject.AddComponent<PlayerAnimations>();
		animation.setPositions (positions);
		makeBody ();


	}
	
	// Update is called once per frame
	void Update () {
		NetworkView nView = GetComponent<NetworkView>();
		if (nView.isMine) {
			checkInput ();
		}

		movePlayer ();

		positions.changePosition ();

	}

	void checkInput (){

		if ( !inputLocked ){

			// W is the walk key
			if (Input.GetKeyDown (KeyCode.W)) {
				animation.startWalk();
				isWalking = true;
				moveSpeed = walkSpeed;
			}
			if (Input.GetKeyUp (KeyCode.W)) {
				animation.stopWalk();
				stopMovement();
			}
			// s is the backup key
			if (Input.GetKeyDown (KeyCode.S)) {
				animation.startWalk();
				moveSpeed = backupSpeed;
				isWalking = true;

			}
			if (Input.GetKeyUp (KeyCode.S)) {
				animation.stopWalk();
				stopMovement();

			}
			// A is the turn left key
			if (Input.GetKeyDown (KeyCode.A)) {
				positions.targetPosition("leftStep");
				turning -= turnSpeed;
			}
			if (Input.GetKeyUp (KeyCode.A)) {
				positions.targetPosition("stand");
				turning += turnSpeed;
			}
			// E is the left punch key
			if (Input.GetKeyDown (KeyCode.E)) {
				animation.stopWalk();
				positions.targetPosition("leftPunch");
				stopMovement();
				GetComponent<Rigidbody>().Sleep();
			}
			if (Input.GetKeyUp (KeyCode.E)) {
				positions.targetPosition("stand");
				GetComponent<Rigidbody>().WakeUp();
			}
			// Q is the right punch key
			if (Input.GetKeyDown (KeyCode.Q)) {
				animation.stopWalk();
				positions.targetPosition("rightPunch");
				stopMovement();
				GetComponent<Rigidbody>().Sleep();
			}
			if (Input.GetKeyUp (KeyCode.Q)) {
				positions.targetPosition("stand");
				GetComponent<Rigidbody>().WakeUp();
			}
			// D is the turn right key
			if (Input.GetKeyDown (KeyCode.D)) {
				positions.targetPosition("rightStep");
				turning += turnSpeed;
			}
			if (Input.GetKeyUp (KeyCode.D)) {
				positions.targetPosition("stand");
				turning -= turnSpeed;
			}
			// left shift
			if (Input.GetKeyDown (KeyCode.LeftShift)) {
				if (isWalking){
					moveSpeed = moveSpeed*2;
					positions.setShiftSpeed(40f);
					animation.setStepTime(.05f);
				}
			}
			if (Input.GetKeyUp (KeyCode.LeftShift)) {
				if (isWalking){
					moveSpeed = moveSpeed*.5f;
					positions.setShiftSpeed(10f);
					animation.setStepTime(.2f);
				}
			}


			// X is the sit key
			if (Input.GetKeyDown (KeyCode.X)) {
				positions.targetPosition("sit");
				animation.stopSequence();
				stopMovement();
				GetComponent<Rigidbody>().Sleep();
				GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
			}
			if (Input.GetKeyUp (KeyCode.X)) {
				positions.targetPosition("stand");
				GetComponent<Rigidbody>().WakeUp();
				GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
			}




		}

	}

	IEnumerator unlockJump()
	{
		yield return new WaitForSeconds (1);
		jumpLocked = false;
	}
	void stopMovement(){

		moveSpeed = 0;
		isWalking = false;
	}

	void movePlayer(){

		// rotate player
		transform.Rotate(new Vector3(0,turning,0));	
		// move player
		if (isWalking) {
			transform.position = Vector3.Lerp(transform.position, transform.position + (transform.forward * moveSpeed), Time.deltaTime);
		}

	}
	void makeBody(){
		positions.makeBody(head,body,leftHand,rightHand,leftFoot,rightFoot);
	}


}
