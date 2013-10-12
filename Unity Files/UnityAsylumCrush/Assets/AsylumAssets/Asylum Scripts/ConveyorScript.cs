using UnityEngine;
using System.Collections;

public class ConveyorScript : MonoBehaviour {
 
    public float speed;
	
	// Player contact behaviour
  	void OnControllerColliderHit(ControllerColliderHit hit) {
 
		// Player/Conveyor object contact behaviour
        if (hit.gameObject.tag == "Conveyor")
		{
			// Apply force pushing player backwards
			float conveyorVelocity = speed * Time.deltaTime;
			hit.controller.Move(new Vector3(0.0f, 0.0f, 
			-conveyorVelocity));
		}
    }
	
	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
