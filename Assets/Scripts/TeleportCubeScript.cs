using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCubeScript : MonoBehaviour {

	public float fixedDistance = 3f;
	private bool direction = false;

	public void RandomTeleport() {
		Vector3 delta = new Vector3 (1f * Random.Range (-3f, 3f), 1f * Random.Range (-3f, 3f), 1f * Random.Range (-3f, 3f));
		this.move (delta);
	}

	public void Teleport() {
		Vector3 delta = new Vector3 (0, 0, direction ? fixedDistance : -fixedDistance);
		this.move (delta);
		direction = !direction;
	}

	private void move(Vector3 delta) {
		this.transform.position += delta;
	}
}
