using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	private Rigidbody2D body;

	public float thrustPower = 550;
	public float rotateDegreePerSec = 90;
	public Transform bulletPrefab;

	public KeyCode thrustButton = KeyCode.W;
	public KeyCode rotateClockwise = KeyCode.D;
	public KeyCode rotateCounterClockwise = KeyCode.A;
	public KeyCode fire = KeyCode.Space;
	public float secondsBetweenBullets = 0.3f;
	public float bulletSpeed = 1;
	private float secondsSinceBullet = 0;
	private HSBColor bulletColor = HSBColor.FromColor(Color.red);
	private float colorAngleIncrement = 5f / 360;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		int rotationDir = 0;
		if (Input.GetKey (rotateClockwise)) {
			rotationDir--;
		}
		if (Input.GetKey (rotateCounterClockwise)) {
			rotationDir++;
		}
		if(Input.GetKey(thrustButton)) {
			body.AddRelativeForce(new Vector2 (thrustPower, 0));
		}

		if (rotationDir != 0) {
			float rotateDeg = rotationDir * rotateDegreePerSec * Time.deltaTime;
			body.transform.Rotate (new Vector3 (0, 0, rotateDeg));
		}

		if(Input.GetKey(fire) && secondsBetweenBullets <= secondsSinceBullet){
			Shoot();
			}

		secondsSinceBullet += Time.deltaTime;
	}

	void Shoot()
	{
		Transform shot = Instantiate (bulletPrefab,transform.position,transform.rotation) as Transform;
		shot.GetComponent<bulletBehaviour>().speed = bulletSpeed;
		SpriteRenderer shotSprite = shot.GetComponent<SpriteRenderer> ();
		shotSprite.color = bulletColor.ToColor ();
		secondsSinceBullet = 0f;
		bulletColor.h = (bulletColor.h + colorAngleIncrement) % 1;
	}
}