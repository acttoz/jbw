using UnityEngine;
using System.Collections;

public class DropZone : MonoBehaviour
{
	public  string droppedId;
	public GameObject droppedItemPrefab;
	public GameObject wrong_answer;
	public Color color1;
	GameObject MGR;
	int Effect = 0;
	int Sound = 1;

	void Start ()
	{
		MGR = GameObject.Find ("MGR");
	}

	public void OnDrop (GameObject dropped)
	{
		if (dropped.transform.tag != "block")
			return;



		if (this.transform.name == dropped.transform.name) {
			droppedId = dropped.transform.name;

			GameObject newPower = NGUITools.AddChild (this.gameObject,
				                      droppedItemPrefab);

			newPower.transform.name = droppedId;
			newPower.GetComponent<BoxCollider> ().enabled = false;
			newPower.GetComponent<UISprite> ().color = color1;
			//MGR.GetComponent<MGR> ().Ins (Sound, 0, new Vector3 (0, 0, 0));
			MGR.GetComponent<MGR> ().Ins (Effect, 0, newPower.transform.position);
			Destroy (dropped);
		} else {
			wrong_answer.SetActive (true);
			iTween.PunchPosition (dropped, new Vector3 (0.2f, 0.2f, 0), 1f);

		}


		// 드롭된 게임오브젝트는 삭제한다.

	}
}
