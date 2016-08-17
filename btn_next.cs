using UnityEngine;
using System.Collections;

public class btn_next : MonoBehaviour
{
	public GameObject next;
	int flag = 0;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnClick ()
	{
		if (flag == 0) {
			GetComponentInChildren<UILabel> ().text = "이전";
			next.SetActive (true);
			flag = 1;
		} else {
			GetComponentInChildren<UILabel> ().text = "다음";
			next.SetActive (false);
			flag = 0;
		}

	}
}
