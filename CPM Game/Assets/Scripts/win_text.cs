using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class win_text : MonoBehaviour
{
    // Start is called before the first frame update
    
    float correctX = -5.18f;
    float correctY = -0.05f;
    float allowence = 0.5f;
    GameObject player;

    bool won = false;

    void Start()
    {
        player = GameObject.Find ("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float cx = player.transform.position.x;
        float cy = player.transform.position.y;
        
        float xs = player.GetComponent<circle_move>().hor;
        float ys = player.GetComponent<circle_move>().ver;

        if (won == false) {
            if (cx > correctX - allowence && cx < correctX + allowence &&
                (cy > correctY - allowence && cy < correctY + allowence &&
                xs == 0 && ys == 0)) {
                    transform.localPosition = new Vector2(0, -131);
                    won = true;

            }
        }
    }
}
