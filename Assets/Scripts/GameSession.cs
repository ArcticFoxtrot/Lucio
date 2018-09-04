using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {

	[SerializeField] int score = 0;
	[SerializeField] int playerLives = 3;
	[SerializeField] Text scoreText;
	[SerializeField] Text livesText;


	private void Awake() {
		int numGameSessions = FindObjectsOfType<GameSession>().Length;
		if (numGameSessions > 1) {
			Destroy(gameObject);
			} else {
			DontDestroyOnLoad(gameObject);
			}
		}
	// Use this for initialization
	void Start () {
		livesText.text = playerLives.ToString();
		scoreText.text = score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddScore(int pointsAdded) {
		score += pointsAdded;
		scoreText.text = score.ToString();
		}

	public void ProcessPlayerDeath() {
		if (playerLives > 1) {
			LoseLife();
			} else {
			Invoke("ResetGameSession", 2);

			}
		}

	private void ResetGameSession() {
		SceneManager.LoadScene(0);
		Destroy(gameObject);
		}

	private void LoseLife() {
		playerLives = playerLives - 1;
		livesText.text = playerLives.ToString();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

	}

