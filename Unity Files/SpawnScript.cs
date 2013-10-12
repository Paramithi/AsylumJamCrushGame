using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	
	// Repeater fields
	public float spawnRate; //in seconds
	public float spawnTime; //in seconds (3)
	public float spawnChance;
	
	// Spawner fields
	public int obsPerRow; // Number of obstacles per row
	public float convWidth; // Conveyor belt width
	public float convX; // Conveyor belt X position coordinate
	public float obsY;  // Desired obstacle Y position
	public float obsZ;  // Desired obstacle Z position	
	public GameObject obstacle;
	
	// Use this for initialization
	void Start () {
		// Test single spawn
		//SpawnObstacles ();
		
		InvokeRepeating("SpawnObstacles", spawnTime , spawnRate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// Spawn a row of obstacles
	void SpawnObstacles(){
		int spawns = 0;
		for(float i = 0; i < obsPerRow; i++){
			if((Random.value <= spawnChance)&&(spawns <= obsPerRow - 2))
			{
				float spawnX = ((i/obsPerRow - 1.0f) * convWidth) + convX;
				Vector3 pos = new Vector3(spawnX, obsY, obsZ);
				Quaternion rot = transform.rotation;
				Instantiate (obstacle, pos, rot);
				spawns++;
			}
		}
	}
}
