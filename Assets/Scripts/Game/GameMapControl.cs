using UnityEngine;
using System.Collections;

public class GameMapControl : MonoBehaviour
{
    public GameObject[] objMap;
    // Use this for initialization
    void Start()
    {

    }

    public void InitData()
    {
        Debug.Log("GameControl InitData");
        for (int i = 0; i < 50; i++)
        {
            if (GameController.GetInstance().currentLevel == i)
            {
                objMap[i].SetActive(true);
                //Debug.Log(objMap[i].gameObject.transform.childCount+">>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                int _lengh = objMap[i].gameObject.transform.childCount;
                objMap[i].GetComponent<GameMapBase>().objChild = new GameObject[_lengh];
                for (int j = 0; j < _lengh; j++)
                {
                    objMap[i].GetComponent<GameMapBase>().objChild[j] =
                        objMap[i].gameObject.transform.GetChild(j).gameObject;
                }
                objMap[i].GetComponent<GameMapBase>().InitData();
            }
            else
            {
                objMap[i].SetActive(false);
            }
        }

        //Invoke("ResetLineLjState", 0.5f);
    }

    /// <summary>
    /// 重置细线状态和连接点状态
    /// </summary>
    public void ResetLineLjState()
    {
        GameController.GetInstance().lineStateJh = new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int _length = objMap[GameController.GetInstance().currentLevel].transform.childCount;
        for (int i = 0; i < _length; i++)
        {
            GameObject obj = objMap[GameController.GetInstance().currentLevel].transform.GetChild(i).gameObject;
            if (obj.tag == "btnLj0")
            {
                obj.GetComponent<GameButtonLj0>().SetJhFalse();
            }
            else if (obj.tag == "btnLj1")
            {
                obj.GetComponent<GameButtonLj1>().SetJhFalse();
            }
            else if (obj.tag == "btnLj2")
            {
                obj.GetComponent<GameButtonLj2>().SetJhFalse();
            }
            else if (obj.tag == "btnLj3")
            {
                obj.GetComponent<GameButtonLj3>().SetJhFalse();
            }
            else if (obj.tag == "sp")
            {
                obj.GetComponent<GameSp>().SetJhFalse();
            }
        }
        //for (int i = 0; i < _length; i++)
        //{
        //    GameObject obj = objMap[GameController.GetInstance().currentLevel].transform.GetChild(i).gameObject;
            
        //    if (obj.tag == "btnCicle")
        //    {                
        //        obj.GetComponent<GameButtonCicle>().StartJh();
        //    }
        //}
    }

    /// <summary>
    /// 激活和按钮项链的细线
    /// </summary>
    /// <param name="_index"></param>
    public void StartJh(int _index, string _tag)
    {
        Debug.Log("mapcontrol startjh: " + _tag + "   " + _index);
        int _length = objMap[GameController.GetInstance().currentLevel].transform.childCount;
        for (int i = 0; i < _length; i++)
        {
            GameObject obj = objMap[GameController.GetInstance().currentLevel].transform.GetChild(i).gameObject;
            if (obj.gameObject.activeSelf)
            {
                if (obj.tag == _tag)
                {
                    if (obj.tag == "line")
                    {
                        if (obj.GetComponent<GameLine>().ID == _index)
                        {
                            obj.GetComponent<GameLine>().StartJh();
                        }
                    }
                    else if (obj.tag == "btnLj0")
                    {
                        if (obj.GetComponent<GameButtonLj0>().ID == _index)
                        {
                            obj.GetComponent<GameButtonLj0>().StartJh();
                        }
                    }
                    else if (obj.tag == "btnLj1")
                    {
                        if (obj.GetComponent<GameButtonLj1>().ID == _index)
                        {
                            obj.GetComponent<GameButtonLj1>().StartJh();
                        }
                    }
                    else if (obj.tag == "btnLj2")
                    {
                        if (obj.GetComponent<GameButtonLj2>().ID == _index)
                        {
                            obj.GetComponent<GameButtonLj2>().StartJh();
                        }
                    }
                    else if (obj.tag == "btnLj3")
                    {
                        if (obj.GetComponent<GameButtonLj3>().ID == _index)
                        {
                            obj.GetComponent<GameButtonLj3>().StartJh();
                        }
                    }
                    else if (obj.tag == "sp")
                    {
                        if (obj.GetComponent<GameSp>().ID == _index)
                        {
                            obj.GetComponent<GameSp>().StartJh();
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// 判断连接点是否可以被激活，主要是三个连接按钮
    /// </summary>
    /// <param name="_index"></param>
    public bool GetStartJhLj(int _indexLine, int _index, string _tag)
    {
        Debug.Log("mapcontrol GetStartJhLj" + _index);
        int _length = objMap[GameController.GetInstance().currentLevel].transform.childCount;
        for (int i = 0; i < _length; i++)
        {
            GameObject obj = objMap[GameController.GetInstance().currentLevel].transform.GetChild(i).gameObject;
            if (obj.gameObject.activeSelf)
            {
                if (obj.tag == _tag)
                {
                    if (obj.tag == "btnLj1")
                    {
                        if (obj.GetComponent<GameButtonLj1>().ID == _index)
                        {
                            return obj.GetComponent<GameButtonLj1>().GetStartJhLj(_indexLine);
                        }
                    }
                    else if (obj.tag == "btnLj2")
                    {
                        if (obj.GetComponent<GameButtonLj2>().ID == _index)
                        {
                            return obj.GetComponent<GameButtonLj2>().GetStartJhLj(_indexLine);
                        }
                    }
                    else if (obj.tag == "btnLj3")
                    {
                        if (obj.GetComponent<GameButtonLj3>().ID == _index)
                        {
                            return obj.GetComponent<GameButtonLj3>().GetStartJhLj(_indexLine);
                        }
                    }
                }
            }
        }
        return false;
    }
    /// <summary>
    /// 激活同种类sp
    /// </summary>
    public void StartJhAllSameSp(int _type)
    {
        Debug.Log("mapcontrol StartJhAllSameSp" + _type);
        int _length = objMap[GameController.GetInstance().currentLevel].transform.childCount;
        for (int i = 0; i < _length; i++)
        {
            GameObject obj = objMap[GameController.GetInstance().currentLevel].transform.GetChild(i).gameObject;
            if (obj.gameObject.activeSelf)
            {
                if (obj.tag == "sp")
                {
                    if (obj.GetComponent<GameSp>().type == _type)
                    {
                        obj.GetComponent<GameSp>().StartJh();
                    }
                }
            }
        }
    }

    /// <summary>
    /// 隐藏指定挡板
    /// </summary>
    /// <param name="_index"></param>
    public void StartHideDb(int _index, string _tag)
    {
        Debug.Log("-------------------mapcontrol startjh" + _index);
        int _length = objMap[GameController.GetInstance().currentLevel].transform.childCount;
        for (int i = 0; i < _length; i++)
        {
            GameObject obj = objMap[GameController.GetInstance().currentLevel].transform.GetChild(i).gameObject;

            if (obj.tag == _tag)
            {
                if (obj.tag == "db")
                {
                    if (obj.GetComponent<GameDb>().ID == _index)
                    {
                        obj.GetComponent<GameDb>().StartHide();
                        return;
                    }
                }
            }
        }
    }

    /// <summary>
    /// 碰撞后复位挡板
    /// </summary>
    /// <param name="_index"></param>
    public void ResetDb(int _index, string _tag)
    {
        Debug.Log("mapcontrol startjh" + _index);
        int _length = objMap[GameController.GetInstance().currentLevel].transform.childCount;
        for (int i = 0; i < _length; i++)
        {
            GameObject obj = objMap[GameController.GetInstance().currentLevel].transform.GetChild(i).gameObject;

            if (obj.tag == _tag)
            {
                if (obj.tag == "db")
                {
                    if (obj.GetComponent<GameDb>().ID == _index)
                    {
                        obj.GetComponent<GameDb>().ResetJh();
                        return;
                    }
                }
            }
        }
    }

    /// <summary>
    /// 碰撞后复位挡板
    /// </summary>
    /// <param name="_index"></param>
    public void ResetDbStateJh(int _index, string _tag)
    {
        Debug.Log("mapcontrol startjh" + _index);
        int _length = objMap[GameController.GetInstance().currentLevel].transform.childCount;
        for (int i = 0; i < _length; i++)
        {
            GameObject obj = objMap[GameController.GetInstance().currentLevel].transform.GetChild(i).gameObject;

            if (obj.tag == _tag)
            {
                if (obj.tag == "db")
                {
                    if (obj.GetComponent<GameDb>().ID == _index)
                    {
                        obj.GetComponent<GameDb>().ResetStateJh();
                        return;
                    }
                }
            }
        }
    }

    /// <summary>
    /// 挡板消失后开始检测有没有需要检测的消失的
    /// </summary>
    /// <param name="_index"></param>
    public void ExamineHide()
    {
        Debug.Log("===================================mapcontrol ExamineHide");
        int a = 3;
        while (a > 0)
        {
            a--;
            //检测两次，先检测挡板连接线，然后检测是否需要消除没用的线===特殊处理就是使用while循环进行多次遍历,暂时不用这个方法
            int _length = objMap[GameController.GetInstance().currentLevel].transform.childCount;
            for (int i = 0; i < _length; i++)
            {
                GameObject obj = objMap[GameController.GetInstance().currentLevel].transform.GetChild(i).gameObject;
                if (obj.tag == "line")
                {
                    obj.GetComponent<GameLine>().ExamineHide();
                }

            }
            //for (int i = 0; i < _length; i++)
            //{
            //    GameObject obj = objMap[GameController.GetInstance().currentLevel].transform.GetChild(i).gameObject;
            //    if (obj.tag == "line")
            //    {
            //        obj.GetComponent<GameLine>().ExamineHide();
            //    }

            //}
            Debug.Log("======================mapcontrol ExamineHide==========line finish");
            //Debug.Log(GameController.GetInstance().stateLine[3]+"==3");
            //特殊连接点
            for (int i = 0; i < _length; i++)
            {
                GameObject obj = objMap[GameController.GetInstance().currentLevel].transform.GetChild(i).gameObject;
                if (obj.tag == "btnLj0")
                {
                    obj.GetComponent<GameButtonLj0>().ExamineHide();
                }
                if (obj.tag == "btnLj1")
                {
                    obj.GetComponent<GameButtonLj1>().ExamineHide();
                }
                if (obj.tag == "btnLj2")
                {
                    obj.GetComponent<GameButtonLj2>().ExamineHide();
                }
                if (obj.tag == "btnLj3")
                {
                    obj.GetComponent<GameButtonLj3>().ExamineHide();
                }
                if (obj.tag == "sp")
                {
                    obj.GetComponent<GameSp>().ExamineHide();
                }
            }
            Debug.Log("======================mapcontrol ExamineHide==========lianjie finish");
            //
            for (int i = 0; i < _length; i++)
            {
                GameObject obj = objMap[GameController.GetInstance().currentLevel].transform.GetChild(i).gameObject;
                if (obj.tag == "btnCicle")
                {
                    obj.GetComponent<GameButtonCicle>().ExamineHide();
                }
            }
            //消除最后一个sp
            if (GameController.GetInstance().sp0Num == 1)
            {
                ExamineLastSameSp(0);
            }
            if (GameController.GetInstance().sp1Num == 1)
            {
                ExamineLastSameSp(1);
            }
            if (GameController.GetInstance().sp2Num == 1)
            {
                ExamineLastSameSp(2);
            }
        }
        Debug.Log("======================mapcontrol ExamineHide==========btnCicle finish");
    }

    /// <summary>
    /// 挡板消失后开始检测有没有需要检测的消失的
    /// </summary>
    /// <param name="_index"></param>
    public void ExamineLastSameSp(int _type)
    {
        Debug.Log("mapcontrol ExamineLastSameSp" + _type);
        int _length = objMap[GameController.GetInstance().currentLevel].transform.childCount;
        for (int i = 0; i < _length; i++)
        {
            GameObject obj = objMap[GameController.GetInstance().currentLevel].transform.GetChild(i).gameObject;
            if (obj.tag == "sp")
            {
                if(obj.gameObject.activeSelf)
                {
                    if (obj.GetComponent<GameSp>().type == _type)
                    {
                        obj.GetComponent<GameSp>().Hide();
                    }                   
                }
                
            }
        }
        ExamineHide();
    }

    /// <summary>
    /// 返回连接点的线是否还有用
    /// </summary>
    /// <param name="_id"></param>
    /// <param name="_type"></param>
    /// <returns></returns>
    public bool GetLineUse(int _idLine, int _idLj, int _type)
    {
        Debug.Log("===================================mapcontrol GetLineUse");
        int _length = objMap[GameController.GetInstance().currentLevel].transform.childCount;
        for (int i = 0; i < _length; i++)
        {
            GameObject obj = objMap[GameController.GetInstance().currentLevel].transform.GetChild(i).gameObject;
            if (_type == 0 && obj.tag == "btnLj0")
            {
                if (obj.GetComponent<GameButtonLj0>().ID == _idLj)
                {
                    return obj.GetComponent<GameButtonLj0>().ExamineLineUse(_idLine);
                }
            }
            if (_type == 1 && obj.tag == "btnLj1")
            {
                if (obj.GetComponent<GameButtonLj1>().ID == _idLj)
                {
                    return obj.GetComponent<GameButtonLj1>().ExamineLineUse(_idLine);
                }
            }
            if (_type == 2 && obj.tag == "btnLj2")
            {
                if (obj.GetComponent<GameButtonLj2>().ID == _idLj)
                {
                    return obj.GetComponent<GameButtonLj2>().ExamineLineUse(_idLine);
                }
            }
            if (_type == 3 && obj.tag == "btnLj3")
            {
                if (obj.GetComponent<GameButtonLj3>().ID == _idLj)
                {
                    return obj.GetComponent<GameButtonLj3>().ExamineLineUse(_idLine);
                }
            }
            //if (_type == 4 && obj.tag == "sp")
            //{
            //    if (obj.GetComponent<GameSp>().ID == _idLj)
            //    {
            //        return obj.GetComponent<GameSp>().ExamineLineUse(_idLine);
            //    }
            //}
        }
        return true;
    }

    /// <summary>
    /// 全部隐藏
    /// </summary>
    public void HideAll()
    {
        objMap[GameController.GetInstance().currentLevel].SetActive(false);
    }

    /// <summary>
    /// 点击按钮开始检测粗线是否可以移动
    /// </summary>
    /// <param name="_index"></param>
    public void ButtonClickFun(int _index)
    {
        Debug.Log("点击按钮开始检测粗线是否可以移动 mapcontrol ButtonClickFun");
        int _length = objMap[GameController.GetInstance().currentLevel].transform.childCount;
        for (int i = 0; i < _length; i++)
        {
            GameObject obj = objMap[GameController.GetInstance().currentLevel].transform.GetChild(i).gameObject;
            if (obj.tag == "db")
            {
                Debug.Log(obj.GetComponent<GameDb>().ID + "&&&&" + GameController.GetInstance().lineStateJh[obj.GetComponent<GameDb>().ID]);
                if (GameController.GetInstance().lineStateJh[obj.GetComponent<GameDb>().ID] == 1)
                {
                    obj.GetComponent<GameDb>().StartJh();
                }
            }
        }
    }
    /// <summary>
    /// 激活粗线
    /// </summary>
    /// <param name="_index"></param>
    /// <param name="_tag"></param>
    public void StartJhBoldLine(int _index, string _tag)
    {
        Debug.Log("mapcontrol startjh" + _index);
        int _length = objMap[GameController.GetInstance().currentLevel].transform.childCount;
        for (int i = 0; i < _length; i++)
        {
            GameObject obj = objMap[GameController.GetInstance().currentLevel].transform.GetChild(i).gameObject;

            if (obj.tag == _tag)
            {
                if (obj.tag == "lineBoldParent")
                {
                    if (obj.GetComponent<GameLineBlodParent>().ID == _index)
                    {
                        obj.GetComponent<GameLineBlodParent>().StartJh(true);
                    }
                }
            }

        }
    }

}
