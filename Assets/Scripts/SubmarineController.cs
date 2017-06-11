using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubmarineController : MonoBehaviour {

	public GameObject torpedoPrefab;

	private GameObject mainCamera;
	private GameObject submarineHolder;
	private GameObject firingPoint;

	private float speed = 2f;
	private float rotationSpeed = 1f;

	private bool gameOn = true;

	// Use this for initialization
	void Start () {
		this.mainCamera = GameObject.Find ("Camera");
		this.submarineHolder = GameObject.Find ("SubmarineHolder");
		this.firingPoint = GameObject.Find ("FiringPoint");
		// Application.Quit() force quits the application
		this.submarineHolder.transform.position = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameOn) {
			this.transform.position += this.mainCamera.transform.forward * Time.deltaTime * speed;
			//this.submarineHolder.transform.rotation = this.mainCamera.transform.rotation;
			this.submarineHolder.transform.rotation = Quaternion.Slerp (
				this.submarineHolder.transform.rotation, 
				this.mainCamera.transform.rotation, 
				Time.deltaTime * this.rotationSpeed
			);

			if (GvrViewer.Instance.Triggered) {
				this.Fire ();
			}

//			if (Input.GetKeyDown (KeyCode.Mouse0)) {
//				this.Fire ();
//			}
		}
	}

	public void KillSub() {
		this.gameOn = false;
		UIHelper_Example.ChangeText ("You have died.");
		GameManager.INSTANCE.EndGame (3);
	}

	public void WinGame() {
		this.gameOn = false;
		UIHelper_Example.ChangeText ("You have won!");
		GameManager.INSTANCE.EndGame (3);
	}

	private void Fire() {
//		GameObject torpedo = Instantiate (this.torpedoPrefab) as GameObject;
//		torpedo.transform.position = this.firingPoint.transform.position;
//		torpedo.transform.rotation = this.firingPoint.transform.rotation;

		// simplified version
		Instantiate (torpedoPrefab, firingPoint.transform.position, firingPoint.transform.rotation);
	}
}
