using UnityEngine;
using System.Collections;

public class ControllerAudio : MonoBehaviour {

	public AudioSource aSource;
	//when trigger is pulled
	public AudioClip audioClipWings;
	//when swimming
	public AudioClip audioClipSwim;

	private SwimPaddle swimPaddleRef;


	public void Awake()
	{
		swimPaddleRef = GetComponent<SwimPaddle>();
		aSource = GetComponent<AudioSource>();
	}

	public void Update()

	{
		if(swimPaddleRef.isTriggered)
		{
			aSource.loop = false;
			aSource.PlayOneShot(audioClipWings);
		}

		if(swimPaddleRef.isSwimming)

		{
			aSource.PlayOneShot(audioClipSwim);
			aSource.loop = true;
		}

	}
}
