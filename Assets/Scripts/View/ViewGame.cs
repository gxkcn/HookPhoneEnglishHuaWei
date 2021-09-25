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
        GameEnd,//游戏结尾，引爆所有水果用
        GamePause,
        GameWin,
        GameLose,
    }
    public GameState currentGameState = GameState.GameWait;
    public float timeWait, timePlay;

    public Button buttonPause;
    public Text textLevel, textTime;

    void Start()
    {
        buttonPause.onClick.AddListener(ClickPause);
    }

    /// <summary>
    /// 初始化游戏数据
    /// </summary>
    public void InitGame()
    {
        Debug.Log("ViewGame InitGame");
        SetGameState(GameState.GamePlay);
        timeWait = 0;
        timePlay = 0;
        textLevel.text = "Level " + (GameController.GetInstance().currentLevel + 1);
        textTime.text = "Time: " + timePlay + " S";
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
                    WinGame();
                    break;
            }
        }
    }


    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        if (ViewController.GetInstance().currentUIStep == ViewController.UIStep.Game)
        {
            switch (currentGameState)
            {
                case GameState.GameWait:
                    break;
                case GameState.GamePlay:
                    timePlay += Time.deltaTime;
                    textTime.text = "Time: " + ((int)timePlay) + " S";
                    if (timePlay > 2)
                    {
                        SetGameState(GameState.GameWin);
                    }
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
                default:
                    break;
            }
        }
    }


    /// <summary>
    /// 暂停按钮点击回调
    /// </summary>
    public void ClickPause()
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
        Clear();
        AudioManager.GetInstance().PlaySound(AudioManager.SoundGameLose);
        //ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.Lose, true);
        ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.Win, true, "", 0);
    }

    /// <summary>
    /// 游戏结束处理游戏逻辑
    /// </summary>
    public void Clear()
    {

    }
}
