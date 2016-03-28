using UnityEngine;
using System.Collections;

// Assumes a square camera pointed at 0,0
public class WrapToCamera : MonoBehaviour {

	public Camera camera;
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		bool wrapped = false;
		if (pos.x < -camera.orthographicSize) {
			pos.x += camera.orthographicSize * 2;
			wrapped = true;
		} else 		if (pos.x > camera.orthographicSize) {
			pos.x -= camera.orthographicSize * 2;
			wrapped = true;
		}
		if (pos.y < -camera.orthographicSize) {
			pos.y += camera.orthographicSize * 2;
			wrapped = true;
		} else if (pos.y > camera.orthographicSize) {
			pos.y -= camera.orthographicSize * 2;
			wrapped = true;
		}
		if (wrapped) {
			transform.position = pos;
		}
	}
}
