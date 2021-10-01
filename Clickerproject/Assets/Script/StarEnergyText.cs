using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StarEnergyText : MonoBehaviour
{
    private Text energyText = null;

    public void Show(Vector2 mousePosition)
    {
        energyText = GetComponent<Text>();
        energyText.text = string.Format("+{0}", 1);

        energyText.gameObject.SetActive(true); 
        energyText.transform.SetParent(GameManager.Instance.Canvas.transform);
        energyText.transform.position = Camera.main.ScreenToWorldPoint(mousePosition); 
        energyText.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

        RectTransform rectTransform = GetComponent<RectTransform>();
        float targetPositionY = rectTransform.anchoredPosition.y + 100f;

        energyText.DOFade(0f, 0.5f).OnComplete(() => Despawn());
        rectTransform.DOAnchorPosY(targetPositionY, 0.5f);
    }

    private void Despawn()
    {
        energyText.DOFade(1f, 0f);
        transform.SetParent(GameManager.Instance.Pool);
        gameObject.SetActive(false);
    }




}
