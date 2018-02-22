using UnityEngine;

public class DestroyTear : MonoBehaviour {
	private Vector3 _playerPosition;

	private void Start() {
		_playerPosition = GameObject.Find("Player").GetComponent<Transform>().position;
	}

	private void Update () {
		var distance = Vector3.Distance(_playerPosition, transform.position);

		if (distance >= 8) {
			Destroy(gameObject);
		}
	}
}
