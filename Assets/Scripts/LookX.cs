 using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class LookX : MonoBehaviour {

	[SerializeField] float sensitivity = 5.0f;
	float rotationX;

	void Start () { }
	
	// Update is called once per frame
	void Update () {
       // transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
	}

	void OnLook(InputValue input)
    {
		Vector2 inputVec = input.Get<Vector2>();
		transform.Rotate(0, inputVec.x * sensitivity, 0);
	}
}
