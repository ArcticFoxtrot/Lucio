using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	[SerializeField] float runSpeed = 5f;


	private Rigidbody2D playerRb;

	// Use this for initialization
	void Start () {
		playerRb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Run();
	}

	private void Run() {
		float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // between -1 and +1
		Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, playerRb.velocity.y);
		playerRb.velocity = playerVelocity;
		}
	}
