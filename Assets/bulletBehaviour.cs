using UnityEngine;
using System.Collections;

public class bulletBehaviour : MonoBehaviour {

	[HideInInspector]
	public float speed;

	void Update () 
	{
		transform.Translate (speed, 0, 0);

		if (GetComponent<Renderer>().isVisible == false)
			Destroy (gameObject);
	}
}
