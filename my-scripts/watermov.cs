using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watermov : MonoBehaviour
{// public float speed = 1.0f;
 // public float moveDirection = 0;
   //public bool parentOnTrigger = true;
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
    public float startZpos = -5.0f;
    public float endZpos = 5.0f;
    public GameObject mesh;
    public ParticleSystem tinyexplosion;
    // Start is called before the first frame update
    void Start()
    {
        startingPoint = new Vector3(this.transform.position.x, this.transform.position.y, (this.transform.position.z + startZpos));
        endPoint = new Vector3(this.transform.position.x, this.transform.position.y, (this.transform.position.z + endZpos));
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + speed * Time.deltaTime);
        mesh.transform.localEulerAngles = new Vector3(0, 0, 0);

        if (this.transform.position.z > endPoint.z)
        {

            mesh.transform.localEulerAngles = new Vector3(0, 90, 0);
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, startingPoint.z);
            ParticleSystem.EmissionModule em = tinyexplosion.emission;
            em.enabled = true;

        }
        
    }
}
