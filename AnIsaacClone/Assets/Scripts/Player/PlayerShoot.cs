using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerShoot : MonoBehaviour {
	public Rigidbody2D Tear;
	
	private int _shootCounter = 30;
	private bool _currentEye = false;

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
				_stats.Shooting = true;
				_stats.Direction = "back";
				
				var tearClone = Instantiate(Tear, playerPositionVertical, transform.rotation);
				tearClone.velocity = transform.up * _stats.ShootSpeed;
				tearClone.position = new Vector3(tearClone.transform.position.x, tearClone.transform.position.y, 1);
				ResetInterval();
			}
			else if (Input.GetKey(KeyCode.RightArrow)) {
				_stats.Shooting = true;
				_stats.Direction = "right";
                				
				var tearClone = Instantiate(Tear, playerPositionHorizontal, transform.rotation);
				tearClone.velocity = transform.right * _stats.ShootSpeed;
				tearClone.position = new Vector3(tearClone.transform.position.x, tearClone.transform.position.y, Random.Range(0, 1));
				ResetInterval();
			}
			else if (Input.GetKey(KeyCode.DownArrow)) {
				_stats.Shooting = true;
				_stats.Direction = "front";
				
				var tearClone = Instantiate(Tear, playerPositionVertical, transform.rotation);
				tearClone.velocity = -transform.up * _stats.ShootSpeed;
				tearClone.position = new Vector3(tearClone.transform.position.x, tearClone.transform.position.y, 0);
				ResetInterval();
			}
			else if (Input.GetKey(KeyCode.LeftArrow)) {
				_stats.Shooting = true;
				_stats.Direction = "left";
				
				var tearClone = Instantiate(Tear, playerPositionHorizontal, transform.rotation);
				tearClone.velocity = -transform.right * _stats.ShootSpeed;
				tearClone.position = new Vector3(tearClone.transform.position.x, tearClone.transform.position.y, Random.Range(0, 1));
				ResetInterval();
			}
			_currentEye = !_currentEye;
		}
		
		if (_shootCounter > 0)
			_shootCounter -= 1;
	}

	private void ResetInterval() {
		_shootCounter = _stats.ShootInterval;
	}
}
