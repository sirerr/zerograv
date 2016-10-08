using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class BallThrow : MonoBehaviour {

	public Rigidbody attachPoint;

	SteamVR_TrackedObject trackedObj;
	FixedJoint joint;

	SteamVR_Controller.Device device;

	// Use this for initialization
	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (joint != null && device.GetTouchUp (SteamVR_Controller.ButtonMask.Trigger)) {
			device = SteamVR_Controller.Input((int)trackedObj.index);

			GameObject go = joint.gameObject;
			Rigidbody rigidbody = go.GetComponent<Rigidbody>();
			Object.DestroyImmediate(joint);
			joint = null;

			rigidbody.velocity = device.velocity;
			rigidbody.angularVelocity = device.angularVelocity;
		}
	}

	void onCollisionEnter(Collision collision) {
		device = SteamVR_Controller.Input((int)trackedObj.index);

		if (collision.gameObject.tag == "Ball" && device.GetTouch(SteamVR_Controller.ButtonMask.Trigger)) {
			collision.transform.position = attachPoint.transform.position;

			joint = collision.gameObject.AddComponent<FixedJoint> ();
			joint.connectedBody = attachPoint;
		}
	}
}
