using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class pointAdd : MonoBehaviour {

	public int playerpoints =0;

	public Text pointtext;


	public void gainedPoint()
	{

		pointtext.text = playerpoints++.ToString();
	}

}
