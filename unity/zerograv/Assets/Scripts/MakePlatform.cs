using UnityEngine;
using System.Collections;

public class MakePlatform : MonoBehaviour {

	[SerializeField] GameObject platform;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
        if (col.gameObject.tag == "Ball")
        {
            Instantiate(platform, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
	}
}
