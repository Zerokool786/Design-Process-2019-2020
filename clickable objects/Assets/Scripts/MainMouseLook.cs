﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMouseLook : MonoBehaviour { 

    Vector2 mouseLook;
    Vector2 smoothV;  
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    GameObject player;

	// Use this for initialization
	void Start ()
    {
        player = this.transform.parent.gameObject;
		
	}

    // Update is called once per frame
    void Update()
    {
        var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")); //mouse x and y

        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity)); //*smoothing
        smoothV.x = Mathf.Lerp(smoothV.x, mouseDelta.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseDelta.y, 1f / smoothing);
        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
    
	}

    public Transform theInventory;

    private void onMouseDown()
    {
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = theInventory.position;
        this.transform.parent = GameObject.Find("Inventory").transform; //destination in 3d space to hover the object and place
    }

    void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }
}
