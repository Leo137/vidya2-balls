using UnityEngine;
using System.Collections;

public class TargetCollisionChecker : MonoBehaviour {

	void OnCollisionEnter() {
		LevelController.WallTouched = true;
		this.audio.Play();
	}
}
