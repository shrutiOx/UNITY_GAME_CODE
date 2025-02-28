using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
   // public float speed = 1.0f;
   // public float moveDirection = 0;
    public bool parentOnTrigger = true;
    // public bool hitBoxOnTrigger = false;
    // public GameObject moverObject = null;

    //  private Renderer renderer = null;
    //  private bool isVisible = false;
    // Start is called before the first frame update
    //public Transform startZpos = (5, 0, 0);
    //public float endZpos = 10.0f;
    public float speed = 3.0f;
    public Vector3 startingPoint;
    public Vector3 endPoint;
    public float startZpos = -1.0f;
    public float endZpos = 1.0f;


    void Start()
    {
        startingPoint = new Vector3(this.transform.position.x , this.transform.position.y, (this.transform.position.z + startZpos));
        endPoint = new Vector3(this.transform.position.x , this.transform.position.y, (this.transform.position.z + endZpos));
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x , this.transform.position.y, this.transform.position.z + speed * Time.deltaTime);
        if (this.transform.position.z > endPoint.z)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, startingPoint.z);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
          //  Debug.Log("Enter.");

            if (parentOnTrigger)
            {
              //  Debug.Log("Enter: Parent to me");

                //other.transform.parent = this.transform;

              //  other.GetComponent<myplayer2>().parentedToObject = true;
                other.GetComponent<myplayer2>().countlog += 1;
// Debug.Log(this.tag + "my tag");

            }

           
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
          //  Debug.Log("EXIT: Parent to me");
            other.GetComponent<myplayer2>().countlog = 0;
            //parentOnTrigger = false;
           // other.transform.parent = null;
           // other.GetComponent<myplayer2>().parentedToObject = false;

        }


    }
}


