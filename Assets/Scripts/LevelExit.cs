using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {


	[SerializeField] float exitDelay = 3f;
	[SerializeField] float levelExitSlowMoFactor = 0.2f;

	private void OnTriggerEnter2D(Collider2D collision) {
		StartCoroutine(LoadNextScene());
		}


	IEnumerator LoadNextScene() {
		Time.timeScale = levelExitSlowMoFactor;
		yield return new WaitForSecondsRealtime(exitDelay);
		Time.timeScale = 1f; //normal timescale
		var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex + 1); 

		}
	}
