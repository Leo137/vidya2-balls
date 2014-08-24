using UnityEngine;
using System.Collections;

public class StarterAreaCollisionChecker : MonoBehaviour {
	private bool startTracking;
	public AudioSource bingo;

	void Start() {
		startTracking = false;
	}

	void OnTriggerExit() {
		startTracking = true;
	}

	void OnTriggerEnter() {
		if (startTracking) {
			LevelController.ReturnedToPlayer = true;
			if(LevelController.WallTouched){

				LevelController.points ++ ;
				bingo.Play();
				if(HighscoreScript.highscore < LevelController.points){
					HighscoreScript.highscore = LevelController.points;
				}
			}
		}
	}
}
