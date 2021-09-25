using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 失败页面
/// </summary>
public class ViewLose : MonoBehaviour
{
    public Button buttonRestart, buttonShop, buttonReturn, buttonBox;

    public Text textScoreMax, textScore, textCoin;

    public GameObject imgScoreBest;

    public GameObject objBox, imgBox0, imgBox1;

    public GameObject imgBackRect;

    // Use this for initialization
    void Start()
    {
        buttonRestart.onClick.AddListener(ClickORestart);
        buttonShop.onClick.AddListener(ClickShop);
        buttonReturn.onClick.AddListener(ClickReturn);
        buttonBox.onClick.AddListener(ClickBox);
    }

    /// <summary>
    /// 初始化结束界面数据
    /// </summary>
    public void InitData()
    {
        

        //保存本地数据
        LocalData.GetInstance().SaveLocalData();
        AudioManager.GetInstance().PlaySound(AudioManager.SoundGameLose);

        imgBackRect.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        LeanTween.scale(imgBackRect, new Vector3(1, 1, 1), 0.1f).setLoopCount(1);
        Invoke("ShowBox", 0.2f);
    }

    public void ShowBox()
    {
        LocalData.GetInstance().playTimePerDay++;
        objBox.SetActive(LocalData.GetInstance().playTimePerDay == 1 ? true : false);
    }

    private void ClickORestart()
    {
        if (ViewController.GetInstance().currentUIStep == ViewController.UIStep.Lose)
        {
            AudioManager.GetInstance().PlaySound(AudioManager.SoundButtonClick);
            ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.Lose, false);
            ViewController.GetInstance().game.GetComponent<ViewGame>().InitGame();
            ViewController.GetInstance().currentUIStep = ViewController.UIStep.Game;
        }
    }

    private void ClickShop()
    {
        if (ViewController.GetInstance().currentUIStep == ViewController.UIStep.Lose)
        {
            AudioManager.GetInstance().PlaySound(AudioManager.SoundButtonClick);
            ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.Shop, true);
            ViewController.GetInstance().shopPanel.GetComponent<ViewShop>().nextStep = ViewController.UIStep.Lose;
        }
    }

    private void ClickReturn()
    {
        if (ViewController.GetInstance().currentUIStep == ViewController.UIStep.Lose)
        {
            AudioManager.GetInstance().PlaySound(AudioManager.SoundButtonClick);
            ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.Lose, false);
            ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.Game, false);
            ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.SelectLevel, true);
            AudioManager.GetInstance().PlayMusic(AudioManager.MusicUI);
        }
    }

    private void ClickBox()
    {
        if (ViewController.GetInstance().currentUIStep == ViewController.UIStep.Lose)
        {
            AudioManager.GetInstance().PlaySound(AudioManager.SoundButtonClick);

            if (imgBox0.activeSelf)
            {
                imgBox0.SetActive(false);
                imgBox1.SetActive(true);
                LocalData.GetInstance().SetGold(200);
                ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.TipsPanel,
                   true, "Congratulations on the first victory of the day Gold X 200");
            }
            else
            {
                ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.TipsPanel,
                   true, "Box has opened");
            }
        }
    }

    void Update()
    {

    }
}
