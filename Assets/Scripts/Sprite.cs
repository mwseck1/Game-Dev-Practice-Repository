using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public abstract class Sprite : MonoBehaviour
{
    public bool isSelected = false; 
    protected bool wasClicked = false;
   
    public void OnMouseDown()
    {
       wasClicked = true;
       isSelected = true;
    }
    
    // Start is called before the first frame update
    abstract public void Start();
    // Update is called once per frame
    abstract public void Update();
    
}
