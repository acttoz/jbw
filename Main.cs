using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
	public GameObject spinner;

	public void loadScene (int level)
	{
		StartCoroutine (loadAsync (level));
	}

	private IEnumerator loadAsync (int level)
	{
		
//		AsyncOperation operation = Application.LoadLevelAdditiveAsync (level);
		AsyncOperation operation = SceneManager.LoadSceneAsync (level);
		spinner.SetActive (true);
		while (!operation.isDone) {
			yield return operation.isDone;
			Debug.Log ("loading progress: " + operation.progress);
		}
		Debug.Log ("load done");


	}


	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
