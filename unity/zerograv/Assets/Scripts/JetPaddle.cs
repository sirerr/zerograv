using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class JetPaddle : MonoBehaviour
{

    public float forceMult = 1;

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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);

        //print("Grip: " + device.GetTouch(SteamVR_Controller.ButtonMask.Grip));

        if (device == null)
        {
            Debug.Log("Device not found");
        }

        if (device.GetPress(SteamVR_Controller.ButtonMask.Grip))
        {
            // print("Hello");





            //controllerForce = GetComponent<Rigidbody>().velocity * -forceMult;
            controllerForce = (transform.position - lastControllerPosition) / Time.fixedDeltaTime * -forceMult;
            controllerDistance = centerOfMass.position - transform.position;
            controllerTorque = Vector3.Cross(controllerDistance, controllerForce);


            playArea.GetComponent<Rigidbody>().AddForce(transform.rotation*Vector3.forward * -forceMult);
            // playArea.GetComponent<Rigidbody>().AddTorque(controllerTorque);

        }

        lastControllerPosition = transform.position;

    }
}
