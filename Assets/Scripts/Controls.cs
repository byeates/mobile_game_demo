using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	public const int speed = 10;
	public const float gravity = 0.1F;
	public CharacterController cc;
	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		NetworkView nView = GetComponent<NetworkView>();
		if( nView.isMine )
		{
			float dt = Time.deltaTime;
			Vector3 move = new Vector3(Input.GetAxis("Horizontal"), -gravity, Input.GetAxis("Vertical"));
			move.z *= speed * dt;
			move.x *= speed * dt;
			cc.Move(move);
		}
	}
}
