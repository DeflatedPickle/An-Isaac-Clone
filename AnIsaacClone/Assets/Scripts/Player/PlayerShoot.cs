using UnityEngine;

public class PlayerShoot : MonoBehaviour {
	public Rigidbody2D Tear;
	
	private int _shootCounter = 30;

	private GeneralStats _stats;

	private void Awake() {
		_stats = GetComponent<GeneralStats>();
	}

	private void Update () {
		var playerPosition = new Vector3(transform.position.x, transform.position.y + _stats.EyeHeight, transform.position.z);
		
		if (_shootCounter == 0 && _stats.CanShoot) {
			_stats.Shooting = false;
			if (Input.GetKey(KeyCode.UpArrow)) {
				_stats.Shooting = true;
				_stats.Direction = "back";
				
				var tearClone = Instantiate(Tear, playerPosition, transform.rotation);
				tearClone.velocity = transform.up * _stats.ShootSpeed;
				ResetInterval();
			}
			else if (Input.GetKey(KeyCode.RightArrow)) {
				_stats.Shooting = true;
				_stats.Direction = "right";
                				
				var tearClone = Instantiate(Tear, playerPosition, transform.rotation);
				tearClone.velocity = transform.right * _stats.ShootSpeed;
				ResetInterval();
			}
			else if (Input.GetKey(KeyCode.DownArrow)) {
				_stats.Shooting = true;
				_stats.Direction = "front";
				
				var tearClone = Instantiate(Tear, playerPosition, transform.rotation);
				tearClone.velocity = -transform.up * _stats.ShootSpeed;
				ResetInterval();
			}
			else if (Input.GetKey(KeyCode.LeftArrow)) {
				_stats.Shooting = true;
				_stats.Direction = "left";
				
				var tearClone = Instantiate(Tear, playerPosition, transform.rotation);
				tearClone.velocity = -transform.right * _stats.ShootSpeed;
				ResetInterval();
			}
		}
		
		if (_shootCounter > 0)
			_shootCounter -= 1;
	}

	private void ResetInterval() {
		_shootCounter = _stats.ShootInterval;
	}
}
