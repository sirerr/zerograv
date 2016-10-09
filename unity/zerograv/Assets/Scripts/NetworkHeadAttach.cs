using UnityEngine;
using System.Collections;
using UnityEngine.VR;
using UnityEngine.Networking;

public class NetworkHeadAttach : NetworkBehaviour {

	bool followVr = false;

	private Transform playArea;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (followVr && playArea != null) {
			transform.position = InputTracking.GetLocalPosition (VRNode.Head);
			transform.rotation = InputTracking.GetLocalRotation (VRNode.Head);
		}
	}

	public override void OnStartLocalPlayer() {
		followVr = true;
		playArea = GameObject.Find ("[CameraRig]").transform;
		transform.parent = playArea;
	}
}
