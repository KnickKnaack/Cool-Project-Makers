using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpSide : MonoBehaviour
{

 void OnTriggerEnter2D(Collider2D other)
   {
       if (other.tag == "FlyBot")
       {
           other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, -4, 0f);
       }
   }

}
