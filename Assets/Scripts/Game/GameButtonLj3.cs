using UnityEngine;
using System.Collections;

public class GameButtonLj3 : MonoBehaviour
{
    /// <summary>
    /// 在地图中 ID (唯一)
    /// </summary>
    public int ID;
    public int state;
    /// <summary>
    /// 相关联的细线索引
    /// </summary>
    public int indexLine0, indexLine1, indexLine2;

    private bool isExit;

    public bool isHide;

    
    private int[] indexLineArr;

    public bool isJh;

    private bool isCanClick;

    // Use this for initialization
    void Start()
    {

    }

    public void InitData()
    {
        gameObject.SetActive(true);
        isHide = false;
        isCanClick = true;
        isJh = false;
        indexLine0 = indexLine1 = indexLine2  = - 1;
        state = 0;
        indexLineArr = new int[] { -1, -1, -1, -1 };
        switch (GameController.GetInstance().currentLevel)
        {
            case 27:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 3,2,4,-1 }; state = 0; break;
                    case 1: indexLineArr = new int[] { 4,1,5, -1 }; state = 0; break;
                    case 2: indexLineArr = new int[] { 5,0,6, -1 }; state = 0; break;
                }
                break;
            case 28:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {6,-1,4,9  }; state = 0; break;
                    case 1: indexLineArr = new int[] {11,10,2,-1  }; state = 0; break;
                }
                break;
            case 29:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {1,3,5,4 }; state = 0; break;
                }
                break;
            case 30:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 0,-1,8,4}; state = 0; break;
                    case 1: indexLineArr = new int[] { 8,-1,9,5}; state = 0; break;
                    case 2: indexLineArr = new int[] {6,7,10,-1 }; state = 0; break;
                    case 3: indexLineArr = new int[] {  10,3,11,-1 }; state = 0; break;
                }
                break;
            case 32:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {7,-1,6,5 }; state = 0; break;
                    case 1: indexLineArr = new int[] {2,4,-1,8 }; state = 0; break;
                    case 2: indexLineArr = new int[] {1,8,9,-1 }; state = 0; break;
                    case 3: indexLineArr = new int[] {7,3,10,-1 }; state = 0; break;
                }
                break;
            case 33:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { -1,6,2,3 }; state = 2; break;
                }
                break;
            case 36:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {9,0,2,11 }; state = 0; break;
                    case 1: indexLineArr = new int[] {5,3,10,12 }; state = 0; break;
                }
                break;
            case 37:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {-1,10,19,15 }; state = 0; break;
                    case 1: indexLineArr = new int[] {7,8,9,16 }; state = 0; break;
                }
                break;
            case 38:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {8,-1,9,11 }; state = 0; break;
                    case 1: indexLineArr = new int[] { -1, 10, 11, -1 };state = 0; break;
                    case 2: indexLineArr = new int[] {0,14,-1,6 }; state = 0; break;
                }
                break;
            case 39:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {0,10,12,1 }; state = 0; break;
                    case 1: indexLineArr = new int[] { 12,11,-1,2}; state = 0; break;
                    case 2: indexLineArr = new int[] {5,-1,14,6 }; state = 0; break;
                    case 3: indexLineArr = new int[] {14,13,9,17 }; state = 0; break;
                    case 4: indexLineArr = new int[] {15,7,16,-1 }; state = 0; break;
                    case 5: indexLineArr = new int[] {16,8,17,-1 }; state = 0; break;
                }
                break;
            case 40:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {13,-1,2,0 }; state = 0; break;
                    case 1: indexLineArr = new int[] {3,-1,14,1 }; state = 0; break;
                    case 2: indexLineArr = new int[] {23,15,5,17 }; state = 0; break;
                }
                break;
            case 41:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {2,-1,14,8 }; state = 0; break;
                    case 1: indexLineArr = new int[] {17,-1,18,3 }; state = 0; break;
                    case 2: indexLineArr = new int[] {18,16,19,4 }; state = 0; break;
                    case 3: indexLineArr = new int[] {5,15,-1,20 }; state = 0; break;
                    case 4: indexLineArr = new int[] { -1,1,6,21}; state = 0; break;
                    case 5: indexLineArr = new int[] {13,20,-1,24 }; state = 0; break;
                    case 6: indexLineArr = new int[] {25,9,23,-1 }; state = 0; break;
                }
                break;
            case 42:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {1,10,4,11 }; state = 0; break;
                    case 1: indexLineArr = new int[] {2,11,5,12 }; state = 0; break;
                    case 2: indexLineArr = new int[] {13,12,14,16 }; state = 0; break;
                }
                break;
            case 43:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {10,-1,11,0 }; state = 0; break;
                    case 1: indexLineArr = new int[] {1,8,13,-1 }; state = 0; break;
                    case 2: indexLineArr = new int[] {21,22,20,-1 }; state = 0; break;
                    case 3: indexLineArr = new int[] {18,4,17,-1 }; state = 0; break;
                }
                break;
            case 44:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {8,6,25,9 }; state = 0; break;
                    case 1: indexLineArr = new int[] {8,9,10,11 }; state = 0; break;
                    case 2: indexLineArr = new int[] {12,-1,13,14 }; state = 0; break;
                    case 3: indexLineArr = new int[] {1,15,2,-1 }; state = 0; break;
                    case 4: indexLineArr = new int[] {20,19,21,22 }; state = 0; break;
                }
                break;
            case 45:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {1,0,10,11 }; state = 0; break;
                    case 1: indexLineArr = new int[] {11,2,18,12 }; state = 0; break;
                    case 2: indexLineArr = new int[] {3,13,14,15 }; state = 0; break;
                    case 3: indexLineArr = new int[] {8,12,19,4 }; state = 0; break;
                    case 4: indexLineArr = new int[] {19,15,-1,16 }; state = 0; break;
                    case 5: indexLineArr = new int[] {7,6,16,17 }; state = 0; break;
                }
                break;
            case 46:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {24,1,26,6 }; state = 0; break;
                    case 1: indexLineArr = new int[] {41,42,46,51 }; state = 0; break;
                    case 2: indexLineArr = new int[] {47,13,49,18 }; state = 0; break;
                }
                break;
            case 47:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {21,2,19,20 }; state = 0; break;
                    case 1: indexLineArr = new int[] {6,5,-1,22 }; state = 0; break;
                    case 2: indexLineArr = new int[] {24,10,9,-1 }; state = 0; break;
                    case 3: indexLineArr = new int[] {13,12,25,28 }; state = 0; break;
                }
                break;
            case 48:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {12,0,1,13 }; state = 0; break;
                    case 1: indexLineArr = new int[] {14,-1,16,15 }; state = 0; break;
                    case 2: indexLineArr = new int[] {17,-1,19,18 }; state = 0; break;
                    case 3: indexLineArr = new int[] { 3, -1, 21, 4 }; state = 0; break;
                }
                break;
            case 49:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {21,23,35,30 }; state = 0; break;
                    case 1: indexLineArr = new int[] {36,27,37,-1 }; state = 0; break;
                    case 2: indexLineArr = new int[] {38,28,39,-1 }; state = 0; break;
                    case 3: indexLineArr = new int[] {39,2,4,31 }; state = 0; break;
                    case 4: indexLineArr = new int[] { 40,1,5,10}; state = 0; break;
                    case 5: indexLineArr = new int[] {19,30,41,-1 }; state = 0; break;
                    case 6: indexLineArr = new int[] {42,-1,43,32 }; state = 0; break;
                    case 7: indexLineArr = new int[] {44,-1,45,33 }; state = 0; break;
                    case 8: indexLineArr = new int[] {45,31,6,8 }; state = 0; break;
                    case 9: indexLineArr = new int[] {14,32,11,34 }; state = 0; break;
                    case 10: indexLineArr = new int[] {18,17,46,-1 }; state = 0; break;
                }
                break;

        }
        SetState(state);
    }

    public void ButtonDown()
    {
        if (isCanClick)
        {
            isExit = false;
            transform.localScale = Vector3.one * 1.2f;
            AudioManager.GetInstance().PlaySound(AudioManager.SoundClick1);
        }
    }

    public void ButtonExit()
    {
        if (isCanClick)
        {
            isExit = true;
            transform.localScale = Vector3.one;
        }
    }

    public void ButtonUp()
    {
        if (isCanClick)
        {
            transform.localScale = Vector3.one;
            if (isExit == false)
            {
                Debug.Log("-------------------------------ButtonUp S<3>P  = " + ID);
                state++;
                SetState(state);
                ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.ResetLineLjState();
                Invoke("ResetClick", 0.8f);
            }
        }
    }

    private void ResetClick()
    {
        isCanClick = true;
    }

    private void SetState(int _value)
    {
        state = _value;
        if (state > 3)
        {
            state = 0;
        }
        gameObject.transform.localEulerAngles = new Vector3(0, 0, state * -90);
        int[] shunXv = { 0,1,2};
        switch (state)
        {
            case 0: shunXv = new int[] { 0, 1, 2 }; break;
            case 1: shunXv = new int[] { 1,2,3 }; break;
            case 2: shunXv = new int[] { 2,3,0 }; break;
            case 3: shunXv = new int[] { 3,0,1 }; break;
        }
        indexLine0 = indexLineArr[shunXv[0]];
        indexLine1 = indexLineArr[shunXv[1]];
        indexLine2 = indexLineArr[shunXv[2]];
    }

    public void StartJh()
    {
        if (isJh == false)
        {
            //gameObject.transform.localScale = Vector3.one * 1.2f;
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
    /// <summary>
    /// 判断是否可以被已经激活的细线激活
    /// </summary>
    /// <param name="_indexLine"></param>
    /// <returns></returns>
    public bool GetStartJhLj(int _indexLine)
    {
        if (indexLine0 == _indexLine || indexLine1 == _indexLine || indexLine2 == _indexLine)
        {
            return true;
        }
        return false;
    }

    public void SetJhFalse()
    {
        gameObject.transform.localScale = Vector3.one;
        isJh = false;
    }


    public void Hide()
    {
        if (isHide == false)
        {
            isHide = true;
            GameController.GetInstance().stateLj3[ID] = 0;
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