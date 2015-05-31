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
	}

}
