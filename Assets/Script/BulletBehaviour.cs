using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

	[HideInInspector]
	public float speed;


	void Update () 
	{
		GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2(speed, 0));
		if (GetComponent<Renderer>().isVisible == false)
			Destroy (gameObject);
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.GetComponent<BulletBehaviour> () != null) {
			return;
		}

		Destroy (gameObject);
	}
}
