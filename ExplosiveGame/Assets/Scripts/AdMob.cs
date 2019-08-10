﻿using UnityEngine;
using GoogleMobileAds.Api;
using System;
public class AdMob : MonoBehaviour
{
    public static AdMob reference;

    InterstitialAd interstitialAd;
    string interstitialId= "ca-app-pub-3940256099942544/1033173712";

    BannerView bannerAd;
    string bannerAddID = "ca-app-pub-3940256099942544/6300978111";

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (reference == null)
        {
            reference = this;
        }else{
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        requestInterstitialAd();
        requestBannerAd();
    }
    
    void requestBannerAd()
    {
        bannerAd = new BannerView(bannerAddID, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        bannerAd.OnAdLoaded += On_BannerLoad;
        bannerAd.LoadAd(request);
    }
    public void HideBanner()
    {
        bannerAd.Hide();
    }

    public void ShowBanner()
    {
        bannerAd.Show();
    }

    public void showInterstitalAd()
    {
        if (interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
            Debug.Log("Yay");
        }
    }

    void requestInterstitialAd()
    {
        interstitialAd = new InterstitialAd(interstitialId);

        interstitialAd.OnAdClosed += On_InterstitialAddClosed;
        AdRequest request = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(request);
    }

    private void On_InterstitialAddClosed(object sender, EventArgs e)
    {
        requestInterstitialAd();
    }

    private void On_BannerLoad(object sender, EventArgs e)
    {
        bannerAd.Show();
    }
}
