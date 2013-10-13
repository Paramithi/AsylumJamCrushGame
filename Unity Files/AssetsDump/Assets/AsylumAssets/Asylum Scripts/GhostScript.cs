using UnityEngine;
using System.Collections;

public class GhostScript : MonoBehaviour {
	
	// Repeater fields
	public float spawnRate; //in seconds
	public float spawnTime; //in seconds (3)
	public float spawnChance;
	
	// Spawner fields
	public int ghostsPerRow; // Number of obstacles per row
	public float convWidth; // Conveyor belt width
	public float convX; // Conveyor belt X position coordinate
	public float obsY;  // Desired obstacle Y position
	public float obsZ;  // Desired obstacle Z position	
	public GameObject ghost;
	
	// Use this for initialization
	void Start () {
		// Test single spawn
		//SpawnObstacles ();
		
		InvokeRepeating("SpawnGhosts", spawnTime , spawnRate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// Spawn a row of obstacles
	void SpawnGhosts(){
		for(float i = 0; i < ghostsPerRow; i++){
			if((Random.value <= spawnChance))
			{
				float spawnX = ((i/ghostsPerRow - 1.0f) * convWidth) + convX;
				Vector3 pos = new Vector3(spawnX, obsY, obsZ);
				Quaternion rot = transform.rotation;
				Instantiate (ghost, pos, rot);
			}
		}
	}
}
