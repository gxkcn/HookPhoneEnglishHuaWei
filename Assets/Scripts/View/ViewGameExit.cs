 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewGameExit : MonoBehaviour
{
    public Button ButtonYes;
    public Button ButtonNo;

    public GameObject imgBackRect;

    void Start()
    {
        ButtonYes.onClick.AddListener(ButtonYesClick);
        ButtonNo.onClick.AddListener(ButtonNoClick);
    }

    public void InitData()
    {
        imgBackRect.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        LeanTween.scale(imgBackRect, new Vector3(1, 1, 1), 0.1f).setLoopCount(1);
    }

    void ButtonYesClick()
    {
        if (ViewController.GetInstance().currentUIStep == ViewController.UIStep.ExitPanel)
        {
            LocalData.GetInstance().SaveLocalData();
            
            AudioManager.GetInstance().PlaySound(AudioManager.SoundButtonClick);
            Application.Quit();
        }
    }
    void ButtonNoClick()
    {
        if (ViewController.GetInstance().currentUIStep == ViewController.UIStep.ExitPanel)
        {
            AudioManager.GetInstance().PlaySound(AudioManager.SoundButtonClick);
            ViewController.GetInstance().currentUIStep = ViewController.UIStep.Menu;
            ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.ExitPanel, false);            
        }
    }
}
