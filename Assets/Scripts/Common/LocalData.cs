using UnityEngine;
using System.Collections;

/// <summary>
/// 数据本地永久存储类
/// </summary>
public class LocalData
{
    private static LocalData instance = null;

    public static LocalData GetInstance()
    {
        if (instance == null)
        {
            instance = new LocalData();
        }
        return instance;
    }

    /// <summary>
    /// 金币
    /// </summary>
    public int Gold = 0;
    /// <summary>
    /// 登录游戏的日期
    /// </summary>
    private string loginDatePerDay = "0000:00:00";
    /// <summary>
    /// 每天打开游戏的次数
    /// </summary>
    public int playTimePerDay = 0;
    /// <summary>
    /// 登录游戏的天数
    /// </summary>
    public int loginTimes = 0;
    /// <summary>
    /// 开启的最大关卡数
    /// </summary>
    public int levelCurMax = 1;
    /// <summary>
    /// 关卡星级
    /// </summary>
    public int[] levelStar = { 0,0,0,0,0,0,0,0,0,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
   /// <summary>
   /// 登录游戏的具体时间
   /// </summary>
    public int loginHour = 0;
    public int loginMinute = 0;
    public int loginS = 0;

    
    //==================================================load-save================================================================
    /// <summary>
    /// 保存数据到本地
    /// </summary>
    public void SaveLocalData()
    {
        Debug.Log("保存游戏数据");
        PlayerPrefs.SetInt("gold", Gold);
        PlayerPrefs.SetInt("playTimePerDay", playTimePerDay);
        PlayerPrefs.SetString("loginDatePerDay", loginDatePerDay);
        Tools.SavePlayerPrefsArray("levelStar", levelStar);
        PlayerPrefs.SetInt("loginTimes", loginTimes);
        PlayerPrefs.SetInt("levelCurMax", levelCurMax);


        PlayerPrefs.Save();
    }
    /// <summary>
    /// 存储离线时间
    /// </summary>
    public void SaveLocalDataOffTime()
    {
        Debug.Log("保存游戏数据  离线时间");
        loginHour = System.DateTime.Now.Hour;
        loginMinute = System.DateTime.Now.Minute;
        loginS = System.DateTime.Now.Second;
        PlayerPrefs.SetInt("loginHour", loginHour);
        PlayerPrefs.SetInt("loginMinute", loginMinute);
        PlayerPrefs.SetInt("loginS", loginS);
        PlayerPrefs.Save();
    }

    public int test = 0;

    /// <summary>
    /// 加载本地数据
    /// 
    /// </summary>
    public void LoadLocalData()
    {
        Debug.Log("加载游戏数据");
        Gold = PlayerPrefs.GetInt("gold", Gold);
        playTimePerDay = PlayerPrefs.GetInt("playTimePerDay", playTimePerDay);
        levelStar = Tools.LoadPlayerPrefsArray("levelStar", levelStar);
        loginTimes = PlayerPrefs.GetInt("loginTimes", loginTimes);
        loginDatePerDay = PlayerPrefs.GetString("loginDatePerDay", loginDatePerDay);
        levelCurMax = PlayerPrefs.GetInt("levelCurMax", levelCurMax);
        
        ///读取离线时间
        loginHour = PlayerPrefs.GetInt("loginHour", loginHour);
        loginMinute = PlayerPrefs.GetInt("loginMinute", loginMinute);
        loginS = PlayerPrefs.GetInt("loginS", loginS);
        Debug.Log(loginHour + ":" + loginMinute + ":" + loginS);
        if (loginHour == 0 && loginMinute == 0 && loginS == 0)
        {
            SaveLocalDataOffTime();
        }
        if (!loginDatePerDay.Equals(System.DateTime.Now.ToString("yyyy:MM:dd")))//每日首次登陆
        {
            Debug.Log("首次登录");
            loginDatePerDay = System.DateTime.Now.ToString("yyyy:MM:dd");
            loginTimes++;
            //每日需要清零的数据
            playTimePerDay = 0;

            SaveLocalDataOffTime();
        }
        else
        {
            playTimePerDay = PlayerPrefs.GetInt("playTimePerDay", playTimePerDay);
            if (playTimePerDay <= 0)
            {
                playTimePerDay = 1;
            }
        }
        playTimePerDay++;
    }

    //==================================================set-get================================================================
    public void SetGold(int _value)
    {
        Gold += _value;
        if (Gold < 0)
        {
            Gold = 0;
        }
    }
    public int GetGold()
    {
        return Gold;
    }
}
