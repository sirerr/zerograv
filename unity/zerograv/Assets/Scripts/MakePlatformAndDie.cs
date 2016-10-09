using UnityEngine;
using System.Collections;

public class MakePlatformAndDie : MonoBehaviour {

	public GameObject newplatform;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.Space)){
			
			iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(0, 0, 0), "easetype", iTween.EaseType.easeInBack, "time", 1.0f));
			GameObject Platform = (GameObject)Instantiate(newplatform, transform.position, Quaternion.identity); 
			iTween.ScaleTo(Platform, iTween.Hash("scale", new Vector3(1, 1, 1), "time", 5.0f, "oncomplete", "KillMe", "oncompletetarget", gameObject));

		}
	}

	void MakePlatform()
	{

	}

	void KillMe(){
		Destroy(gameObject);
	}


}
