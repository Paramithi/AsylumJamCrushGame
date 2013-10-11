using UnityEngine;
using System.Collections;

public class ConveyorScript : MonoBehaviour {
 
    public float speed;
	
  	void OnControllerColliderHit(ControllerColliderHit hit) {
 
        if (hit.gameObject.tag == "Conveyor")
		{
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
