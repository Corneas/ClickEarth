using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Canvas;
    [SerializeField]
    private GameObject SettingButton;
    [SerializeField]
    private GameObject Clicker;
    [SerializeField]
    private AudioClip clip;

    void Awake()
    {
        Canvas = GameObject.Find("Canvas");
        SettingButton = GameObject.Find("Setting");
        Clicker = GameObject.Find("Clicker");
    }

    void Start()
    {
        Canvas.SetActive(true);
        SettingButton.SetActive(false);
    }

    public void GameExit()
    {
        SoundManager.Instance.SFXPlay("Click button", clip);
        Application.Quit();
        Debug.Log("Exit");
    }

    public void Setting()
    {
        SoundManager.Instance.SFXPlay("Click button", clip);
        Time.timeScale = 0;
        if (Clicker) Clicker.SetActive(false);
        if (SettingButton) SettingButton.SetActive(true);
     }

    public void Back()
    {
        SoundManager.Instance.SFXPlay("Click button", clip);
        Time.timeScale = 1;
        if (Clicker) Clicker.SetActive(true);
        if (SettingButton) SettingButton.SetActive(false);
    }
}
