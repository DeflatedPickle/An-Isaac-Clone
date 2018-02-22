using UnityEngine;

public class PlayerMove : MonoBehaviour {
	[Range(1, 30)]
	public float MoveForce = 18f;
	[Range(1, 20)]
	public float MaxSpeed = 10f;

	private Rigidbody2D _rigidbody2D;

	private GeneralStats _stats;

	private void Awake() {
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_stats = GetComponent<GeneralStats>();
	}

	private void Update () {
		var horizontal = Input.GetAxis("Horizontal");

		if (horizontal * _rigidbody2D.velocity.x < MaxSpeed) {
			_rigidbody2D.AddForce(Vector2.right * horizontal * MoveForce);
		}

		if (Mathf.Abs(_rigidbody2D.velocity.x) > MaxSpeed) {
			_rigidbody2D.velocity = new Vector2(Mathf.Sign(_rigidbody2D.velocity.x) * MaxSpeed, _rigidbody2D.velocity.y);
		}

		var vertical = Input.GetAxis("Vertical");

		if (vertical * _rigidbody2D.velocity.y < MaxSpeed) {
			_rigidbody2D.AddForce(Vector2.up * vertical * MoveForce);
		}

		if (Mathf.Abs(_rigidbody2D.velocity.y) > MaxSpeed) {
			_rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, Mathf.Sign(_rigidbody2D.velocity.y) * MaxSpeed);
		}

		if (!_stats.Shooting) {
			if (horizontal > 0) {
				_stats.Direction = "right";
			}
			else if (horizontal < 0) {
				_stats.Direction = "left";
			}
			else {
				_stats.Direction = "front";
			}

			if (vertical > 0) {
				_stats.Direction = "back";
			}
			else if (vertical < 0) {
				_stats.Direction = "front";
			}
		}
	}
}
