﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float mouseX; 
    private float mouseY; 
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.mousePosition.x; 
        mouseY = Input.mousePosition.y;

        if(mouseX >= Screen.width)
        {
            transform.Translate(Vector3.right);
        }
        else if(mouseX <= 0)
        {
            transform.Translate(Vector3.left);
        }
        if(mouseY >= Screen.height)
        {
            transform.Translate(Vector3.up);
        }
        else if(mouseY <= 0)
        {
            transform.Translate(Vector3.down);
        }

    }
}
