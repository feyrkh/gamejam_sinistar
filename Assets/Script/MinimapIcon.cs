using UnityEngine;
using System.Collections;

public class MinimapIcon : MonoBehaviour {
	public Transform minimapIcon;
	private Transform myIcon;

	// Use this for initialization
	void Start () {
		myIcon = GameObject.Instantiate (minimapIcon);
		//newIcon.transform.parent = gameObject.transform;
		StartCoroutine(UpdatePosition());
	}

	IEnumerator UpdatePosition() {
		while(true) {
			myIcon.transform.position = gameObject.transform.position;
			myIcon.transform.rotation = Quaternion.identity;
			yield return new WaitForSeconds(1f);
		}
	}
}
