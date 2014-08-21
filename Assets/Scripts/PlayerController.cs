using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float minImpulse;
	public float maxImpulse;
	private float currentImpulse;
	public float impulseDeltaPercent;
	private float impulseDelta;
	public float jumpImpulse;
	
	public GameObject cameraObject;

	public float cameraPivotSpeed;

	private float cameraOriginalFov;
	public float cameraFovDelta;

	private Vector3 cameraOriginalPosition;
	public float cameraPullbackDelta;

	public float cameraResetMultiplier;
	
	private bool isLaunching;
	private bool isInPlay;
	private bool resetCamera;
	private float distToGround;

	public AudioClip chargingSound;
	public AudioClip launchingSound;
	
	
	void Start() {
		distToGround = this.collider.bounds.extents.y;
		resetCamera = isInPlay = isLaunching = false;
		
		impulseDelta = (maxImpulse - minImpulse) * impulseDeltaPercent / 100;
	}
	
	private bool IsGrounded() {
		return Physics.Raycast(this.transform.position, -Vector3.up, distToGround + 0.1f);
	}
	
	void Update () {
		if (!isInPlay) {
			if (Input.GetKey(KeyCode.Space)) {
				if (!isLaunching) {
					cameraOriginalPosition = cameraObject.transform.position;
					cameraOriginalFov = cameraObject.camera.fieldOfView;
					currentImpulse = minImpulse;
					this.audio.PlayOneShot(chargingSound, 0.5f);
				}

				if (currentImpulse + impulseDelta <= maxImpulse) {
					currentImpulse += impulseDelta;

					cameraObject.camera.fieldOfView -= cameraFovDelta;
					cameraObject.camera.transform.position -= cameraObject.transform.forward * cameraPullbackDelta;

					isLaunching = true;
				}

				this.transform.Rotate(-15, 0, 0);
			} else if (isLaunching) {
				this.rigidbody.isKinematic = false;
				this.rigidbody.AddForce(cameraObject.transform.forward * currentImpulse, ForceMode.Impulse);
				isLaunching = false;
				isInPlay = resetCamera = true;
				this.audio.Stop();
				this.audio.PlayOneShot(launchingSound);
			} else {
				var horizontal = Input.GetAxis("Horizontal");
				var vertical = Input.GetAxis("Vertical");
				var rotation = Input.GetAxis("Rotation");

				cameraObject.transform.RotateAround(this.transform.position, cameraObject.transform.up, horizontal * cameraPivotSpeed);
				cameraObject.transform.RotateAround(this.transform.position, cameraObject.transform.right, vertical * cameraPivotSpeed);
				cameraObject.transform.Rotate(0, 0, rotation * cameraPivotSpeed);
			}
		} else {
			if (Input.GetKeyDown(KeyCode.Space) && !IsGrounded()) {
				this.rigidbody.velocity = new Vector3(this.rigidbody.velocity.x, 0, this.rigidbody.velocity.z);
				this.rigidbody.AddForce(Vector3.up * jumpImpulse, ForceMode.Impulse);
			}
		}

		if (resetCamera) {
			cameraObject.camera.fieldOfView += cameraFovDelta * cameraResetMultiplier;
			cameraObject.camera.transform.position += cameraObject.transform.forward * cameraPullbackDelta * cameraResetMultiplier;

			if (cameraObject.camera.fieldOfView >= cameraOriginalFov) {
				cameraObject.camera.fieldOfView = cameraOriginalFov;
				cameraObject.transform.position = cameraOriginalPosition;
				resetCamera = false;
			}
		}
	}
	public void OnCollisionEnter() {
		this.audio.Play();
	}
}