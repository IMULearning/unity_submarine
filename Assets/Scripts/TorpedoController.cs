using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TorpedoController : MonoBehaviour {

	private float speed = 10f;

	public GameObject explosionPrefab;

	private SubmarineController submarineController;

	// Use this for initialization
	void Start () {
		GameObject baseObject = GameObject.Find("Submarine");
		this.submarineController = (SubmarineController) baseObject.GetComponent (typeof(SubmarineController));

		Destroy (this.gameObject, 10f);	// destory itself after 10s, saves memory
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += this.transform.forward * Time.deltaTime * speed;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer == 0) {
			this.playExplosionSound ();
			Destroy (this.gameObject);
		} else if (other.tag == "Destroyable") {
			this.playExplosionSound ();
			Destroy (other.gameObject);
			Destroy (this.gameObject);

			MineCounter.number--;
			if (MineCounter.number == 0) {
				this.submarineController.WinGame ();
			} else {
				MineCounter.DisplayProgress ();
			}
		}
	}

	void playExplosionSound() {
		GameObject explosion = Instantiate (this.explosionPrefab) as GameObject;
		explosion.transform.position = this.transform.position;
		explosion.transform.rotation = this.transform.rotation;
	}
}
