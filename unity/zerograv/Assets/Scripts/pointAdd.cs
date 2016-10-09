using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class pointAdd : MonoBehaviour {

	public int playerpoints =0;
	public Canvas canvasobj;
	public Text pointtext;


	public void gainedPoint()
	{
		canvasobj.enabled = true;
		pointtext.text = playerpoints++.ToString();

	}

	IEnumerator disableCanvas()
	{
		yield return new WaitForSeconds(10);
		canvasobj.enabled = false;

	}

}
