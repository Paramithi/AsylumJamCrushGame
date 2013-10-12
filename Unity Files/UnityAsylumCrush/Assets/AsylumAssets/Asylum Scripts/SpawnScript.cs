using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	
	// Crusher fields
	public float fSpawnRate; //in seconds
	public float fSpawnTime; //in seconds (3)
	public int obsPerRow; // Number of obstacles per row

	// Use this for initialization
	void Start () {
		//InvokeRepeating("SpawnObstacles", fStartTime , fSpawnRate);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// Spawn a row of obstacles
	void SpawnObstacles(){
		for(int i = 0; i < obsPerRow; i++){
			//Instantiate (,,);
		}
	}
}
