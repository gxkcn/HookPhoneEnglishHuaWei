using UnityEngine;
using System.Collections;

public class GameLineBlodParent : MonoBehaviour
{

    public int ID;
    //直线 直线和曲线
    public int type = 0;

    public int typeMove = 0;

    public bool isJh;

    //private float timeMove;
    /// <summary>
    /// 移动部分
    /// </summary>
    public GameObject objChild;

    public GameObject[] objChildBold;

    private float width;
    private float speed = 6;
    private float curX = 0;

    private bool isLoop;
    private float loopTime;
    private int loopState;


    void Start()
    {

    }

    public void InitData()
    {
        gameObject.SetActive(true);
        isJh = false;
        isLoop = false;
        loopTime = 0;
        loopState = 0;

        objChild.transform.localPosition = Vector3.zero;
        curX = 0;
        width = transform.GetComponent<RectTransform>().rect.width;
        Debug.Log("width = " + width);
        //timeMove = transform.GetComponent<RectTransform>().rect.width / 405*0.5F;

        int _length = objChildBold.Length;
        for (int i = 0; i < _length; i++)
        {
            objChildBold[i].GetComponent<GameLineBlod>().ID = ID;
        }

    }

    public void StartJh(bool _value)
    {
        if (isLoop)
        {
            return;
        }
        if (isJh != _value)
        {
            Debug.Log("bold >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>"+ _value);
            isJh = _value;
            if (isJh)
            {
                GameController.GetInstance().stateJhBold[ID] = 1;
                ViewController.GetInstance().game.GetComponent<ViewGame>().PlayMoveSound();
            }
            else
            {
                GameController.GetInstance().stateJhBold[ID] = 0;
                SetLoop(true);
                //ResetChildHitState();
                ViewController.GetInstance().game.GetComponent<ViewGame>().StopMoveSound();
                ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.ResetDb(ID, "db");
            }
        }
    }

    private void Hide()
    {
        if (gameObject.activeSelf)
        {
            ViewController.GetInstance().game.GetComponent<ViewGame>().StopMoveSound();
            ViewController.GetInstance().game.GetComponent<ViewGame>().StartHide(ID, "db");
            gameObject.SetActive(false);
        }
    }


    public void Update()
    {        
        if (isLoop)
        {
            
        }
        else
        {
            if (isJh)
            {
                if (ExamineHit())
                {
                    StartJh(false);
                }
                else
                {
                    if (typeMove == 0)
                    {
                        if (objChild.transform.localPosition.x < width)
                        {
                            curX += speed;
                            ViewController.GetInstance().game.GetComponent<ViewGame>().PlayMoveSound();
                        }
                        else
                        {
                            Hide();
                        }
                    }
                    else
                    {
                        if (objChild.transform.localPosition.x > -width)
                        {
                            curX -= speed;
                            ViewController.GetInstance().game.GetComponent<ViewGame>().PlayMoveSound();
                        }
                        else
                        {
                            Hide();
                        }
                    }
                    objChild.transform.localPosition = new Vector3(curX, 0, 0);//移动         
                }
            }
        }
    }

    /// <summary>
    /// 检测
    /// </summary>
    /// <returns></returns>
    private bool ExamineHit()
    {
        if (type == 1)
        {
            return false;
        }
        int _length = objChildBold.Length;
        for (int i = 0; i < _length; i++)
        {
            if (objChildBold[i].GetComponent<GameLineBlod>().isHit)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 将所有碰撞子对象重置isHit
    /// </summary>
    /// <returns></returns>
    public void ResetChildHitState()
    {
        Debug.Log(ID + "lineBoldParent reset hit bool value");        
        int _length = objChildBold.Length;
        for (int i = 0; i < _length; i++)
        {
            objChildBold[i].GetComponent<GameLineBlod>().isHit = false;
        }        
    }

    private void SetLoop(bool _value)
    {
        if (isLoop != _value)
        {
            Debug.Log("start loop>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            isLoop = _value;
            loopTime = -1;
            loopState = -1;
            if (isLoop)
            {
                //测试
                //objChild.transform.localPosition = new Vector3(0, 0, 0);//往回倒 
                curX = 0;
                LeanTween.moveLocal(objChild, new Vector3(0, 0, 0), 0.25F).setLoopCount(2);
                Invoke("ResetDbStateJh", 0.5f);
                //正式
                //SetLoopState(0);
            }
        }
    }

    /// <summary>
    /// 复位后让挡板可以再次开始检测
    /// </summary>
    private void ResetDbStateJh()
    {        
        ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.ResetDbStateJh(ID, "db");
        isLoop = false;
        ResetChildHitState();
        Debug.Log("finish loop>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
    }

    //private void SetLoopState(int _value)
    //{
    //    if (loopState != _value)
    //    {
    //        loopState = _value;
    //        switch (loopState)
    //        {
    //            case 0:
    //                if (typeMove == 0)
    //                {
    //                    curX -= speed;
    //                }
    //                else
    //                {
    //                    curX += speed;
    //                }                    
    //                break;
    //            case 1:
    //                if (typeMove == 0)
    //                {
    //                    curX += speed;
    //                }
    //                else
    //                {
    //                    curX -= speed;
    //                }
    //                break;
    //            case 2:
    //                curX = 0;
    //                break;
    //        }
    //        objChild.transform.localPosition = new Vector3(curX, 0, 0);//往回倒 
    //        if (loopState == 2)
    //        {
    //            SetLoop(false);
    //        }
    //    }
    //}

    //private void UpdateLoop()
    //{
        //loopTime += Time.deltaTime;
        //if (loopTime >=0.1f&& loopTime <0.2F)
        //{
        //    SetLoopState(1);
        //}
        //else if (loopTime >= 0.2f && loopTime < 0.3F)
        //{
        //    SetLoopState(2);
        //}
    //}
}
