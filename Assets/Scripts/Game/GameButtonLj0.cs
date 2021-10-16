using UnityEngine;
using System.Collections;

public class GameButtonLj0 : MonoBehaviour
{
    /// <summary>
    /// 在地图中 ID (唯一)
    /// </summary>
    public int ID;
    /// <summary>
    /// 相关联的细线索引
    /// </summary>
    public int indexLine0, indexLine1, indexLine2, indexLine3;
    
    public bool isHide;

    private int[] indexLineArr;

    public bool isJh;
    

    // Use this for initialization
    void Start()
    {

    }

    public void InitData()
    {
        gameObject.SetActive(true);
        isHide = false;
        isJh = false;
        indexLine0 = indexLine1 = indexLine2 = indexLine3  = -1;
        indexLineArr = new int[] { -1, -1, -1, -1 };
        switch (GameController.GetInstance().currentLevel)
        {
            case 12:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 0,-1,3,6 };  break;
                    case 1: indexLineArr = new int[] { 1,6,4,7 };  break;
                    case 2: indexLineArr = new int[] { 2,7,5,8 };  break;
                }
                break;
            case 13:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 1,-1,3,4 }; break;
                }
                break;
            case 35:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 0, 5,8,-1 }; break;
                    case 1: indexLineArr = new int[] { 8,6,9,-1 }; break;
                }
                break;
        }
        indexLine0 = indexLineArr[0];
        indexLine1 = indexLineArr[1];
        indexLine2 = indexLineArr[2];
        indexLine3 = indexLineArr[3];
    }
           

    public void StartJh()
    {
        if (isJh == false)
        {
            isJh = true;
            if (indexLine0 != -1)
            {
                ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.StartJh(indexLine0, "line");
            }
            if (indexLine1 != -1)
            {
                ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.StartJh(indexLine1, "line");
            }
            if (indexLine2 != -1)
            {
                ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.StartJh(indexLine2, "line");
            }
        }
    }

    public void SetJhFalse()
    {
        isJh = false;
    }


    public void Hide()
    {
        if (isHide == false)
        {
            isHide = true;
            GameController.GetInstance().stateLj0[ID] = 0;
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

        if (indexLineArr[0] != -1)
        {
            if (GameController.GetInstance().stateDb[indexLineArr[0]] == 1)
            {
                _numLj++;
            }
        }
        if (indexLineArr[1] != -1)
        {
            if (GameController.GetInstance().stateDb[indexLineArr[1]] == 1)
            {
                _numLj++;
            }
        }
        if (indexLineArr[2] != -1)
        {
            if (GameController.GetInstance().stateDb[indexLineArr[2]] == 1)
            {
                _numLj++;
            }
        }
        if (indexLineArr[3] != -1)
        {
            if (GameController.GetInstance().stateDb[indexLineArr[3]] == 1)
            {
                _numLj++;
            }
        }

        //检测结束判断是否需要隐藏
        if (_numLj <= 1)
        {
            Hide();
        }
    }
    public bool ExamineLineUse(int _id)
    {
        int _numShow = 0;
        for (int i = 0; i < indexLineArr.Length; i++)
        {
            if (indexLineArr[i] != -1)
            {
                if (GameController.GetInstance().stateLine[indexLineArr[i]] == 1)
                {
                    _numShow++;
                }
            }
        }
        if (_numShow > 1)
        {
            return true;
        }
        return false;
    }
}