using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ViewShop : MonoBehaviour
{
    public int type = 0;
    public Button buttonBack;

    public Button buttonTypeCar;
    public Button buttonTypeCarDay;
    public Button buttonTypeGold;

    public Sprite[] spriteCar, spriteCarDay, spriteGold;

    public Text textGold;

    public GameObject scrollCar, scrollCarDay, scrollGold;
    public GameObject parentCarRect, parentCarDayRect, parentGoldRect;

    public Text textTime;

    public ViewController.UIStep nextStep;

    public Image imageRed1,imageRed2;

    public GameObject parentGoldJian, prefabGoldJian;

    public Transform rightGold;

    public Button button0, button1, button2, button3;
    //小手位置的时候用到
    public int curScrollIndex;

    void Start()
    {
        buttonBack.onClick.AddListener(ClickBack);
        buttonTypeCar.onClick.AddListener(ClickTypeCar);
        buttonTypeCarDay.onClick.AddListener(ClickTypeCarDay);
        buttonTypeGold.onClick.AddListener(ClickTypeGold);
    }

    /// <summary>
    /// 初始化/刷新 显示
    /// </summary>
    /// <param name="_type">种类：0道具 1金币</param>
    public void InitDataShop(int _type)
    {
        
    }

    public void InitType(int _value)
    {
        scrollCar.GetComponent<ScrollRect>().content.localPosition = new Vector3(0,-520,0);
        scrollCarDay.GetComponent<ScrollRect>().content.localPosition = new Vector3(0, -520, 0);
        scrollGold.GetComponent<ScrollRect>().content.localPosition = new Vector3(0, -2, 0);
        type = _value;
        buttonTypeCar.image.sprite = spriteCar[type == 0 ? 1 : 0];
        buttonTypeCarDay.image.sprite = spriteCarDay[type == 1 ? 1 : 0];
        buttonTypeGold.image.sprite = spriteGold[type == 2 ? 1 : 0];
        scrollCar.SetActive(false);
        scrollCarDay.SetActive(false);
        scrollGold.SetActive(false);
        switch (type)
        {
            case 0:
                scrollCar.SetActive(true);
                textTime.gameObject.SetActive(false);
                parentCarRect.transform.localPosition = new Vector3(0, -273, 0);
                break;
            case 1:
                scrollCarDay.SetActive(true);
                textTime.gameObject.SetActive(false);
                imageRed1.gameObject.SetActive(false);
                parentCarDayRect.transform.localPosition = new Vector3(0, -231, 0);
                break;
            case 2:
                scrollGold.SetActive(true);
                textTime.gameObject.SetActive(true);
                imageRed2.gameObject.SetActive(false);
                break;
        }
        curScrollIndex = 0;
    }

    public void ChangeIndex(int _value)
    {
        curScrollIndex += _value;
        switch (type)
        {
            case 0:
                parentCarRect.transform.localPosition = new Vector3(0, -273+91*curScrollIndex, 0);
                break;
            case 1:
                parentCarDayRect.transform.localPosition = new Vector3(0, -231+92*curScrollIndex, 0);
                break;
        }
    }

    public void ClickScroll(int _value)
    {
       
    }

    public void ClickBack()
    {
       
    }

    private void ClickTypeCar()
    {
        AudioManager.GetInstance().PlaySound(AudioManager.SoundButtonClick);
        InitType(0);
    }

    private void ClickTypeCarDay()
    {
        AudioManager.GetInstance().PlaySound(AudioManager.SoundButtonClick);
        InitType(1);
    }


    private void ClickTypeGold()
    {
        AudioManager.GetInstance().PlaySound(AudioManager.SoundButtonClick);
        InitType(2);
    }

   

    private void Update()
    {
        if (ViewController.GetInstance().currentUIStep == ViewController.UIStep.Shop)
        {
           
        }
    }

   
}
