using UnityEngine;
using System.Collections;

public class MGR : MonoBehaviour
{
	public static int quests;
	public GameObject robot;
	public GameObject success_cut;
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

	public GameObject Panel_select;
	public GameObject Panel_quest1;
	public GameObject Panel_quest2;
	public GameObject Panel_algori1;
	public GameObject Panel_algori2;

	public GameObject wrong_answer;
	public GameObject right_answer;

	// Use this for initialization
	void Start ()
	{ 
		quests = setQuest;
		tempTexsts = texts;
		tempScale = new Vector3 (scale, scale, scale);
		block_no = 0;
		controlPanel (1);
	
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
		if (isRight) {
			robot.GetComponent<Animation> ().Play ();
			success_cut.SetActive (true);
		} else
			wrong_answer.SetActive (true);
	}


	public void afterRobot ()
	{
		right_answer.SetActive (true);
	}

	public void controlPanel (int no)
	{
		Panel_select.SetActive (false);
		Panel_quest1.SetActive (false);
		Panel_quest2.SetActive (false);
		Panel_algori1.SetActive (false);
		Panel_algori2.SetActive (false);

		switch (no) {
		case 1:
			Panel_select.SetActive (true);
			break;
		case 2:
			Panel_quest1.SetActive (true);
			break;
		case 3:
			Panel_quest2.SetActive (true);
			break;
		case 4:
			Panel_algori1.SetActive (true);
			break;
		case 5:
			Panel_algori2.SetActive (true);
			break;

		}

	}
}
