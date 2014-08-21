using UnityEngine;
using System.Collections;

public class TargetCollisionChecker : MonoBehaviour {

	void OnCollisionEnter() {
		MasterController.WallTouched = true;
		this.audio.Play();
	}
}
