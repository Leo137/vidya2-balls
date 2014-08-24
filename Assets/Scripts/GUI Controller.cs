using UnityEngine;
using System.Collections;

public class GuiController : MonoBehaviour {
	public static int PlatformsTouched { get; set; }
	public static bool WallTouched { get; set;}
	public static bool ReturnedToPlayer { get; set; }

	public static int CurrentPlayer { get; set;}

	public GUIText platformCountGUI;
	public GUIText hitTargetGUI;
	public GUIText returnedGUI;

	// Use this for initialization
	void Awake() {
		PlatformsTouched = 0;
		WallTouched = ReturnedToPlayer = false;

		CurrentPlayer = 1;
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.F5)) {
			Debug.Log("Reset");
			Application.LoadLevel(Application.loadedLevelName);
		}
	}

	void LateUpdate() {
		this.platformCountGUI.text = string.Format("Plataformas: {0}", PlatformsTouched);
		if (WallTouched) this.hitTargetGUI.text = "Yay!";
		if (ReturnedToPlayer) this.returnedGUI.text = "Llego!";
	}
}
