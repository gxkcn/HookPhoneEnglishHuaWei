using UnityEngine;
using System.Collections;

public class GameLine : MonoBehaviour
{
    /// <summary>
    /// 在地图中 ID (唯一)
    /// </summary>
    public int ID;

    public int indexBtnCicle;
    /// <summary>
    ///相关联的<挡板>索引
    /// </summary>
    public int indexDb;
    /// <summary>
    /// 相关联的<连接0>索引
    /// </summary>
    public int indexLJ00, indexLJ01;
    /// <summary>
    /// 相关联的<连接1>索引
    /// </summary>
    public int indexLJ10, indexLJ11;
    /// <summary>
    /// 相关联的<连接2>索引
    /// </summary>
    public int indexLJ20, indexLJ21;
    /// <summary>
    /// 相关联的<连接2>索引
    /// </summary>
    public int indexLJ30, indexLJ31;
    /// <summary>
    /// 相关联的<特殊0>索引
    /// </summary>
    public int indexSp;

    public bool isJh = false;

    public bool isHide;

    // Use this for initialization
    void Start()
    {

    }

    public void InitData()
    {
        gameObject.SetActive(true);
        isJh = false;
        isHide = false;
        indexBtnCicle = -1;
        indexDb = -1;
        indexLJ00 = indexLJ01 = -1;
        indexLJ10 = indexLJ11 = -1;
        indexLJ20 = indexLJ21 = -1;
        indexLJ30 = indexLJ31 = -1;
        indexSp = -1;
        //excel 数据导出
        //= "case " & A2 & ":indexBtnCicle=" & B2 & ";indexDb=" & C2 & ";indexLJ00=" & D2 & ";indexLJ01=" & E2 & ";indexLJ10=" & F2 & ";indexLJ11=" & G2 & ";indexLJ20=" & H2 & ";indexLJ21=" & I2 & ";indexLJ30=" & J2 & ";indexLJ31=" & K2 & ";indexSp=" & L2 & ";break;"
        switch (GameController.GetInstance().currentLevel)
        {
            case 0:
                switch (ID)
                {
                    case 0: indexBtnCicle = 0; indexDb = 0; break;
                }
                break;
            case 1:
                switch (ID)
                {
                    case 0: indexBtnCicle = 0; indexDb = 0; break;
                    case 1: indexBtnCicle = 1; indexDb = 1; break;
                }
                break;
            case 2:
                switch (ID)
                {
                    case 0: indexBtnCicle = 0; indexDb = 0; break;
                    case 1: indexBtnCicle = 1; indexDb = 1; break;
                    case 2: indexBtnCicle = 2; indexDb = 2; break;
                    case 3: indexBtnCicle = 3; indexDb = 3; break;
                }
                break;
            case 3:
                switch (ID)
                {
                    case 0: indexBtnCicle = 0; indexDb = 0; break;
                    case 1: indexBtnCicle = 1; indexDb = 1; break;
                    case 2: indexBtnCicle = 2; indexDb = 2; break;
                }
                break;
            case 4: switch (ID) {
                    case 0: indexBtnCicle = 0; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = 1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                }
                break;
            case 5: switch (ID) {
                    case 0: indexBtnCicle = 0; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = 1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = 2; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = 3; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                }
                break;
            case 6: switch (ID) {
                    case 0: indexBtnCicle = 0; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = 0; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = 1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = 2; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = 3; indexDb = 4; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                }
                break;
            case 7: switch (ID) {
                    case 0: indexBtnCicle = 4; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = 1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = 2; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = 0; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = 3; indexDb = 4; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                }
                break;
            case 8: switch (ID) {
                    case 0: indexBtnCicle = 1; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = 0; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = 2; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = 1; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = 0; indexDb = 4; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = 2; indexDb = 5; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                }
                break;
            case 9: switch (ID) {
                    case 0: indexBtnCicle = 3; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = 1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = 2; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = 0; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                }
                break;
            case 10: switch (ID) {
                    case 0: indexBtnCicle = 0; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = 3; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = 2; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = 1; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;

                }
                break;
            case 11: switch (ID) {
                    case 0: indexBtnCicle = 5; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = 2; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = 1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = 4; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = 3; indexDb = 4; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = 0; indexDb = 5; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                }
                break;            
            case 12:
                switch (ID)
                {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = -1; indexDb = 4; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = -1; indexDb = 5; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 6: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = 1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 7: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 1; indexLJ01 = 2; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 8: indexBtnCicle = 0; indexDb = -1; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                }
                break;
            case 13: switch (ID)
                {
                    case 0: indexBtnCicle = 0; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = 2; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = 1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                }
                break;
            case 14: switch (ID) {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = 1; indexDb = -1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = 0; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                }
                break;
            case 15: switch (ID) {
                    case 0: indexBtnCicle = 2; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = 3; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = 0; indexDb = 4; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = 4; indexDb = 5; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 6: indexBtnCicle = 1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                }
                break;
            case 16: switch (ID) {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = -1; indexDb = 4; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = -1; indexDb = 5; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 6: indexBtnCicle = -1; indexDb = 6; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 7: indexBtnCicle = -1; indexDb = 7; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 8: indexBtnCicle = 5; indexDb = 8; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 9: indexBtnCicle = 6; indexDb = 9; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 10: indexBtnCicle = 2; indexDb = 10; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 11: indexBtnCicle = -1; indexDb = 11; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 12: indexBtnCicle = 0; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 13: indexBtnCicle = 3; indexDb = -1; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 14: indexBtnCicle = 4; indexDb = -1; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 15: indexBtnCicle = 1; indexDb = -1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                }
                break;
            case 17:
                switch (ID) {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = 1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 6: indexBtnCicle = 2; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 7: indexBtnCicle = 3; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;

                }
                break;
            case 18: switch (ID) {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = 0; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                }
                break;
            case 19: switch (ID) {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 2; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 2; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = 1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 6: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = 1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 7: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = 2; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 8: indexBtnCicle = 2; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 9: indexBtnCicle = 3; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 2; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                }
                break;
            case 20: switch (ID) {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 2; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = -1; indexDb = 4; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 3; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = -1; indexDb = 5; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 6: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 7: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 8: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = 2; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 9: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = 1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 10: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = 3; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 11: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = 2; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 12: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = 3; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 13: indexBtnCicle = 0; indexDb = -1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 14: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 2; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 15: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 3; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                }
                break;
            case 21:
                switch (ID)
                {
                    case 0:
                        indexBtnCicle = -1;
                        indexDb = 0;
                        indexLJ00 = -1;
                        indexLJ01 = -1;
                        indexLJ10 = -1;
                        indexLJ11 = -1;
                        indexLJ20 = 1;
                        indexLJ21 = -1;
                        indexLJ30 = -1;
                        indexLJ31 = -1;
                        indexSp = -1;
                        break;
                    case 1:
                        indexBtnCicle = -1;
                        indexDb = 1;
                        indexLJ00 = -1;
                        indexLJ01 = -1;
                        indexLJ10 = -1;
                        indexLJ11 = -1;
                        indexLJ20 = 1;
                        indexLJ21 = -1;
                        indexLJ30 = -1;
                        indexLJ31 = -1;
                        indexSp = -1;
                        break;
                    case 2:
                        indexBtnCicle = -1;
                        indexDb = 2;
                        indexLJ00 = -1;
                        indexLJ01 = -1;
                        indexLJ10 = -1;
                        indexLJ11 = -1;
                        indexLJ20 = 2;
                        indexLJ21 = -1;
                        indexLJ30 = -1;
                        indexLJ31 = -1;
                        indexSp = -1;
                        break;
                    case 3:
                        indexBtnCicle = -1;
                        indexDb = 3;
                        indexLJ00 = -1;
                        indexLJ01 = -1;
                        indexLJ10 = -1;
                        indexLJ11 = -1;
                        indexLJ20 = 2;
                        indexLJ21 = -1;
                        indexLJ30 = -1;
                        indexLJ31 = -1;
                        indexSp = -1;
                        break;
                    case 4:
                        indexBtnCicle = -1;
                        indexDb = -1;
                        indexLJ00 = -1;
                        indexLJ01 = -1;
                        indexLJ10 = -1;
                        indexLJ11 = -1;
                        indexLJ20 = 1;
                        indexLJ21 = 0;
                        indexLJ30 = -1;
                        indexLJ31 = -1;
                        indexSp = -1;
                        break;
                    case 5:
                        indexBtnCicle = -1;
                        indexDb = -1;
                        indexLJ00 = -1;
                        indexLJ01 = -1;
                        indexLJ10 = -1;
                        indexLJ11 = -1;
                        indexLJ20 = 2;
                        indexLJ21 = 0;
                        indexLJ30 = -1;
                        indexLJ31 = -1;
                        indexSp = -1;
                        break;
                    case 6:
                        indexBtnCicle = 0;
                        indexDb = -1;
                        indexLJ00 = -1;
                        indexLJ01 = -1;
                        indexLJ10 = -1;
                        indexLJ11 = -1;
                        indexLJ20 = 0;
                        indexLJ21 = -1;
                        indexLJ30 = -1;
                        indexLJ31 = -1;
                        indexSp = -1;
                        break;
                }
                break;
            case 22: switch (ID) {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 6: indexBtnCicle = 0; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 7: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 8: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                }
                break;
            case 23: switch (ID) {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 6: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 7: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = 1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                }
                break;
            case 24: switch (ID) {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 3; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = -1; indexDb = 4; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 2; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = -1; indexDb = 5; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 2; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 6: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 7: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = 1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 8: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 9: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 2; indexLJ21 = 3; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 10: indexBtnCicle = 1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 2; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 11: indexBtnCicle = 1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 3; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;

                }
                break;
            case 25: switch (ID) {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 2; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 3; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = -1; indexDb = 4; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 8; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = -1; indexDb = 5; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 9; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 6: indexBtnCicle = -1; indexDb = 6; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 10; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 7: indexBtnCicle = -1; indexDb = 7; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 11; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 8: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = 1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 9: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = 4; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 10: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = 4; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 11: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 2; indexLJ21 = 3; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 12: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 2; indexLJ21 = 5; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 13: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 3; indexLJ21 = 5; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 14: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 4; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 15: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 6; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 16: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 4; indexLJ21 = 5; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 17: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = 1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 18: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 6; indexLJ21 = 7; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 19: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 5; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 20: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 7; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 21: indexBtnCicle = 0; indexDb = -1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 22: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 6; indexLJ21 = 8; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 23: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 8; indexLJ21 = 9; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 24: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 6; indexLJ21 = 9; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 25: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 7; indexLJ21 = 10; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 26: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 10; indexLJ21 = 11; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 27: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 7; indexLJ21 = 11; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                }
                break;
            case 26: switch (ID) {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 6; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = 1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = 2; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 1; indexLJ01 = 1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = -1; indexLJ20 = 3; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 6: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 5; indexLJ21 = 6; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 7: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 4; indexLJ21 = 5; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 8: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 9: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 10: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 2; indexLJ21 = 3; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 11: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = 6; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 12: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = -1; indexLJ20 = 5; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 13: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 3; indexLJ21 = 4; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 14: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 3; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;

                }
                break;
            case 27:
                switch (ID)
                {
                    case 0:
                        indexBtnCicle = -1;
                        indexDb = 0;
                        indexLJ00 = -1;
                        indexLJ01 = -1;
                        indexLJ10 = -1;
                        indexLJ11 = -1;
                        indexLJ20 = -1;
                        indexLJ21 = -1;
                        indexLJ30 = 2;
                        indexLJ31 = -1;
                        indexSp = -1;
                        break;
                    case 1:
                        indexBtnCicle = -1;
                        indexDb = 1;
                        indexLJ00 = -1;
                        indexLJ01 = -1;
                        indexLJ10 = -1;
                        indexLJ11 = -1;
                        indexLJ20 = -1;
                        indexLJ21 = -1;
                        indexLJ30 = 1;
                        indexLJ31 = -1;
                        indexSp = -1;
                        break;
                    case 2:
                        indexBtnCicle = -1;
                        indexDb = 2;
                        indexLJ00 = -1;
                        indexLJ01 = -1;
                        indexLJ10 = -1;
                        indexLJ11 = -1;
                        indexLJ20 = -1;
                        indexLJ21 = -1;
                        indexLJ30 = 0;
                        indexLJ31 = -1;
                        indexSp = -1;
                        break;
                    case 3:
                        indexBtnCicle = -1;
                        indexDb = 3;
                        indexLJ00 = -1;
                        indexLJ01 = -1;
                        indexLJ10 = -1;
                        indexLJ11 = -1;
                        indexLJ20 = -1;
                        indexLJ21 = -1;
                        indexLJ30 = 0;
                        indexLJ31 = -1;
                        indexSp = -1;
                        break;
                    case 4:
                        indexBtnCicle = -1;
                        indexDb = -1;
                        indexLJ00 = -1;
                        indexLJ01 = -1;
                        indexLJ10 = -1;
                        indexLJ11 = -1;
                        indexLJ20 = -1;
                        indexLJ21 = -1;
                        indexLJ30 = 0;
                        indexLJ31 = 1;
                        indexSp = -1;
                        break;
                    case 5:
                        indexBtnCicle = -1;
                        indexDb = -1;
                        indexLJ00 = -1;
                        indexLJ01 = -1;
                        indexLJ10 = -1;
                        indexLJ11 = -1;
                        indexLJ20 = -1;
                        indexLJ21 = -1;
                        indexLJ30 = 1;
                        indexLJ31 = 2;
                        indexSp = -1;
                        break;
                    case 6:
                        indexBtnCicle = 0;
                        indexDb = -1;
                        indexLJ00 = -1;
                        indexLJ01 = -1;
                        indexLJ10 = -1;
                        indexLJ11 = -1;
                        indexLJ20 = -1;
                        indexLJ21 = -1;
                        indexLJ30 = 2;
                        indexLJ31 = -1;
                        indexSp = -1;
                        break;
                }
                break;            
            case 28: switch (ID) {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = -1; indexDb = 4; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 6: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 7: indexBtnCicle = 0; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 8: indexBtnCicle = 0; indexDb = -1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 9: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 10: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 11: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                }
                break;
            case 29: switch (ID) {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                }
                break;
            case 30: switch (ID) {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 2; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = -1; indexDb = 4; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = -1; indexDb = 5; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 6: indexBtnCicle = -1; indexDb = 6; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 7: indexBtnCicle = -1; indexDb = 7; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 8: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = 1; indexSp = -1; break;
                    case 9: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 10: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = 3; indexSp = -1; break;
                    case 11: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 2; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = -1; indexSp = -1; break;
                    case 12: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = 0; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 13: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 14: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 2; indexLJ21 = 0; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 15: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = 3; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 16: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 2; indexLJ21 = 3; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 17: indexBtnCicle = 1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 3; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;

                }
                break;
            case 31: switch (ID) {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = -1; indexDb = 4; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = -1; indexDb = 5; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 6: indexBtnCicle = -1; indexDb = 6; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 3; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 7: indexBtnCicle = -1; indexDb = 7; indexLJ00 = 4; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 8: indexBtnCicle = -1; indexDb = 8; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 4; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 9: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 10: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 11: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 12: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 13: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 14: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 2; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 15: indexBtnCicle = 1; indexDb = -1; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 16: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 17: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 18: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 4; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 3; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 19: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 4; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 4; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 20: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 4; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 21: indexBtnCicle = 2; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;

                }
                break;
            case 32: switch (ID) {
                    case 0: indexBtnCicle = 1; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = -1; indexDb = 4; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = -1; indexDb = 5; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 6: indexBtnCicle = -1; indexDb = 6; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 7: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = 3; indexSp = -1; break;
                    case 8: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = 2; indexSp = -1; break;
                    case 9: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 10: indexBtnCicle = 2; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = -1; indexSp = -1; break;
                }
                break;
            case 33:
                switch (ID)
                {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 0; break;
                    case 5: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 1; break;
                    case 6: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = 2; break;

                }
                break;
            case 34:
                switch (ID)
                {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 3; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 0; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 2; break;
                    case 4: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = 1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 5; break;
                    case 6: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 2; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 7: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 2; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 4; break;
                    case 8: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 6; break;
                    case 9: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 10: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = 2; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;

                }
                break;
            case 35:switch (ID){
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 3; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 0; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 2; break;
                    case 4: indexBtnCicle = -1; indexDb = 4; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 1; break;
                    case 5: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 4; break;
                    case 6: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 7: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 8: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = 1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 9: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 10: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 11: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 12: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 5; break;
                    case 13: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 6; break;

                }
                break;
            case 36: switch (ID) {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = -1; indexDb = 4; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 2; break;
                    case 5: indexBtnCicle = -1; indexDb = 5; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 6: indexBtnCicle = 0; indexDb = 6; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 7: indexBtnCicle = -1; indexDb = 7; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 4; break;
                    case 8: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 0; break;
                    case 9: indexBtnCicle = 1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 10: indexBtnCicle = 2; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 11: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = 3; break;
                    case 12: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = 5; break;

                }
                break;
            case 37: switch (ID) {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 0; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 5; break;
                    case 4: indexBtnCicle = -1; indexDb = 4; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = -1; indexDb = 5; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 6: indexBtnCicle = -1; indexDb = 6; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 6; break;
                    case 7: indexBtnCicle = -1; indexDb = 7; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 8: indexBtnCicle = -1; indexDb = 8; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 9: indexBtnCicle = -1; indexDb = 9; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 10: indexBtnCicle = -1; indexDb = 10; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 11: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 4; break;
                    case 12: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 2; break;
                    case 13: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 14: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 15: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 16: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 17: indexBtnCicle = 0; indexDb = -1; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 18: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 3; break;
                    case 19: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 20: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 1; indexLJ01 = 3; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 21: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 22: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 7; break;

                }
                break;
            case 38: switch (ID) {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 5; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 6; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 7; break;
                    case 4: indexBtnCicle = -1; indexDb = 4; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 8; break;
                    case 5: indexBtnCicle = -1; indexDb = 5; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 9; break;
                    case 6: indexBtnCicle = -1; indexDb = 6; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 7: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 0; break;
                    case 8: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 9: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = 1; break;
                    case 10: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 11: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = 0; indexSp = -1; break;
                    case 12: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 2; break;
                    case 13: indexBtnCicle = 1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 3; break;
                    case 14: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = 4; break;

                }
                break;
            case 39: switch (ID) {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 2; break;
                    case 4: indexBtnCicle = -1; indexDb = 4; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 3; break;
                    case 5: indexBtnCicle = -1; indexDb = 5; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 6: indexBtnCicle = -1; indexDb = 6; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 7: indexBtnCicle = -1; indexDb = 7; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 4; indexLJ31 = -1; indexSp = -1; break;
                    case 8: indexBtnCicle = -1; indexDb = 8; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 5; indexLJ31 = -1; indexSp = -1; break;
                    case 9: indexBtnCicle = -1; indexDb = 9; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = -1; indexSp = -1; break;
                    case 10: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = 0; break;
                    case 11: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = 1; break;
                    case 12: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = 1; indexSp = -1; break;
                    case 13: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = 1; indexSp = -1; break;
                    case 14: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = 3; indexSp = -1; break;
                    case 15: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 4; indexLJ31 = -1; indexSp = 4; break;
                    case 16: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 4; indexLJ31 = 5; indexSp = -1; break;
                    case 17: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = 5; indexSp = -1; break;

                }
                break;
            case 40: switch (ID) {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = -1; indexDb = 4; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = -1; indexDb = 5; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 6: indexBtnCicle = -1; indexDb = 6; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 7: indexBtnCicle = -1; indexDb = 7; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 3; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 8: indexBtnCicle = -1; indexDb = 8; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 5; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 9: indexBtnCicle = -1; indexDb = 9; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 5; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 10: indexBtnCicle = -1; indexDb = 10; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 2; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 11: indexBtnCicle = -1; indexDb = 11; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 12: indexBtnCicle = 1; indexDb = 12; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 13: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 14: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 3; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = 1; indexSp = -1; break;
                    case 15: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 16: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = 1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 17: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 18: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 3; indexLJ21 = 5; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 19: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 3; indexLJ21 = 4; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 20: indexBtnCicle = 2; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 4; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 21: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 4; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 22: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 5; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 23: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 24: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = 2; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;

                }
                break;
            case 41: switch (ID) {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 4; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = -1; indexDb = 4; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = -1; indexDb = 5; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = -1; indexSp = -1; break;
                    case 6: indexBtnCicle = -1; indexDb = 6; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 4; indexLJ31 = -1; indexSp = -1; break;
                    case 7: indexBtnCicle = -1; indexDb = 7; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 8: indexBtnCicle = -1; indexDb = 8; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 9: indexBtnCicle = -1; indexDb = 9; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 6; indexLJ31 = -1; indexSp = -1; break;
                    case 10: indexBtnCicle = -1; indexDb = 10; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 11: indexBtnCicle = 1; indexDb = 11; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 12: indexBtnCicle = -1; indexDb = 12; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 13: indexBtnCicle = -1; indexDb = 13; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 5; indexLJ31 = -1; indexSp = -1; break;
                    case 14: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 15: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = -1; indexSp = -1; break;
                    case 16: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 17: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 18: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = 2; indexSp = -1; break;
                    case 19: indexBtnCicle = 2; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 20: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = 5; indexSp = -1; break;
                    case 21: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 4; indexLJ31 = -1; indexSp = -1; break;
                    case 22: indexBtnCicle = 1; indexDb = -1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 23: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 6; indexLJ31 = -1; indexSp = -1; break;
                    case 24: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 5; indexLJ31 = -1; indexSp = -1; break;
                    case 25: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 6; indexLJ31 = -1; indexSp = -1; break;

                }
                break;
            case 42: switch (ID) {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 0; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = -1; indexDb = 4; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = -1; indexDb = 5; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 6: indexBtnCicle = -1; indexDb = 6; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 3; break;
                    case 7: indexBtnCicle = -1; indexDb = 7; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 2; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 8: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 1; break;
                    case 9: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 2; break;
                    case 10: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 11: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = 1; indexSp = -1; break;
                    case 12: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = 2; indexSp = -1; break;
                    case 13: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 14: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 2; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 15: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 4; break;
                    case 16: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 17: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 2; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 5; break;

                }
                break;
            case 43: switch (ID) {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = 4; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = -1; indexDb = 4; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = -1; indexDb = 5; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 6: indexBtnCicle = -1; indexDb = 6; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 7: indexBtnCicle = -1; indexDb = 7; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 8: indexBtnCicle = -1; indexDb = 8; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 9: indexBtnCicle = -1; indexDb = 9; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 10: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 11: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 12: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = 1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 13: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 14: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 15: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 16: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 1; indexLJ01 = 4; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 17: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 4; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = -1; indexSp = -1; break;
                    case 18: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = -1; indexSp = -1; break;
                    case 19: indexBtnCicle = 0; indexDb = -1; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 20: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 21: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 22: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 23: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 2; indexLJ01 = 0; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;

                }
                break;
            case 44: switch (ID) {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = -1; indexDb = 4; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = -1; indexDb = 5; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 8; break;
                    case 6: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = 0; break;
                    case 7: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 1; break;
                    case 8: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = 1; indexSp = -1; break;
                    case 9: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = 1; indexSp = -1; break;
                    case 10: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 11: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = 2; break;
                    case 12: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = 3; break;
                    case 13: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = 5; break;
                    case 14: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = 4; break;
                    case 15: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = -1; indexSp = 6; break;
                    case 16: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 17: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 18: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 7; break;
                    case 19: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 4; indexLJ31 = -1; indexSp = -1; break;
                    case 20: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 4; indexLJ31 = -1; indexSp = -1; break;
                    case 21: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 4; indexLJ31 = -1; indexSp = 9; break;
                    case 22: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 4; indexLJ31 = -1; indexSp = -1; break;
                    case 23: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 10; break;
                    case 24: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 11; break;
                    case 25: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;

                }
                break;
            case 45: switch (ID) {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = -1; indexDb = 4; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = -1; indexDb = 5; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 1; break;
                    case 6: indexBtnCicle = -1; indexDb = 6; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 5; indexLJ31 = -1; indexSp = -1; break;
                    case 7: indexBtnCicle = -1; indexDb = 7; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 5; indexLJ31 = -1; indexSp = -1; break;
                    case 8: indexBtnCicle = -1; indexDb = 8; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = -1; indexSp = -1; break;
                    case 9: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 0; break;
                    case 10: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = 3; break;
                    case 11: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = 1; indexSp = -1; break;
                    case 12: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = 3; indexSp = -1; break;
                    case 13: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 14: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 15: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = 4; indexSp = -1; break;
                    case 16: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 4; indexLJ31 = 5; indexSp = -1; break;
                    case 17: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 5; indexLJ31 = -1; indexSp = 2; break;
                    case 18: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 19: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = 4; indexSp = -1; break;

                }
                break;
            case 46: switch (ID) {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = -1; indexDb = 4; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = -1; indexDb = 5; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 3; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 6: indexBtnCicle = -1; indexDb = 6; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 7: indexBtnCicle = -1; indexDb = 7; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 4; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 8: indexBtnCicle = -1; indexDb = 8; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 5; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 9: indexBtnCicle = -1; indexDb = 9; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 10: indexBtnCicle = -1; indexDb = 10; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 11: indexBtnCicle = -1; indexDb = 11; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 12: indexBtnCicle = -1; indexDb = 12; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 7; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 13: indexBtnCicle = -1; indexDb = 13; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 14: indexBtnCicle = -1; indexDb = 14; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 8; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 15: indexBtnCicle = -1; indexDb = 15; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 6; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 16: indexBtnCicle = -1; indexDb = 16; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 6; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 17: indexBtnCicle = -1; indexDb = 17; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 9; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 18: indexBtnCicle = -1; indexDb = 18; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 19: indexBtnCicle = -1; indexDb = 19; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 10; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 20: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = 1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 21: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = 2; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 22: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 23: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 3; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 24: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 25: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = 1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 26: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = 1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 27: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = 1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 2; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 28: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 4; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 29: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 3; indexLJ21 = 4; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 30: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 2; indexLJ21 = 4; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 31: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = 0; indexLJ20 = -1; indexLJ21 = 2; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 32: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 0; break;
                    case 33: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 34: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 5; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 35: indexBtnCicle = 0; indexDb = -1; indexLJ00 = 4; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 36: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 5; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 37: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 38: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 4; indexLJ01 = -1; indexLJ10 = 1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 39: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 4; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 6; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 40: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 6; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 41: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 4; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 42: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 7; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 43: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 7; indexLJ21 = 8; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 44: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 5; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 7; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 45: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 6; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 8; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 46: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 5; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 47: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 5; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 48: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 5; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 9; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 49: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 6; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 50: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 6; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 10; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 51: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 9; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 52: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 9; indexLJ21 = 10; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 53: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = 0; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 54: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 5; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 1; break;

                }
                break;
            case 47: switch (ID) {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = -1; indexDb = 4; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 2; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = -1; indexDb = 5; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 6: indexBtnCicle = -1; indexDb = 6; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 7: indexBtnCicle = 0; indexDb = 7; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 8: indexBtnCicle = -1; indexDb = 8; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 9: indexBtnCicle = -1; indexDb = 9; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 10: indexBtnCicle = -1; indexDb = 10; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 11: indexBtnCicle = -1; indexDb = 11; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 12: indexBtnCicle = -1; indexDb = 12; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = -1; indexSp = -1; break;
                    case 13: indexBtnCicle = -1; indexDb = 13; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = -1; indexSp = -1; break;
                    case 14: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 15: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 16: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 17: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 18: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 19: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 20: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = 0; break;
                    case 21: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 2; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 22: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 23: indexBtnCicle = 1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 2; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 24: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 4; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 25: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = -1; indexSp = -1; break;
                    case 26: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 4; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = 1; break;
                    case 27: indexBtnCicle = 1; indexDb = -1; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 28: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 4; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = -1; indexSp = -1; break;

                }
                break;
            case 48:
                switch (ID)
                {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = -1; indexDb = 4; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = -1; indexDb = 5; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 6: indexBtnCicle = -1; indexDb = 6; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 7: indexBtnCicle = -1; indexDb = 7; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 8: indexBtnCicle = -1; indexDb = 8; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 9: indexBtnCicle = -1; indexDb = 9; indexLJ00 = 4; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 10: indexBtnCicle = -1; indexDb = 10; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 2; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 11: indexBtnCicle = -1; indexDb = 11; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 12: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 13: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 14: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 15: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 16: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 17: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 18: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 19: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 4; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 20: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 2; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 21: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = -1; indexSp = -1; break;
                    case 22: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 2; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 23: indexBtnCicle = 1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 24: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 0; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 25: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 4; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 26: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = 1; indexLJ21 = 2; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;

                }
                break;
            case 49:
                switch (ID)
                {
                    case 0: indexBtnCicle = -1; indexDb = 0; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 1: indexBtnCicle = -1; indexDb = 1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 4; indexLJ31 = -1; indexSp = -1; break;
                    case 2: indexBtnCicle = -1; indexDb = 2; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = -1; indexSp = -1; break;
                    case 3: indexBtnCicle = -1; indexDb = 3; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 4: indexBtnCicle = -1; indexDb = 4; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = -1; indexSp = -1; break;
                    case 5: indexBtnCicle = -1; indexDb = 5; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 4; indexLJ31 = -1; indexSp = -1; break;
                    case 6: indexBtnCicle = -1; indexDb = 6; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 8; indexLJ31 = -1; indexSp = -1; break;
                    case 7: indexBtnCicle = -1; indexDb = 7; indexLJ00 = 6; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 8: indexBtnCicle = -1; indexDb = 8; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 8; indexLJ31 = -1; indexSp = -1; break;
                    case 9: indexBtnCicle = -1; indexDb = 9; indexLJ00 = 7; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 10: indexBtnCicle = -1; indexDb = 10; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 4; indexLJ31 = -1; indexSp = -1; break;
                    case 11: indexBtnCicle = -1; indexDb = 11; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 9; indexLJ31 = -1; indexSp = -1; break;
                    case 12: indexBtnCicle = -1; indexDb = 12; indexLJ00 = 6; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 13: indexBtnCicle = -1; indexDb = 13; indexLJ00 = 5; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 14: indexBtnCicle = -1; indexDb = 14; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 9; indexLJ31 = -1; indexSp = -1; break;
                    case 15: indexBtnCicle = -1; indexDb = 15; indexLJ00 = 4; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 16: indexBtnCicle = -1; indexDb = 16; indexLJ00 = 6; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 17: indexBtnCicle = -1; indexDb = 17; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 10; indexLJ31 = -1; indexSp = -1; break;
                    case 18: indexBtnCicle = -1; indexDb = 18; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 10; indexLJ31 = -1; indexSp = -1; break;
                    case 19: indexBtnCicle = -1; indexDb = 19; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 5; indexLJ31 = -1; indexSp = -1; break;
                    case 20: indexBtnCicle = -1; indexDb = 20; indexLJ00 = 4; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 21: indexBtnCicle = -1; indexDb = 21; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 22: indexBtnCicle = -1; indexDb = 22; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 23: indexBtnCicle = -1; indexDb = 23; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 24: indexBtnCicle = -1; indexDb = 24; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 25: indexBtnCicle = -1; indexDb = 25; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 26: indexBtnCicle = -1; indexDb = 26; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 27: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 0; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 28: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 29: indexBtnCicle = 0; indexDb = -1; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = -1; indexLJ31 = -1; indexSp = -1; break;
                    case 30: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = 5; indexSp = -1; break;
                    case 31: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 3; indexLJ31 = 8; indexSp = -1; break;
                    case 32: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 6; indexLJ31 = 9; indexSp = -1; break;
                    case 33: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 6; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 7; indexLJ31 = -1; indexSp = -1; break;
                    case 34: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 7; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 9; indexLJ31 = -1; indexSp = -1; break;
                    case 35: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 0; indexLJ31 = -1; indexSp = -1; break;
                    case 36: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 2; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 37: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 1; indexLJ31 = -1; indexSp = -1; break;
                    case 38: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 3; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = -1; indexSp = -1; break;
                    case 39: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 2; indexLJ31 = 3; indexSp = -1; break;
                    case 40: indexBtnCicle = 0; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 4; indexLJ31 = -1; indexSp = -1; break;
                    case 41: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 4; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 5; indexLJ31 = -1; indexSp = -1; break;
                    case 42: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 4; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 6; indexLJ31 = -1; indexSp = -1; break;
                    case 43: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 5; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 6; indexLJ31 = -1; indexSp = -1; break;
                    case 44: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 5; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 7; indexLJ31 = -1; indexSp = -1; break;
                    case 45: indexBtnCicle = -1; indexDb = -1; indexLJ00 = -1; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 7; indexLJ31 = 8; indexSp = -1; break;
                    case 46: indexBtnCicle = -1; indexDb = -1; indexLJ00 = 7; indexLJ01 = -1; indexLJ10 = -1; indexLJ11 = -1; indexLJ20 = -1; indexLJ21 = -1; indexLJ30 = 10; indexLJ31 = -1; indexSp = -1; break;

                }
                break;
            default:
                break;

        }
    }
    
    public void StartJh()
    {
        Debug.Log("=====================================线被激活line id  = "+ID);
        //gameObject.transform.localEulerAngles = 
        //    new Vector3(0,0,2);
        isJh = true;
        GameController.GetInstance().lineStateJh[ID] = 1;
        //if (indexDb != -1)
        //{
        //    ViewController.GetInstance().game.GetComponent<ViewGame>().StartJh(indexDb, "db");
        //}
        if (indexLJ00 != -1)
        {
            ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.StartJh(indexLJ00, "btnLj0");
        }
        if (indexLJ01 != -1)
        {
            ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.StartJh(indexLJ01, "btnLj0");
        }
        if (indexLJ10 != -1)
        {
            if(ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.GetStartJhLj(ID, indexLJ10, "btnLj1"))
            {
                ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.StartJh(indexLJ10, "btnLj1");
            }            
        }
        if (indexLJ11 != -1)
        {
            if (ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.GetStartJhLj(ID, indexLJ11, "btnLj1"))
            {
                ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.StartJh(indexLJ11, "btnLj1");
            }                
        }
        
        if (indexLJ20 != -1)
        {
            if (ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.GetStartJhLj(ID, indexLJ20, "btnLj2"))
            {
                ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.StartJh(indexLJ20, "btnLj2");
            }
        }
        if (indexLJ21 != -1)
        {
            if (ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.GetStartJhLj(ID, indexLJ21, "btnLj2"))
            {
                ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.StartJh(indexLJ21, "btnLj2");
            }
        }
        if (indexLJ30 != -1)
        {
            if (ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.GetStartJhLj(ID, indexLJ30, "btnLj3"))
            {
                ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.StartJh(indexLJ30, "btnLj3");
            }
        }
        if (indexLJ31 != -1)
        {
            if (ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.GetStartJhLj(ID, indexLJ31, "btnLj3"))
            {
                ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.StartJh(indexLJ31, "btnLj3");
            }
        }
        if (indexSp != -1)
        {
            ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.StartJh(indexSp, "sp");
        }
    }

    public void SetJhFalse()
    {
        //gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
        isJh = false;
        GameController.GetInstance().lineStateJh[ID] = 0;
    }

    public void Hide()
    {
        if (isHide == false)
        {
            isHide = true;
            GameController.GetInstance().stateLine[ID] = 0;
            LeanTween.alpha(gameObject, 0, 0.1f).setLoopCount(1);
            Invoke("HideActive", 0.1F);
        }
    }

    public void HideActive()
    {
        gameObject.SetActive(false);
    }

    public void ExamineHide()
    {
        Debug.Log(ID + " ExamineHide ====" + indexBtnCicle+"==DB="+ indexDb
            + "==0=" + indexLJ00 + "==0=" + indexLJ01
            + "==1=" + indexLJ10 + "==1=" + indexLJ11
            + "==2=" + indexLJ20 + "==2=" + indexLJ21
            + "==3=" + indexLJ30 + "==3=" + indexLJ31
            + "==S=" + indexSp
            );
        //Debug.Log(ID + " ExamineHid2 ====" + indexBtnCicle
        //   + "==DB=" + (indexDb == -1 ? 9 : GameController.GetInstance().stateDb[indexDb])
        //   + "==0=" + (indexLJ00 == -1 ? 9 : GameController.GetInstance().stateLj0[indexLJ00]) + "==0=" + (indexLJ01 == -1 ? 9 : GameController.GetInstance().stateLj0[indexLJ00])
        //   + "==1=" + (indexLJ10 == -1 ? 9 : GameController.GetInstance().stateLj1[indexLJ10]) + "==1=" + (indexLJ11 == -1 ? 9 : GameController.GetInstance().stateLj1[indexLJ10])
        //   + "==2=" + (indexLJ20 == -1 ? 9 : GameController.GetInstance().stateLj2[indexLJ20]) + "==2=" + (indexLJ21 == -1 ? 9 : GameController.GetInstance().stateLj2[indexLJ20])
        //   + "==3=" + (indexLJ30 == -1 ? 9 : GameController.GetInstance().stateLj3[indexLJ30]) + "==3=" + (indexLJ31 == -1 ? 9 : GameController.GetInstance().stateLj3[indexLJ30])
        //   + "==S=" + (indexSp == -1 ? 9 : GameController.GetInstance().stateSp[indexSp])
        //   );

        int _numLj = 0;
        if (indexBtnCicle != -1)
        {             
            _numLj++;
        }
        if (indexDb != -1)
        {
            if (GameController.GetInstance().stateDb[indexDb] == 1)
            {
                _numLj++;
            }
        }
        if (indexLJ00 != -1)
        {
            if (GameController.GetInstance().stateLj0[indexLJ00] == 1)
            {
                //if (ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.GetLineUse(indexLJ00, 0))
                //{
                    _numLj++;
                //}                
            }
        }
        if (indexLJ01 != -1)
        {
            if (GameController.GetInstance().stateLj0[indexLJ01] == 1)
            {
                //if (ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.GetLineUse(indexLJ01, 0))
                //{
                    _numLj++;
                //}                   
            }
        }
        if (indexLJ10 != -1)
        {
            if (GameController.GetInstance().stateLj1[indexLJ10] == 1)
            {
                if (ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.GetLineUse(ID,indexLJ10, 1))
                {
                    _numLj++;
                }                    
            }
        }
        if (indexLJ11 != -1)
        {
            if (GameController.GetInstance().stateLj1[indexLJ11] == 1)
            {
                if (ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.GetLineUse(ID, indexLJ11, 1))
                {
                    _numLj++;
                }                   
            }
        }
        if (indexLJ20 != -1)
        {
            if (GameController.GetInstance().stateLj2[indexLJ20] == 1)
            {
                if (ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.GetLineUse(ID, indexLJ20, 2))
                {
                    _numLj++;
                }                    
            }
        }
        if (indexLJ21 != -1)
        {
            if (GameController.GetInstance().stateLj2[indexLJ21] == 1)
            {
                if (ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.GetLineUse(ID, indexLJ21, 2))
                {
                    _numLj++;
                }                    
            }
        }
        if (indexLJ30 != -1)
        {
            if (GameController.GetInstance().stateLj3[indexLJ30] == 1)
            {
                if (ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.GetLineUse(ID, indexLJ30, 3))
                {
                    _numLj++;
                }                   
            }
        }
        if (indexLJ31 != -1)
        {
            if (GameController.GetInstance().stateLj3[indexLJ31] == 1)
            {
                if (ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.GetLineUse(ID, indexLJ31, 3))
                {
                    _numLj++;
                }                   
            }
        }
        if (indexSp != -1)
        {
            if (GameController.GetInstance().stateSp[indexSp] == 1)
            {
                //if (ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.GetLineUse(ID, indexSp, 4))
                //{
                    _numLj++;
                //}
            }
        }
        Debug.Log(ID + "???????????????????????????????????????线  num  = " + _numLj);
        //检测结束判断是否需要隐藏
        if (_numLj <= 1)
        {            
            Hide();
        }
    }
}
