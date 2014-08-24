using UnityEngine;
using System.Collections;

public class HighscoreScript : MonoBehaviour {

	public TextMesh texto;
	public static int highscore = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		texto.text = "Puntaje - " + highscore;	
	}
}
