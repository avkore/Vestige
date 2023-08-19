using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class MenuManager : MonoBehaviour
{
    public Button playBtn;
    public Button settingsBtn;
    public Button exitBtn;
    public Button musicOnOff;
    public Button soundOnOff;
    public Button settingsClose;
    
    public Sprite[] toggles;
    
    public PanelAnimator uiManagerSettings;
    public PanelAnimator uiManagerMenu;
    
    private bool isSettingsOpen = false;
    
    private void Start()
    {
        playBtn.onClick.AddListener(() => GameManager.Instance.LoadGameScene());
        settingsBtn.onClick.AddListener(() => OpenPanel(true, uiManagerSettings, ref isSettingsOpen));
        exitBtn.onClick.AddListener(() => GameManager.Instance.ExitGame());
        
        settingsClose.onClick.AddListener(() => OpenPanel(false, uiManagerSettings, ref isSettingsOpen));

        musicOnOff.onClick.AddListener(() => ToggleMusic(musicOnOff));
        soundOnOff.onClick.AddListener(() => ToggleMusic(soundOnOff));
    }
    
    public void OpenPanel(bool flag, PanelAnimator uiManager, ref bool isPanelOpen)
    {
        if(flag && isSettingsOpen)
            return;
        if(flag)
        {
            uiManagerMenu.MoveLeft();
            uiManager.FadeInPanel();
            uiManager.canvasGroup.interactable = true;
            uiManager.canvasGroup.blocksRaycasts = true;
            isPanelOpen = true;
        }
        else
        {
            uiManagerMenu.MoveRight();
            uiManager.FadeOutPanel();
            uiManager.canvasGroup.interactable = false;
            uiManager.canvasGroup.blocksRaycasts = false;
            isPanelOpen = false;
        }        
    }
    
    public void ToggleMusic(Button button)
    {
        Image image = button.GetComponent<Image>();
        var currentSprite = image.sprite;
        if(currentSprite == toggles[0])
        {
             image.sprite = toggles[1];
             if(button == musicOnOff)
                 AudioManager.Instance.TurnOffAudio(false);
             else if(button == soundOnOff)
                 AudioManager.Instance.TurnOffSounds(false);
        }
           
        else
        {
            image.sprite = toggles[0];
            if(button == musicOnOff)
                 AudioManager.Instance.TurnOffAudio(true);
            else if(button == soundOnOff)
                AudioManager.Instance.TurnOffSounds(true);
        }
    }

}
