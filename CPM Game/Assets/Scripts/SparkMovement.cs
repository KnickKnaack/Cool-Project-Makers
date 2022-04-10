using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkMovement : MonoBehaviour
{

    [SerializeField]
    private float speed;

    public Transform movePoint;
    public LayerMask wireHere;
    public LayerMask wireInter;
    public Vector3 inc;
    public bool gate;

    private float cellSize;
    private float detectSize;

    // Start is called before the first frame update
    void Start()
    {
        cellSize = 0.32f;
        detectSize = 0.02f;
        movePoint.position = transform.position;
        movePoint.parent = null;
    }

    // Update is called once per frame 
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);

        if (Mathf.Abs(Input.GetAxisRaw("SparkHor")) == 0f && Mathf.Abs(Input.GetAxisRaw("SparkVer")) == 0f)
            gate = true;


        if (Vector3.Distance(transform.position, movePoint.position) <= 0.03f && gate) {
            if (Mathf.Abs(Input.GetAxisRaw("SparkHor")) == 1f) {
                gate = false;
                inc = new Vector3(Input.GetAxisRaw("SparkHor") * cellSize, 0f, 0f);
                while (Physics2D.OverlapCircle(movePoint.position + inc, detectSize, wireHere)) {
                    movePoint.position += inc;
                }

                if (Physics2D.OverlapCircle(movePoint.position + inc, detectSize * 3, wireHere)){
                    movePoint.position += inc;
                }

            }

            else if (Mathf.Abs(Input.GetAxisRaw("SparkVer")) == 1f) {
                gate = false;
                inc = new Vector3(0, Input.GetAxisRaw("SparkVer") * cellSize, 0f);
                while (Physics2D.OverlapCircle(movePoint.position + inc, 0.02f, wireHere)) {
                    movePoint.position += inc;
                }
                if (Physics2D.OverlapCircle(movePoint.position + inc, detectSize * 3, wireHere)){
                    movePoint.position += inc;
                }
            }

        }
    }
}
