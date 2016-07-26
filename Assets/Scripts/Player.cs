using UnityEngine;
using System.Collections;

[RequireComponent (typeof (PlayerController))]
public class Player : MonoBehaviour {

	public float moveSpeed = 4.0f;

	PlayerController controller;
	Camera viewCamera;

	void Start () {
		viewCamera = Camera.main;
		controller = GetComponent<PlayerController>();
	}

	void Update () {
		// move input
		if (Input.GetMouseButton(0)) {

			Vector2 targetPos = viewCamera.ScreenToWorldPoint(Input.mousePosition);
			Vector2 moveVelocity = targetPos.normalized * moveSpeed;
			Debug.Log ("Cliceked");
			controller.Move (targetPos, moveSpeed);
		} 
	}
}
