using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class ViewMenu : MonoBehaviour {
    public Button buttonStart;
    public Button buttonSound;
    public Button buttonExit;

    public Image ImageSound;
    public Sprite[] spriteSound;

    private void Awake()
    {

    }

    
    void Start()
    {
        buttonStart.onClick.AddListener(StartClick);
        buttonSound.onClick.AddListener(SoundClick);
        buttonExit.onClick.AddListener(ExitClick);
        AudioManager.GetInstance().soundState = 1;
        ImageSound.sprite = spriteSound[AudioManager.GetInstance().soundState];
        //LeanTween.scale(buttonStart.gameObject, new Vector3(1.1f, 1.1f, 1.1f), 1.3f).setLoopPingPong();
              
    }    
       
    void StartClick()
    {
        if (ViewController.GetInstance().currentUIStep == ViewController.UIStep.Menu)
        {
            AudioManager.GetInstance().PlaySound(AudioManager.SoundButtonClick);

            ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.Menu, false);
            ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.SelectLevel, true);
                      
        }
    }
    void SoundClick()
    {
        if (ViewController.GetInstance().currentUIStep == ViewController.UIStep.Menu)
        {
            AudioManager.GetInstance().PlaySound(AudioManager.SoundButtonClick);
            AudioManager.GetInstance().SetSoundState(AudioManager.GetInstance().soundState == 1 ? 0 : 1);
            ImageSound.sprite = spriteSound[AudioManager.GetInstance().soundState];
        }
    }
    void ExitClick()
    {
        if (ViewController.GetInstance().currentUIStep == ViewController.UIStep.Menu)
        {
            LocalData.GetInstance().SaveLocalData();
            AudioManager.GetInstance().PlaySound(AudioManager.SoundButtonClick);
            ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.ExitPanel, true);
        }
    }

}
