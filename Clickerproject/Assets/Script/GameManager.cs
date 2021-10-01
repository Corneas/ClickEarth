using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField]
    public GameObject[] Star = new GameObject[9];
    [SerializeField]
    private User user = null;

    public User CurrentUser { get { return user; } }

    public UpgradePanel upgradePanel;

    private UIManager uiManager = null;
    public UIManager UI
    {
        get
        {
            if(uiManager == null)
            {
                uiManager = GetComponent<UIManager>();
            }
            return uiManager;
        }
    }

    private Canvas canvas = null;

    public Canvas Canvas
    {
        get
        {
            if(canvas == null)
            {
                canvas = FindObjectOfType<Canvas>();
            }
            return canvas;
        }
    }

    [SerializeField]
    private Transform poolManager = null;
    public Transform Pool {  get { return poolManager; } }

    private string SAVE_PATH = "";
    private string SAVE_FILENAME = "/SaveFile.txt";

    private void Awake()
    {
        SAVE_PATH = Application.persistentDataPath + "/Save";
        if (!Directory.Exists(SAVE_PATH))
        {
            Directory.CreateDirectory(SAVE_PATH);
        }

        LoadFromJson();
    }

    void Start()
    {
        InvokeRepeating("SaveToJson", 1f, 60f);
        InvokeRepeating("EarnStarEnergyPerSecond", 0f, 1f);
    }

    public void EarnStarEnergyPerSecond()
    {
        foreach(Star star in user.starList)
        {
            user.StarEnergy += star.sePs * star.amount;
        }
        UI.UpdateStarEnergyPanel();
    }


    private void LoadFromJson()
    {
        if(File.Exists(SAVE_PATH + SAVE_FILENAME))
        {
            string json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME);
            user = JsonUtility.FromJson<User>(json);
        }
    }

    private void SaveToJson()
    {
        string json = JsonUtility.ToJson(user, true);
        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8);


    }

    private void OnApplicationQuit()
    {
        SaveToJson();
    }


}
