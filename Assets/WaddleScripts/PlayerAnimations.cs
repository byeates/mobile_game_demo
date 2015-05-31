using UnityEngine;
using System.Collections;

public class PlayerAnimations : MonoBehaviour {
	private ArrayList sequence;
	private int sequenceLength;
	private int sequencePosition;
	private float stepTime;
	private bool loopAnim;
	private PlayerPositions positions;
	private string currentAnim;

	private bool isWalking = false;

	public void setPositions(PlayerPositions pos){
		positions = pos;
	}
	public void startWalk(){
		sequence = new ArrayList ();
		sequence.Add ( "rightStep" );
		sequence.Add ( "stand" );
		sequence.Add ( "leftStep" );
		sequence.Add ( "stand" );
		sequenceLength 		= sequence.Count;
		sequencePosition 	= 0;
		stepTime 			= .2f;
		loopAnim 			= true;
		StartCoroutine ( "playSequence" );
	}
	public void stopWalk(){
		StopCoroutine ( "playSequence" );
		positions.targetPosition ("stand");
	}

	public void jump(bool walking){
		currentAnim = "jump";
		sequence = new ArrayList ();
		if (walking) {
			isWalking = true;
			sequence.Add ( "jumpForward" );
		} 
		else {
			isWalking = false;
			sequence.Add ( "jump" );
		}

		sequence.Add ( "stand" );
		sequenceLength 		= sequence.Count;
		sequencePosition 	= 0;
		stepTime 			= .4f;
		loopAnim 			= false;
		StartCoroutine ( "playSequence" );
	}

	public void pickUp(){
		sequencePosition 	= 0;
		StartCoroutine ( "pickUpAnim" );
	}


	public void setStepTime(float st){
		stepTime = st;
	}
	public void stopSequence(){
		StopCoroutine ( "playSequence" );

	}
	IEnumerator playSequence(){

		if ( sequencePosition >= sequenceLength ){
			sequencePosition = 0;
		}
		
		string gotPos = sequence[sequencePosition].ToString();
		positions.targetPosition (gotPos);

		sequencePosition++;
		yield return new WaitForSeconds (stepTime);
		if (loopAnim || sequencePosition < sequenceLength) {
			StartCoroutine ("playSequence");
		} 
		else {
			if (currentAnim=="jump" && isWalking)
			{
				Debug.Log ("end jump");
				startWalk();
			}
		}

	}

	IEnumerator pickUpAnim(){
		
				if (sequencePosition == 0) {
						yield return new WaitForSeconds (0);
						positions.setShiftSpeed(6f);
						positions.targetPosition ("grab");
						StartCoroutine ("pickUpAnim");
						sequencePosition++;
				}
				if (sequencePosition == 1) {
						yield return new WaitForSeconds (.5f);
						positions.setShiftSpeed(6f);
						positions.targetPosition ("windup");
						StartCoroutine ("pickUpAnim");
						sequencePosition++;
				}
				if (sequencePosition == 2) {
						yield return new WaitForSeconds (1f);
						positions.setShiftSpeed(20f);
						positions.targetPosition ("toss");
						StartCoroutine ("pickUpAnim");
						sequencePosition++;
				}
				if (sequencePosition == 3) {
						yield return new WaitForSeconds (1f);
						positions.setShiftSpeed(6f);
						positions.targetPosition ("stand");
				}
		}
}
