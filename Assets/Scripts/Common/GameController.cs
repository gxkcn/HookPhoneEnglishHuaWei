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
    /// <summary>
    /// 每次打开游戏玩每个关卡的次数,用来记录关卡地图坐标数据的，只有第一次进入的时候记录原始坐标
    /// </summary>
    public int[] playLevelTimes = { 0,0,0,0,0,0,0,0,0,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
     0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0,};
    /// <summary>
    /// 当前消除的挡板个数，个数小于等于0就结束游戏，获得胜利
    /// </summary>
    public int totalHideDbNum = 0;
    /// <summary>
    /// 用来记录按钮是否消失
    /// </summary>
    public int[] stateBtnCicle = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    /// <summary>
    /// 用来记录线是否消失1 存在默认值
    /// </summary>
    public int[] stateLine = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    /// <summary>
    /// 用来记录挡板是否消失的
    /// </summary>
    public int[] stateDb = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    /// <summary>
    /// 用来记录连接点是否消失
    /// </summary>
    public int[] stateLj0 = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    /// <summary>
    /// 用来记录连接点是否消失
    /// </summary>
    public int[] stateLj1 = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    /// <summary>
    /// 用来记录连接点是否消失
    /// </summary>
    public int[] stateLj2 = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    /// <summary>
    /// 用来记录连接点是否消失
    /// </summary>
    public int[] stateLj3 = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    /// <summary>
    /// 用来记录特殊点是否消失
    /// </summary>
    public int[] stateSp = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    /// <summary>
    /// 只有激活的粗线进行碰撞判定
    /// </summary>
    public int[] stateJhBold = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    /// <summary>
    /// 点击按钮的时候用来判断挡板line是否被激活了
    /// </summary>
    public int[] lineStateJh = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    public int sp0Num = 0;
    public int sp1Num = 0;
    public int sp2Num = 0;
    //================================================================游戏关卡数据变量===============================================================
    public static GameController GetInstance()
    {
        if (instance == null)
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
        //AudioManager.GetInstance().PlayMusic(AudioManager.MusicGame0);
        totalHideDbNum = 0;
        stateBtnCicle = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }; 
        stateLine = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        stateDb = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        stateLj0 = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        stateLj1 = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        stateLj2 = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        stateLj3 = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        stateSp = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        stateJhBold = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        lineStateJh = new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        sp0Num = 0;
        sp1Num = 0;
        sp2Num = 0;
    }
}
