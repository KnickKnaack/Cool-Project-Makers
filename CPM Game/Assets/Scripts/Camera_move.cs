using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move : MonoBehaviour
{
    private GameObject currObj;
    private GameObject[] myCams;
    private GameObject tempCam; 

    private int currCam;
    private int numCams;

    // Start is called before the first frame update
    void Start()
    {

        currCam = 0;

        numCams = transform.childCount;

        myCams = new GameObject[numCams];

        for (int i = 0; i < numCams; i++) {
            currObj = transform.GetChild(i).gameObject;

            tempCam = new GameObject();
            tempCam.transform.parent = currObj.transform;

            tempCam.AddComponent(typeof(Camera));

            tempCam.GetComponent<Camera>().orthographic = true;
            tempCam.GetComponent<Camera>().orthographicSize = currObj.GetComponent<BoxCollider2D>().size.y/2;
            tempCam.GetComponent<Camera>().aspect = currObj.GetComponent<BoxCollider2D>().size.x / currObj.GetComponent<BoxCollider2D>().size.y;

            tempCam.transform.localPosition = new Vector3(currObj.GetComponent<BoxCollider2D>().size.x/2, -currObj.GetComponent<BoxCollider2D>().size.y/2, -1.0f);

            currObj.SetActive(false); 
            
        }

        transform.GetChild(currCam).gameObject.SetActive(true);

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(",")) {
            if (currCam == 0) {
                transform.GetChild(numCams - 1).gameObject.SetActive(true);
                transform.GetChild(currCam).gameObject.SetActive(false);
                currCam = numCams - 1;
            }
            else {
                transform.GetChild(currCam - 1).gameObject.SetActive(true);
                transform.GetChild(currCam).gameObject.SetActive(false);
                currCam -= 1;
            }
        }
        else if (Input.GetKeyDown(".")) {
            if (currCam == numCams - 1) {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(currCam).gameObject.SetActive(false);
                currCam = 0;
            }
            else {
                transform.GetChild(currCam + 1).gameObject.SetActive(true);
                transform.GetChild(currCam).gameObject.SetActive(false);
                currCam += 1;
            }
        }

    }
}
