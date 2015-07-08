using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]

public class CameraManager : MonoBehaviour {
	private const float ThirdPersonCameraDepth = -5.04f,
						FirstPersonCameraDepth = 0f;

	private Camera camera;

	void Awake () {
		camera = GetComponent<Camera>();
	}

	void Start () {
		ChangeToThirdPerson ();
	}

	public void ChangeToThirdPerson() {
		camera.transform.localPosition = new Vector3 (camera.transform.localPosition.x,
		                                              camera.transform.localPosition.y,
		                                        	  ThirdPersonCameraDepth);
	}

	public void ChangeToFirstPerson() {
		camera.transform.localPosition = new Vector3 (camera.transform.localPosition.x,
		                                         	  camera.transform.localPosition.y,
		                                         	  FirstPersonCameraDepth);
	}

	public bool isThirdPerson() {
		return camera.transform.localPosition.z == ThirdPersonCameraDepth;
	}

	public bool isFirstPerson() {
		return camera.transform.localPosition.z == FirstPersonCameraDepth;
	}
}
