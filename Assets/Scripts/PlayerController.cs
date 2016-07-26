using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Vector2 target;
	float speed = 2;
	bool moveFlag = true;

	void Start () {
		target = transform.position;
	}

	void Update () {
		Debug.Log (moveFlag);

		if ((Vector2) transform.position != target) {
			moveFlag = false;
			transform.position = Vector2.MoveTowards (transform.position, target, speed * Time.deltaTime);
		}
		else moveFlag = true;
	}

	public void Move (Vector2 targetPosition_player, float moveSpeed_player) {
		if (moveFlag) {
			target = targetPosition_player;
			speed = moveSpeed_player;
		}
	}
}
