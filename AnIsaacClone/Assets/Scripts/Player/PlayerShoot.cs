using UnityEngine;

public class PlayerShoot : MonoBehaviour {
	public Rigidbody2D Tear;
	public float ShootSpeed = 5f;

	public int ShootInterval = 30;

	private void Update () {
		if (ShootInterval == 0) {
			if (Input.GetKey(KeyCode.UpArrow)) {
				var tearClone = Instantiate(Tear, transform.position, transform.rotation);
				tearClone.velocity = transform.up * ShootSpeed;
				ResetInterval();
			}
			else if (Input.GetKey(KeyCode.RightArrow)) {
				var tearClone = Instantiate(Tear, transform.position, transform.rotation);
				tearClone.velocity = transform.right * ShootSpeed;
				ResetInterval();
			}
			else if (Input.GetKey(KeyCode.DownArrow)) {
				var tearClone = Instantiate(Tear, transform.position, transform.rotation);
				tearClone.velocity = -transform.up * ShootSpeed;
				ResetInterval();
			}
			else if (Input.GetKey(KeyCode.LeftArrow)) {
				var tearClone = Instantiate(Tear, transform.position, transform.rotation);
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
