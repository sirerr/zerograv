using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class ColliderFollow : MonoBehaviour {

    private BoxCollider playerCollider;
    private Vector3 yDiff;

	// Use this for initialization
	void Start () {
        playerCollider = GetComponent<BoxCollider>();
        yDiff = playerCollider.center;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 headPos = InputTracking.GetLocalPosition(VRNode.Head);
        headPos.y = 0;
        playerCollider.center = headPos;
    }
}
