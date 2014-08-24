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
    public bool touchedFloor;
	public int bounceNumber = 2;
	// Use this for initialization
	void Awake() {
		PlatformsTouched = 0;
		WallTouched = ReturnedToPlayer = false;
		
		CurrentPlayer = 1;
		Timer = timerLengthSeconds;
        touchedFloor = false;
	}
    void resetAfterTime()
    {
        //Es para poder invocar el cambio de nivel despues de un tiempo dado
        //usando Invoke()
        Application.LoadLevel(Application.loadedLevelName);
    }
    bool ResetChecker()
    {
        //Revisa si se cumplen las condiciones para que la pelota vuelva al juego
        //True: Si dentro de las condiciones permiten que el jugador obtenga un punto
        //False: En cualquier otro caso
        if (WallTouched && PlatformsTouched < bounceNumber ||
            !WallTouched && touchedFloor)
        {
            //Por ahora que en todos esos casos simplemente se resetee el nivel
            Invoke("resetAfterTime", 0.5f);
        }
        return false;
    }
	void Update() {
		if (Input.GetKeyDown(KeyCode.F5)) {
			Debug.Log("Reset");
			Application.LoadLevel(Application.loadedLevelName);
		}
        ResetChecker();
		Timer -= Time.deltaTime;
	}
	
	void LateUpdate() {
		this.platformCountGUI.text = string.Format("Plataformas: {0}", PlatformsTouched);
		if (WallTouched) this.hitTargetGUI.text = "Yay!";
		if (ReturnedToPlayer) this.returnedGUI.text = "Llego!";
		timerGUI.text = string.Format("{0,2:N0}:{1,2:N0}", Timer / 60, Timer % 60);
	}
}
