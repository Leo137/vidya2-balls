using UnityEngine;
using System.Collections;

public class PlatformCollisionChecker : MonoBehaviour {
	private bool alreadyTouched;

	void Start() {
		alreadyTouched = false;
	}

	void OnCollisionEnter() {
		if (!alreadyTouched) { 
			MasterController.PlatformsTouched += 1;
			alreadyTouched = true;
		}
	}
}
