using UnityEngine;
using System.Collections;

public class FireAudio : MonoBehaviour
{
	void Update ()
	{
		GetComponent<AudioSource>().volume = GetComponent<ParticleSystem>().startColor.a * 2f;
	}
}
