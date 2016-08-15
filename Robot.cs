using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour
{
	public GameObject MGR;
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
		MGR.GetComponent<MGR> ().afterRobot ();
	}
}
