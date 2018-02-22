using UnityEngine;

public class PlayerShoot : MonoBehaviour {
	public Rigidbody2D Tear;
	public float ShootSpeed = 5f;

	public int ShootInterval = 30;

	private GeneralStats _stats;

	private void Awake() {
		_stats = GetComponent<GeneralStats>();
	}

	private void Update () {
		if (ShootInterval == 0) {
			_stats.Shooting = false;
			if (Input.GetKey(KeyCode.UpArrow)) {
				_stats.Shooting = true;
				_stats.Direction = "back";
				
				var tearClone = Instantiate(Tear, transform.position, transform.rotation);
				tearClone.velocity = transform.up * ShootSpeed;
				ResetInterval();
			}
			else if (Input.GetKey(KeyCode.RightArrow)) {
				_stats.Shooting = true;
				_stats.Direction = "right";
                				
				var tearClone = Instantiate(Tear, transform.position, transform.rotation);
				tearClone.velocity = transform.right * ShootSpeed;
				ResetInterval();
			}
			else if (Input.GetKey(KeyCode.DownArrow)) {
				_stats.Shooting = true;
				_stats.Direction = "front";
				
				var tearClone = Instantiate(Tear, transform.position, transform.rotation);
				tearClone.velocity = -transform.up * ShootSpeed;
				ResetInterval();
			}
			else if (Input.GetKey(KeyCode.LeftArrow)) {
				_stats.Shooting = true;
				_stats.Direction = "left";
				
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
