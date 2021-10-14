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
        }
        //case 7:
        //                indexBtnCicle = -1;
        //indexDb = -1;
        //indexLJ00 = indexLJ01 = -1;
        //indexLJ10 = indexLJ11 = -1;
        //indexLJ20 = indexLJ21 = -1;
        //indexLJ30 = indexLJ31 = -1;
        //indexSp = -1;
        //break;
    }

    public void StartJh()
    {
        Debug.Log("=====================================线被激活line id  = "+ID);
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
            if (ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.GetStartJhLj(ID, indexLJ20, "btnLj2"))
            {
                ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.StartJh(indexLJ20, "btnLj2");
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
            Debug.Log(ID+"  *******************************"+indexLJ10);
            if (GameController.GetInstance().stateLj1[indexLJ10] == 1)
            {
                if (ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.GetLineUse(ID,indexLJ10, 1))
                {
                    Debug.Log(ID + "+++++++++++++++++++++++++++++++++++++++++++" );
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
                if (ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.GetLineUse(ID, indexSp, 4))
                {
                    _numLj++;
                }
            }
        }

        //检测结束判断是否需要隐藏
        if (_numLj <= 1)
        {
            Hide();
        }
    }
}
