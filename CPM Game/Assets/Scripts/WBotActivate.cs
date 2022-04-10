using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WBotActivate : MonoBehaviour
{
    public bool toggle; 
    public bool inTrigger;
    public bool inWBot; //means P2 is currently controlling WBot

    public void Start()
    {
        enabled = false; 
        inWBot = false;
        toggle = false;
        inTrigger = false; 
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Slash) && toggle == false)
        {
            if (GameObject.Find("WBot") != null) // just to avoid null pointer exceptions
            {
                inWBot = true;
                GameObject.Find("WBot").GetComponent<WBotController>().enabled = true;
                GameObject.Find("P2").GetComponent<SparkMovement>().enabled = false;
                GameObject.Find("FlyBot").GetComponent<FlyBotController>().enabled = false;
            }

        toggle = !toggle;
        }

        else if (Input.GetKeyUp(KeyCode.Slash) && toggle == true)
        {
            if (GameObject.Find("WBot") != null) 
            {
                inWBot = false;
                GameObject.Find("WBot").GetComponent<WBotController>().enabled = false;
                GameObject.Find("P2").GetComponent<SparkMovement>().enabled = true;
                GameObject.Find("FlyBot").GetComponent<FlyBotController>().enabled = false;
            }

        toggle = !toggle;
        }
        if (!inTrigger && !inWBot)
        {
            enabled = false;
        }
     }

   private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player2"))
        {
             enabled = true;
             inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player2"))
        {
            inTrigger = false;
        }
    }
}

