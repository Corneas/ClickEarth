using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text starEnergyText = null;
    [SerializeField]
    private Animator earthAnimator = null;
    [SerializeField]
    private GameObject upgradePanelTemplate = null;
    [SerializeField]
    private StarEnergyText starEnergyTextTemplate = null;
    [SerializeField]
    private AudioClip clip;

    private List<UpgradePanel> upgradePanelList = new List<UpgradePanel>();

    void Start()
    {
        UpdateStarEnergyPanel();
        CreatePanels();
    }

    private void CreatePanels()
    {
        GameObject newPanel = null;
        UpgradePanel newPanelComponent = null;

        int i = 0;
        foreach(Star star in GameManager.Instance.CurrentUser.starList)
        {
            newPanel = Instantiate(upgradePanelTemplate, upgradePanelTemplate.transform.parent);
            newPanelComponent = newPanel.GetComponent<UpgradePanel>();
            newPanelComponent.SetValue(star);
            newPanelComponent.index = i;
            newPanel.SetActive(true);
            upgradePanelList.Add(newPanelComponent);
            i++;
        }
    }       


    public void OnClickStar()
    {
        SoundManager.Instance.SFXPlay("click earth", clip);
        GameManager.Instance.CurrentUser.StarEnergy++;
        earthAnimator.Play("Earth_Click");
        

        StarEnergyText newText = null;
        if(GameManager.Instance.Pool.childCount > 0)
        {
            newText = GameManager.Instance.Pool.GetChild(0).GetComponent<StarEnergyText>();
        }
        else
        {
            newText = Instantiate(starEnergyTextTemplate, GameManager.Instance.Canvas.transform);
        }

        newText.Show(Input.mousePosition);
        UpdateStarEnergyPanel();
    }

    public void UpdateStarEnergyPanel()
    {
        long starEnergy = GameManager.Instance.CurrentUser.StarEnergy;
        starEnergyText.text = string.Format("{0} 별에너지", starEnergy > 10000 ? $"{starEnergy / 10000}A" : starEnergy.ToString());
        
    }

    


}
