using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
	GameObject bars;
	// Use this for initialization
	void Start ()
	{
		bars = GameObject.Find ("bars");

		 
	}
	
	// Update is called once per frame
	void Update ()
	{
		GetComponentInChildren<UILabel> ().text = MGR.tempTexsts [int.Parse (transform.name)];
	
	}

	void OnPress (bool pressed)
	{
		transform.parent = bars.transform;
		transform.localScale = MGR.tempScale;
		// 아이템을 누르고 있는 동안은 충돌체를 비활성화한다.
		GetComponent<BoxCollider> ().enabled = !pressed;
	}


}
