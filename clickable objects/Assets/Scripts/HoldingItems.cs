﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingItems : MonoBehaviour //Picked Up Items
{
    public Transform theInventory;
    
    private void onMouseDown()
    {
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = theInventory.position;
        this.transform.parent = GameObject.Find("Inventory").transform;
    }

    void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }
}
