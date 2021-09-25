using UnityEngine;
using UnityEngine.UI;

public class ViewSelectMap : MonoBehaviour
{
    public Button ButtonBack;
    public Text textGold;

    public Button buttonLeft, buttonRight;

    public GameObject objParentCar;
    public GameObject preCar;

    public Button buttonPlay, buttonPlayNot;

    private int middleIndex = 0, leftIndex = 11, rightIndex = 1;

    // Use this for initialization
    void Start()
    {
        ButtonBack.onClick.AddListener(ClickBack);
        buttonLeft.onClick.AddListener(ClickLeft);
        buttonRight.onClick.AddListener(ClickRight);
        buttonPlay.onClick.AddListener(ClickPlay);
        buttonPlayNot.onClick.AddListener(ClickPlayNot);
    }

    /// <summary>
    /// 初始化关卡数据,每次进入关卡会调用
    /// </summary>
    public void InitData()
    {
        objParentCar.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        LeanTween.scale(objParentCar, new Vector3(1, 1, 1), 0.1f).setLoopCount(1);

        textGold.text = LocalData.GetInstance().GetGold() + "";

        RefurshCar();
    }

    private void RefurshCar()
    {
       
    }

    private void CreatePreCar(int _index, Vector3 _vec, float _scale, bool _isM)
    {
       
    }

    public void ClickLeft()
    {
        
    }

    public void ClickRight()
    {
      
    }




    public void ClickPlay()
    {
       
    }

    public void ClickPlayNot()
    {
        AudioManager.GetInstance().PlaySound(AudioManager.SoundButtonClick);
       
    }
    public void ClickBack()
    {
        AudioManager.GetInstance().PlaySound(AudioManager.SoundButtonClick);
        ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.SelectMap, false);
        ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.SelectLevel, true);
    }


}