using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

	private SubmarineController submarineController;

	// Use this for initialization
	void Start () {
		GameObject baseObject = GameObject.Find("Submarine");
		this.submarineController = (SubmarineController) baseObject.GetComponent (typeof(SubmarineController));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider otherCollider) {
		//this.transform.root.GetComponent<SubmarineController> ().KillSub ();
		if (otherCollider.gameObject.name == "UnderwaterMine") {
			submarineController.KillSub ();
		}
		//this.SendMessageUpwards("KillSub");
	}

//	void OnTriggerStay(Collider other) {
//	}
//
//	void OnTriggerExit(Collider other) {
//	}
}
