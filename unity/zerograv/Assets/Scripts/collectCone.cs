using UnityEngine;
using System.Collections;

public class collectCone : MonoBehaviour {

	public void OnTriggerEnter(Collider col)
	{
		GameObject obj = GameObject.FindGameObjectWithTag("pointcanvas");

		obj.GetComponent<pointAdd>().gainedPoint();
		Destroy(gameObject);
	}

}