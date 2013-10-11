using UnityEngine;
using System.Collections;

public class CrushScript : MonoBehaviour {
	
	public float fCrushRate; //in seconds
	public float fStartTime; //in seconds (3)
	public AudioSource asCrushSound;
	
	bool bPlayerInRange = false;
	bool bGameOver = false;
	

	// Use this for initialization
	void Start () {
		InvokeRepeating("Crush", fStartTime , fCrushRate);
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void Crush()
	{
		Debug.Log("SMASH!");
		if(bPlayerInRange)
		{
			Debug.Log("Game Over!");
			bGameOver = true;
		}
		else
			Debug.Log ("Keep Running!");
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag.Equals("Player"))
		{
			Debug.Log("Player!");
			bPlayerInRange = true;
		}
		Debug.Log("Enter!");
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.tag.Equals("Player"))
		{
			Debug.Log("Come again!");
			bPlayerInRange = false;
		}
		Debug.Log("Exit!");
	}
}
