using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPressurePlate : MonoBehaviour {

    [SerializeField] private GameObject doorGameObject;
    [SerializeField] private Animator animator;
    private IDoor door;
    private float timer;
    public static int count = 0;

    private void Awake() {
        door = doorGameObject.GetComponent<IDoor>();
    }

    private void Update() {
    if (count > 1)
      {
          animator.SetBool("Open", true);
      }   
    else
    {
        animator.SetBool("Open", false);
    }
        if (timer > 0) {
            timer -= Time.deltaTime;
            if (timer <= 0f) {
                //door.CloseDoor();
            }
        }
    }

   /* private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            door.OpenDoor();
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collider) {

        if (collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag("Box"))
        {
            count += 1;
            Debug.Log(count);
        }
          //  door.OpenDoor();
           // animator.SetBool("Open", true);
        
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag("Box"))
        {
            count -= 1;
            Debug.Log(count);
        }
    }

    private void OnTriggerStay2D(Collider2D collider) {
        if (collider.GetComponent<CharacterController>() != null) {
            // player continually on top of collider
            timer = 1f;
        }
    }

}