using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class HeadFollower : MonoBehaviour {

    private Vector3 diff;
    private Vector3 lastPosition;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    void FixedUpdate() {
        diff = (transform.parent.transform.position - lastPosition) / Time.fixedDeltaTime;
        Quaternion q = new Quaternion();
        //if (diff.magnitude < 1) {
          //  q = InputTracking.GetLocalRotation(VRNode.Head);
        //} else {
            q.SetLookRotation(diff);
        //}
        transform.parent.transform.rotation = q;
        lastPosition = transform.parent.transform.position;
    }
}
