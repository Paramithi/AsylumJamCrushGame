using UnityEngine;
using System.Collections;

public class CrushScript : MonoBehaviour {
	
	// Crusher fields
	public float crushIntensity;
	public float crushRate; //in seconds
	public float startTime; //in seconds
	public AudioClip crushSound; // Sound for crushing machine
	public AudioClip gameOver; // Sound for game over (squish)
	public int obsInRow; // must be synced with SpawnScript.cs
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
		InvokeRepeating("Crush", startTime , crushRate);
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
			bPlayerInRange = true; // update player state
		}
		else if (other.tag.Equals("Obstacle"))
		{
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
			// Destroy object
			Destroy (other.gameObject);
		}
		
	}
	
	// Object is in danger zone
	void OnTriggerStay(Collider other)
	{
		// Pseudo-destroy event
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
		audio.PlayOneShot(crushSound);
	
		// Send "Crush" message to scripts
		GameObject.Find("Near Region").GetComponent("NearScript").SendMessage("CrushSignal");
		
		// Shake camera (controller)
		float fPosZ = GameObject.Find ("First Person Controller").transform.position.z;
		fPosZ = 280 - fPosZ;
		float fShakeIntensity = fPosZ * crushIntensity / 50;
		
		GameObject.Find ("First Person Controller").GetComponent
			            ("CameraShakeScript").SendMessage
				        ("DoShake", fShakeIntensity);
		
		if(bPlayerInRange)
		{
			if(!bGameOver) // Trigger game over state (once)
			{
				audio.PlayOneShot(gameOver);
				bGameOver = true;
			}
		}
		
		// Pseudo-trigger for destroy event
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
			}
			
			GUILayout.EndArea();
		}
	}
}
