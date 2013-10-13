/// <summary>
/// Camera shake script.
/// Code inspired from http://answers.unity3d.com/questions/212189/camera-shake.html
/// Provided by mdjasper and translated to C# by bgprocks 
/// </summary>
using UnityEngine;
using System.Collections;

public class CameraShakeScript : MonoBehaviour {
	
	public float shakeDecay;
	
	bool bShaking;
	float fShakeDecay;
	float fShakeIntensity;
	
	Vector3 vOriginalPos;
	Quaternion qOriginalRot;

	// Use this for initialization
	void Start () {
		bShaking = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	    if(fShakeIntensity > 0)
	    {
	        transform.position = vOriginalPos + Random.insideUnitSphere * fShakeIntensity;
	        transform.rotation = new Quaternion(qOriginalRot.x + Random.Range(-fShakeIntensity, fShakeIntensity)*.2f,
	                                  qOriginalRot.y + Random.Range(-fShakeIntensity, fShakeIntensity)*.2f,
	                                  qOriginalRot.z + Random.Range(-fShakeIntensity, fShakeIntensity)*.2f,
	                                  qOriginalRot.w + Random.Range(-fShakeIntensity, fShakeIntensity)*.2f);
	 
	       fShakeIntensity -= fShakeDecay;
	    }
	    else if (bShaking)
	    {
	       bShaking = false;  
	    }
	}
	
	public void DoShake(float shakeIntensity)
	{
	    vOriginalPos = transform.position;
	    qOriginalRot = transform.rotation;
	 
	    fShakeIntensity = shakeIntensity;
	    fShakeDecay = shakeDecay;
	    bShaking = true;
	}
}
