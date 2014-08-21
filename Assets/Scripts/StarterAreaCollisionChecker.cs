using UnityEngine;
using System.Collections;

public class StarterAreaCollisionChecker : MonoBehaviour {
	private bool startTracking;

	void Start() {
		startTracking = false;
	}

	void OnTriggerExit() {
		startTracking = true;
	}

	void OnTriggerEnter() {
		if (startTracking) {
			LevelController.ReturnedToPlayer = true;
		}
	}
}
