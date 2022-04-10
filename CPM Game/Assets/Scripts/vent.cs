using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vent : MonoBehaviour
{
    public static int count = 0;
    [SerializeField] private Animator anim;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("WTE"))
        {
            count += 1;
            Debug.Log(count);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("WTE"))
        {
            count -= 1;
            Debug.Log(count);
        }
    }

    // Update is called once per frame
    void Update()
    {
      if (count == 2)
      {
          anim.SetBool("TwoTrue", true);
      }   
        
    }
}
