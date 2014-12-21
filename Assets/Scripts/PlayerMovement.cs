using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float speed;

	void FixedUpdate () {
		Vector3 delta = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

		transform.position += delta*speed*Time.deltaTime;
	}
}