using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerShoot : MonoBehaviour {
	public Rigidbody Tear;
	
	private int _shootCounter = 30;
	private bool _currentEye = false;
	private readonly List<float> _tearZ = new List<float>{0.05f, -0.05f};

	private GeneralStats _stats;

	private void Awake() {
		_stats = GetComponent<GeneralStats>();
	}

	private void Update () {
		var verticalPlaces = new List<float>{_stats.LeftEye, _stats.RightEye};
		
		var playerPositionHorizontal = new Vector3(transform.position.x, transform.position.y + _stats.EyeHeight + Random.Range(-_stats.TearHeightDifference, _stats.TearHeightDifference), transform.position.z);
		var playerPositionVertical = new Vector3(transform.position.x + verticalPlaces[Convert.ToInt32(_currentEye)], transform.position.y + _stats.EyeHeight, transform.position.z);
		
		if (_shootCounter == 0 && _stats.CanShoot) {
			_stats.Shooting = false;
			
			if (Input.GetKey(KeyCode.UpArrow)) {
				ShootTear(transform.up, "back", playerPositionVertical);
			}
			else if (Input.GetKey(KeyCode.RightArrow)) {
				ShootTear(transform.right, "right", playerPositionHorizontal);
			}
			else if (Input.GetKey(KeyCode.DownArrow)) {
				ShootTear(-transform.up, "front", playerPositionVertical);
			}
			else if (Input.GetKey(KeyCode.LeftArrow)) {
				ShootTear(-transform.right, "left", playerPositionHorizontal);
			}
			
			_currentEye = !_currentEye;
		}
		
		if (_shootCounter > 0)
			_shootCounter -= 1;
	}

	private void ResetInterval() {
		_shootCounter = _stats.ShootInterval;
	}

	private void ShootTear(Vector3 direction, string directionString, Vector3 playerPosition) {
		_stats.Shooting = true;
		_stats.Direction = directionString;
				
		var tearClone = Instantiate(Tear, playerPosition, transform.rotation);
		tearClone.GetComponent<DestroyTear>().Shooter = transform;
		tearClone.velocity = direction * _stats.ShootSpeed;

		if (direction == -transform.right || direction == transform.right) {
			tearClone.position = new Vector3(tearClone.transform.position.x, tearClone.transform.position.y, _tearZ[Convert.ToInt32(_currentEye)]);
		}
		else if (direction == transform.up) {
			tearClone.position = new Vector3(tearClone.transform.position.x, tearClone.transform.position.y, _tearZ[0]);
		}
		else if (direction == -transform.up) {
			tearClone.position = new Vector3(tearClone.transform.position.x, tearClone.transform.position.y, _tearZ[1]);
		}
		
		ResetInterval();
	}
}
