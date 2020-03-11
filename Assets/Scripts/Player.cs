using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//we can attach this to an empty gameobject
public abstract class Player : MonoBehaviour
{
    private int numPlayers = 2;
    public int playerId; 
    public bool isPlayerTurn; 
    public GameObject[] ships; 
    public int money;

    //instantiate two players here
    // Start is called before the first frame update
    void Start()
    {   
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
