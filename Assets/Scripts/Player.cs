using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {


	//Config
	[SerializeField] float runSpeed = 5f;
	[SerializeField] float jumpSpeed = 5f;
	[SerializeField] float fallMultiplier = 2.5f;
	[SerializeField] float jumpMultiplier = 2.5f;
	[SerializeField] float climbSpeed = 5f;

	//State
	private bool isAlive = true;

	//Cached Components
	private Rigidbody2D playerRb;
	private Animator playerAnimator;
	private Collider2D playerCollider;
	float gravityScaleAtStart;

	//Messages then methods
	// Use this for initialization
	void Start () {
		playerRb = gameObject.GetComponent<Rigidbody2D>();
		playerAnimator = gameObject.GetComponent<Animator>();
		playerCollider = gameObject.GetComponent<Collider2D>();
		gravityScaleAtStart = playerRb.gravityScale;
	}
	
	// Update is called once per frame
	void Update () {
		Run();
		FlipSprite();
		Jump();
		ClimbLadder(); 
	}

	private void Run() {
		float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // between -1 and +1
		Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, playerRb.velocity.y);
		playerRb.velocity = playerVelocity;
		

		bool playerHasHorizontalSpeed = Mathf.Abs(playerRb.velocity.x) > Mathf.Epsilon;
		playerAnimator.SetBool("isRunning", playerHasHorizontalSpeed);

		}

	private void Jump() {
		
		if(playerRb.velocity.y < 0) {
			playerRb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
			} else if (!CrossPlatformInputManager.GetButtonDown("Jump") && playerRb.velocity.y > 0) {
			playerRb.velocity += Vector2.up * Physics2D.gravity.y * (jumpMultiplier - 1) * Time.deltaTime; 
			}
		if (!playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
			return; 
				} else if (playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
			if (CrossPlatformInputManager.GetButtonDown("Jump")) {
				Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
				playerRb.velocity += jumpVelocityToAdd;
				}
			}
		}


	private void ClimbLadder() {
		
		if (!playerCollider.IsTouchingLayers(LayerMask.GetMask("Climbable"))) {
			playerAnimator.SetBool("isClimbing", false);
			playerRb.gravityScale = gravityScaleAtStart;
			return;
			}
		float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");
		Vector2 climbVelocity = new Vector2(playerRb.velocity.x, controlThrow * climbSpeed);
		playerRb.velocity = climbVelocity;
		playerRb.gravityScale = 0f;

		bool playerHasVerticalSpeed = Mathf.Abs(playerRb.velocity.y) > Mathf.Epsilon;
		playerAnimator.SetBool("isClimbing", playerHasVerticalSpeed);

		}

	private void FlipSprite() {
		bool playerHasHorizontalSpeed = Mathf.Abs(playerRb.velocity.x) > Mathf.Epsilon;
		if (playerHasHorizontalSpeed) {
			transform.localScale = new Vector2(Mathf.Sign(playerRb.velocity.x), 1f);
			}
			// if player moving horizontally  
			// reverse scaling on x axis

		}
	}
