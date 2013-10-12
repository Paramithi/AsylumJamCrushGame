using UnityEngine;
using System.Collections;

public class NearScript : MonoBehaviour {
	
	bool bPlayerNear = false;
	bool bPlayerGasped = false;
	public AudioClip gasp; 
	
	void OnTriggerEnter(Collider other){
		
		if(other.tag.Equals("Player"))
		{
			bPlayerNear = true;
		}
	}
	
	void OnTriggerExit(Collider other){
		
		if(other.tag.Equals("Player"))
		{
		bPlayerNear = false;
		bPlayerGasped = false;
		}
	}
	
	void CrushSignal() {
		// Make gasp noise
		if(!bPlayerGasped && bPlayerNear)
		{
			audio.PlayOneShot(gasp);
			bPlayerGasped = true;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
