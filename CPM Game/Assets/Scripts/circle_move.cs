using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle_move : MonoBehaviour
{

    float xpos, ypos, dt;
    [HideInInspector]
    public float hor, ver;
    public float xSpeed, ySpeed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        xpos = transform.position.x;
        ypos = transform.position.y;
        dt = Time.deltaTime;

        if (Input.GetKey("w") && !Input.GetKey("s")) {
            ver = ySpeed;
        }
        else if (Input.GetKey("s") && !Input.GetKey("w")) {
            ver = -ySpeed;
        }
        else {ver = 0;}

        if (Input.GetKey("d") &&  !Input.GetKey("a")) {
            hor = xSpeed;
        }
        else if (Input.GetKey("a") && !Input.GetKey("d")){
            hor = -xSpeed;
        }
        else {hor = 0;}        

        transform.position = new Vector2(xpos + hor * dt, ypos + ver * dt);
    }
}

//test push