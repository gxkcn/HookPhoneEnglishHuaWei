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
        indexLine0 = indexLine1 = indexLine2 = indexLine3 = -1;
        indexLineArr = new int[] { -1, -1, -1, -1 };
        switch (GameController.GetInstance().currentLevel)
        {
            case 12:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 0, -1, 3, 6 }; break;
                    case 1: indexLineArr = new int[] { 1, 6, 4, 7 }; break;
                    case 2: indexLineArr = new int[] { 2, 7, 5, 8 }; break;
                }
                break;
            case 13:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 1, -1, 3, 4 }; break;
                }
                break;
            case 14:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 0, -1, 2, 5 }; break;
                    case 1: indexLineArr = new int[] { 1, 3, 4, -1 }; break;
                }
                break;
            case 15:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 2,-1,3,6 }; break;
                }
                break;
            case 16:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 2,12,3,-1 }; break;
                    case 1: indexLineArr = new int[] { 1,15,-1,7}; break;
                    case 2: indexLineArr = new int[] { 0,4,11,13}; break;
                    case 3: indexLineArr = new int[] { 5,6,-1,14}; break;
                }
                break;
            case 18:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 3,1,4,5 }; break;
                }
                break;
            case 20:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 6,-1,7,9 }; break;
                    case 1: indexLineArr = new int[] { 11,9,12,13}; break;
                }
                break;
            case 22:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 4,-1, 5, 6 }; break;
                }
                break;
            case 23:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { -1,5,1,6 }; break;
                }
                break;
            case 24:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { }; break;
                }
                break;
            case 25:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {14,-1,15,17 }; break;
                    case 1: indexLineArr = new int[] {19,17,20,21 }; break;
                }
                break;
            case 26:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { }; break;
                }
                break;
            case 27:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { }; break;
                }
                break;
            case 28:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 5,-1,6,7 }; break;
                    case 1: indexLineArr = new int[] { 1,8,11,-1 }; break;
                }
                break;
            case 29:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { }; break;
                }
                break;
            case 30:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { }; break;
                }
                break;
            case 31:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {0,-1,9,11 }; break;
                    case 1: indexLineArr = new int[] {2,12,10,-1 }; break;
                    case 2: indexLineArr = new int[] {-1,13,15,14 }; break;
                    case 3: indexLineArr = new int[] {17,3,4,5 }; break;
                    case 4: indexLineArr = new int[] {7,18,20,19 }; break;
                }
                break;
            case 32:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { }; break;
                }
                break;
            case 33:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { }; break;
                }
                break;
            case 34:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { }; break;
                }
                break;

            case 35:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 0, 5, 8, -1 }; break;
                    case 1: indexLineArr = new int[] { 8, 6, 9, -1 }; break;
                }
                break;
            case 36:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { }; break;
                }
                break;
            case 37:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {2,12,-1,13 }; break;
                    case 1: indexLineArr = new int[] {19,14,20,-1 }; break;
                    case 2: indexLineArr = new int[] {4,11,5,-1 }; break;
                    case 3: indexLineArr = new int[] {20,16,21,17 }; break;
                }
                break;
            case 38:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { -1,7,8,10}; break;
                }
                break;
            case 39:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { }; break;
                }
                break;
            case 40:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {22,21,-1,11 }; break;
                }
                break;
            case 41:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {14,-1,15,16 }; break;
                    case 1: indexLineArr = new int[] {0,22,10,-1 }; break;
                    case 2: indexLineArr = new int[] {23,12,24,-1 }; break;
                    case 3: indexLineArr = new int[] {7,17,25,-1 }; break;
                }
                break;
            case 43:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {-1,10,7,23}; break;
                    case 1: indexLineArr = new int[] {15,14,-1,16}; break;
                    case 2: indexLineArr = new int[] {23,6,21,-1}; break;
                    case 3: indexLineArr = new int[] {20,19,18,-1}; break;
                    case 4: indexLineArr = new int[] {17,2,16,-1 }; break;
                }
                break;
            case 44:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 25,7,-1,10}; break;
                    case 1: indexLineArr = new int[] {0,3,16,-1 }; break;
                    case 2: indexLineArr = new int[] {17,4,18,-1 }; break;
                }
                break;
            case 45:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 18,9,-1,13}; break;
                }
                break;
            case 46:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {-1,22,24,23 }; break;
                    case 1: indexLineArr = new int[] { 26,25,27,28}; break;
                    case 2: indexLineArr = new int[] {4,3,32,53 }; break;
                    case 3: indexLineArr = new int[] {-1,37,40,36 }; break;
                    case 4: indexLineArr = new int[] {35,38,41,39 }; break;
                    case 5: indexLineArr = new int[] {46,44,47,48 }; break;
                    case 6: indexLineArr = new int[] { 49,45,-1 ,50}; break;
                }
                break;
            case 47:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 14,1,-1,15}; break;
                    case 1: indexLineArr = new int[] {19,16,18,-1 }; break;
                    case 2: indexLineArr = new int[] {27,22,17,-1 }; break;
                    case 3: indexLineArr = new int[] { 25,11,8,-1}; break;
                    case 4: indexLineArr = new int[] { 26,28,24,-1}; break;
                }
                break;
            case 48:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {21,-1,22,23 }; break;
                    case 1: indexLineArr = new int[] {16,-1,20,2 }; break;
                    case 2: indexLineArr = new int[] {-1,15,18,8 }; break;
                    case 3: indexLineArr = new int[] {14,5,24,-1 }; break;
                    case 4: indexLineArr = new int[] {-1,9,25,19 }; break;
                }
                break;
            case 49:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {22,25,-1,27 }; break;
                    case 1: indexLineArr = new int[] {-1,0,3,28 }; break;
                    case 2: indexLineArr = new int[] {35,24,36,-1 }; break;
                    case 3: indexLineArr = new int[] { 37, 26, 38, 29 }; break;
                    case 4: indexLineArr = new int[] { 41,20,42,15}; break;
                    case 5: indexLineArr = new int[] {43,-1,44,13 }; break;
                    case 6: indexLineArr = new int[] {16,33,7,12 }; break;
                    case 7: indexLineArr = new int[] {46,34,9,-1 }; break;
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
            Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>LJ< 0 >被激活 " + ID);
            Debug.Log("<lj   0 >"+ID+"   "+indexLine0 + "   " + indexLine1 + "   " + indexLine2 + "   " + indexLine3);
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
            if (indexLine3 != -1)
            {
                ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.StartJh(indexLine3, "line");
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
            if (GameController.GetInstance().stateLine[indexLineArr[0]] == 1)
            {
                _numLj++;
            }
        }
        if (indexLineArr[1] != -1)
        {
            if (GameController.GetInstance().stateLine[indexLineArr[1]] == 1)
            {
                _numLj++;
            }
        }
        if (indexLineArr[2] != -1)
        {
            if (GameController.GetInstance().stateLine[indexLineArr[2]] == 1)
            {
                _numLj++;
            }
        }
        if (indexLineArr[3] != -1)
        {
            if (GameController.GetInstance().stateLine[indexLineArr[3]] == 1)
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