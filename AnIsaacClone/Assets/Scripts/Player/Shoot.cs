using UnityEngine;

public class Shoot : MonoBehaviour {
	public Rigidbody2D Tear;
	public float ShootSpeed = 5f;

	public int ShootInterval = 30;

	private void Update () {
		if (ShootInterval == 0) {
			if (Input.GetKey(KeyCode.UpArrow)) {
				Rigidbody2D tearClone = Instantiate(Tear, transform.position, transform.rotation);
				tearClone.velocity = transform.up * (ShootSpeed / 2);
				ResetInterval();
			}
			else if (Input.GetKey(KeyCode.RightArrow)) {
				Rigidbody2D tearClone = Instantiate(Tear, transform.position, transform.rotation);
				tearClone.velocity = transform.right * ShootSpeed;
				ResetInterval();
			}
			else if (Input.GetKey(KeyCode.DownArrow)) {
				Rigidbody2D tearClone = Instantiate(Tear, transform.position, transform.rotation);
				tearClone.velocity = -transform.up * (ShootSpeed / 2);
				ResetInterval();
			}
			else if (Input.GetKey(KeyCode.LeftArrow)) {
				Rigidbody2D tearClone = Instantiate(Tear, transform.position, transform.rotation);
				tearClone.velocity = -transform.right * ShootSpeed;
				ResetInterval();
			}
		}
		
		if (ShootInterval > 0)
			ShootInterval -= 1;
	}

	private void ResetInterval() {
		ShootInterval = 30;
	}
}
