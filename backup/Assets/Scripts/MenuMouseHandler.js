/**
    Mouse Down Event Handler
*/
function OnMouseDown()
{
    // if we clicked the play button
    if (this.name == "PlayBT")
    {
        // load the game
        Application.LoadLevel("MainStage");
    }
	// if we clicked the help button
else if (this.name == "HighScoreBT")
{
    // rotate the camera to view the help &quot;page&quot;
	iTween.RotateTo(Camera.main.gameObject, Vector3(0, -900, 0), 1.0);
     
}

else if (this.name == "BackBT")
{
    // rotate the camera to view the menu "page"
    iTween.RotateTo(Camera.main.gameObject, Vector3(0, 1.630868, 0), 1.0);
}
}