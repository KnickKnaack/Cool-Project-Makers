using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WBotController : MonoBehaviour
{
    private Rigidbody2D myRB;
    private SpriteRenderer mySprite;
    private Animator myAnim;
    
    [SerializeField]
    private float speed;


    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        mySprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        myRB.velocity = new Vector2(Input.GetAxisRaw("SparkHor"), Input.GetAxisRaw("SparkVer")) * speed * Time.deltaTime;

        if (myRB.velocity.x == 0 && myRB.velocity.y == 0)
        {
            myAnim.SetBool("moving", false);
        }
        else  { myAnim.SetBool("moving", true); }

        if (myRB.velocity.x < 0)
        {
            mySprite.flipX = true;
        }
        else if (myRB.velocity.x > 0)
        {
            mySprite.flipX = false;
        }
    }
}
