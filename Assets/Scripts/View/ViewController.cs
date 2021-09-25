using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// UI管理类,用来控制UI面板的显示和隐藏
/// </summary>
public class ViewController : MonoBehaviour
{
    public static ViewController instance;
        
    /// <summary>
    /// UI页面
    /// </summary>
    public enum UIStep
    {
        Menu,
        ExitPanel,
        SelectLevel,
        SelectMap,
        TipsPanel,
        Game,
        Pause,
        Win,
        Lose,
        Shop,
    }

    /// <summary>
    /// 当前UI页面
    /// </summary>
    public UIStep currentUIStep = UIStep.SelectLevel;

    public GameObject startMenu;
    public GameObject exitPanel;
    public GameObject selectLevel;
    public GameObject selectMap;
    public GameObject game;
    public GameObject tipsPanel;
    public GameObject pausePanel;
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject shopPanel;

    public HandController hand;

    public float timePlay = 0;

    public static ViewController GetInstance()
    {
        return instance;
    }
    
    private void Awake()
    {
        instance = this;
        LocalData.GetInstance().LoadLocalData();
    }
        
    void Start()
    {
        currentUIStep = UIStep.Menu;
    }

    /// <summary>
    /// 显示/隐藏页面
    /// </summary>
    /// <param name="_isShow">显示true；隐藏false</param>
    /// <param name="_ext1">扩展参数1</param>
    public void ShowOrHideUI(UIStep _step, bool _isShow,string _ext1=null,int _ext2=0)
    {
        switch( _step)
        {
            case UIStep.Menu:
                startMenu.SetActive(_isShow);
                break;
            case UIStep.ExitPanel:
                //startMenu.transform.Find("ExitPanel").gameObject.SetActive(_isShow);
                exitPanel.SetActive(_isShow);
                if(_isShow)
                {
                    exitPanel.GetComponent<ViewGameExit>().InitData();
                }
                break;
            case UIStep.SelectLevel:
                selectLevel.SetActive(_isShow);
                if( _isShow)
                {
                    selectLevel.GetComponent<ViewSelect>().InitData();
                }                
                break;
            case UIStep.SelectMap:
                selectMap.SetActive(_isShow);
                if (_isShow)
                {
                    selectMap.GetComponent<ViewSelectMap>().InitData();
                }
                break;
            case UIStep.TipsPanel:
                tipsPanel.SetActive(_isShow);
                if(_isShow)
                {
                    tipsPanel.GetComponent<TipsPanel>().InitBaseData(_ext1, currentUIStep);
                }                
                break;
            case UIStep.Game:
                game.SetActive(_isShow);
                if (_isShow)
                {
                    GameController.GetInstance().InitGameData();
                    game.GetComponent<ViewGame>().InitGame();                    
                }
                else
                {
                    AudioManager.GetInstance().PlayMusic(AudioManager.MusicUI);
                }              
                break;
            case UIStep.Pause:
                pausePanel.SetActive(_isShow);
                break;
            case UIStep.Win:
                winPanel.SetActive(_isShow);
                if (_isShow)
                {
                    winPanel.GetComponent<ViewWin>().InitData(_ext2);
                }
                break;
            case UIStep.Lose:
                losePanel.SetActive(_isShow);
                if (_isShow)
                {
                    losePanel.GetComponent<ViewLose>().InitData();
                }
                break;
            case UIStep.Shop:
                shopPanel.SetActive(_isShow);
                if (_isShow)
                {
                    shopPanel.GetComponent<ViewShop>().InitDataShop(0);
                }                    
                break;
        }
        if( _isShow)
        {
            currentUIStep = _step;
        }
        //Invoke("InitHandPosition", 0.1f);
        if (_step != UIStep.TipsPanel )
        {
            hand.GetComponent<HandController>().InitHandIndex();
        }
        
    }

    //private void InitHandPosition()
    //{
    //    hand.GetComponent<HandController>().InitHandIndex();
    //}

    private void Update()
    {
        timePlay = System.DateTime.Now.Hour * 3600 + System.DateTime.Now.Minute * 60 + System.DateTime.Now.Second -
        LocalData.GetInstance().loginHour * 3600 -
        LocalData.GetInstance().loginMinute * 60 - LocalData.GetInstance().loginS;

        //Debug.Log("0="+timePlay);
        //Debug.Log("1=" + System.DateTime.Now.Hour);
        //Debug.Log("2=" + System.DateTime.Now.Minute);
        //Debug.Log("3=" + System.DateTime.Now.Second);
        //Debug.Log("4=" + LocalData.GetInstance().loginHour);
        //Debug.Log("5=" + LocalData.GetInstance().loginMinute);
        //Debug.Log("6=" + LocalData.GetInstance().loginS);
        if (timePlay > 300)
        {
            timePlay = 300;
        }
    }
}
