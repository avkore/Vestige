using UnityEngine;
using DG.Tweening;

[System.Serializable]
public class PanelAnimator
{
    public CanvasGroup canvasGroup;
    public RectTransform rect;
    public float fadeTime = 0.5f;
    public float posY = -1000f;
    public float posX = -100f;
    private Vector3 startPos = Vector3.zero;
    
    public void FadeInPanel()
    {
        if(startPos == Vector3.zero)
            startPos = rect.transform.localPosition;
        
        canvasGroup.alpha = 0f;
        rect.transform.localPosition = new Vector3(startPos.x, posY, startPos.z);
        rect.transform.DOLocalMoveY(startPos.y, fadeTime).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1f, fadeTime);
    }

    public void FadeOutPanel()
    {
        canvasGroup.alpha = 1f;
        rect.transform.localPosition = new Vector3(startPos.x, startPos.y, startPos.z);
        rect.transform.DOLocalMoveY(posY, fadeTime).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(0f, fadeTime);
    }

    public void MoveLeft()
    {
        Vector3 targetPosition = new Vector3(posX, rect.localPosition.y, rect.localPosition.z);
        rect.DOLocalMove(targetPosition, fadeTime).SetEase(Ease.OutElastic);
    }

    public void MoveRight()
    {
        Vector3 targetPosition = new Vector3(startPos.x, rect.localPosition.y, rect.localPosition.z);
        rect.DOLocalMove(targetPosition, fadeTime).SetEase(Ease.OutElastic);
    }

}