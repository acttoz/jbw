using UnityEngine;
using System.Collections;

public class Line : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void setHeight (float height)
	{
		transform.localScale = new Vector3 (transform.localScale.x, height, transform.localScale.z);
	}
}
