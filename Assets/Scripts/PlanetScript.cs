using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlanetScript : Sprite
{
   public Rect popUpWindow;
   public Vector3 coordinates;
   private bool selectedShip;
   public GameObject shipToMove;

    public bool CheckForSelectedShip()
    {
        GameObject[] PlayerShips = GameObject.FindGameObjectsWithTag("PlayerShip");

        foreach (var ship in PlayerShips)
        {
            if(ship.GetComponent<P1Controller>().isSelected == true)
            {
                shipToMove = ship;
                return true;
            }
        }

        return false;
    }
    
    public bool WndowWasClicked()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = (Screen.height - Input.mousePosition.y);

        if(mouseX > popUpWindow.x + 300 || mouseX < popUpWindow.x)
        {
            return false;
        }
       
        if(mouseY < popUpWindow.y || mouseY > popUpWindow.y + 300)
        {
            return false;
        }

        return true;
    }

   public void CreateWindow(int WindowID)
   {
       if(GUI.Button(new Rect(100,100, 50, 50), "Test"))
       {
           var newShip = GameObject.Find("p1");
           Instantiate(newShip);
       }
   }

   public void OnGUI()
   {
        if(isSelected)
            popUpWindow = GUI.Window(0, popUpWindow, CreateWindow, "meow");
   }

   public void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(1) && !isSelected && selectedShip)
        {
            shipToMove.GetComponent<P1Controller>().newPosition = transform.position;
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
        selectedShip = false;
        shipToMove = null;
    }

    // Update is called once per frame
    public override void Update()
    {
      selectedShip = CheckForSelectedShip();

      if(wasClicked && Input.GetMouseButtonDown(0))
      {
         transform.GetChild(0).GetComponent<Renderer>().enabled = true;
         isSelected = true;
         wasClicked = false;
      }
      else if(!wasClicked && Input.GetMouseButtonDown(0) && !WndowWasClicked())
      {
          transform.GetChild(0).GetComponent<Renderer>().enabled = false;
          isSelected = false;
      }
    }
}
