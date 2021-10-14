using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameButtonCicle : MonoBehaviour {
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

    public bool isCanClick;

    // Use this for initialization
    void Start () {

	}

    public void InitData()
    {
        gameObject.SetActive(true);
        isHide = false;
        isCanClick = true;
        indexLine0 = indexLine1= indexLine2= indexLine3=-1;
                
        switch (GameController.GetInstance().currentLevel)
        {
            case 0:
                switch (ID)
                {
                    case 0: indexLine0 = 0; break; 
                }                
                break;
            case 1:
                switch (ID)
                {
                    case 0: indexLine0 = 0; break;
                    case 1: indexLine0 = 1; break;
                }
                break;
            case 2:
                switch (ID)
                {
                    case 0: indexLine0 = 0; break;
                    case 1: indexLine0 = 1; break;
                    case 2: indexLine0 = 2; break;
                    case 3: indexLine0 = 3; break;
                }
                break;
            case 3:
                switch (ID)
                {
                    case 0: indexLine0 = 0; break;
                    case 1: indexLine0 = 1; break;
                    case 2: indexLine0 = 2; break;
                }
                break;
            case 17:
                switch (ID)
                {
                    case 0: indexLine0 = 4; break;
                    case 1: indexLine0 = 5; break;
                    case 2: indexLine0 = 6; break;
                    case 3: indexLine0 = 7; break;
                }
                break;
            case 21:
                switch (ID)
                {
                    case 0: indexLine0 = 6; break;
                }
                break;
        }

    }

    public void ButtonDown()
    {
        if (isCanClick)
        {
            isExit = false;
            transform.localScale = Vector3.one * 1.2f;
            AudioManager.GetInstance().PlaySound(AudioManager.SoundClick0);
        }        
    }

    public  void ButtonExit()
    {
        if (isCanClick)
        {
            isExit = true;
            transform.localScale = Vector3.one;
        }           
    }

    public void ButtonUp()
    {
        transform.localScale = Vector3.one;
        if (isExit == false)
        {
            Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>ButtonUp ID = " + ID);
            StartJh();
            Invoke("ButtonClickFun", 0.1f);
           
            isCanClick = false;
            Invoke("ResetClick",0.8f);
        }       
    }
    private void ButtonClickFun()
    {
        ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.ButtonClickFun(ID);
    }

    private void ResetClick()
    {
        isCanClick = true;
    }

    public void StartJh()
    {
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


    public void Hide()
    {
        if (isHide == false)
        {
            isHide = true;
            GameController.GetInstance().stateBtnCicle[ID] = 0;
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
            if (GameController.GetInstance().stateLine[indexLine0] == 1)
            {
                _numLj++;
            }
        }
        if (indexLine1 != -1)
        {
            if (GameController.GetInstance().stateLine[indexLine1] == 1)
            {
                _numLj++;
            }
        }
        if (indexLine2 != -1)
        {
            if (GameController.GetInstance().stateLine[indexLine2] == 1)
            {
                _numLj++;
            }
        }
        if (indexLine3 != -1)
        {
            if (GameController.GetInstance().stateLine[indexLine3] == 1)
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
}
