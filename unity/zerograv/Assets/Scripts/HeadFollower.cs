using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class HeadFollower : MonoBehaviour {

    public float disappearVelocity = 0.5f;
    public Transform particles;

    private Vector3 diff;
    private Vector3 lastPosition;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        diff = (transform.position - lastPosition) / Time.fixedDeltaTime;
        Quaternion q = new Quaternion();
        if (diff.magnitude < disappearVelocity) {
            particles.gameObject.SetActive(false);
        } else {
            particles.gameObject.SetActive(true);
            q.SetLookRotation(diff);
        }
        transform.rotation = q;
        lastPosition = transform.position;
	}

}
