using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager INSTANCE;

	// Use this for initialization
	void Start () {
		INSTANCE = this;
	}
	
	public void EndGame(float time) {
		Invoke ("ReloadGame", time);
	}

	public void ReloadGame() {
		MineCounter.number = 5;
		UIHelper_Example.ChangeText ("Destroy the mines to win!");
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}
