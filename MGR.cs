using UnityEngine;
using System.Collections;

public class MGR : MonoBehaviour
{
	public static int quests;
	public int setQuest;
	public string[] texts;
	public static string[] tempTexsts;
	public float scale;
	public static Vector3 tempScale;
	public GameObject[] blocks;
	public GameObject[] sounds;
	public GameObject[] effects;
	float Counter;
	int current_no = 0;
	int block_no;
	int STATE = 0;
	int WAIT = 0;
	int START = 1;
	int PLAYING = 2;
	int Effect = 0;
	int Sound = 1;

	public GameObject wrong_answer;
	public GameObject right_answer;

	// Use this for initialization
	void Start ()
	{ 
		quests = setQuest;
		tempTexsts = texts;
		tempScale = new Vector3 (scale, scale, scale);
		block_no = 0;
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (STATE == PLAYING) {
			Counter += Time.deltaTime / 2;

			float Counter2;

			Counter2 = ((int)Counter) / 1000;

			GetComponent<UILabel> ().text = Counter + "";

			blocks [current_no].BroadcastMessage ("setHeight", Counter - current_no);

			if (current_no != (int)Counter) {

				Debug.Log (blocks [current_no].GetComponent<DropZone> ().droppedId);
				Debug.Log (current_no);
				current_no = (int)Counter;
			}
		}
	}

	public void play ()
	{
		STATE = PLAYING;
	}

	public void Ins (int what, int index, Vector3 position)
	{

		if (what == Effect)
			Instantiate (effects [index], position, Quaternion.identity);
		if (what == 1)
			Instantiate (sounds [index], position, Quaternion.identity);
	}

	public void result (bool isRight)
	{
		if (isRight)
			right_answer.SetActive (true);
		else
			wrong_answer.SetActive (true);
	}
}
