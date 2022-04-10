using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Activate : MonoBehaviour
{

    [SerializeField] private Animator anim;
    public bool toggle; 

    public void Start()
    {
        enabled = false; 
        toggle = false;
        //Debug.Log(enabled);
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Slash))
        {
            //Debug.Log(toggle);
            anim.SetBool("PlayActive", !toggle);
            toggle = !toggle;
        }
     
     }

   private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player2"))
        {
            enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player2"))
        {
            enabled = false;
            //Debug.Log(enabled);
        }
    }
}
