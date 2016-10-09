using UnityEngine;
using System.Collections;
using VRTK;

[RequireComponent(typeof(VRTK_InteractTouch)), RequireComponent(typeof(VRTK_ControllerEvents))]
public class DiscSpawner : MonoBehaviour {

    bool grabbed = false;
    [SerializeField]
    GameObject pubDisc;

    GameObject disc;

    // Use this for initialization
    void Start () {
        InstatiateDisc();
    }

    void grabEvent(object sender, InteractableObjectEventArgs e)
    {
        grabbed = true;
    }

    void ungrabEvent(object sender, InteractableObjectEventArgs e)
    {
        grabbed = false;
        StartCoroutine(KillDisc(disc));

        InstatiateDisc();
    }

    void InstatiateDisc()
    {
        disc = Instantiate(pubDisc, transform.position, Quaternion.identity) as GameObject;

        disc.GetComponent<VRTK_InteractableObject>().InteractableObjectUngrabbed += new InteractableObjectEventHandler(ungrabEvent);
        disc.GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += new InteractableObjectEventHandler(grabEvent);
    }

    private IEnumerator KillDisc(GameObject _disc)
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            Destroy(_disc);
        }
    }

    // Update is called once per frame
    void Update () {
	
	}

}
