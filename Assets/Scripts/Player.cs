using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//Persistance player data
	public bool active;
	public bool alive;
	public int lives;
	public GameObject playerCharacterPrefab;
	public int playerIndex;

	private GameObject player;

	internal void SpawnPlayer()
	{
		active = true;
		player = Instantiate(playerCharacterPrefab, PlayerController.GetInstance().spawnPoints[playerIndex].position, Quaternion.identity, transform);
		Camera.main.GetComponent<CameraFocus>().AddCameraTarget(player.transform);
	}

	public void RemovePlayer()
	{
		active = false;
		Destroy(player);
		PlayerController.GetInstance().UpdateGameStatus();
		//TODO: add code to decide if spawn player again.
	}
}
