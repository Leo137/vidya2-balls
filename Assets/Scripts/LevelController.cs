using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {
	public static int PlatformsTouched { get; set; }
	public static bool WallTouched { get; set;}
	public static bool ReturnedToPlayer { get; set; }
	public static float Timer { get; set; } // millisecs
	
	public static int CurrentPlayer { get; set;}

	public float timerLengthSeconds;
	public GUIText platformCountGUI;
	public GUIText hitTargetGUI;
	public GUIText returnedGUI;
	public GUIText timerGUI;
	
	// Use this for initialization
	void Awake() {
		PlatformsTouched = 0;
		WallTouched = ReturnedToPlayer = false;
		
		CurrentPlayer = 1;
		Timer = timerLengthSeconds;
	}
	
	void Update() {
		if (Input.GetKeyDown(KeyCode.F5)) {
			Debug.Log("Reset");
			Application.LoadLevel(Application.loadedLevelName);
		}
		Timer -= Time.deltaTime;
	}
	
	void LateUpdate() {
		this.platformCountGUI.text = string.Format("Plataformas: {0}", PlatformsTouched);
		if (WallTouched) this.hitTargetGUI.text = "Yay!";
		if (ReturnedToPlayer) this.returnedGUI.text = "Llego!";
		timerGUI.text = string.Format("{0,2:N0}:{1,2:N0}", Timer / 60, Timer % 60);
	}
}
