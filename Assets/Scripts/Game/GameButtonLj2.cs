using UnityEngine;
using System.Collections;

public class GameButtonLj2 : MonoBehaviour
{
    /// <summary>
    /// 在地图中 ID (唯一)
    /// </summary>
    public int ID;
    public int state;
    /// <summary>
    /// 相关联的细线索引
    /// </summary>
    public int indexLine0, indexLine1;

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
        indexLine0 = indexLine1 = -1;
        state = 0;
        indexLineArr = new int[] { -1, -1, -1, -1 };
        switch (GameController.GetInstance().currentLevel)
        {
            case 21:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 4,-1,5,6 }; state = 0; break;
                    case 1: indexLineArr = new int[] { 0,-1,1,4 }; state = 0; break;
                    case 2: indexLineArr = new int[] { 2,-1,3,5 }; state = 0; break;
                }
                break;
            case 22:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 0,1,4,7 }; state = 3; break;
                    case 1: indexLineArr = new int[] { 5,2,3,8 }; state = 0; break;
                }
                break;
            case 23:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {4,2,7,5}; state = 0; break;
                    case 1: indexLineArr = new int[] {3,6,7,0}; state = 0; break;
                }
                break;
            case 24:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {0,1,7,6  }; state = 0; break;
                    case 1: indexLineArr = new int[] {7,2,-1,8  }; state = 0; break;
                    case 2: indexLineArr = new int[] { 4,5,10,9}; state = 0; break;
                    case 3: indexLineArr = new int[] {3,9,11,-1 }; state = 0; break;
                }
                break;
            case 25:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {0,-1,9,8 }; state = 0; break;
                    case 1: indexLineArr = new int[] {1,8,10,-1 }; state = 0; break;
                    case 2: indexLineArr = new int[] {2,-1,12,11 }; state = 0; break;
                    case 3: indexLineArr = new int[] {3,11,13,-1 }; state = 0; break;
                    case 4: indexLineArr = new int[] {10,9,14,16 }; state = 0; break;
                    case 5: indexLineArr = new int[] {12,16,19,13 }; state = 0; break;
                    case 6: indexLineArr = new int[] {15,22,24,18 }; state = 0; break;
                    case 7: indexLineArr = new int[] {20,18,25,27 }; state = 0; break;
                    case 8: indexLineArr = new int[] {22,-1,4,23 }; state = 0; break;
                    case 9: indexLineArr = new int[] {24,23,5,-1 }; state = 0; break;
                    case 10: indexLineArr = new int[] {25,-1,6,26 }; state = 0; break;
                    case 11: indexLineArr = new int[] {27,26,7,-1 }; state = 0; break;
                }
                break;
            case 26:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {0,-1,2,8 }; state = 3; break;
                    case 1: indexLineArr = new int[] { 2,-1,3,9}; state = 3; break;
                    case 2: indexLineArr = new int[] {3,-1,-1,10 }; state = 0; break;
                    case 3: indexLineArr = new int[] {5,10,14,13 }; state = 0; break;
                    case 4: indexLineArr = new int[] {7,13,-1,-1 }; state = 0; break;
                    case 5: indexLineArr = new int[] {6,12,7,-1 }; state = 3; break;
                    case 6: indexLineArr = new int[] {1,11,6,-1 }; state = 3; break;
                }
                break;
            case 28:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { -1,9,3,10}; state = 0; break;
                }
                break;
            case 29:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 0, -1, -1,3 }; state = 0; break;
                    case 1: indexLineArr = new int[] { -1,2,4,-1 }; state = 0; break;
                }
                break;
            case 30:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 1,9,12,14}; state = 0; break;
                    case 1: indexLineArr = new int[] { 12,-1,13,15}; state = 0; break;
                    case 2: indexLineArr = new int[] {2,14,16,11 }; state = 0; break;
                    case 3: indexLineArr = new int[] { 16,15,17,-1}; state = 0; break;
                }
                break;
            case 31:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 9,-1,-1,13}; state = 0; break;
                    case 1: indexLineArr = new int[] { 1,11,-1,12}; state = 0; break;
                    case 2: indexLineArr = new int[] {10,14,-1,-1 }; state = 0; break;
                    case 3: indexLineArr = new int[] {6,-1,-1,18 }; state = 0; break;
                    case 4: indexLineArr = new int[] {8,19,-1,-1 }; state = 0; break;
                }
                break;
            case 33:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 0,-1,1,5 }; state = 3; break;
                }
                break;
            case 34:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { -1,8,4,9}; state = 3; break;
                    case 1: indexLineArr = new int[] { 4,-1,5,10 }; state = 3; break;
                    case 2: indexLineArr = new int[] { 6,10,7,-1}; state = 3; break;
                }
                break;
            case 35:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 9,6,10,12 }; state = 3; break;
                }
                break;
            case 37:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 18,15,-1,-1}; state = 0; break;
                }
                break;
            case 38:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { }; state = 0; break;
                    case 1: indexLineArr = new int[] { }; state = 0; break;
                    case 2: indexLineArr = new int[] { }; state = 0; break;
                    case 3: indexLineArr = new int[] { }; state = 0; break;
                }
                break;
            case 40:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {15,13,4,16 }; state = 3; break;
                    case 1: indexLineArr = new int[] {17,16,6,24 }; state = 3; break;
                    case 2: indexLineArr = new int[] {-1,24,10,-1 }; state = 3; break;
                    case 3: indexLineArr = new int[] {7,14,19,18 }; state = 3; break;
                    case 4: indexLineArr = new int[] {  -1,19,20,21 }; state = 3; break;
                    case 5: indexLineArr = new int[] { 8,18,22,9  }; state = 3; break;
                }
                break;
            case 42:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 8,-1,9,10}; state = 0; break;
                    case 1: indexLineArr = new int[] {-1,3,13,15 }; state = 0; break;
                    case 2: indexLineArr = new int[] {14,7,-1,17 }; state = 0; break;
                    
                }
                break;
            case 43:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {11,-1,12,3 }; state = 3; break;
                    case 1: indexLineArr = new int[] {13,12,-1,14 }; state = 3; break;
                }
                break;
            case 46:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { -1,0,20,22}; state = 3; break;
                    case 1: indexLineArr = new int[] { 20,2,21,25}; state = 3; break;
                    case 2: indexLineArr = new int[] {27,21,31,30 }; state = 3; break;
                    case 3: indexLineArr = new int[] { -1,23,29,5}; state = 3; break;
                    case 4: indexLineArr = new int[] {29,28,30,7 }; state = 3; break;
                    case 5: indexLineArr = new int[] {8,34,36,54 }; state = 3; break;
                    case 6: indexLineArr = new int[] { 40,39,16,15}; state = 3; break;
                    case 7: indexLineArr = new int[] {42,12,43,44 }; state = 3; break;
                    case 8: indexLineArr = new int[] { 43,14,-1,45}; state = 3; break;
                    case 9: indexLineArr = new int[] { 51,48,52,17}; state = 3; break;
                    case 10: indexLineArr = new int[] {52,50,-1,19 }; state = 3; break;
                }
                break;
            case 47:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {3,0,14,16 }; state = 3; break;
                    case 1: indexLineArr = new int[] {18,15,-1,17 }; state = 3; break;
                    case 2: indexLineArr = new int[] {-1,4,21,23 }; state = 3; break;
                }
                break;
            case 48:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {24,6,7,13}; state = 0; break;
                    case 1: indexLineArr = new int[] {25,11,26,-1 }; state = 0; break;
                    case 2: indexLineArr = new int[] {10,20,22,26 }; state = 0; break;
                }
                break;
            case 49:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { }; state = 0; break;
                    case 1: indexLineArr = new int[] { }; state = 0; break;
                    case 2: indexLineArr = new int[] { }; state = 0; break;
                    case 3: indexLineArr = new int[] { }; state = 0; break;
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
                Debug.Log("-------------------------------ButtonUp S<2>P  = " + ID);
                state ++;
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
        int[] shunXv = { 1, 2 };
        switch (state)
        {
            case 0: shunXv = new int[] { 1,2 }; break;
            case 1: shunXv = new int[] { 2,3 }; break;
            case 2: shunXv = new int[] { 3,0 }; break;
            case 3: shunXv = new int[] { 0,1 }; break;
        }
        indexLine0 = indexLineArr[shunXv[0]];
        indexLine1 = indexLineArr[shunXv[1]];
    }

    public void StartJh()
    {
        if (isJh == false)
        {
            Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>LJ< 2 >被激活 " + ID);
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
        }
    }
    /// <summary>
    /// 判断是否可以被已经激活的细线激活
    /// </summary>
    /// <param name="_indexLine"></param>
    /// <returns></returns>
    public bool GetStartJhLj(int _indexLine)
    {
        if (indexLine0 == _indexLine || indexLine1 == _indexLine)
        {
            Debug.Log(_indexLine + "可以被激活" + ID);
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
            GameController.GetInstance().stateLj2[ID] = 0;
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
        Debug.Log(ID + "***********************************************use 2    " + _id);
        int _postion = 0;
        for(int i = 0; i < indexLineArr.Length; i++)
        {
            if(indexLineArr[i] == _id)
            {
                _postion = i;
                break;
            }
        }
        int[] _threeLine = { 0,0,0};
        switch (_postion)
        {
            case 0: _threeLine = new int[] { indexLineArr[0], indexLineArr[1], indexLineArr[3] }; break;
            case 1: _threeLine = new int[] { indexLineArr[1], indexLineArr[0], indexLineArr[2] }; break;
            case 2: _threeLine = new int[] { indexLineArr[2], indexLineArr[1], indexLineArr[3] }; break;
            case 3: _threeLine = new int[] { indexLineArr[3], indexLineArr[0], indexLineArr[2] }; break;
        }
        int _numShow = 0;
        for (int i = 0; i < _threeLine.Length; i++)
        {
            if (_threeLine[i] != -1)
            {
                if (GameController.GetInstance().stateLine[_threeLine[i]] == 1)
                {
                    _numShow++;
                }
            }
        }
        if (_numShow > 1)
        {
            Debug.Log(ID+"***********************************************use 2    " + true);
            return true;
        }
        Debug.Log(ID + "***********************************************use 2    " + false);
        return false;
    }
}