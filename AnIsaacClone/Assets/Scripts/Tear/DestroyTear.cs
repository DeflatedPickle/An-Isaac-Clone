using UnityEngine;

public class DestroyTear : MonoBehaviour {
	public Transform Shooter;

	private GeneralStats _stats;
	private Vector3 _shooterPosition;

	private void Start() {
		_shooterPosition = Shooter.GetComponent<Transform>().position;
		_stats = Shooter.GetComponent<GeneralStats>();
	}

	private void Update () {
		var distance = Vector3.Distance(_shooterPosition, transform.position);

		if (distance >= _stats.TearDistance) {
			Destroy(gameObject);
		}
	}
}
