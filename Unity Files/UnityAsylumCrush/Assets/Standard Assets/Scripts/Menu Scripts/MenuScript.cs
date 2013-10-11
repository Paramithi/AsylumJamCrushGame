using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	
	public GUISkin menuSkin;
	public float areaWidth;
	public float areaHeight;
	
	void OnGUI(){
		GUI.skin = menuSkin;
		float screenX = ((Screen.width * 0.5f) - (areaWidth * 0.5f));
		float screenY = ((Screen.height * 0.5f) - (areaHeight * 0.5f));
		GUILayout.BeginArea (new Rect( screenX, screenY, areaWidth, areaHeight));
		
		if(GUILayout.Button ("Play")){
			OpenLevel("asylumGame");
		}
		
		if(GUILayout.Button ("Quit")){
			Application.Quit ();
			Debug.Log("This part works!");
		}
		
		GUILayout.EndArea();
	}
	
	void OpenLevel(string level){
		//yield return new WaitForSeconds(0.35f);
		Application.LoadLevel(level);
		Debug.Log("Level loaded!");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
