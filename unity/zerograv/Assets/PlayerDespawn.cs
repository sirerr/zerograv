using UnityEngine;
using System.Collections;

public class PlayerDespawn : MonoBehaviour {

    public Collider player;

    private Collider exiter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit(Collider collider)
    {
        if (collider == player)
        {
            exiter = collider;
            StartCoroutine(Fade());
        }
    }

    IEnumerator Fade()
    {
        SteamVR_Fade.Start(Color.black, 1);
        yield return new WaitForSeconds(1);

        exiter.transform.position = transform.position;

        SteamVR_Fade.Start(Color.clear, 1);

    }
}
