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

    private bool isExit;

    public bool isHide;

    private int state;
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
        state = 0;
        indexLineArr = new int[] { -1, -1, -1, -1 };
        switch (GameController.GetInstance().currentLevel)
        {
            case 44:
                switch (ID)
                {
                    case 0: indexLineArr = new int[] { 2, 0, 1, 3 }; break;
                    case 1: indexLineArr = new int[] { 7, 6, 8, -1 }; break;
                    case 2: indexLineArr = new int[] { 18, 16, 20, 19 }; break;
                    case 3: indexLineArr = new int[] { 18, 19, 21, 22 }; break;
                    case 4: indexLineArr = new int[] { 23, -1, 25, 24 }; break;
                }
                break;
        }
        SetState(state);
    }

    public void ButtonDown()
    {
        isExit = false;
        transform.localScale = Vector3.one * 1.2f;
        AudioManager.GetInstance().PlaySound(AudioManager.SoundClick1);
    }

    public void ButtonExit()
    {
        isExit = true;
        transform.localScale = Vector3.one;
    }

    public void ButtonUp()
    {
        transform.localScale = Vector3.one;
        if (isExit == false)
        {
            Debug.Log("-------------------------------ButtonUp S<3>P  = " + ID);
            state++;
            SetState(state);
        }

    }

    private void SetState(int _value)
    {
        state = _value;
        if (state > 3)
        {
            state = 0;
        }
        gameObject.transform.localEulerAngles = new Vector3(0, 0, state * -90);
        int[] shunXv = { 0, 1, 2, 3 };
        switch (state)
        {
            case 0: shunXv = new int[] { 0, 1, 2 }; break;
            case 1: shunXv = new int[] { 1, 2, 3 }; break;
            case 2: shunXv = new int[] { 2, 3, 0 }; break;
            case 3: shunXv = new int[] { 3, 0, 1 }; break;
        }
        Debug.Log(state);
        Debug.Log(indexLineArr);
        Debug.Log(shunXv);
        indexLine0 = indexLineArr[shunXv[0]];
        indexLine1 = indexLineArr[shunXv[1]];
        indexLine2 = indexLineArr[shunXv[2]];
        indexLine3 = -1;
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

        if (indexLine0 != -1)
        {
            if (GameController.GetInstance().stateDb[indexLine0] == 1)
            {
                _numLj++;
            }
        }
        if (indexLine1 != -1)
        {
            if (GameController.GetInstance().stateDb[indexLine0] == 1)
            {
                _numLj++;
            }
        }
        if (indexLine2 != -1)
        {
            if (GameController.GetInstance().stateDb[indexLine0] == 1)
            {
                _numLj++;
            }
        }
        if (indexLine3 != -1)
        {
            if (GameController.GetInstance().stateDb[indexLine0] == 1)
            {
                _numLj++;
            }
        }

        //检测结束判断是否需要隐藏
        if (_numLj <= 0)
        {
            Hide();
        }
    }

    public bool ExamineLineUse(int _id)
    {

        return true;
    }
}