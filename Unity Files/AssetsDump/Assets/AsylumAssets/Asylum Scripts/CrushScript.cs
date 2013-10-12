using UnityEngine;
using System.Collections;

public class CrushScript : MonoBehaviour {
	
	// Crusher fields
	public float fCrushRate; //in seconds
	public float fStartTime; //in seconds
	public AudioSource asCrushSound; // Sound for crushing machine
	public AudioSource asGameOver; // Sound for game over (squish)
	public int obsInRow;
	int destroyedObjs = 0;
	
	// Menu fields
	public GUISkin menuSkin; // Game over menu skin
	// Game over menu dimensions
	public float areaWidth;  // Game over menu width
	public float areaHeight; // Game over menu height
	
	// Private fields
	bool bPlayerInRange = false; // Is player in danger zone?
	bool bGameOver = false; // Has player lost the game?
	bool bDestroy = false; // Destroy object?
	bool bObjectsInRange = false; // Are objects in range?
	

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
			//Debug.Log("Player!");
			bPlayerInRange = true; // update player state
		}
		else if (other.tag.Equals("Obstacle"))
		{
			//Debug.Log("Player!");
			bObjectsInRange = true; // update objects state
		}
	}
	
	// Object exits danger zone
	void OnTriggerExit(Collider other)
	{
		// Player exits danger zone
		if(other.tag.Equals("Player"))
		{
			bPlayerInRange = false; // update player state
		}
		// Obstacle exits danger zone (shouldn't happen)
		if(other.tag.Equals("Obstacle"))
		{
			Destroy (other.gameObject);
		}
		
	}
	
	void OnTriggerStay(Collider other)
	{
		if(bDestroy)
		{
			if(other.tag.Equals("Obstacle"))
			{
				Destroy (other.gameObject);
				destroyedObjs++;
			}
			if(destroyedObjs >= obsInRow)
			{
				destroyedObjs = 0;
				bDestroy = false;
				bObjectsInRange = false;
			}
		}
	}
	
	// Periodic crushing method
	void Crush()
	{
		Debug.Log("SMASH!");
		if(bPlayerInRange)
		{
			if(!bGameOver) // Trigger game over state (once)
			{
				//Debug.Log("Game Over!");
				bGameOver = true;
			}
		}
		if(bObjectsInRange)
			bDestroy = true;
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
