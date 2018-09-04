using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

	[SerializeField] AudioClip pickUpSFX;
	[SerializeField] int scorePoints;

	private GameSession gameSessionController;

	private void Awake() {
		gameSessionController = FindObjectOfType<GameSession>();
		}


	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.GetComponent<Player>()) {
			AudioSource.PlayClipAtPoint(pickUpSFX, Camera.main.transform.position);
			gameSessionController.AddScore(scorePoints);
			Destroy(gameObject);
			}
		}
	}
