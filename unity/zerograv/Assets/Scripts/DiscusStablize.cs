using UnityEngine;
using System.Collections;
using VRTK;

[RequireComponent(typeof(VRTK_InteractTouch)), RequireComponent(typeof(VRTK_ControllerEvents))]
public class DiscusStablize : MonoBehaviour {

    public float lift = 0;

    private bool grabbed = false;
    private Vector3 angVelInit;

    Rigidbody rigid;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
        GetComponent<VRTK_InteractableObject>().InteractableObjectUngrabbed += new InteractableObjectEventHandler(ungrabEvent);
        GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += new InteractableObjectEventHandler(grabEvent);
    }
	
    void grabEvent(object sender, InteractableObjectEventArgs e) {
        grabbed = true;
    }

    void ungrabEvent(object sender, InteractableObjectEventArgs e) {
        grabbed = false;
        angVelInit = rigid.angularVelocity;
        Vector3 angVelLocal = transform.InverseTransformDirection(angVelInit);
        angVelLocal.x = 0;
        angVelLocal.z = 0;
        rigid.angularVelocity = transform.TransformDirection(angVelLocal);
    }

	// Update is called once per frame
	void FixedUpdate () {
        if (!grabbed) {
            rigid.AddForce(transform.TransformDirection(Vector3.up) * lift * rigid.velocity.magnitude);
        }
	}
}
