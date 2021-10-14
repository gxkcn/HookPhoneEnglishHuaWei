using UnityEngine;
using System.Collections;

public class GameButtonLj2 : MonoBehaviour
{
    /// <summary>
    /// 在地图中 ID (唯一)
    /// </summary>
    public int ID;
    /// <summary>
    /// 相关联的细线索引
    /// </summary>
    public int indexLine0, indexLine1;

    private bool isExit;

    public bool isHide;

    public int state;
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
            return true;
        }
        return false;
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
        Debug.Log(ID + "------------------------检测的" + _id);
        Debug.Log(indexLine0 + "- 0 0---" + indexLine1);
        if (indexLine0 != _id && indexLine1 != _id)
        {
            return true;
        }
        int _otherID = indexLine0 == _id ? indexLine1 : indexLine0;
        bool _hide0 = false;
        if (_otherID == -1)
        {
            _hide0 = true;
        }
        else
        {
            if (GameController.GetInstance().stateLine[_otherID] == 0)
            {
                _hide0 = true;
            }
        }

        int _otherID1 = indexLineArr[new int[] {3,0,1,2 }[state]];
        bool _hide1 = false;
        if (_otherID1 == -1)
        {
            _hide1 = true;
        }
        else
        {
            if (GameController.GetInstance().stateLine[_otherID1] == 0)
            {
                _hide1 = true;
            }
        }
        if (_hide0 && _hide1)
        {
            return false;
        }
        return true;
    }
}