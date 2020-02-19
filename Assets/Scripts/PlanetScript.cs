using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlanetScript : Sprite
{
   
   public void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(1) && !isSelected && GameObject.Find("p1").GetComponent<P1Controller>().isSelected == true)
        {
            GameObject.Find("p1").GetComponent<P1Controller>().newPosition = transform.position;
        }
    }

    // Start is called before the first frame update
    public override void Start()
    {
        transform.GetChild(0).GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    public override void Update()
    {
      if(isSelected && Input.GetMouseButtonDown(0))
      {
         transform.GetChild(0).GetComponent<Renderer>().enabled = true;
         isSelected = false;
      }
      else if(!isSelected && Input.GetMouseButtonDown(0))
      {
          transform.GetChild(0).GetComponent<Renderer>().enabled = false;
      }
    }
}
