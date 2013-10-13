using UnityEngine;
using System.Collections;

public class ConveyorScript : MonoBehaviour {
 
    public float speed;
	public float impact;
	public AudioClip impactSound;
	public AudioClip fallSound;
	// Menu fields
	public GUISkin menuSkin; // Game over menu skin
	// Game over menu dimensions
	public float areaWidth;  // Game over menu width
	public float areaHeight; // Game over menu height
	bool bGameOver = false; // Has player lost the game?
	
	// Player contact behaviour
  	void OnControllerColliderHit(ControllerColliderHit hit) {
 
		// Player/Conveyor object contact behaviour
        if (hit.gameObject.tag == "Conveyor")
		{
			if(hit.controller.transform.position.z > 230.0f)
			{
				// Apply force pushing player backwards
				float conveyorVelocity = speed * Time.deltaTime;
				hit.controller.Move(new Vector3(0.0f, 0.0f, 
				-conveyorVelocity));
			}
		}
		
		// Player/Conveyor object contact behaviour
        if (hit.gameObject.tag == "Obstacle")
		{
			if(!bGameOver)
			{
				audio.PlayOneShot(impactSound);
				// Apply force pushing player backwards
				float conveyorVelocity = impact * Time.deltaTime;
				hit.controller.transform.Translate(new Vector3(0.0f, 0.0f, 
				-conveyorVelocity));
			}
		}
		
		if (hit.gameObject.tag == "Killbox")
		{
			if(!bGameOver)
			{
				GameObject.Find("GameOverScreen").guiTexture.enabled = true;
				audio.PlayOneShot(fallSound);
				bGameOver = true;
			}
		}
    }
	
	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
	
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
