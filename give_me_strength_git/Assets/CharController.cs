using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CharController : MonoBehaviour {


	public float moveSpeed = 6f;
	

	public Text countText;
  // Rotate rotator;
  
  Vector3 movement;
  Animator anim;
  Rigidbody playerRB;
  int floorMask;
  float camRayLength = 100f;


  // private Vector3 rb_EulerAngleVelocity;
	private int count;

	// Vector3 upVelocity = new Vector3(0.1f, 0.0f, 0.1f);
	// Vector3 downVelocity = new Vector3(-0.1f, 0.0f, -0.1f);
	// Vector3 leftVelocity = new Vector3(-0.1f, 0.0f, 0.1f);
	// Vector3 rightVelocity = new Vector3(0.1f, 0.0f, -0.1f);


  void Awake() {
    floorMask = LayerMask.GetMask("Ground");
    anim = GetComponent<Animator> ();
    playerRB = GetComponent<Rigidbody> ();
  }

	// Use this for initialization
	// void Start () {
	// 	// rotation about the y axiz, with a speed of 100 (might need to unhardcode)
	// 	// Need EAV to be based on mouse postion
	// 	// wait but ok so i know how to get an angle... can i just use
		
	// 	// rb_EulerAngleVelocity = new Vector3(0,100,0); 

	// 	playerRB = GetComponent<Rigidbody>();
 //    rotator = GetComponent<Rotate>();
 //    playerRB.freezeRotation = false;
	// }

  void FixedUpdate() {
    float h = Input.GetAxisRaw("Horizontal");
    float v = Input.GetAxisRaw("Vertical");
  
    Move(h, v);
    Turning();
    Animating(h,v);
  }

  void Move(float h, float v) {
    // changes things so that it moves in a more natural way (up has to be up and right... if it doesn't make sense
    // try and set it to (v, 0, h))
    movement.Set(v + h, 0f, v - h);
    // don't want diagonal to move character faster, need to normalize
    movement = movement.normalized * moveSpeed * Time.deltaTime;
    // essentially, current position + new bit to move
    playerRB.MovePosition(transform.position + movement);
  }

  void Turning() {
    // will always find the ray that leads from screen (under mouse) to the floor
    Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

    RaycastHit floorHit;

    // .Raycast returns true if it hits something, specifically something on the
    // floormask with the camRay parameters. Want output from floorhit  
    if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)){
      // need to make a vector3 from player to the mouse
      Vector3 playerToMouse = floorHit.point - transform.position;
      // want to make completely sure we don't move in the y axis
      playerToMouse.y = 0f;
      // need a quaternion to deal with the rotation 
      Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
      playerRB.MoveRotation(newRotation);

    }
  }

  void Animating(float h, float v) {
    bool walking = h != 0f || v != 0f;
    anim.SetBool("IsWalking", walking);
  }

	// void Update () {
	// 	// need to pick angle based on mouse position
	// 	// it rotates! but it spins WAY too fast, 
	// 	// it should just stop once it faces the mouse...
	// 	// might need to use a SLERP quaternion thing? but what would the
	// 	// "other" object be.. i guess teh mouse? but I don't really want that
	// 	// could maybe put an invisible object under the mouse but that
	// 	// seems unnessecary... 
	// 	// float x = Input.mousePosition.x - Screen.width/2;
	// 	// float z = Input.mousePosition.y - Screen.height/2; 
	// 	// float RotationAngle = Mathf.Atan2(x,z) * Mathf.Rad2Deg;
	// 	// Quaternion quatRotation = Quaternion.AngleAxis(RotationAngle, Vector3.up);
	// 	// playerRB.MoveRotation(quatRotation);
		
 //    ///////////
 //      // rotator.doRotation();
 //      if (Input.GetKey(KeyCode.UpArrow)) {
 //        	// up and right gives right
 //        	playerRB.transform.position += upVelocity;
 //          rotator.doRotation();

 //        	/**Time.deltaTime*/
 //        	//playerRB.MovePosition(transform.position+Vector3.left*.1f);
 //        	//playerRB.MovePosition(transform.position + transform.position * Time.deltaTime);
 //    	}
 //        if (Input.GetKey(KeyCode.DownArrow)) {
 //        	// down and left gives down
 //        	// playerRB.transform.position += Vector3.forward*(-0.1f);
 //        	// playerRB.transform.position += Vector3.left*(0.1f);
 //        	playerRB.transform.position += downVelocity;
 //          rotator.doRotation();

 //        }
 //        if (Input.GetKey(KeyCode.LeftArrow)) {
 //        	// up and left gives left
 //        	// playerRB.transform.position += Vector3.forward*0.1f;       	
 //        	// playerRB.transform.position += Vector3.left*0.1f;
 //        	playerRB.transform.position += leftVelocity;
 //          rotator.doRotation();

 //        }
 //        if (Input.GetKey(KeyCode.RightArrow)) {
 //        	// playerRB.transform.position += Vector3.left*(-0.1f);
 //        	playerRB.transform.position += rightVelocity;
 //          rotator.doRotation();
        
 //        }        
 //    }
    //////////////
  //       if (Input.GetKey(KeyCode.DownArrow))
  //       {
  //           //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
  //           playerRB.velocity = -transform.forward * moveSpeed;
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
