using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

    public Animator avatarAnim;

    public void JumpTrigger() {
        avatarAnim.SetTrigger("JumpTrigger");
    }

    public void LandTrigger()
    {
        avatarAnim.SetTrigger("LandTrigger");
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
