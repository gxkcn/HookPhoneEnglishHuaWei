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
            case 14: switch (ID) { } break;
            case 15: switch (ID) { } break;
            case 16: switch (ID) { } break;
            case 17:
                switch (ID)
                {
                    case 0:
                        indexBtnCicle = -1;
                        indexDb = 0;
                        indexLJ00 = indexLJ01 = -1;
                        indexLJ10 = 0;
                        indexLJ11 = -1;
                        indexLJ20 = indexLJ21 = -1;
                        indexLJ30 = indexLJ31 = -1;
                        indexSp = -1;
                        break;
                    case 1:
                        indexBtnCicle = -1;
                        indexDb = 1;
                        indexLJ00 = indexLJ01 = -1;
                        indexLJ10 = 0;
                        indexLJ11 = -1;
                        indexLJ20 = indexLJ21 = -1;
                        indexLJ30 = indexLJ31 = -1;
                        indexSp = -1;
                        break;
                    case 2:
                        indexBtnCicle = -1;
                        indexDb = 2;
                        indexLJ00 = indexLJ01 = -1;
                        indexLJ10 = 0;
                        indexLJ11 = -1;
                        indexLJ20 = indexLJ21 = -1;
                        indexLJ30 = indexLJ31 = -1;
                        indexSp = -1;
                        break;
                    case 3:
                        indexBtnCicle = -1;
                        indexDb = 3;
                        indexLJ00 = indexLJ01 = -1;
                        indexLJ10 = 0; indexLJ11 = -1;
                        indexLJ20 = indexLJ21 = -1;
                        indexLJ30 = indexLJ31 = -1;
                        indexSp = -1;
                        break;
                    case 4:
                        indexBtnCicle = 0;
                        indexDb = -1;
                        indexLJ00 = indexLJ01 = -1;
                        indexLJ10 = 0; indexLJ11 = -1;
                        indexLJ20 = indexLJ21 = -1;
                        indexLJ30 = indexLJ31 = -1;
                        indexSp = -1;
                        break;
                    case 5:
                        indexBtnCicle = 1;
                        indexDb = -1;
                        indexLJ00 = indexLJ01 = -1;
                        indexLJ10 = 0; indexLJ11 = -1;
                        indexLJ20 = indexLJ21 = -1;
                        indexLJ30 = indexLJ31 = -1;
                        indexSp = -1;
                        break;
                    case 6:
                        indexBtnCicle = 2;
                        indexDb = -1;
                        indexLJ00 = indexLJ01 = -1;
                        indexLJ10 = 1; indexLJ11 = -1;
                        indexLJ20 = indexLJ21 = -1;
                        indexLJ30 = indexLJ31 = -1;
                        indexSp = -1;
                        break;
                    case 7:
                        indexBtnCicle = 3;
                        indexDb = -1;
                        indexLJ00 = indexLJ01 = -1;
                        indexLJ10 = 1; indexLJ11 = -1;
                        indexLJ20 = indexLJ21 = -1;
                        indexLJ30 = indexLJ31 = -1;
                        indexSp = -1;
                        break;
                }
                break;
            case 18: switch (ID) { } break;
            case 19: switch (ID) { } break;
            case 20: switch (ID) { } break;
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
            case 22: switch (ID) { } break;
            case 23: switch (ID) { } break;
            case 24: switch (ID) { } break;
            case 25: switch (ID) { } break;
            case 26: switch (ID) { } break;
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
            case 28: switch (ID) { } break;
            case 29: switch (ID) { } break;
            case 30: switch (ID) { } break;
            case 31: switch (ID) { } break;
            case 32: switch (ID) { } break;
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
            case 36: switch (ID) { } break;
            case 37: switch (ID) { } break;
            case 38: switch (ID) { } break;
            case 39: switch (ID) { } break;
            case 40: switch (ID) { } break;
            case 41: switch (ID) { } break;
            case 42: switch (ID) { } break;
            case 43: switch (ID) { } break;
            case 44: switch (ID) { } break;
            case 45: switch (ID) { } break;
            case 46: switch (ID) { } break;
            case 47: switch (ID) { } break;
            case 48: switch (ID) { } break;
            case 49: switch (ID) { } break;
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
        Debug.Log(ID + "====" + indexBtnCicle+"==="+ indexDb);

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
        Debug.Log(ID + "====" + indexBtnCicle + "===" + indexDb+"==="+ _numLj);
        //检测结束判断是否需要隐藏
        if (_numLj <= 1)
        {
            Hide();
        }
    }
}
