using UnityEngine;
using System.Collections;

public class GameController
{
    private static GameController instance = null;
    /// 是否是测试版本
    public static bool DEBUG = false;
    /// 是否是手机版本
    public static bool PHONE_VERSION = true;

    //================================================================游戏关卡数据变量===============================================================
    /// <summary>
    /// 当前进入的关卡
    /// </summary>
    public int currentLevel = 0;
 




    //================================================================游戏关卡数据变量===============================================================
    public static GameController GetInstance()
    {
        if( instance == null)
        {
            instance = new GameController();
        }
        return instance;
    }
    

    /// <summary>
    /// 初始化游戏数据
    /// </summary>
    public void InitGameData()
    {       
        AudioManager.GetInstance().PlayMusic(AudioManager.MusicGame0);



    }
}
