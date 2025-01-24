using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int lane = 1; //Lane de 0 a 2 
    [SerializeField] Transform playerPosition;
    private bool hasMoved = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float axe = Input.GetAxis("Horizontal");
        if (axe <0f && lane != 0 && !hasMoved)
        {
            lane--;
            playerPosition.position = new Vector3(playerPosition.position.x - 30, 10, 10);
            hasMoved = true;
        }
        else if(axe > 0f && lane != 2 && !hasMoved)
        {
            lane++;
            playerPosition.position = new Vector3(playerPosition.position.x + 30, 10, 10);
            hasMoved = true;
        }
            
        
    }
}
