using UnityEngine;
using System.Collections;

public class ZeeGeeSign : MonoBehaviour {

    public float waitTime = 7f;

    private MeshRenderer title;
    private MeshRenderer background;

	// Use this for initialization
	void Start () {
        MeshRenderer[] renders = GetComponentsInChildren<MeshRenderer>();
        title = renders[0];
        background = renders[1];

        StartCoroutine(Fade());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Fade()
    {
        print("Before");

        yield return new WaitForSeconds(waitTime);

        print("After");

        for (float f = 1f; f >= -0.05; f -= 0.05f)
        {
            Color c = title.material.color;
            c.a = f;
            title.material.color = c;

            background.material.SetFloat("_Cutoff", 1 - f / 2);

            yield return new WaitForSeconds(0.1f);
        }

        gameObject.SetActive(false);
    }
}
