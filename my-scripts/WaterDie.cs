using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDie : MonoBehaviour
{
    private bool parentOnTriggerwater = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

   /*void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Enter water");

            if (parentOnTriggerwater)
            {
                Debug.Log("Enter: Parent to water");

                //other.transform.parent = this.transform;

                //other.GetComponent<myplayer2>().parentedToObject = true;
                other.GetComponent<myplayer2>().countlog = 0;
                Debug.Log(this.tag + "my tag water");
                Debug.Log("Exit " + other.GetComponent<myplayer2>().countlog);

            }


        }
    }*/
}
