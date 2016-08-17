using UnityEngine;
using System.Collections;

public class text : MonoBehaviour
{
	public GameObject parent;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		GetComponent<UILabel> ().text = parent.GetComponent<UILabel> ().text;		
	
	}
}
