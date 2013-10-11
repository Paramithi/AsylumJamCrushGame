using UnityEngine;
using System.Collections;

public class ConveyorScript : MonoBehaviour {
 
    public float speed;
	
  	void OnControllerColliderHit(ControllerColliderHit hit) {
 
        if (hit.gameObject.tag == "Conveyor")
		{
			float conveyorVelocity = speed * Time.deltaTime;
			hit.controller.Move(-conveyorVelocity * hit.collider.transform.forward);
		}
    }
	
    /*void OnCollisionStay(Collision collision) { 
        // Assign velocity based upon direction of conveyor belt
        // Ensure that conveyor mesh is facing towards its local Z-axis
 
        float conveyorVelocity = speed * Time.deltaTime;
 
        Rigidbody rigidbody = collision.gameObject.rigidbody;
        rigidbody.velocity = -conveyorVelocity * transform.forward;
    }*/

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
