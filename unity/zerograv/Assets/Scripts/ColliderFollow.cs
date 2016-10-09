using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class ColliderFollow : MonoBehaviour {

    private BoxCollider playerColliderFeet;
    private BoxCollider playerColliderHead;
    private Vector3 yDiff;

	// Use this for initialization
	void Start () {
        BoxCollider[] colliders = GetComponents<BoxCollider>();
        playerColliderFeet = colliders[0];
        playerColliderHead = colliders[1];
        yDiff = playerColliderFeet.center;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 headPos = InputTracking.GetLocalPosition(VRNode.Head);

        playerColliderHead.center = headPos;

        headPos.y = 0;
        playerColliderFeet.center = headPos;
    }
}
