using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CharController : MonoBehaviour {

	[SerializeField]
	float moveSpeed = 10f;
	
	public Text countText;

	// do i want these to be private?
	private Rigidbody rb;
	// private Vector3 rb_EulerAngleVelocity;
	private int count;

	// Use this for initialization
	void Start () {
		// rotation about the y axiz, with a speed of 100 (might need to unhardcode)
		// Need EAV to be based on mouse postion
		// wait but ok so i know how to get an angle... can i just use
		
		// rb_EulerAngleVelocity = new Vector3(0,100,0); 

		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
	}

	void FixedUpdate () {
		// need to pick angle based on mouse position
		// it rotates! but it spins WAY too fast, 
		// it should just stop once it faces the mouse...
		// might need to use a SLERP quaternion thing? but what would the
		// "other" object be.. i guess teh mouse? but I don't really want that
		// could maybe put an invisible object under the mouse but that
		// seems unnessecary... 
		float x = Input.mousePosition.x - Screen.width/2;
		float z = Input.mousePosition.y - Screen.height/2; 
		float RotationAngle = Mathf.Atan2(x,z) * Mathf.Rad2Deg;
		Quaternion quatRotation = Quaternion.AngleAxis(RotationAngle, Vector3.up);
		// rb.rotation = quatRotation;
		rb.MoveRotation(quatRotation);
		//
        if (Input.GetKey(KeyCode.UpArrow)) {
        	rb.transform.position += Vector3.left*0.1f/**Time.deltaTime*/;
        	//rb.MovePosition(transform.position+Vector3.left*.1f);
        	//rb.MovePosition(transform.position + transform.position * Time.deltaTime);
    	}
    }

  //       if (Input.GetKey(KeyCode.DownArrow))
  //       {
  //           //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
  //           rb.velocity = -transform.forward * moveSpeed;
  //       }

  //       if (Input.GetKey(KeyCode.RightArrow))
  //       {
  //           //Rotate the sprite about the Y axis in the positive direction
  //           transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * moveSpeed, Space.World);
  //       }

  //       if (Input.GetKey(KeyCode.LeftArrow))
  //       {
  //           //Rotate the sprite about the Y axis in the negative direction
  //           transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * moveSpeed, Space.World);
  //       }
	// }
}
