using UnityEngine;
using System.Collections;

public class DropZone : MonoBehaviour
{
	public  string droppedId;
	string thisId;
	public GameObject robot;
	public GameObject successCut;
	public GameObject droppedItemPrefab;
	public GameObject bars;
	public Color color1;
	GameObject mMGR;
	int Effect = 0;
	int Sound = 1;

	void Start ()
	{
		mMGR = GameObject.Find ("MGR");
		string str = this.transform.name;
		string[] result = str.Split ('_');
		thisId = result [1];
	}

	public void OnDrop (GameObject dropped)
	{
		if (dropped.transform.tag != "block")
			return;

		if (thisId == dropped.transform.name) {
			bars.GetComponent<Bar_set> ().blockNum--;
			if (bars.GetComponent<Bar_set> ().blockNum == 0) {
				mMGR.GetComponent<MGR> ().result (true);
				successCut.SetActive (true);
				robot.GetComponent<Animation> ().Play ();
			}

			droppedId = dropped.transform.name;

			//GameObject newPower = NGUITools.AddChild (this.gameObject,
			//	                      droppedItemPrefab);

			dropped.GetComponent<BoxCollider> ().enabled = false;
			dropped.GetComponent<UISprite> ().color = color1;

			//MGR.GetComponent<MGR> ().Ins (Sound, 0, new Vector3 (0, 0, 0));
			dropped.transform.position = this.transform.position;
			dropped.transform.localScale = this.transform.localScale;

			mMGR.GetComponent<MGR> ().Ins (Effect, 0, this.transform.position);
		} else {
			iTween.PunchPosition (dropped, new Vector3 (0.2f, 0.2f, 0), 1f);
		}
		// 드롭된 게임오브젝트는 삭제한다.
	}
}
