using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //singleton
    private static PlayerController instance;
    public static PlayerController GetInstance()
    {
        return instance;
    }

    //Variables
    public int maxNumberOfPlayers;
	public Player playerHandlerPrefab;
    public Transform[] spawnPoints;

	private List<Player> players = new List<Player>();

    void Awake()
    {
        instance = this;
    }

	void Start()
	{
		for (int i = 0; i < maxNumberOfPlayers; i++)
		{
			var newPlayer = Instantiate(playerHandlerPrefab, transform);
			newPlayer.playerIndex = i;
			players.Add(newPlayer);
		}

		//Spawn players here instead of update
	}

	void Update()
    {
		//Temporary way to spawn new player
		if (Input.GetButtonDown("Jump"))
			SpawnPlayerCharacter();
    }

	//Spawn first inactive player
	private void SpawnPlayerCharacter()
	{
		foreach (var player in players)
		{
			if (!player.active)
			{
				player.SpawnPlayer();
				return;
			}
		}
	}

	public void UpdateGameStatus()
	{
		//Check if we only have one player left?
	}
}
