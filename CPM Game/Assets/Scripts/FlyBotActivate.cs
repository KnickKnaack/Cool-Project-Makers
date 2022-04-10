using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBotActivate : MonoBehaviour
{
    public bool toggle; 
    public bool inTrigger;
    public bool inFlyBot; //means P2 is currently controlling FlyBot

    public void Start()
    {
        enabled = false; 
        inFlyBot = false;
        toggle = false;
        inTrigger = false; 
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Slash) && toggle == false)
        {
            if (GameObject.Find("FlyBot") != null) // just to avoid null pointer exceptions
            {
                inFlyBot = true;
                GameObject.Find("WBot").GetComponent<WBotController>().enabled = false;
                GameObject.Find("P2").GetComponent<SparkMovement>().enabled = false;
                GameObject.Find("FlyBot").GetComponent<FlyBotController>().enabled = true;
            }

        toggle = !toggle;
        }

        else if (Input.GetKeyUp(KeyCode.Slash) && toggle == true)
        {
            if (GameObject.Find("FlyBot") != null) 
            {
                inFlyBot = false;
                GameObject.Find("WBot").GetComponent<WBotController>().enabled = false;
                GameObject.Find("P2").GetComponent<SparkMovement>().enabled = true;
                GameObject.Find("FlyBot").GetComponent<FlyBotController>().enabled = false;
            }

        toggle = !toggle;
        }
        if (!inTrigger && !inFlyBot)
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
