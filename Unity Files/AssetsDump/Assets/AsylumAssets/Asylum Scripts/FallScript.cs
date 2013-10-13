using UnityEngine;
using System.Collections;

public class FallScript : MonoBehaviour {
	
	// Menu fields
	public GUISkin menuSkin; // Game over menu skin
	// Game over menu dimensions
	public float areaWidth;  // Game over menu width
	public float areaHeight; // Game over menu height
	bool bGameOver = false; // Has player lost the game?
	
	// Player contact behaviour
  	void OnCollisionEnter(Collision collision) {
		Debug.Log ("B");
		if(!bGameOver)
			bGameOver = true;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
