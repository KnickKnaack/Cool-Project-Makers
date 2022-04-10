using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSide : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D other)
   {
       if (other.tag == "FlyBot")
       {
           other.gameObject.transform.position = new Vector3(-7.8f, other.gameObject.transform.position.y, 0f);
       }
   }
   
}
