using UnityEngine;
using System.Collections;

public class GameButtonLj1 : MonoBehaviour
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
            case 17:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 1,0,5,4 }; state = 1; break;
                    case 1: indexLineArr = new int[] { 6,3,2,7 }; state = 0; break;
                }
                break;
            case 18:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { -1,0,-1,3 }; state = 1; break;
                    case 1: indexLineArr = new int[] { -1,2, -1, 4 }; state = 0; break;
                }
                break;
            case 19:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {4,0,1,6  }; state = 1; break;
                    case 1: indexLineArr = new int[] { 5,6,7,8 }; state = 0; break;
                    case 2: indexLineArr = new int[] { 7,2,3,9 }; state = 0; break;
                }
                break;
            case 20:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 3, 0, 6, 8 };state = 0; break;
                    case 1: indexLineArr = new int[] { 7, 1, 5, 10 }; state = 0; break;
                    case 2: indexLineArr = new int[] { 2, 8, 11, 14 }; state = 1; break;
                    case 3: indexLineArr = new int[] { 12, 10, 4, 15 }; state = 1; break;
                }
                break;
            case 26:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {-1,8,4,11 }; state = 1; break;
                    case 1: indexLineArr = new int[] {4,9,5,12 }; state = 0; break;
                }
                break;
            case 28:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {0,-1,5,-1  }; state = 0; break;
                }
                break;
            case 31:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 16,-1,17,-1 }; state = 1; break;
                    case 1: indexLineArr = new int[] { 20,-1,21,-1 }; state = 1; break;
                }
                break;
            case 35:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 10,7,11,13 }; state = 1; break;
                }
                break;
            case 37:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {-1,13,-1,14 }; state = 1; break;
                    case 1: indexLineArr = new int[] {21,-1,22,-1 }; state = 0; break;
                }
                break;
            case 43:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 5,22,15,9}; state = 0; break;
                }
                break;
            case 44:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] {16,-1,17,-1 }; state = 0; break;
                    case 1: indexLineArr = new int[] {20,22,23,24 }; state = 1; break;
                }
                break;
            case 46:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 31,53,33,9}; state = 0; break;
                    case 1: indexLineArr = new int[] {37,10,11,38 }; state = 0; break;
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
                Debug.Log("-------------------------------ButtonUp S<1>P  = " + ID);
                state = state == 0 ? 1 : 0;
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
        gameObject.transform.localEulerAngles = new Vector3(0, 0, state * -90);
        int[] shunXv = { 0, 2 };
        switch (state)
        {
            case 0: shunXv = new int[] { 0, 2 }; break;
            case 1: shunXv = new int[] { 1, 3 }; break;
        }
        indexLine0 = indexLineArr[shunXv[0]];
        indexLine1 = indexLineArr[shunXv[1]];
    }

    public void StartJh()
    {
        if (isJh == false)
        {
            //gameObject.transform.localScale = Vector3.one * 1.2f;
            Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>LJ< 1 >被激活 " + ID);
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
        if(indexLine0 == _indexLine || indexLine1 == _indexLine)
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
            GameController.GetInstance().stateLj1[ID] = 0;
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
        Debug.Log("LJ 1 检测num "+ID + indexLineArr[0]+" " + indexLineArr[1] + " " + indexLineArr[2] + " " + indexLineArr[3]);
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
        Debug.Log("LJ 1 检测num " + ID + "===="+_numLj);
        //检测结束判断是否需要隐藏
        if (_numLj <= 1)
        {
            Hide();
        }
    }
    public bool ExamineLineUse(int _id)
    {
        Debug.Log(ID + "------------------------检测的" + _id);
        Debug.Log(indexLine0 + "- 0 0---" + indexLine1);
        if (indexLine0 != _id&& indexLine1 != _id)
        {
            return true;
        }
        int _otherID = indexLine0 == _id ? indexLine1 : indexLine0;
        if (_otherID == -1)
        {
            return false;
        }
        Debug.Log(ID + "------------------------对应的" + _otherID);
        Debug.Log(ID + "------------------------对应的" + GameController.GetInstance().stateLine[_otherID]);
        if (GameController.GetInstance().stateLine[_otherID] == 0)
        {
            Debug.Log(ID + "------------------------" + false);
            return false;
        }
        Debug.Log(ID + "------------------------" + true);
        return true;
    }
}