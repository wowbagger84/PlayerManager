using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5;
	[Range(0,4)]
    public int playerIndex = 1;

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
		playerIndex = transform.parent.GetComponent<Player>().playerIndex;
		Debug.Log("Player " + playerIndex + " has joined");
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxisRaw("Horizontal" + playerIndex);
        float y = Input.GetAxisRaw("Vertical" + playerIndex);
        Vector2 movement = new Vector2(x, y).normalized * speed;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.y);
    }
}
