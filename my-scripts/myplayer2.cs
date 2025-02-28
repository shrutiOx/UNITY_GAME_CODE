using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

//using GoogleMobileAds.Api;

public class myplayer2 : MonoBehaviour
{
    // private RewardBasedVideoAd rewardbasedvideoadd;
    bool isJumpingUp;
    bool isJumpingDown;
    bool isJumpingLeft;
    bool isJumpingRight;

    bool gameIsPlaying = false;
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public GameObject pause;
    public GameObject unpause;
    //public GameObject MediumPanel;
    //  public GameObject mutebutton1;
    //   public GameObject panelmedium;
    public AudioClip CoinClip;
    public AudioClip splashing;
    public AudioClip hitting;
    public AudioClip hopping;
    public AudioClip dieing;
    //  public AudioClip ambient;

    public GameObject ghost;

    public GameObject character1;
    public GameObject character2;
    public GameObject character3;

    public GameObject strip1;
    public GameObject strip2;
    public GameObject strip3;
    public GameObject strip4;
    public GameObject strip5;
    public GameObject strip6;
    public GameObject strip7;
    public GameObject strip8;
    public GameObject strip9;
    public GameObject strip10;
    public GameObject strip11;
    public GameObject strip12;
    public GameObject strip13;
    public GameObject strip14;
    public GameObject strip15;
    //public bool parentedToObject = false;
    // public GameObject strip16;
    // public GameObject strip17;

    public static double score = 0;
    public int score1 = 0;
    public Text scoreText;
    public Text Hit;
    public Text Coins;
    public Text swipe;
    public int indexOfTheHighestRoadStrip = 0;

    public GameObject BoundaryLeft;
    public GameObject BoundaryRight;
    public ParticleSystem splash = null;

    public float jumpDistanceZ = 2.0f;

    private List<GameObject> strips;
    int stripsCurrentIndex;

    public GameObject[] poolOfStripsPrefabs;

    public GameObject mesh;

    public float jumpOffsetX = -3.01f;
    float count = 10;

    public Vector3 JumpTargetLocation;
    public float movingSpeed = 100.0f;

    private float midWayPointX;
    public float jumpHeightIncrement = 2f;

    private float initialPositionY;
    //  public ParticleSystem particle = null;

    public bool isDead = false;
    private bool isPlayingDeathAnimation = false;

    public bool isPaused = false;
    public int countlog;
    public Scene scene;

   // public GameObject button;
    //public GameObject interstitialads;


    // Use this for initialization
    void Start()
    {
       
        //button.SetActive(false);

        //   button.SetActive(false);
        // MobileAds.Initialize((initStatus) => {
        //       Debug.Log("Initialized MobileAds");
        //   });

        Hit.text = "Lives: " + count.ToString();
        strips = new List<GameObject>();
        isJumpingUp = isJumpingDown = isJumpingRight = isJumpingLeft = false;

        strips.Add(strip1); //strip1.name = "1";
        strips.Add(strip2); //strip2.name = "2";
        strips.Add(strip3); //strip3.name = "3";
        strips.Add(strip4); //strip4.name = "4";
        strips.Add(strip5); //strip5.name = "5";
        strips.Add(strip6); //strip6.name = "6";
        strips.Add(strip7); //strip7.name = "7";
        strips.Add(strip8); //strip8.name = "8";
        strips.Add(strip9); //strip9.name = "9";
        strips.Add(strip10); //strip10.name = "10";
        strips.Add(strip11); //strip11.name = "11";
        strips.Add(strip12); //strip12.name = "12";
        strips.Add(strip13); //strip13.name = "13";
        strips.Add(strip14); //strip14.name = "14";
        strips.Add(strip15); //strip15.name = "15";
                             //  strips.Add(strip16); //strip16.name = "16";
                             //  strips.Add(strip17); //strip17.name = "17";

        stripsCurrentIndex = 0;
        initialPositionY = this.transform.position.y;
        //  HidemediumPanel();
        HideGameOverPanel();

        if (scene.name == "LEVEL_2")
        {
            HideGameStartPanel();
            ButtonStartPressed();
            // panelmedium.SetActive(true);
        }

        int isGameReloaded = PlayerPrefs.GetInt("reloaded");
        if (isGameReloaded == 1)
        {
            PlayerPrefs.SetInt("reloaded", 0);
            ButtonStartPressed();

        }
        if (isGameReloaded == 2)
        {
            PlayerPrefs.SetInt("reloaded", 0);
            ButtonStartPressed();

        }

        if (isGameReloaded == 3)
        {
            PlayerPrefs.SetInt("reloaded", 0);
            ButtonStartPressed();

        }
        setSelectedCharacter();
        
    }

    // Update is called once per frame
    void Update()
    {

        /*  if(count%3 == 0)
            {
                button.SetActive(true);
            }
            else
            {
                button.SetActive(false);
            }*/

        /* if (isPaused)
         {
             Time.timeScale = 0;
         }
         else
         {
             Time.timeScale = 1;
         }*/

        // this.GetComponent<AudioSource>().PlayOneShot(ambient);
        if ((score1 > 50) && (scene.name == "LEVEL_1"))
        {
            SceneManager.LoadScene("LEVEL_2");
            // HideGameStartPanel();
            // ButtonStartPressed();
            PlayerPrefs.SetInt("reloaded", 3);


        }
        if ((score1 > 100) && (scene.name == "LEVEL_2"))
        {

            // panelmedium.SetActive(true);
            //  Debug.Log("start panel  deactivated");
            SceneManager.LoadScene("LEVEL_1");
            PlayerPrefs.SetInt("reloaded", 2);


        }


        if (gameIsPlaying == false)
        {
            return;
        }

        if (isDead == true)
        {

            return;


        }
        /*if (Input.GetMouseButtonDown (0)) {
			if(isJumping == false )
			{
				isJumping = true;
				Jump ();
			}
		}*/

        if (isJumpingUp)
        {
            swipe.enabled = false;
            if (this.transform.position.x > JumpTargetLocation.x)
            {
                this.transform.position = new Vector3(this.transform.position.x - (movingSpeed * Time.deltaTime), this.transform.position.y, this.transform.position.z);
                if (this.transform.position.x > midWayPointX)
                {
                    this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + jumpHeightIncrement * Time.deltaTime, this.transform.position.z);
                }
                else
                {
                    this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - jumpHeightIncrement * Time.deltaTime, this.transform.position.z);
                }
            }
            else
            {
                isJumpingUp = false;
                this.transform.position = new Vector3(transform.position.x, initialPositionY, transform.position.z);
            }
        }
        else if (isJumpingDown)
        {
            swipe.enabled = false;
            // todo
            if (this.transform.position.x < JumpTargetLocation.x)
            {
                this.transform.position = new Vector3(this.transform.position.x + (movingSpeed * Time.deltaTime), this.transform.position.y, this.transform.position.z);
                if (this.transform.position.x < midWayPointX)
                {
                    this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + jumpHeightIncrement * Time.deltaTime, this.transform.position.z);
                }
                else
                {
                    this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - jumpHeightIncrement * Time.deltaTime, this.transform.position.z);
                }
            }
            else
            {
                isJumpingDown = false;
                this.transform.position = new Vector3(transform.position.x, initialPositionY, transform.position.z);
            }
        }
        else if (isJumpingLeft)
        {
            swipe.enabled = false;
            if (this.transform.position.z > JumpTargetLocation.z)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - (movingSpeed * Time.deltaTime));
                if (this.transform.position.z > midWayPointX)
                {
                    this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + jumpHeightIncrement * Time.deltaTime, this.transform.position.z);
                }
                else
                {
                    this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - jumpHeightIncrement * Time.deltaTime, this.transform.position.z);
                }
            }
            else
            {
                isJumpingLeft = false;
                this.transform.position = new Vector3(transform.position.x, initialPositionY, transform.position.z);
            }
        }
        else if (isJumpingRight)
        {
            swipe.enabled = false;
            if (this.transform.position.z < JumpTargetLocation.z)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + (movingSpeed * Time.deltaTime));
                if (this.transform.position.z < midWayPointX)
                {
                    this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + jumpHeightIncrement * Time.deltaTime, this.transform.position.z);
                }
                else
                {
                    this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - jumpHeightIncrement * Time.deltaTime, this.transform.position.z);
                }
            }
            else
            {
                isJumpingRight = false;
                this.transform.position = new Vector3(transform.position.x, initialPositionY, transform.position.z);
            }
        }

        if (isPlayingDeathAnimation == true)
        {
            UpdateDeathAnimation();
        }


    }


    void JumpUp()
    {
        if (gameIsPlaying == false)
            return;
        // we want to move to the next strip on the field
        //this.transform.position = new Vector3 (strip5.transform.position.x, transform.position.y, transform.position.z);

        // A) move the strips current index by 1 (increment)
        // B) get the strip at this index within the strips list
        // C) get the x position of this new stip and apply it to the chicken

        // A)
        stripsCurrentIndex += 1;
        if (stripsCurrentIndex > indexOfTheHighestRoadStrip)
        {
            score += 1;
            scoreText.text = "score: " + score.ToString();
            indexOfTheHighestRoadStrip = stripsCurrentIndex;
            //  Debug.Log("new  score: " + indexOfTheHighestRoadStrip.ToString());
        }

        // B)
        GameObject nextStrip = strips[stripsCurrentIndex] as GameObject;

        // C)
        JumpTargetLocation = new Vector3(nextStrip.transform.position.x - jumpOffsetX, transform.position.y, transform.position.z);
        midWayPointX = JumpTargetLocation.x + ((this.transform.position.x - JumpTargetLocation.x) / 2);
        mesh.transform.localEulerAngles = new Vector3(0, 0, 0);

        SpawnNewStrip();

        // todo: move boundy up
        // we need to to figure out the distance that the chicken will travel as it jumps
        float distanceX = this.transform.position.x - JumpTargetLocation.x;
        BoundaryLeft.transform.position -= new Vector3(distanceX, 0, 0);
        BoundaryRight.transform.position -= new Vector3(distanceX, 0, 0);
    }

    void SpawnNewStrip()
    {
        // A) we take a strip from the pool of strips prefabs at random
        // B) then we instantiate it at the location of the last item of the "strips" list and add the width of this item as an offset (X axis)

        // A)
        int stripsPrefabCount = poolOfStripsPrefabs.Length;
        int randomNumber = Random.Range(0, stripsPrefabCount);
        GameObject item = poolOfStripsPrefabs[randomNumber] as GameObject;
        Transform itemChildTransform = item.transform.GetChild(0) as Transform;
        Transform itemChildOfChildTranform = itemChildTransform.GetChild(0) as Transform;
        float itemWidth = itemChildOfChildTranform.gameObject.GetComponent<Renderer>().bounds.size.x;
        //float itemWidth = 10.2f; // static width
        // Debug.Log("strip width : " + itemWidth.ToString());

        // get location of the last item:
        GameObject lastStrip = strips[strips.Count - 1] as GameObject;

        GameObject newStrip = Instantiate(item, lastStrip.transform.position, lastStrip.transform.rotation) as GameObject;
        newStrip.transform.position = new Vector3(newStrip.transform.position.x - itemWidth, newStrip.transform.position.y, newStrip.transform.position.z);
        strips.Add(newStrip);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ghost")
        {
            // ParticleSystem.EmissionModule em = particle.emission;
            //  em.enabled = true;

            DeathAnimation();
            mesh.transform.localScale = new Vector3(0, 0, 0);


            if (isDead == false)
            {
                this.GetComponent<AudioSource>().PlayOneShot(dieing);
                //GameObject.Find("AdsManager").GetComponent<AdsManager>().RequestInterstitialAd();

                //interstitialads.GetComponent<UnityMonetization>().DsiplayInterstitialAD();

                  
               // 
             }
         }

            if ((other.gameObject.tag == "Water") && (countlog == 0))
            {
                // Debug.Log("Enter.");
                //Debug.Log("Tag " + other.gameObject.tag);

                DeathAnimation();
                ParticleSystem.EmissionModule em = splash.emission;
                em.enabled = true;
                // Destroy(this.gameObject);
                //other.gameObject.transform.localScale = new Vector3(0, 0, 0);
                mesh.transform.localScale = new Vector3(0, 0, 0);
                this.GetComponent<AudioSource>().PlayOneShot(splashing);
                //ParticleSystem.EmissionModule em = splash.emission;
                // GameObject.Find("AdsManager").GetComponent<AdsManager>().RequestInterstitialAd();
            }




            if (other.gameObject.tag == "Coin")
            {
                //Debug.Log("Collision wth Coin");
                score1 += 1;
                Coins.text = "Coins: " + score1.ToString();
                Destroy(other.gameObject);
                this.GetComponent<AudioSource>().PlayOneShot(CoinClip);
           

            }
            if (other.gameObject.tag == "Enemy")
            {

                //Debug.Log("collision");
                DeathAnimation();
                this.GetComponent<AudioSource>().PlayOneShot(hitting);



            }

            if (other.gameObject.tag == "WaterEnemy")
            {
                Debug.Log("collision with waterenemy");
                DeathAnimation();
                this.GetComponent<AudioSource>().PlayOneShot(hitting);
                //  GameObject.Find("AdsManager").GetComponent<AdsManager>().RequestInterstitialAd();
            }

            if (other.gameObject.tag == "obstacles")
            {
                // Debug.Log("hit an obstacle");
                count -= 1;
                Hit.text = "Lives: " + count.ToString();
                this.GetComponent<AudioSource>().PlayOneShot(hitting);

                //mesh.transform.localScale -= new Vector3(0, 0, 0.02f);


                float offsetUpDown = 0;
                float offsetLeftRight = 0;
                // todo:
                if (isJumpingDown)
                {
                    offsetUpDown = -2.0f;
                }
                else if (isJumpingUp)
                {
                    offsetUpDown = 2.0f;
                }
                else if (isJumpingRight)
                {
                    offsetLeftRight = -2.0f;
                }
                else if (isJumpingLeft)
                {
                    offsetLeftRight = 2.0f;
                }

                transform.position = new Vector3(transform.position.x + offsetUpDown, initialPositionY, transform.position.z + offsetLeftRight);
                // transform.position = new Vector3(transform.position.x , initialPositionY, transform.position.z );
                isJumpingUp = isJumpingRight = isJumpingLeft = isJumpingDown = false;
                if (count == 0)
                {
                    DeathAnimation();
                    //Debug.Log("died due to collision");
                }

            }
            if (other.gameObject.tag == "gifty")
            {
                count += 5;
                Hit.text = "Lives: " + count.ToString();
                Destroy(other.gameObject);
            }
        }

        /*if(other.gameObject.tag == "Water" && (parentedToObject == false))
       {
           DeathAnimation();
           // Destroy(this.gameObject);
           mesh.transform.localScale = new Vector3(0, 0, 0);
       }*/



        void DeathAnimation()
        {

            isPlayingDeathAnimation = true;


        }

        void UpdateDeathAnimation()
        {
            if (mesh.transform.localScale.z > 0.1)
            {
                mesh.transform.localScale -= new Vector3(0, 0, 0.02f);
            }
            else
            {
                isPlayingDeathAnimation = false;
                isDead = true;
                BringUpGameOverPanel();
            }
            if (mesh.transform.rotation.eulerAngles.x == 0 || mesh.transform.rotation.eulerAngles.x > 270)
            {
                mesh.transform.Rotate(-4.0f, 0, 0);
            }

        }

        void SwipeUp()
        {
            // Debug.Log("consuming swipe up");
            // todo: move chicken up
            if (isJumpingUp == false)
            {
                isJumpingUp = true;
                JumpUp();
                this.GetComponent<AudioSource>().PlayOneShot(hopping);
            }
        }

        void SwipeDown()
        {
            //  Debug.Log("consuming swipe down");
            // todo move chicken down
            if (isJumpingDown == false)
            {
                isJumpingDown = true;
                JumpDown();
                this.GetComponent<AudioSource>().PlayOneShot(hopping);
            }
        }

        void SwipeLeft()
        {
            //   Debug.Log("consuming swipe left");
            // todo: chicken moving left
            if (isJumpingLeft == false)
            {
                isJumpingLeft = true;
                JumpLeft();
                this.GetComponent<AudioSource>().PlayOneShot(hopping);
            }
        }

        void SwipeRight()
        {
            //  Debug.Log("consuming swipe right");
            // todo: chicken moving right
            if (isJumpingRight == false)
            {
                isJumpingRight = true;
                JumpRight();
                this.GetComponent<AudioSource>().PlayOneShot(hopping);
            }
        }

        void JumpDown()
        {
            if (gameIsPlaying == false)
                return;
            // A)
            stripsCurrentIndex -= 1;
            if (stripsCurrentIndex < 0)
            {
                stripsCurrentIndex = 0;
                return;
            }


            // B)
            GameObject previousStrip = strips[stripsCurrentIndex] as GameObject;

            // C)
            JumpTargetLocation = new Vector3(previousStrip.transform.position.x - jumpOffsetX, transform.position.y, transform.position.z);
            midWayPointX = JumpTargetLocation.x - ((JumpTargetLocation.x - this.transform.position.x) / 2);

            mesh.transform.localEulerAngles = new Vector3(0, 180, 0);

            // todo: move boundary down
            float distanceX = JumpTargetLocation.x - this.transform.position.x;
            BoundaryLeft.transform.position += new Vector3(distanceX, 0, 0);
            BoundaryRight.transform.position += new Vector3(distanceX, 0, 0);
        }

        void JumpRight()
        {
            if (gameIsPlaying == false)
                return;
            JumpTargetLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z + jumpDistanceZ);
            midWayPointX = JumpTargetLocation.z + ((this.transform.position.z - JumpTargetLocation.z) / 2);
            mesh.transform.localEulerAngles = new Vector3(0, 90, 0);
        }

        void JumpLeft()
        {
            if (gameIsPlaying == false)
                return;
            JumpTargetLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z - jumpDistanceZ);
            midWayPointX = JumpTargetLocation.z - ((JumpTargetLocation.z - this.transform.position.z) / 2);
            mesh.transform.localEulerAngles = new Vector3(0, -90, 0);
        }


        void ButtonStartPressed()
        {

            //  Debug.Log("button start pressed");
            gameIsPlaying = true;
            startPanel.SetActive(false);
        }


        void BringUpGameOverPanel()
        {
            gameOverPanel.SetActive(true);
        }

        void HideGameOverPanel()
        {
            gameOverPanel.SetActive(false);
        }
        /*  void HidemediumPanel()
          {
              MediumPanel.SetActive(false);
          }*/
        void HideGameStartPanel()
        {
            startPanel.SetActive(false);
        }

        void PlayAgain()
        {
            //   Debug.Log("play again button pressed");

            //Application.LoadLevel("LEVEL_1");


            SceneManager.LoadScene("LEVEL_1");
            PlayerPrefs.SetInt("reloaded", 1);
        //interstitialads.GetComponent<AdsManager2>().interstitial.Destroy();

        // ghost.GetComponent<GhostScript>().SendMessage("GameHasStarted");

    }
        void PlayerCharacterSelection()
        {
            SceneManager.LoadScene("Character_Selection");
        }
        void CharacterSelectedChicken()
        {
            Debug.Log("Chicken character has been selected");
            PlayerPrefs.SetInt("selectedCharacter", 0);
            SceneManager.LoadScene("LEVEL_1");
        }
        void CharacterSelectedChickenBrown()
        {
            Debug.Log("Chicken Brown character has been selected");
            PlayerPrefs.SetInt("selectedCharacter", 1);
            SceneManager.LoadScene("LEVEL_1");
        }
        void CharacterSelectedDuck()
        {
            Debug.Log("Duck character has been selected");
            PlayerPrefs.SetInt("selectedCharacter", 2);
            SceneManager.LoadScene("LEVEL_1");
        }
        void setSelectedCharacter()
        {
            int selectedCharactervalue = PlayerPrefs.GetInt("selectedCharacter");
            switch (selectedCharactervalue)
            {
                case 0:
                    character1.SetActive(true);
                    character2.SetActive(false);
                    character3.SetActive(false);
                    mesh = character1;
                    break;
                case 1:
                    character1.SetActive(false);
                    character2.SetActive(true);
                    character3.SetActive(false);
                    mesh = character2;
                    break;
                case 2:
                    character1.SetActive(false);
                    character2.SetActive(false);
                    character3.SetActive(true);
                    mesh = character3;
                    break;

            }
        }
        private void OnGUI()
        {
            scene = SceneManager.GetActiveScene();


        }
        public void OnApplicationQuit()
        {
            Application.Quit();

        }

        public void PauseGame()
        {
            if (isDead != true)
            {
                unpause.SetActive(true);
                pause.SetActive(false);
                Time.timeScale = 0;
                isPaused = true;
            }
        }
        public void ResumeGame()
        {
            unpause.SetActive(false);
            pause.SetActive(true);
            Time.timeScale = 1;
            isPaused = false;
        }


    }













