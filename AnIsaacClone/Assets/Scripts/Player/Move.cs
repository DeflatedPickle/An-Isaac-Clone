using UnityEngine;

public class Move : MonoBehaviour {
	[Range(1, 30)]
	public float MoveForce = 18f;
	[Range(1, 20)]
	public float MaxSpeed = 10f;

	private Rigidbody2D _rigidbody2D;

	private void Awake() {
		_rigidbody2D = GetComponent<Rigidbody2D>();
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
	}
}
