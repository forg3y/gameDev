using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // store the mouse position
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.z, 10);
        
        // need to use the mouse data to influence where the player is facing
        // WITHOUT influencing mocement whatsoever. Up is always up, so to speak
        // would need to do something relating to: WASD -> transform.forward
        // how do we determine what direction the character is facing?

        //"screentoworldpoint" is not in the documentation... what is it..?
        // Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
        // lookPos = lookPos - transform.position;
        // float angle = Mathf.Atan2(lookPos.z, lookPos.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
