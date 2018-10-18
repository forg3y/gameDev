﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

    void Start () {
        offset = transform.position - player.transform.position;
    }
    
    void LateUpdate () {
        // transform.position = player.transform.position + offset;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}