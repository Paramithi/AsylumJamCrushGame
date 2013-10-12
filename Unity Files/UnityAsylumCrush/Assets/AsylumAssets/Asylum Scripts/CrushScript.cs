using UnityEngine;
using System.Collections;

public class CrushScript : MonoBehaviour {
	
	// Crusher fields
	public float fCrushRate; //in seconds
	public float fStartTime; //in seconds
	public AudioSource asCrushSound; // Sound for crushing machine
	public AudioSource asGameOver; // Sound for game over (squish)
	
	// Menu fields
	public GUISkin menuSkin; // Game over menu skin
	// Game over menu dimensions
	public float areaWidth;  // Game over menu width
	public float areaHeight; // Game over menu height
	
	// Private fields
	bool bPlayerInRange = false; // Is player in danger zone?
	bool bGameOver = false; // Has player lost the game?
	

	// Use this for initialization
	void Start () {
		InvokeRepeating("Crush", fStartTime , fCrushRate);
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	// Object enters danger zone
	void OnTriggerEnter(Collider other)
	{
		// Player enters danger zone
		if(other.tag.Equals("Player"))
		{
			Debug.Log("Player!");
			bPlayerInRange = true; // update player state
		}
		Debug.Log("Enter!");
	}
	
	// Object exits danger zone
	void OnTriggerExit(Collider other)
	{
		// Player exits danger zone
		if(other.tag.Equals("Player"))
		{
			Debug.Log("Come again!");
			bPlayerInRange = false; // update player state
		}
		Debug.Log("Exit!");
	}
	
	// Periodic crushing method
	void Crush()
	{
		Debug.Log("SMASH!");
		if(bPlayerInRange)
		{
			if(!bGameOver) // Trigger game over state (once)
			{
				Debug.Log("Game Over!");
				bGameOver = true;
			}
		}
		else
			Debug.Log ("Keep Running!");
	}
	
	// Game over GUI screen
	void OnGUI()
	{
		// Only activate when the fail state has been reached
		if(bGameOver)
		{			
			// Freeze player movement
			GameObject.Find ("First Person Controller").GetComponent
				            ("CharacterMotor").SendMessage
					        ("SetControllable", false);
			
			// Menu functionality
			GUI.skin = menuSkin;
			float screenX = ((Screen.width * 0.5f) - (areaWidth * 0.5f));
			float screenY = ((Screen.height * 0.5f) - (areaHeight * 0.5f));
			GUILayout.BeginArea (new Rect( screenX, screenY, areaWidth, areaHeight));
			
			// Replay game option
			if(GUILayout.Button ("Play Again")){
				Application.LoadLevel("asylumGame");
			}
			
			// Quit the game
			if(GUILayout.Button ("Quit")){
				Application.Quit ();
				Debug.Log("This part works!");
			}
			
			GUILayout.EndArea();
		}
	}
}
