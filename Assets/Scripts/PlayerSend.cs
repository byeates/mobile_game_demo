using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerSend : NetworkBehaviour 
{
	[SyncVar]
	private Vector3 position;

	[SerializeField] Transform playerTransform;
	[SerializeField] float lerpBy = 15.0f;
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		SendPosition();
		LerpPosition();
	}

	/** Interpolate users positions to resolve stutter effect */
	void LerpPosition()
	{
		if ( !isLocalPlayer )
		{
			playerTransform.position = Vector3.Lerp( playerTransform.position, position, Time.deltaTime * lerpBy );
		}
	}

	/** Server command to send position updates */
	[Command]
	void CmdUpdatePosition( Vector3 pos )
	{
		if ( isLocalPlayer )
		{
			position = pos;
		}
	}

	[ClientCallback]
	void SendPosition()
	{
		if ( isLocalPlayer )
		{
			CmdUpdatePosition( playerTransform.position );
		}
	}
}
