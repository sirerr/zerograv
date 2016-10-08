using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class SwimPaddle : MonoBehaviour {

    public float forceMult = 1;
    public float torqueMult = 1;

    public Transform centerOfMass;
    public Transform playArea;

    SteamVR_Controller.Device device;
    SteamVR_TrackedObject trackedObj;

    private Vector3 controllerForce;
    private Vector3 controllerDistance;
    private Vector3 controllerTorque;

    private Vector3 lastControllerPosition;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
    }

    void FixedUpdate()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);

        //print("Grip: " + device.GetTouch(SteamVR_Controller.ButtonMask.Grip));

        if(device == null)
        {
            Debug.Log("Device not found");
        }

        //if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        //{

            float triggerVal = Mathf.Pow(device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x, 2f);

            //controllerForce = GetComponent<Rigidbody>().velocity * -forceMult;
            controllerForce = (transform.position - lastControllerPosition) / Time.fixedDeltaTime * -forceMult * triggerVal;
            controllerDistance = transform.position - centerOfMass.position;
            controllerTorque = Vector3.Cross(controllerDistance, controllerForce/forceMult * torqueMult);


            playArea.GetComponent<Rigidbody>().AddForce(controllerForce);
            playArea.GetComponent<Rigidbody>().AddTorque(controllerTorque);

            
        //}

        lastControllerPosition = transform.position;

    }
}
