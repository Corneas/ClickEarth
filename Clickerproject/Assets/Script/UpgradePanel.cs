using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{



    [SerializeField]
    private Image starImage = null;
    [SerializeField]
    private Text starNameText = null;
    [SerializeField]
    private Text amountText = null;
    [SerializeField]
    private Text priceText = null;
    [SerializeField]
    private Button purchaseButton = null;
    [SerializeField]
    private Sprite[] starSprite = null;


    [SerializeField]
    private AudioClip clip;
    [SerializeField]
    private AudioClip buzz;

    private Star star = null;

    public int index = 0;

    public void SetValue(Star star)
    {
        this.star = star;
        UpdateValue();
    }

    public void UpdateValue()
    {
        starImage.sprite = starSprite[star.StarNumber];
        starNameText.text = star.starName;
        amountText.text = string.Format("{0}", star.amount);
        priceText.text = string.Format("{0} 별에너지", star.price > 10000 ? (star.price / 10000) + "A" : star.price.ToString());
        
    }

    public void OnClickPurchaseStar()
    {
        if(GameManager.Instance.CurrentUser.StarEnergy < star.price)
        {
            SoundManager.Instance.SFXPlay("Buzz", buzz);
            return;
        }


        SoundManager.Instance.SFXPlay("buy something", clip);

        GameManager.Instance.CurrentUser.StarEnergy -= star.price;
        star.amount++;

        
        switch(star.price / 10)
        {
            case 1: star.price = (long)(star.price + star.price * 0.157); break;
            case 2: star.price = (long)(star.price + star.price * 0.13); break;
            case 3: star.price = (long)(star.price + star.price * 0.12); break;
            default: star.price = (long)(star.price + star.price * 0.1); break;
        }

        star.sePs = (long)(star.sePs + star.sePs * 0.3 * 0.5);
        UpdateValue();
        GameManager.Instance.UI.UpdateStarEnergyPanel();
        GameManager.Instance.Star[index].SetActive(true);
    }

    

    


}
