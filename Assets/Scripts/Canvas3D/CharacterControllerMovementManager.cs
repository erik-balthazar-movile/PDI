using UnityEngine;
using System.Collections;

public class CharacterControllerMovementManager : MonoBehaviour {
	public float speed = 6f;
	public float jumpSpeed = 8f;
	public float gravity = 20f;
	private Vector3 moveDirection = Vector3.zero;
	private bool hasJumped = false;

	public MainMenuManager menu;
	public BalloonManager balloon;

	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump")) {
				if (!hasJumped)	{
					hasJumped = true;
					moveDirection.y = jumpSpeed;
				}
			} else {
				hasJumped = false;
			}

			if (Input.GetKeyUp(KeyCode.Escape)) {
				if (!menu.isOpened()) {
					menu.OpenMenu();
				} else {
					menu.CloseMenu();
				}
			}

			if (Input.GetKey(KeyCode.Return)) {
				balloon.ShowBalloon();
			}
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}
