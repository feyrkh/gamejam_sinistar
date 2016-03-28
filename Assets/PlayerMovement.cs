using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	private Rigidbody2D body;

	public float thrustPower = 550;
	public float rotateDegreePerSec = 90;
	public Transform bulletPrefab;
	private Transform transform;

	private int upDownFacing = 1;
	private int leftRightFacing = 0;

	public KeyCode upButton = KeyCode.W;
	public KeyCode downButton = KeyCode.S;
	public KeyCode rightButton = KeyCode.D;
	public KeyCode leftButton = KeyCode.A;
	public KeyCode fire = KeyCode.Space;
	public float secondsBetweenBullets = 0.3f;
	public float bulletSpeed = 1;
	private float secondsSinceBullet = 0;
	private HSBColor bulletColor = HSBColor.FromColor(Color.red);
	private float colorAngleIncrement = 5f / 360;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		transform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		int upDown = 0;
		int leftRight = 0;
		if (Input.GetKey (leftButton)) {
			leftRight--;
		}
		if (Input.GetKey (rightButton)) {
			leftRight++;
		}
		if (Input.GetKey (downButton))
			upDown--;
		if (Input.GetKey (upButton))
			upDown++;

		if (upDown != 0 && leftRight != 0) {
			leftRightFacing = leftRight;
			upDownFacing = upDown;
		} else if (upDown != 0) {
			leftRightFacing = 0;
			upDownFacing = upDown;
		} else if (leftRight != 0) {
			leftRightFacing = leftRight;
			upDownFacing = 0;
		}


		if (leftRightFacing == 0) {
			if (upDownFacing == -1) {
				body.rotation = 180;
			} else {
				body.rotation = 0;
			}
		} else if (leftRightFacing == 1) {
			if (upDownFacing == -1) {
				body.rotation = 225;
			} else if (upDownFacing == 0) {
				body.rotation =  270;
			} else {
				body.rotation = 315;
			}
		} else {
			if (upDownFacing == -1) {
				body.rotation = 135;
			} else if (upDownFacing == 0) {
				body.rotation = 90;
			} else {
				body.rotation = 45;
			}
		}
				

		body.AddForce(new Vector2 (leftRight*thrustPower, upDown*thrustPower));


		if(Input.GetKey(fire) && secondsBetweenBullets <= secondsSinceBullet) {
			Shoot();
		}

		secondsSinceBullet += Time.deltaTime;
	}

	void Shoot()
	{
		Transform shot = Instantiate (bulletPrefab,transform.position + new Vector3(leftRightFacing*30, upDownFacing*30, 0) + new Vector3(Random.value*10-5, Random.value*10-5, 0),transform.rotation) as Transform;
		shot.Rotate (new Vector3 (0, 0, 90));
		shot.GetComponent<Rigidbody2D>().velocity = new Vector2(leftRightFacing*bulletSpeed, upDownFacing*bulletSpeed);
		SpriteRenderer shotSprite = shot.GetComponent<SpriteRenderer> ();
		shotSprite.color = bulletColor.ToColor ();
		secondsSinceBullet = 0f;
		bulletColor.h = (bulletColor.h + colorAngleIncrement) % 1;
	}
}