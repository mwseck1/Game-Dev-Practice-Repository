using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlanetScript : Sprite
{
   public Rect popUpWindow;
   public Vector3 coordinates;
   private bool isShipSelected;
   public GameObject currentPlayer;
   public GameObject shipToMove;

    public bool CheckForSelectedShip()
    {
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");

        foreach (var player in Players)
        {
            if(player.GetComponent<CorporationController>().isPlayerTurn == true)
            {
                currentPlayer = player;
            }
        }

       GameObject[] ships = currentPlayer.GetComponent<CorporationController>().ships;

       foreach(var ship in ships)
       {
           if(ship.GetComponent<P1Controller>().isSelected == true)
           {
               shipToMove = ship;
               return true;
           }
       }

        return false;
    }
    
    public bool WindowWasClicked()
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
       if(GUI.Button(new Rect(125,200, 50, 50), "Test"))
       {
           var newShip = GameObject.Find("p1");
           
           Instantiate(newShip, new Vector3(transform.position.x + 1, transform.position.y + 1, 0), Quaternion.identity);
       }
   }

   public void OnGUI()
   {
        if(isSelected)
            popUpWindow = GUI.Window(0, popUpWindow, CreateWindow, "meow");
   }

   public void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(1) && !isSelected && isShipSelected)
        {
            shipToMove.GetComponent<P1Controller>().newPosition = 
                new Vector3(transform.position.x + 1, transform.position.y + 1, 0);
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
        isShipSelected = false;
        shipToMove = null;
    }

    // Update is called once per frame
    public override void Update()
    {
      isShipSelected = CheckForSelectedShip();
      
      if(wasClicked && Input.GetMouseButtonDown(0))
      {
         transform.GetChild(0).GetComponent<Renderer>().enabled = true;
         isSelected = true;
         wasClicked = false;
      }
      else if(!wasClicked && Input.GetMouseButtonDown(0) && !WindowWasClicked())
      {
          transform.GetChild(0).GetComponent<Renderer>().enabled = false;
          isSelected = false;
      }
    }
}
