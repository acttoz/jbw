using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour
{
	public GameObject sound;
	public GameObject summary;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void afterClip ()
	{
		summary.SetActive (true);
		sound.GetComponent<AudioSource> ().Pause ();
	}
}
