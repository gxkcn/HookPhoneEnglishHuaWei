using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 胜利页面
/// </summary>
public class ViewWin : MonoBehaviour
{
    private int type;
    public Button buttonRe, buttonBack;

    private float timeUpdate;

    public GameObject objRect;
    public Text textTitle;

    private int numStar;

    public Image imageStar0, imageStar1, imageStar2;

    public Text textTime;

    public Text textButton0;
    void Start()
    {
        buttonRe.onClick.AddListener(ClickRestart);
        buttonBack.onClick.AddListener(ClickReturn);
    }

    /// <summary>
    /// 初始化结束界面数据
    /// </summary>
    public void InitData(int _ext2)
    {
        Debug.Log("ViewWin InitData"+_ext2);
        type = _ext2;
        timeUpdate = 0;
        textTitle.text = type == 1 ? "Game Win" : "Game Lose";
        textTime.text = "Time: " + (int)ViewController.GetInstance().game.GetComponent<ViewGame>().timePlay + " S";
        textButton0.text = type == 0 ? "Replay" : "Continue";
                
        if (type == 1)
        {
            if(GameController.GetInstance().currentLevel == 49)
            {
                textButton0.text ="Replay" ;
            }
            int _time = (int)ViewController.GetInstance().game.GetComponent<ViewGame>().timePlay;
            int _timeMin = 10+GameController.GetInstance().currentLevel*5;
            numStar = 1;
            if (_time <= _timeMin)
            {
                numStar = 3;
            }
            else if (_time <= _timeMin * 1.5F)
            {
                numStar = 2;
            }
            if (LocalData.GetInstance().levelStar[GameController.GetInstance().currentLevel] < numStar)
            {
                LocalData.GetInstance().levelStar[GameController.GetInstance().currentLevel] = numStar;
            }
            imageStar0.gameObject.SetActive(false);
            imageStar1.gameObject.SetActive(false);
            imageStar2.gameObject.SetActive(false);

            if(GameController.GetInstance().currentLevel+1== LocalData.GetInstance().levelCurMax)
            {
                LocalData.GetInstance().levelCurMax++;
                if (LocalData.GetInstance().levelCurMax > 50)
                {
                    LocalData.GetInstance().levelCurMax = 50;
                }
            }
        }else{
imageStar0.gameObject.SetActive(false);
            imageStar1.gameObject.SetActive(false);
            imageStar2.gameObject.SetActive(false);
}
        objRect.transform.localScale = Vector3.one * .2f;
        LeanTween.scale(objRect, Vector3.one, 0.2f).setLoopCount(1);
        //保存本地数据
       
        LocalData.GetInstance().SaveLocalData();
        AudioManager.GetInstance().StopMusic();
    }

    private void Update()
    {
        if (ViewController.GetInstance().currentUIStep == ViewController.UIStep.Win)
        {
            if (type == 1)
            {
                timeUpdate += Time.deltaTime;
                if (numStar > 0)
                {
                    if (timeUpdate > 0.2f)
                    {
                        if (imageStar0.gameObject.activeSelf == false)
                        {
                            imageStar0.gameObject.SetActive(true);
                            imageStar0.transform.localScale = Vector3.one * 4;
                            LeanTween.scale(imageStar0.gameObject, Vector3.one*0.9f, 0.2f).setLoopCount(1);
                        }
                    }                        
                }
                if (numStar > 1)
                {
                    if (timeUpdate > 0.4f)
                    {
                        if (imageStar1.gameObject.activeSelf == false)
                        {
                            imageStar1.gameObject.SetActive(true);
                            imageStar1.transform.localScale = Vector3.one * 4;
                            LeanTween.scale(imageStar1.gameObject, Vector3.one, 0.2f).setLoopCount(1);
                        }
                    }
                }
                if (numStar > 2)
                {
                    if (timeUpdate > 0.6f)
                    {
                        if (imageStar2.gameObject.activeSelf == false)
                        {
                            imageStar2.gameObject.SetActive(true);
                            imageStar2.transform.localScale = Vector3.one * 4;
                            LeanTween.scale(imageStar2.gameObject, Vector3.one * 0.9f, 0.2f).setLoopCount(1);
                        }
                    }
                }
            }
        }
    }

    private void ClickRestart()
    {
        if (ViewController.GetInstance().currentUIStep == ViewController.UIStep.Win)
        {
            AudioManager.GetInstance().PlaySound(AudioManager.SoundButtonClick);
            ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.Win, false);

            if (type == 1)
            {
                GameController.GetInstance().currentLevel++;
                if (GameController.GetInstance().currentLevel > 49)
                {
                    GameController.GetInstance().currentLevel = 49;
                }
            }
            GameController.GetInstance().InitGameData();
            ViewController.GetInstance().game.GetComponent<ViewGame>().InitGame();
            ViewController.GetInstance().currentUIStep = ViewController.UIStep.Game;
            ViewController.GetInstance().hand.InitHandIndex();
        }
    }

    private void ClickReturn()
    {
        if (ViewController.GetInstance().currentUIStep == ViewController.UIStep.Win)
        {
            AudioManager.GetInstance().PlaySound(AudioManager.SoundButtonClick);
            ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.Win, false);
            ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.Game, false);
            ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.SelectLevel, true);
            AudioManager.GetInstance().PlayMusic(AudioManager.MusicUI);
        }
    }

}
