using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 游戏页面
/// </summary>
public class ViewGame : MonoBehaviour
{
    public enum GameState
    {
        GameWait,//暂停等待-进入第三方界面的时候使用
        GamePlay,
        GameEnd,//游戏结尾，慢镜头等特殊结尾处理
        GamePause,
        GameWin,
        GameLose,
    }
    public GameState currentGameState = GameState.GameWait;
    public float timeWait, timePlay;

    public Button buttonPause;
    public Text textLevel, textTime;

    public int numLife;
    public Image[] imageLife;

    public GameMapControl mapCon;

    public bool soundMovePlaying;

    void Start()
    {
        buttonPause.onClick.AddListener(ClickPause);
        InitGame();
    }

    /// <summary>
    /// 初始化游戏数据
    /// </summary>
    public void InitGame()
    {
        GameController.GetInstance().currentLevel = 13;
        Debug.Log("ViewGame InitGame");
        SetGameState(GameState.GamePlay);
        timeWait = 0;
        timePlay = 0;
        textLevel.text = "Level " + (GameController.GetInstance().currentLevel + 1);
        textTime.text = "Time: " + timePlay + " S";
        numLife = 0;
        imageLife[0].gameObject.SetActive(false);
        imageLife[1].gameObject.SetActive(false);
        imageLife[2].gameObject.SetActive(false);
        if (GameController.GetInstance().currentLevel >= 40)
        {
            numLife = 3;
            for (int i = 0; i < numLife; i++)
            {
                imageLife[i].gameObject.SetActive(true);
            }
        }

        GameController.GetInstance().playLevelTimes[GameController.GetInstance().currentLevel]++;
        mapCon.InitData();

        soundMovePlaying = false;
    }


    /// <summary>
    /// 切换游戏状态
    /// </summary>
    /// <param name="_state"></param>
    public void SetGameState(GameState _state)
    {
        if (currentGameState != _state)
        {
            currentGameState = _state;
            switch (currentGameState)
            {
                case GameState.GameWait:
                    break;
                case GameState.GamePlay:
                    break;
                case GameState.GameEnd:
                    break;
                case GameState.GamePause:
                    PauseGame();
                    break;
                case GameState.GameWin:
                    WinGame();
                    break;
                case GameState.GameLose:
                    LoseGame();
                    break;
            }
        }
    }


    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        //if (ViewController.GetInstance().currentUIStep == ViewController.UIStep.Game)
        //{
        switch (currentGameState)
        {
            case GameState.GameWait:
                break;
            case GameState.GamePlay:
                timePlay += Time.deltaTime;
                textTime.text = "Time: " + ((int)timePlay) + " S";
                //if (timePlay > 5)
                //{
                //    SetGameState(GameState.GameWin);
                //}
                break;
            case GameState.GameEnd:
                break;
            case GameState.GamePause:
                break;
            case GameState.GameWin:
                break;
            case GameState.GameLose:
                break;
            default:
                break;
        }
        //}
    }


    /// <summary>
    /// 暂停按钮点击回调
    /// </summary>
    private void ClickPause()
    {
        AudioManager.GetInstance().PlaySound(AudioManager.SoundButtonClick);
        SetGameState(GameState.GamePause);
    }


    /// <summary>
    /// 暂停游戏
    /// </summary>
    private void PauseGame()
    {
        //处理游戏逻辑 

        ViewController.GetInstance().pausePanel.GetComponent<ViewPause>().upState = GameState.GamePlay;
        //UI
        ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.Pause, true);
        AudioManager.GetInstance().StopMusic();
    }

    /// <summary>
    /// 游戏胜利
    /// </summary>
    private void WinGame()
    {
        Clear();
        AudioManager.GetInstance().PlaySound(AudioManager.SoundGameWin);
        ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.Win, true, "", 1);
    }

    /// <summary>
    /// 游戏失败
    /// </summary>
    private void LoseGame()
    {
        //Clear();
        ////AudioManager.GetInstance().PlaySound(AudioManager.SoundGameLose);
        ////ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.Lose, true);
        //ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.Win, true, "", 0);

        Invoke("DelayLose",0.5f);
    }

    private void DelayLose()
    {
        Clear();
        //AudioManager.GetInstance().PlaySound(AudioManager.SoundGameLose);
        //ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.Lose, true);
        ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.Win, true, "", 0);
    }

    /// <summary>
    /// 游戏结束处理游戏逻辑
    /// </summary>
    public void Clear()
    {

    }

    //=======================================================data function==================================================
    /// <summary>
    /// 生命减少
    /// </summary>
    public void LifeSubtract()
    {        
        //numLife--;
        //for (int i = 0; i < numLife; i++)
        //{
        //    imageLife[i].gameObject.SetActive(true);
        //}
        //if (numLife < 0)
        //{
        //    SetGameState(GameState.GameLose);
        //}
    }

    //=======================================================function==================================================
    ///// <summary>
    ///// 按钮按下后开始激活相联的细线
    ///// </summary>
    ///// <param name="_index"></param>
    ///// <param name="_type">1:细线  </param>
    //public void StartJh(int _index,string _tag)
    //{
    //    Debug.Log("-------------------viewgame start jh " + _index+" _tag = "+_tag);
    //    mapCon.StartJh(_index,_tag);
    //}

    /// <summary>
    /// 粗线消失后从挡板开始检测消失
    /// </summary>
    /// <param name="_index"></param>
    /// <param name="_type">1:细线  </param>
    public void StartHide(int _index, string _tag)
    {
        Debug.Log("-------------------viewgame Start Hide " + _index);
        mapCon.StartHideDb(_index, _tag);
    }

    public void PlayMoveSound()
    {
        if (soundMovePlaying == false)
        {
            soundMovePlaying = true;
            AudioManager.GetInstance().PlaySound(AudioManager.SoundMove0);
        }
    }
    public void StopMoveSound()
    {
        if (soundMovePlaying)
        {
            soundMovePlaying = false;
            AudioManager.GetInstance().StopSound();
            AudioManager.GetInstance().PlaySound(AudioManager.SoundGameLose);
        }
    }
}
