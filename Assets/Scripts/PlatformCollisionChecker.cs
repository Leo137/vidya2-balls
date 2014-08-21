using UnityEngine;
using System.Collections;
using System.Linq;

public class PlatformCollisionChecker : MonoBehaviour {
	private bool alreadyTouched;

	void Start() {
		alreadyTouched = false;
	}

	void OnCollisionEnter(Collision collisionData) {
		if (!alreadyTouched && collisionData.contacts[0].normal == Vector3.down) {
			LevelController.PlatformsTouched += 1;
			alreadyTouched = true;
		}
	}
}
