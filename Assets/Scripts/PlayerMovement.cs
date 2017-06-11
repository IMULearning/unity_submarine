using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 0.5f;
	//public GameObject camera;
	public Transform cameraTransform;		// eyes, don't forget you may have a body

	private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		//camera = GameObject.Find ("Camera");
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			this.transform.position += ray.GetPoint (3);
		}

		//Debug.Log (Camera.main.ScreenToWorldPoint (Input.mousePosition));

		//this.targetPosition = this.transform.position;
		//this.transform.position = this.transform.position + this.cameraTransform.forward * speed * Time.deltaTime;
		//this.transform.position = this.transform.position + this.camera.transform.forward * speed * Time.deltaTime;
	}
}
