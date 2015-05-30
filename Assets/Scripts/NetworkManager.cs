using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour 
{
	// GUI junk
	public double btnX;
	public double btnY;
	public double btnW;
	public double btnH;

	//public GameObject playerPrefab;
	public Transform spawnObject;

	// servers found
	public HostData[] hostData;

	// set to true while waiting for list to populate
	protected bool _waitingForList;

	// server name
	protected const string GAME_NAME = "ZDHDY_MGD";

	// Use this for initialization
	void Start() 
	{
		btnX = Screen.width * 0.1;
		btnY = Screen.height * 0.1;
		btnW = Screen.width * 0.12;
		btnH = Screen.width * 0.12;
		_waitingForList = true;
	}

	// checking for server list
	void Update()
	{
		if (_waitingForList && MasterServer.PollHostList().Length != 0) 
		{
			_waitingForList = false;
			hostData = MasterServer.PollHostList();
			int i = 0;
			while (i < hostData.Length) {
				Debug.Log("Game name: " + hostData[i].gameName);
				i++;
			}
			MasterServer.ClearHostList();
		}
	}

	void StartServer()
	{
		Network.InitializeServer(32, 25000, !Network.HavePublicAddress());
		MasterServer.RegisterHost(GAME_NAME, "Mobile Game Demo", "Mobile network testing");
	}

	void RefreshList()
	{
		MasterServer.RequestHostList(GAME_NAME);
		_waitingForList = true;
		Debug.Log( "Waiting for server list" );
	}

	// server messages
	void OnServerInitialized()
	{
		Debug.Log("Server initialized");
		//AddPlayer();
	}

	void OnConnectedToServer()
	{
		//AddPlayer();
	}

	// add a new player at the start position
	void AddPlayer()
	{
		//Network.Instantiate( playerPrefab, spawnObject.position, Quaternion.identity, 0 );
	}

	void OnMasterServerEvent(MasterServerEvent mse)
	{
		if (mse == MasterServerEvent.RegistrationSucceeded) 
		{
			Debug.Log("Registration succeeded");
		}
	}

	void OnGUI()
	{
		if ( !Network.isClient && !Network.isServer )
		{
			Rect rect = new Rect();
			rect.x = (float)btnX;
			rect.y = (float)btnY;
			rect.width = (float)btnW;
			rect.height = (float)btnH;
			if ( GUI.Button( rect, "Start Server" ) )
			{
				Debug.Log( "Starting server" );
				StartServer();
			}

			if ( GUI.Button( new Rect( rect.x, (float)(rect.y * 1.2) + rect.height, rect.width, rect.height ), "Refresh Host" ) )
			{
				Debug.Log( "Refreshing" );
				RefreshList();
			}

			if ( hostData != null )
			{
				int i = 0;
				while (i < hostData.Length)
				{
					if( GUI.Button( new Rect( (float)(rect.x * 1.5 + rect.width), rect.y, rect.width, rect.height/4 ), hostData[i].gameName ) )
					{
						Network.Connect( hostData[i] );
					}
					i++;
				}
			}
		}
	}
}
