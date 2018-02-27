using UnityEngine;

public class GeneralStats : MonoBehaviour {
	public string Name;
	public int Health;

	// front, back, left, right
	public string Direction = "front";

	public float EyeHeight = 0f;
	public float FeetHeight = 0f;
	public float LeftEye = 0f;
	public float RightEye = 0f;
	
	public bool Shooting = false;
	
	public float MaxSpeed = 10f;

	public bool CanShoot = true;
	public bool CanMove = true;
	public bool CanRotate = true;
	
	public float ShootSpeed = 5f;
	public int ShootInterval = 30;

	public float TearHeightDifference = 0.04f;
}
