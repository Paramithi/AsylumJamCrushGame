using UnityEngine;
using System.Collections;

public class ConveyorBeltScript : MonoBehaviour {
 
    public float speed;
	
	void OnCollisionStay(Collision collision){
		if (collision.gameObject.tag != "Obstacle") 
			return;
 
        // Assign velocity based upon direction of conveyor belt
        // Ensure that conveyor mesh is facing towards its local Z-axis
 
        float conveyorVelocity = speed * Time.deltaTime;
 
        GameObject obstacle = collision.gameObject;
        obstacle.transform.position -= conveyorVelocity * transform.forward;
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
