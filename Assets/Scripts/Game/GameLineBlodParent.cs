using UnityEngine;
using System.Collections;

public class GameLineBlodParent : MonoBehaviour
{

    public int ID;

    public int typeMove = 0;

    public bool isJh;

    //private float timeMove;
    /// <summary>
    /// 移动部分
    /// </summary>
    public GameObject objChild;

    public GameObject[] objChildBold;
    public bool isHit = false;

    private float width;
    private float speed = 6;
    private float curX = 0;

    private bool isLoop;
    private float loopTime;
    private int loopState;

    private float moveDis = 0;


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
        isHit = false;
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
        moveDis = 0;
    }

    public void StartJh(bool _value)
    {
        Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>bold start jh "+ID+  _value);
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
                if (ExamineHit()|| ViewController.GetInstance().game.GetComponent<ViewGame>().isHit)
                {
                    StartJh(false);
                }
                else
                {
                    moveDis += speed;
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
        if (moveDis > 40f)
        {
            isHit = false;
            return false;
        }
        int _length = objChildBold.Length;
        for (int i = 0; i < _length; i++)
        {
            if (objChildBold[i].GetComponent<GameLineBlod>().isHit)
            {
                Debug.Log(ID+ "==="+ moveDis + "  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>hit true " + moveDis);

                moveDis = 0;
                isHit = true;
                ViewController.GetInstance().game.GetComponent<ViewGame>().LifeSubtract();
                return true;
            }
        }
        isHit = false;
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
            isLoop = _value;
            loopTime = -1;
            loopState = -1;
            if (isLoop)
            {
                curX = 0;
                LeanTween.moveLocal(objChild, new Vector3(0, 0, 0), 0.25F).setLoopCount(isHit?2:1);
                Invoke("ResetDbStateJh", 0.5f);
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
    }    
}
