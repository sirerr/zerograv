using UnityEngine;
using System.Collections;

public class ColliderFollow : MonoBehaviour {

    private CapsuleCollider playerCollider;
    private Transform playerTransform;
    public GameObject cameraHead;

	// Use this for initialization
	void Start () {
        updatePosition();
    }
	
	// Update is called once per frame
	void Update () {
        updatePosition();
	}

    void updatePosition() {
	    // get the coordinates of the camera
        playerCollider = GetComponent<CapsuleCollider>();
        // playerCollider.center = transform.InverseTransformPoint(transform.position);
        playerCollider.center = cameraHead.transform.position;
    }
}
