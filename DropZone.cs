using UnityEngine;
using System.Collections;

public class DropZone : MonoBehaviour
{
	public  string droppedId;
	string thisId;
	public GameObject droppedItemPrefab;

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
			MGR.quests--;
			if (MGR.quests == 0)
				mMGR.GetComponent<MGR> ().result (true);

			droppedId = dropped.transform.name;

			GameObject newPower = NGUITools.AddChild (this.gameObject,
				                      droppedItemPrefab);

			newPower.transform.name = droppedId;
			newPower.GetComponent<BoxCollider> ().enabled = false;
			newPower.GetComponent<UISprite> ().color = color1;
			//MGR.GetComponent<MGR> ().Ins (Sound, 0, new Vector3 (0, 0, 0));
			mMGR.GetComponent<MGR> ().Ins (Effect, 0, newPower.transform.position);
			Destroy (dropped);
		} else {
			mMGR.GetComponent<MGR> ().result (false);
			
			iTween.PunchPosition (dropped, new Vector3 (0.2f, 0.2f, 0), 1f);

		}


		// 드롭된 게임오브젝트는 삭제한다.

	}
}
