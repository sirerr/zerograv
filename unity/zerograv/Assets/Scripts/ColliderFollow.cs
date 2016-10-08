using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class ColliderFollow : MonoBehaviour {

    private CapsuleCollider playerCollider;
    private Vector3 yDiff;

	// Use this for initialization
	void Start () {
        playerCollider = GetComponent<CapsuleCollider>();
        yDiff = playerCollider.center;
        print(yDiff);
    }
	
	// Update is called once per frame
	void Update () {
        playerCollider.center = InputTracking.GetLocalPosition(VRNode.Head) + yDiff;
    }
}
