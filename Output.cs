using UnityEngine;
using System.Collections;

public class Output : MonoBehaviour
{
	public GameObject tempText;
	public GameObject endCut;
	public GameObject text1, text2;
	public GameObject passResult, passSet, mathResult;
	// Use this for initialization
	void Start ()
	{
		 
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void OnClick1 ()
	{
		if (tempText.GetComponent<UILabel> ().text == "") {
			StartCoroutine ("noText");
		} else {
			GetComponentInChildren<UILabel> ().text = tempText.GetComponent<UILabel> ().text + "야 안녕?";
			iTween.ShakeScale (this.gameObject, iTween.Hash ("x", 0.1f, "time", 2));
			StartCoroutine ("end"); 
			GetComponent<AudioSource> ().Play ();
		}
	}

	public void OnClick2 ()
	{
		string str1 = text1.GetComponent<UILabel> ().text;
		string str2 = text2.GetComponent<UILabel> ().text;
		string resultStr = "";

		for (int i = 0; i < str1.Length; i++) {
			if (str1 [i] == str2 [i])
				resultStr += str1 [i];
			else
				break;
		}
		if (resultStr == "")
			GetComponentInChildren<UILabel> ().text = "기본형이 같은 단어를 입력하세요.";
		else {
			GetComponentInChildren<UILabel> ().text = "기본형은 " + resultStr + "다입니다.";
			GetComponent<AudioSource> ().Play ();
			iTween.ShakeScale (this.gameObject, iTween.Hash ("x", 0.1f, "time", 2));
			StartCoroutine ("end");
		}
	}


	public void OnClick3 ()
	{
		if (passSet.GetComponent<UILabel> ().text == "비밀번호 입력") {
			
		} else {
			passResult.SetActive (true);

			StartCoroutine ("end"); 
			GetComponent<AudioSource> ().Play ();
		}
	}

	public void OnClick4 ()
	{
		GetComponent<AudioSource> ().Play ();
		mathResult.SetActive (true);	
		StartCoroutine ("end"); 
	}

	IEnumerator end ()
	{
		yield return new WaitForSeconds (3);
		endCut.SetActive (true);

	}

	IEnumerator noText ()
	{
		GetComponentInChildren<UILabel> ().text = "먼저 이름을 입력하세요.";
		yield return new WaitForSeconds (2);
		GetComponentInChildren<UILabel> ().text = "결과 출력하기";

	}
}
