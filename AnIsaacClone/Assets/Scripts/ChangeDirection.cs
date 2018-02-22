using UnityEngine;

public class ChangeDirection : MonoBehaviour {
	private void Update () {
		var spriteName = GetComponent<GeneralStats>().Name.ToLower();
		var direction = GetComponent<GeneralStats>().Direction;

		var sprite = Resources.Load<Sprite>(string.Format("Sprites/Player/{0}_{1}", spriteName, direction));
		GetComponent<SpriteRenderer>().sprite = sprite;
		
		Debug.Log(direction);
	}
}
