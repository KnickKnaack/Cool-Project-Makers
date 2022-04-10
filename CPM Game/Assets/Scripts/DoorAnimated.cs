using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimated : MonoBehaviour {

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void OpenDoor() {
        animator.SetBool("Open", true);
        Debug.Log("Open door DoorAnimated");
    }

    public void CloseDoor() {
        animator.SetBool("Open", false);
    }

}