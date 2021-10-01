using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    private GameObject UpgradeScroll;
    [SerializeField]
    private GameObject BackButton;
    [SerializeField]
    private AudioClip clip;

    void Awake()
    {
        UpgradeScroll = GameObject.Find("UpgradeScroll");
        BackButton = GameObject.Find("BackButton");
    }

    void Start()
    {
        UpgradeScroll.SetActive(false);
        BackButton.SetActive(false);
    }

    public void ClickShop()
    {
        SoundManager.Instance.SFXPlay("Click button", clip);
        if (UpgradeScroll) UpgradeScroll.SetActive(true);
        if (BackButton) BackButton.SetActive(true);
    }

    public void Back()
    { 
        SoundManager.Instance.SFXPlay("Click button", clip);
        Start();
    }

}
