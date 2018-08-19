using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


	[SerializeField] float enemySpeed = 1f;

	private Rigidbody2D enemyRb;
	// Use this for initialization
	void Start () {
		enemyRb = gameObject.GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (IsFacingRight()) {
			enemyRb.velocity = new Vector2(-enemySpeed, 0);
			} else {
			enemyRb.velocity = new Vector2(enemySpeed, 0);
			}
	}

	private void OnTriggerExit2D(Collider2D collision) {
		print("Triggered");
		transform.localScale = new Vector2((Mathf.Sign(enemyRb.velocity.x)), 1f);
		}

	private bool IsFacingRight() {
		return transform.localScale.x > 0;
		}
	}


