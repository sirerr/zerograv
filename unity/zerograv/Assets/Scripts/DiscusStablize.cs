using UnityEngine;
using System.Collections;
using VRTK;

[RequireComponent(typeof(VRTK_InteractTouch)), RequireComponent(typeof(VRTK_ControllerEvents))]
public class DiscusStablize : MonoBehaviour {

    public float lift = 0;
    public float stableTime = 2.5f;

    private bool grabbed = false;

   // private Quaternion avgRot;
    private Vector3 upVector;
    private Vector3 angVelInit;
    private float timer = 0f;

    Rigidbody rigid;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
        GetComponent<VRTK_InteractableObject>().InteractableObjectUngrabbed += new InteractableObjectEventHandler(ungrabEvent);
        GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += new InteractableObjectEventHandler(grabEvent);

    }
	
    void grabEvent(object sender, InteractableObjectEventArgs e)
    {
        grabbed = true;
    }

    void ungrabEvent(object sender, InteractableObjectEventArgs e)
    {
        grabbed = false;
        //avgRot = transform.rotation;
        upVector = transform.up;
        angVelInit = rigid.angularVelocity;
        timer = 0f;
    }

	// Update is called once per frame
	void FixedUpdate () {
        
        if (!grabbed && timer <= stableTime)
        {
            //avgRot = Quaternion.Euler((avgRot.eulerAngles + transform.rotation.eulerAngles)*.5f);

            Quaternion newRot = Quaternion.LookRotation(transform.forward, upVector);

            Vector3 angVel = rigid.angularVelocity;
            angVel.x = Mathf.Lerp(angVelInit.x, 0, timer / stableTime);
            angVel.z = Mathf.Lerp(angVelInit.z, 0, timer / stableTime);

            transform.rotation = Quaternion.Lerp(transform.rotation, newRot, timer / stableTime);
            
            timer += Time.fixedDeltaTime;

            rigid.AddForce(transform.TransformDirection(Vector3.up) * lift * rigid.velocity.magnitude);
        }
	}
}
