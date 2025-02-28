using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostScript : MonoBehaviour
{
    public GameObject maincharacter;
    public GameObject player;
    public float speed = 1f;
    public float regularspeed = 6.0f;
    public float maxspeed = 15.2f;
    public static bool gameisplaying = false;
   // public static bool gameisplayinglev2 = false;
    public Scene scene;
    // Start is called before the first frame update
    //inpts for AI:speed,distance,hide th ghost and make it jump on main chracter,score,patroling(cubes):u make th ghost to go from
    //one way point to another an repeat
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<myplayer2>().isPaused == false)
        {
            if (gameisplaying == true)
            {

                float Distance = Vector3.Distance(maincharacter.transform.position, this.transform.position);
                if (Distance < 10)
                {
                    speed = regularspeed;
                }
                else
                {
                    speed = maxspeed;
                }
                transform.position = Vector3.MoveTowards(transform.position, maincharacter.transform.position, speed * Time.fixedDeltaTime);
                transform.LookAt(maincharacter.transform.position);
            }
        }

        
       // Debug.Log("is executed?" + gameisplaying);

    }
    public void GameHasStarted()
    {
       gameisplaying = true;
    }
   
    public void GameHasStartedAgain()
    {
        gameisplaying = true;
      //  Debug.Log("executed"+  gameisplaying);
    }
    
    private void OnGUI()
    {
        scene = SceneManager.GetActiveScene();


    }
   /* void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "house")
        {
            gameisplaying = false;
            

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "house")
        {
            gameisplaying = true;


        }
    }*/
}



