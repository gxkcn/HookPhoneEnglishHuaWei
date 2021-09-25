using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 关卡选择
/// </summary>
public class ViewSelect : MonoBehaviour
{
    public Button ButtonBack;
    public Text textGold;

    public Button buttonLeft, buttonRight;

    public GameObject parentButtonLevel;
    public GameObject prefabButtonLevel;
    /// <summary>
    /// 当前页面
    /// </summary>
    private int curPage = 0;

    public Image imageCicle0, imageCicle1, imageCicle2;

    //手指动作的敏感度，这里设定为 二十分之一的屏幕宽度.
    private float fingerActionSensitivity = Screen.width * 0.05f; 
    private float fingerBeginX;
    private float fingerBeginY;
    private float fingerCurrentX;
    private float fingerCurrentY;
    private float fingerSegmentX;
    private float fingerSegmentY;
    //
    private int fingerTouchState;
    //
    private int FINGER_STATE_NULL = 0;
    private int FINGER_STATE_TOUCH = 1;
    private int FINGER_STATE_ADD = 2;


    void Start()
    {
        ButtonBack.onClick.AddListener(ClickBack);
        buttonLeft.onClick.AddListener(ClickLeft);
        buttonRight.onClick.AddListener(ClickRight);
    }

    /// <summary>
    /// 初始化关卡数据,每次进入关卡会调用
    /// </summary>
    public void InitData()
    {
        parentButtonLevel.transform.localScale = Vector3.one * .2f;
        LeanTween.scale(parentButtonLevel, Vector3.one, 0.2f).setLoopCount(1);

        //
        fingerActionSensitivity = Screen.width * 0.05f;
        fingerBeginX = 0;
        fingerBeginY = 0;
        fingerCurrentX = 0;
        fingerCurrentY = 0;
        fingerSegmentX = 0;
        fingerSegmentY = 0;
        fingerTouchState = FINGER_STATE_NULL;
        //
        curPage = (LocalData.GetInstance().levelCurMax - 1) / 18;        
        //初始化 Grid Grounp数据--暂时没有用


        RefrushPanelButtonLevel();
    }

    private void InitCicle()
    {
        imageCicle0.gameObject.SetActive(curPage == 0 ? true : false);
        imageCicle1.gameObject.SetActive(curPage == 1 ? true : false);
        imageCicle2.gameObject.SetActive(curPage == 2 ? true : false);
    }

    /// <summary>
    /// 刷新关卡按钮
    /// </summary>
    public void RefrushPanelButtonLevel()
    {
        InitCicle();
        Tools.RemoveAllChildren(parentButtonLevel);
        for (int i = 0; i < 18; i++)
        {
            int _index = curPage * 18 + i;
            if (_index < 50)
            {
                Vector3 _vec = Vector3.one;
                CreatePreCar(_index, _vec);
            }
        }
    }

    private void CreatePreCar(int _index, Vector3 _vec)
    {
        GameObject obj = GameObject.Instantiate(prefabButtonLevel, _vec,
            Quaternion.identity) as GameObject;
        obj.transform.SetParent(parentButtonLevel.transform);
        obj.GetComponent<PrefabButtonLevel>().InitData(_index);
        obj.transform.localScale = Vector3.one;
        obj.transform.localPosition = new Vector3(obj.transform.localPosition.x, obj.transform.localPosition.y,0); ;
    }


    public void ClickLeft()
    {
        AudioManager.GetInstance().PlaySound(AudioManager.SoundButtonClick);
        curPage--;
        if (curPage < 0)
        {
            curPage = 0;
        }
        RefrushPanelButtonLevel();
    }

    public void ClickRight()
    {
        AudioManager.GetInstance().PlaySound(AudioManager.SoundButtonClick);
        curPage++;
        if (curPage > 2)
        {
            curPage = 2;
        }
        RefrushPanelButtonLevel();
    }

    public void ClickBack()
    {
        AudioManager.GetInstance().PlaySound(AudioManager.SoundButtonClick);
        ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.SelectLevel, false);
        ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.Menu, true);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            if (fingerTouchState == FINGER_STATE_NULL)
            {
                fingerTouchState = FINGER_STATE_TOUCH;
                fingerBeginX = Input.mousePosition.x;
                fingerBeginY = Input.mousePosition.y;
            }

        }

        if (fingerTouchState == FINGER_STATE_TOUCH)
        {
            fingerCurrentX = Input.mousePosition.x;
            fingerCurrentY = Input.mousePosition.y;
            fingerSegmentX = fingerCurrentX - fingerBeginX;
            fingerSegmentY = fingerCurrentY - fingerBeginY;

        }


        if (fingerTouchState == FINGER_STATE_TOUCH)
        {
            float fingerDistance = fingerSegmentX * fingerSegmentX + fingerSegmentY * fingerSegmentY;

            if (fingerDistance > (fingerActionSensitivity * fingerActionSensitivity))
            {
                toAddFingerAction();
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            fingerTouchState = FINGER_STATE_NULL;
        }
    }

    private void toAddFingerAction()
    {

        fingerTouchState = FINGER_STATE_ADD;

        if (Mathf.Abs(fingerSegmentX) > Mathf.Abs(fingerSegmentY))
        {
            fingerSegmentY = 0;
        }
        else
        {
            fingerSegmentX = 0;
        }

        if (fingerSegmentX == 0)
        {
            if (fingerSegmentY > 0)
            {
                Debug.Log("up");
            }
            else
            {
                Debug.Log("down");
            }
        }
        else if (fingerSegmentY == 0)
        {
            if (fingerSegmentX > 0)
            {
                Debug.Log("right");
                ClickLeft();
            }
            else
            {
                Debug.Log("left");
                ClickRight();
            }
        }

    }

}