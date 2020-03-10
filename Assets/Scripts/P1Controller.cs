using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class P1Controller : Sprite
{
    public Vector3 newPosition;

    public void Move()
    {
      if(GetComponent<Transform>().position != newPosition)
      {
          GetComponent<Transform>().position = Vector2.MoveTowards(transform.position, newPosition, 0.1f);
      }
    }
    
    // Start is called before the first frame update
    public override void Start()
    {
       newPosition = transform.position;
       transform.GetChild(0).GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    public override void Update()
    {
      if(wasClicked && Input.GetMouseButtonDown(0))
      {
         transform.GetChild(0).GetComponent<Renderer>().enabled = true;
         wasClicked = false;
      }
      else if(!wasClicked && Input.GetMouseButtonDown(0))
      {
          transform.GetChild(0).GetComponent<Renderer>().enabled = false;
          isSelected = false;
      }
            
      Move();
    }
}
