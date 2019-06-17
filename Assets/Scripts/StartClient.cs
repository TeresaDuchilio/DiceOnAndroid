using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StartClient : MonoBehaviour {

	public bool isAtStartup = true;

	NetworkClient myClient;

	void Update ()
	{
		if (isAtStartup) {
			
			if (Input.GetKeyDown (KeyCode.C)) {
				SetupClient ();
			}

		}
	}

	void OnGUI()
	{
		if (isAtStartup)
		{     
			GUI.Label(new Rect(2, 50, 150, 100), "Press C to connect");
		}
	}   

	// Create a client and connect to the server port
	public void SetupClient()
	{
		myClient = new NetworkClient();
		myClient.RegisterHandler(MsgType.Connect, OnConnected);     
		myClient.Connect("192.168.178.1", 4444);
		isAtStartup = false;
	}

	// client function
	public void OnConnected(NetworkMessage netMsg)
	{
		Debug.Log("Connected to server");
	}
}
