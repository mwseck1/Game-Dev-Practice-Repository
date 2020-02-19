using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlanetScript : Sprite
{
   public Rect popUpWindow;
   public Vector3 coordinates;

   public void CreateWindow(int WindowID)
   {

   }

   public void OnGUI()
   {
        if(isSelected)
            popUpWindow = GUI.Window(0, popUpWindow, CreateWindow, "meow");
   }

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
        coordinates = new Vector3(transform.position.x, transform.position.y,1.0f);
        coordinates = RectTransformUtility.WorldToScreenPoint(Camera.main, coordinates);
        float correctYPosition = (Screen.height - coordinates.y) - 100; 
        popUpWindow = new Rect(coordinates.x - 350, correctYPosition,300, 300);
    }

    // Update is called once per frame
    public override void Update()
    {
      if(wasClicked && Input.GetMouseButtonDown(0))
      {
         transform.GetChild(0).GetComponent<Renderer>().enabled = true;
         isSelected = true;
         wasClicked = false;
      }
      else if(!wasClicked && Input.GetMouseButtonDown(0))
      {
          transform.GetChild(0).GetComponent<Renderer>().enabled = false;
          isSelected = false;
      }
    }
}
