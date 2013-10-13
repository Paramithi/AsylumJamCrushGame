using UnityEngine;
using System.Collections;

public class GhostMoveScript : MonoBehaviour {
    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		float conveyorVelocity = speed * Time.deltaTime;
	
		transform.position -= conveyorVelocity * transform.forward;
	}
}
