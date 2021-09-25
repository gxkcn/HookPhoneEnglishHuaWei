using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// 系统提示弹框
/// </summary>
public class TipsPanel : MonoBehaviour
{
    /// <summary>
    /// 提示信息
    /// </summary>
    public Text textInfo;

    /// <summary>
    /// 关闭时间
    /// </summary>
    public float timeClose = 0;
    /// <summary>
    /// 提示页面下边的页面,提示页面显示关闭后需要回到的页面
    /// </summary>
    public ViewController.UIStep currentUpStep;

    public GameObject imgBackRect;

    // Use this for initialization
    void Start()
    {

    }

    public void InitBaseData(string _textInfo, ViewController.UIStep _upStep)
    {
        textInfo.text = _textInfo;
        timeClose = 1;
        currentUpStep = _upStep;
        
            imgBackRect.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            LeanTween.scale(imgBackRect, new Vector3(1, 1, 1), 0.1f).setLoopCount(1);
    }

    private void ClosePanel()
    {
        ViewController.GetInstance().currentUIStep = currentUpStep;
        ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.TipsPanel, false, "");
    }

    void Update()
    {
        timeClose-=Time.deltaTime;
        if (timeClose <= 0)
        {
            ClosePanel();
        }
        //点击任意位置关闭本界面
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            ClosePanel();
        }
    }


}
