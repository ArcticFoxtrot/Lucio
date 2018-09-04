using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour {

	private int startingLevelIndex;


	private void Awake() {
		int numScenePersist= FindObjectsOfType<ScenePersist>().Length;
		if (numScenePersist > 1) {
			Destroy(gameObject);
			} else {
			DontDestroyOnLoad(gameObject);
			}
		}
	// Use this for initialization
	void Start () {
		startingLevelIndex = SceneManager.GetActiveScene().buildIndex;
	}
	
	// Update is called once per frame
	void Update () {
		int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
		if(startingLevelIndex != currentLevelIndex) {
			Destroy(gameObject);
			}
	}
}
