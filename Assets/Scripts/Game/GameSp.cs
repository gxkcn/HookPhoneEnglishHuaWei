using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameSp : MonoBehaviour
{
    /// <summary>
    /// 在地图中 ID (唯一)
    /// </summary>
    public int ID;

    public int type;
    /// <summary>
    /// 相关联的细线索引
    /// </summary>
    public int indexLine;

    public bool isHide;
    
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
        Debug.Log("name = " + GetComponent<Image>().sprite.name);
        type = int.Parse(GetComponent<Image>().sprite.name);
        switch (type)
        {
            case 0: GameController.GetInstance().sp0Num++;Debug.Log("woshi 0"); break;
            case 1: GameController.GetInstance().sp1Num++; Debug.Log("woshi 1"); break;
            case 2: GameController.GetInstance().sp2Num++; Debug.Log("woshi 2"); break;
        }

        indexLine = -1;
        switch (GameController.GetInstance().currentLevel)
        {
            case 33:
                switch (ID)
                {
                    case 0: indexLine = 4; break;
                    case 1: indexLine = 5; break;
                    case 2: indexLine = 6; break;
                }
                break;
            case 34:
                switch (ID)
                {
                    case 0: indexLine = 2; break;
                    case 1: indexLine = 1; break;
                    case 2: indexLine = 3; break;
                    case 3: indexLine = 0; break;
                    case 4: indexLine = 7; break;
                    case 5: indexLine = 5; break;
                    case 6: indexLine = 8; break;
                }
                break;
            case 35:
                switch (ID)
                {
                    case 0: indexLine = 2; break;
                    case 1: indexLine = 4; break;
                    case 2: indexLine = 3; break;
                    case 3: indexLine = 1; break;
                    case 4: indexLine = 5; break;
                    case 5: indexLine = 12; break;
                    case 6: indexLine = 13; break;
                }
                break;
            case 36:
                switch (ID)
                {
                    case 0: indexLine = 8; break;
                    case 1: indexLine = 1; break;
                    case 2: indexLine = 4; break;
                    case 3: indexLine = 11; break;
                    case 4: indexLine = 7; break;
                    case 5: indexLine = 12; break;
                }
                break;
            case 37:
                switch (ID)
                {
                    case 0: indexLine = 0; break;
                    case 1: indexLine = 1; break;
                    case 2: indexLine = 12; break;
                    case 3: indexLine = 18; break;
                    case 4: indexLine = 11; break;
                    case 5: indexLine = 3; break;
                    case 6: indexLine = 6; break;
                    case 7: indexLine = 22; break;
                }
                break;
            case 38:
                switch (ID)
                {
                    case 0: indexLine = 7; break;
                    case 1: indexLine = 9; break;
                    case 2: indexLine = 12; break;
                    case 3: indexLine = 13; break;
                    case 4: indexLine = 14; break;
                    case 5: indexLine = 1; break;
                    case 6: indexLine = 2; break;
                    case 7: indexLine = 3; break;
                    case 8: indexLine = 4; break;
                    case 9: indexLine = 5; break;
                }
                break;
            case 39:
                switch (ID)
                {
                    case 0: indexLine =10; break;
                    case 1: indexLine = 11; break;
                    case 2: indexLine = 3; break;
                    case 3: indexLine = 4; break;
                    case 4: indexLine = 15; break;
                }
                break;
            case 42:
                switch (ID)
                {
                    case 0: indexLine = 0; break;
                    case 1: indexLine = 8; break;
                    case 2: indexLine = 9; break;
                    case 3: indexLine = 6; break;
                    case 4: indexLine = 15; break;
                    case 5: indexLine = 17; break;
                }
                break;
            case 44:
                switch (ID)
                {
                    case 0: indexLine = 6; break;
                    case 1: indexLine = 7; break;
                    case 2: indexLine = 11; break;
                    case 3: indexLine = 12; break;
                    case 4: indexLine = 14; break;
                    case 5: indexLine = 13; break;
                    case 6: indexLine = 15; break;
                    case 7: indexLine = 18; break;
                    case 8: indexLine = 5; break;
                    case 9: indexLine = 21; break;
                    case 10: indexLine = 23; break;
                }
                break;
            case 45:
                switch (ID)
                {
                    case 0: indexLine = 9; break;
                    case 1: indexLine = 5; break;
                    case 2: indexLine = 17; break;
                    case 3: indexLine = 10; break;
                }
                break;
            case 46:
                switch (ID)
                {
                    case 0: indexLine = 32; break;
                    case 1: indexLine = 54; break;
                }
                break;
            case 47:
                switch (ID)
                {
                    case 0: indexLine = 20; break;
                    case 1: indexLine = 26; break;
                }
                break;
        }
    }


    public void StartJh()
    {
        if (isJh == false)
        {
            Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>sp被激活" + ID + "    " + type);
            gameObject.transform.localScale = Vector3.one;
            LeanTween.scale(gameObject, Vector3.one * 1.3f, 0.2f).setLoopCount(1);
            Invoke("ScaleReset", 0.2f);
            isJh = true;
            if (indexLine != -1)
            {
                ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.StartJh(indexLine, "line");
                ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.StartJhAllSameSp(type);
            }
        }
    }

    private void ScaleReset()
    {
        LeanTween.scale(gameObject, Vector3.one, 0.2f).setLoopCount(1);
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
            switch (type)
            {
                case 0: GameController.GetInstance().sp0Num--;break;
                case 1: GameController.GetInstance().sp1Num--; break;
                case 2: GameController.GetInstance().sp2Num--; break;
            }
            GameController.GetInstance().stateSp[ID] = 0;
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

        if (indexLine != -1)
        {
            Debug.Log(ID + "  SPSPSPSPSP line id = "+ indexLine+"----"+
                GameController.GetInstance().stateLine[indexLine]);

            if (GameController.GetInstance().stateLine[indexLine] == 1)
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