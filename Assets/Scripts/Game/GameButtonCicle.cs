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
            case 4:
                switch (ID)
                {
                    case 0: indexLine0 = 0; break;
                    case 1: indexLine0 = 1; break;                    
                }
                break;
            case 5:
                switch (ID)
                {
                    case 0: indexLine0 = 0; break;
                    case 1: indexLine0 = 1; break;
                    case 2: indexLine0 = 2; break;
                    case 3: indexLine0 = 3; break;
                }
                break;
            case 6:
                switch (ID)
                {
                    case 0: indexLine0 = 0; indexLine1 = 1; break;
                    case 1: indexLine0 = 2; break;
                    case 2: indexLine0 = 3; break;
                    case 3: indexLine0 = 4; break;
                }
                break;
            case 7:
                switch (ID)
                {
                    case 0: indexLine0 = 3; break;
                    case 1: indexLine0 = 1; break;
                    case 2: indexLine0 = 2; break;
                    case 3: indexLine0 = 4; break;
                    case 4: indexLine0 = 0; break;
                }
                break;
            case 8:
                switch (ID)
                {
                    case 0: indexLine0 = 1; indexLine1 = 4; break;
                    case 1: indexLine0 = 0; indexLine1 = 3; break;
                    case 2: indexLine0 = 2; indexLine1 = 5; break;
                }
                break;
            case 9:
                switch (ID)
                {
                    case 0: indexLine0 = 3;  break;
                    case 1: indexLine0 = 1;  break;
                    case 2: indexLine0 = 2;  break;
                    case 3: indexLine0 = 0;  break;
                }
                break;
            case 10:
                switch (ID)
                {
                    case 0: indexLine0 = 0; break;
                    case 1: indexLine0 = 3; break;
                    case 2: indexLine0 = 2; break;
                    case 3: indexLine0 = 1; break;
                }
                break;
            case 11:
                switch (ID)
                {
                    case 0: indexLine0 = 5; break;
                    case 1: indexLine0 = 2; break;
                    case 2: indexLine0 = 1; break;
                    case 3: indexLine0 = 4; break;
                    case 4: indexLine0 = 3; break;
                    case 5: indexLine0 = 0; break;
                }
                break;
            case 12:
                switch (ID)
                {
                    case 0: indexLine0 = 8; break;
                }
                break;
            case 13:
                switch (ID)
                {
                    case 0: indexLine0 = 0; break;
                    case 1: indexLine0 = 4; break;
                    case 2: indexLine0 = 2; break;
                }
                break;
            case 14:
                switch (ID)
                {
                    case 0: indexLine0 = 5; break;
                    case 1: indexLine0 = 4; break;
                }
                break;
            case 15:
                switch (ID)
                {
                    case 0: indexLine0 = 4; break;
                    case 1: indexLine0 = 6; break;
                    case 2: indexLine0 = 0; break;
                    case 3: indexLine0 = 1; break;
                    case 4: indexLine0 = 5; break;
                }
                break;
            case 16:
                switch (ID)
                {
                    case 0: indexLine0 = 12; break;
                    case 1: indexLine0 = 15; break;
                    case 2: indexLine0 = 10; break;
                    case 3: indexLine0 = 13; break;
                    case 4: indexLine0 = 14; break;
                    case 5: indexLine0 = 8; break;
                    case 6: indexLine0 = 9; break;
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
            case 18:
                switch (ID)
                {
                    case 0: indexLine0 = 5; break;
                }
                break;
            case 19:
                switch (ID)
                {
                    case 0: indexLine0 = 4; break;
                    case 1: indexLine0 = 5; break;
                    case 2: indexLine0 = 8; break;
                    case 3: indexLine0 = 9; break;
                }
                break;
            case 20:
                switch (ID)
                {
                    case 0: indexLine0 = 13; indexLine1 = 14; indexLine2 = 15; break;
                }
                break;
            case 21:
                switch (ID)
                {
                    case 0: indexLine0 = 6; break;
                }
                break;
            case 22:
                switch (ID)
                {
                    case 0: indexLine0 = 7; indexLine1 = 6; indexLine2 = 8; break;
                }
                break;
            case 23:
                switch (ID)
                {
                    case 0: indexLine0 = 3; indexLine1 = 4; break;
                }
                break;
            case 24:
                switch (ID)
                {
                    case 0: indexLine0 = 6; indexLine1 = 8; break;
                    case 1: indexLine0 = 10; indexLine1 = 11; break;
                }
                break;
            case 25:
                switch (ID)
                {
                    case 0: indexLine0 = 21; break;
                }
                break;
            case 26:
                switch (ID)
                {
                    case 0: indexLine0 = 14; break;
                }
                break;
            case 27:
                switch (ID)
                {
                    case 0: indexLine0 = 6; break;
                }
                break;
            case 28:
                switch (ID)
                {
                    case 0: indexLine0 = 7; indexLine1 = 8; break;
                }
                break;
            case 29:
                switch (ID)
                {
                    case 0: indexLine0 = 5;  break;
                }
                break;
            case 30:
                switch (ID)
                {
                    case 0: indexLine0 = 13; break;
                    case 1: indexLine0 = 17; break;
                }
                break;
            case 31:
                switch (ID)
                {
                    case 0: indexLine0 = 16; break;
                    case 1: indexLine0 = 15; break;
                    case 2: indexLine0 = 21; break;
                }
                break;
            case 32:
                switch (ID)
                {
                    case 0: indexLine0 = 9; break;
                    case 1: indexLine0 = 0; break;
                    case 2: indexLine0 = 10; break;
                }
                break;
            case 33:
                switch (ID)
                {
                    case 0: indexLine0 = 4; break;
                }
                break;
            case 34:
                switch (ID)
                {
                    case 0: indexLine0 = 6; indexLine1 = 9; break;
                }
                break;
            case 35:
                switch (ID)
                {
                    case 0: indexLine0 = 7; indexLine1 = 11; break;
                }
                break;
            case 36:
                switch (ID)
                {
                    case 0: indexLine0 = 6; indexLine1 = 8; break;
                    case 1: indexLine0 = 9; break;                    
                    case 2: indexLine0 = 10; break;
                }
                break;
            case 37:
                switch (ID)
                {
                    case 0: indexLine0 = 17; break;
                }
                break;
            case 38:
                switch (ID)
                {
                    case 0: indexLine0 = 12; break;
                    case 1: indexLine0 = 13; break;
                }
                break;
            case 39:
                switch (ID)
                {
                    case 0: indexLine0 = 13; break;
                }
                break;
            case 40:
                switch (ID)
                {
                    case 0: indexLine0 = 23; break;
                    case 1: indexLine0 = 12; break;
                    case 2: indexLine0 = 20; break;
                }
                break;
            case 41:
                switch (ID)
                {
                    case 0: indexLine0 = 21; break;
                    case 1: indexLine0 = 11; indexLine1 = 22; break;
                    case 2: indexLine0 = 19; break;
                }
                break;
            case 42:
                switch (ID)
                {
                    case 0: indexLine0 = 16; break;
                }
                break;
            case 43:
                switch (ID)
                {
                    case 0: indexLine0 = 19; break;
                }
                break;
            case 44:
                switch (ID)
                {
                    case 0: indexLine0 = 19; break;
                }
                break;
            case 45:
                switch (ID)
                {
                    case 0: indexLine0 = 14; break;
                }
                break;
            case 46:
                switch (ID)
                {
                    case 0: indexLine0 = 33; indexLine1 = 34; indexLine2 = 35; break;
                }
                break;
            case 47:
                switch (ID)
                {
                    case 0: indexLine0 = 7; break;
                    case 1: indexLine0 = 23; indexLine1 = 27; break;
                }
                break;
            case 48:
                switch (ID)
                {
                    case 0: indexLine0 = 12; indexLine1 = 17; break;
                    case 1: indexLine0 = 23; break;
                }
                break;
            case 49:
                switch (ID)
                {
                    case 0: indexLine0 = 29; indexLine1 = 40; break;
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
            ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.ResetLineLjState();
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
        Debug.Log("Btn jh "+ID + ": " + indexLine0 + " , " + indexLine1 + " , " +
            indexLine2 + " , " + indexLine3);
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
