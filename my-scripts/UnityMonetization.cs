using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityMonetization : MonoBehaviour
{
    string GooglePlay_ID = "3877823";
    //bool testMode = false;
    private string interstitialAd = "video";
    public bool istargetPlayStore;
    public bool isTestAd = false;
    // Start is called before the first frame update
    void Start()
    {
        // Advertisement.Initialize(GooglePlay_ID, testMode);
        InitializeAd();
    }

    // Update is called once per frame
    public void DsiplayInterstitialAD()
    {
        //Advertisement.Show();
        if(!Advertisement.IsReady(interstitialAd))
        {
            return;
        }
        Advertisement.Show(interstitialAd);
    }
    public void InitializeAd()
    {
        if (istargetPlayStore)
        {
            Advertisement.Initialize(GooglePlay_ID, isTestAd);
            return;
        }
    }

    
}
