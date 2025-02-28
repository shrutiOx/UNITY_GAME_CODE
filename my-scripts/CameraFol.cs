using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFol : MonoBehaviour
{
    
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    // camera will follow this object
    public Transform Target;
    //camera transform
   // public Transform camTransform;
    // offset between camera and target
    public Vector3 Offset;
    // change this value to get desired smoothness
    public Vector3 targetPosition;
    public float SmoothTime = 0.3f;
    //public Vector3 Offset;
    void Start()
    {
        //Offset = this.transform.position - Target.position;
        Offset = new Vector3(51, 28, -1);
    }

    // Update is called once per frame
    void Update()
    {

        // Define a target position above and behind the target transform
        //Vector3 targetPosition = Target.position + Offset;
        // targetPosition = Target.TransformPoint(new Vector3(-5, 5, -10));
        targetPosition = Target.transform.position + Offset;

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);
       // Debug.Log(targetPosition + "targetpos");
        // update rotation
        //transform.LookAt(Target);
    }
}


/*// camera will follow this object
public Transform Target;
//camera transform
public Transform camTransform;
// offset between camera and target
public Vector3 Offset;
// change this value to get desired smoothness
public float SmoothTime = 0.3f;

// This value will change at the runtime depending on target movement. Initialize with zero vector.
private Vector3 velocity = Vector3.zero;

private void Start()
{
    Offset = camTransform.position - Target.position;
}

private void LateUpdate()
{
    // update position
    Vector3 targetPosition = Target.position + Offset;
    camTransform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);

    
}*/