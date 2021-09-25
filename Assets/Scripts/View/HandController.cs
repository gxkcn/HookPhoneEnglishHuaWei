using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 遥控小手 
/// @date 2020/06/05
/// </summary>
public class HandController : MonoBehaviour
{
    public GameObject imgHand;
    /// <summary>
    /// 操作种类 0 手机 1电视
    /// </summary>
    private int handleType = 0;
    public ViewMenu menu;
    public ViewGameExit gameExit;
    public ViewSelect select;
    public ViewSelectMap selectMap;
    public ViewGame game;
    public TipsPanel tipsPanel;
    public ViewPause pause;
    public ViewWin win;
    public ViewLose lose;
    public ViewShop shop;

    private Button[] allButton;
    public int currentButtonIndex = 0;
    private float timer = 0;
    private bool isHaveClick = false;
    
    void Start()
    {
        if (handleType == 0)
        {
            return;
        }
        imgHand.gameObject.SetActive(!GameController.PHONE_VERSION);
        LeanTween.scale(gameObject, Vector3.one*0.7f, 0.5f).setLoopPingPong();
        InitHandIndex();
    }

    void InitAllButton()
    {
        if (handleType == 0)
        {
            return;
        }
        allButton = new Button[] {
        menu.buttonSound, menu.buttonStart,menu.buttonExit, //0 1 2 3 4
        gameExit.ButtonYes,gameExit.ButtonNo,//  5 6 
        select.buttonLeft,select.buttonRight,//7  8  9  10 11 12
        selectMap.buttonLeft,selectMap.buttonRight,selectMap.buttonPlay,//13  14  15
        pause.btnYse,pause.btnNo,//16 17
        win.buttonRe,win.buttonBack,//18   19  20
        shop.buttonTypeCar,shop.buttonTypeCarDay,shop.buttonTypeGold,
            shop.button0,shop.button1,shop.button2,shop.button3,//  21 22 23   24 25 26 27
        game.buttonPause//26 27 28 29
        };
    }

    public void RefurshSelectLevelButton()
    {
        InitAllButton();
    }

    /// <summary>
    /// 初始化按钮的索引，切换界面的时候调用
    /// </summary>
    public void InitHandIndex()
    {
        if (handleType == 0)
        {
            return;
        }
        imgHand.gameObject.SetActive(true);
        InitAllButton();
        switch (ViewController.GetInstance().currentUIStep)
        {
            case ViewController.UIStep.Menu:
                currentButtonIndex = 1;
                break;
            case ViewController.UIStep.ExitPanel:
                currentButtonIndex = 5;
                break;
            case ViewController.UIStep.SelectLevel:
                currentButtonIndex = 12;
                break;
            case ViewController.UIStep.SelectMap:
                currentButtonIndex = 15;
                break;
            case ViewController.UIStep.Game:
                imgHand.gameObject.SetActive(false);
                break;
            case ViewController.UIStep.Win:
                currentButtonIndex = 18;
                break;
            case ViewController.UIStep.Lose:
                break;
            case ViewController.UIStep.TipsPanel:
                imgHand.gameObject.SetActive(false);
                break;
            case ViewController.UIStep.Pause:
                currentButtonIndex = 16;
                break;
            case ViewController.UIStep.Shop:
                //currentButtonIndex = 21+shop.type;
                currentButtonIndex = 24;
                break;
        }
        //transform.position = allButton[currentButtonIndex].transform.position;
    }

    void Update()
    {
        if (handleType == 0)
        {
            return;
        }
        ClickUp();
        ClickDown();
        ClickLeft();
        ClickRight();
        ClickSureDown();
        ClickSureUp();
        ClickReturn();
        if (isHaveClick == true)
        {
            timer += Time.deltaTime;
            if (timer >= 0.00001f)
            {
                timer = 0;
                isHaveClick = false;
            }
        }
        transform.position = allButton[currentButtonIndex].transform.position;
    }

    /// <summary>
    /// 按箭按下，个别界面需要
    /// </summary>
    public void ClickSureDown()
    {
        //if (isHaveClick == false)
        //{
        KeyCode MIOkKeyCode = GameController.DEBUG ? KeyCode.Return : (KeyCode)10;//小米遥控器确认键
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(MIOkKeyCode))
        {
            isHaveClick = true;
            switch (ViewController.GetInstance().currentUIStep)
            {
                case ViewController.UIStep.Menu:
                    allButton[currentButtonIndex].onClick.Invoke();
                    if (currentButtonIndex == 4)
                    {
                        imgHand.gameObject.SetActive(false);
                    }
                    break;
                case ViewController.UIStep.Game:
                    break;
                case ViewController.UIStep.SelectLevel:
                                
                    break;
                case ViewController.UIStep.Shop:
                    if (currentButtonIndex > 23)
                    {
                        shop.ClickScroll(currentButtonIndex - 24);
                    }
                    else//21 22 23
                    {
                        allButton[currentButtonIndex].onClick.Invoke();
                    }
                    break;
                case ViewController.UIStep.SelectMap:
                    if (currentButtonIndex == 15)
                    {
                        if (selectMap.buttonPlay.gameObject.activeSelf)
                        {
                            selectMap.buttonPlay.onClick.Invoke();
                        }
                        if (selectMap.buttonPlayNot.gameObject.activeSelf)
                        {
                            selectMap.buttonPlayNot.onClick.Invoke();
                        }
                    }
                    else
                    {
                        allButton[currentButtonIndex].onClick.Invoke();
                    }
                    break;
                case ViewController.UIStep.TipsPanel:
                    break;
                default:
                    allButton[currentButtonIndex].onClick.Invoke();
                    break;
            }
        }
        //}
    }

    /// <summary>
    /// 按箭抬起，抬起的时候处理确认键操作
    /// </summary>
    public void ClickSureUp()
    {
        //if (isHaveClick == false)
        //{
        //KeyCode MIOkKeyCode = GameController.DEBUG ? KeyCode.Return : (KeyCode)10;//小米遥控器确认键
        //if (Input.GetKeyUp(KeyCode.P) || Input.GetKeyUp(KeyCode.JoystickButton0) || Input.GetKeyUp(MIOkKeyCode))
        //{
        //    isHaveClick = true;
        //    switch (ViewController.GetInstance().currentUIStep)
        //    {
        //        case ViewController.UIStep.Game:
        //            break;
        //        default:
        //           // allButton[currentButtonIndex].onClick.Invoke();
        //            break;
        //    }
        //}
        //}
    }
    public void ClickUp()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            switch (ViewController.GetInstance().currentUIStep)
            {
                case ViewController.UIStep.Menu:
                    switch (currentButtonIndex)
                    {
                        case 0:
                        case 1:
                        case 2:
                            currentButtonIndex = 3;
                            break;
                        case 3:
                        case 4:
                            currentButtonIndex = 1;
                            break;
                    }
                    break;
                case ViewController.UIStep.ExitPanel:
                    currentButtonIndex = currentButtonIndex == 5 ? 6 : 5;
                    break;
                case ViewController.UIStep.SelectLevel:
                    switch (currentButtonIndex)
                    {
                        case 7: currentButtonIndex = 12; break;
                        case 8: currentButtonIndex = 12; break;
                        case 9: currentButtonIndex = 10; break;
                        case 10: currentButtonIndex = 11; break;
                        case 11: currentButtonIndex = 7; break;
                        case 12: currentButtonIndex = 8; break;
                    }
                    break;
                case ViewController.UIStep.SelectMap:
                    switch (currentButtonIndex)
                    {
                        case 13: currentButtonIndex = 15; break;
                        case 14: currentButtonIndex = 15; break;
                        case 15: currentButtonIndex = 13; break;
                    }
                    break;
                case ViewController.UIStep.Game:
                   
                    break;
                case ViewController.UIStep.Win:
                    currentButtonIndex--;
                    if (currentButtonIndex < 18)
                    {
                        currentButtonIndex = 20;
                    }

                    break;
                case ViewController.UIStep.Lose:
                    
                    break;
                case ViewController.UIStep.Pause:
                    currentButtonIndex = currentButtonIndex == 16 ? 17 : 16;
                    break;
                case ViewController.UIStep.Shop:
                    if (shop.type==0)
                    {
                        switch (currentButtonIndex)
                        {
                            case 21: currentButtonIndex = 24; break;
                            case 22: currentButtonIndex = 24; break;
                            case 23: currentButtonIndex = 24; break;

                            case 24:
                                if (shop.curScrollIndex == 0)
                                {
                                    currentButtonIndex = 21 + shop.type;
                                }
                                else
                                {
                                    shop.ChangeIndex(-1);
                                }                                
                                break;
                            case 25: currentButtonIndex = 24; break;
                            case 26: currentButtonIndex = 25; break;
                            case 27: currentButtonIndex = 26; break;
                        }
                    }
                    else if (shop.type == 1)
                    {
                        switch (currentButtonIndex)
                        {
                            case 21: currentButtonIndex = 24; break;
                            case 22: currentButtonIndex = 24; break;
                            case 23: currentButtonIndex = 24; break;

                            case 24:
                                if (shop.curScrollIndex == 0)
                                {
                                    currentButtonIndex = 21 + shop.type;
                                }
                                else
                                {
                                    shop.ChangeIndex(-1);
                                }
                                break;
                            case 25: currentButtonIndex = 24; break;
                            case 26: currentButtonIndex = 25; break;
                            case 27: currentButtonIndex = 26; break;
                        }
                    }
                    else
                    {
                        switch (currentButtonIndex)
                        {
                            case 21: currentButtonIndex = 24; break;
                            case 22: currentButtonIndex = 24; break;
                            case 23: currentButtonIndex = 24; break;

                            case 24:
                                    currentButtonIndex = 21 + shop.type;
                                break;
                            case 25: currentButtonIndex = 24; break;
                            case 26: currentButtonIndex = 25; break;
                            case 27: currentButtonIndex = 26; break;
                        }
                    }
                    break;
            }
            //transform.position = allButton[currentButtonIndex].transform.position;
        }
    }

    public void ClickDown()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            switch (ViewController.GetInstance().currentUIStep)
            {
                case ViewController.UIStep.Menu:
                    switch (currentButtonIndex)
                    {
                        case 0:
                        case 1:
                        case 2:
                            currentButtonIndex = 3;
                            break;
                        case 3:
                        case 4:
                            currentButtonIndex = 1;
                            break;
                    }
                    break;
                case ViewController.UIStep.ExitPanel:
                    currentButtonIndex = currentButtonIndex == 5 ? 6 : 5;
                    break;
                case ViewController.UIStep.SelectLevel:
                    switch (currentButtonIndex)
                    {
                        case 7: currentButtonIndex = 12; break;
                        case 8: currentButtonIndex = 12; break;
                        case 9: currentButtonIndex = 10; break;
                        case 10: currentButtonIndex = 11; break;
                        case 11: currentButtonIndex = 7; break;
                        case 12: currentButtonIndex = 8; break;
                    }
                    break;
                case ViewController.UIStep.SelectMap:
                    switch (currentButtonIndex)
                    {
                        case 13: currentButtonIndex = 15; break;
                        case 14: currentButtonIndex = 15; break;
                        case 15: currentButtonIndex = 13; break;
                    }
                    break;
                case ViewController.UIStep.Game:
                    
                    break;
                case ViewController.UIStep.Win:
                    currentButtonIndex++;
                    if (currentButtonIndex > 20)
                    {
                        currentButtonIndex = 18;
                    }
                    break;
                case ViewController.UIStep.Lose:
                   
                    break;
                case ViewController.UIStep.Pause:
                    currentButtonIndex = currentButtonIndex == 16 ? 17 : 16;
                    break;
                case ViewController.UIStep.Shop:
                    if (shop.type == 0)
                    {
                        switch (currentButtonIndex)
                        {
                            case 21: currentButtonIndex = 24; break;
                            case 22: currentButtonIndex = 24; break;
                            case 23: currentButtonIndex = 24; break;

                            case 24:
                                currentButtonIndex = 25;
                                break;
                            case 25: currentButtonIndex = 26; break;
                            case 26: currentButtonIndex = 27; break;
                            case 27:
                                if (shop.curScrollIndex < 6)
                                {
                                    shop.ChangeIndex(1);
                                }
                                else
                                {
                                    currentButtonIndex = 21 + shop.type;
                                }
                                break;
                        }
                    }
                    else if (shop.type == 1)
                    {
                        switch (currentButtonIndex)
                        {
                            case 21: currentButtonIndex = 24; break;
                            case 22: currentButtonIndex = 24; break;
                            case 23: currentButtonIndex = 24; break;

                            case 24:
                                currentButtonIndex = 25;
                                break;
                            case 25: currentButtonIndex = 26; break;
                            case 26: currentButtonIndex = 27; break;
                            case 27:
                                if (shop.curScrollIndex < 5)
                                {
                                    shop.ChangeIndex(1);
                                }
                                else
                                {
                                    currentButtonIndex = 21 + shop.type;
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (currentButtonIndex)
                        {
                            case 21: currentButtonIndex = 24; break;
                            case 22: currentButtonIndex = 24; break;
                            case 23: currentButtonIndex = 24; break;

                            case 24:currentButtonIndex = 25;break;
                            case 25: currentButtonIndex = 26; break;
                            case 26: currentButtonIndex = 27; break;
                            case 27:currentButtonIndex = 21 + shop.type;break;
                        }
                    }
                    break;
            }
            //transform.position = allButton[currentButtonIndex].transform.position;
        }
    }

    public void ClickLeft()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            switch (ViewController.GetInstance().currentUIStep)
            {
                case ViewController.UIStep.Menu:
                    switch (currentButtonIndex)
                    {
                        case 0:
                            currentButtonIndex = 2;
                            break;
                        case 1:
                            currentButtonIndex = 0;
                            break;
                        case 2:
                            currentButtonIndex = 1;
                            break;
                        case 3:
                            currentButtonIndex = 4;
                            break;
                        case 4:
                            currentButtonIndex = 3;
                            break;
                    }
                    break;
                case ViewController.UIStep.ExitPanel:
                    currentButtonIndex = currentButtonIndex == 5 ? 6 : 5;
                    break;
                case ViewController.UIStep.SelectLevel:
                    switch (currentButtonIndex)
                    {
                        case 7: currentButtonIndex = 8; break;
                        case 8: currentButtonIndex = 7; break;
                        case 9: currentButtonIndex = 12; break;
                        case 10: currentButtonIndex = 12; break;
                        case 11: currentButtonIndex = 12; break;
                        case 12: currentButtonIndex = 9; break;
                    }
                    break;
                case ViewController.UIStep.SelectMap:
                    switch (currentButtonIndex)
                    {
                        case 13: currentButtonIndex = 14; break;
                        case 14: currentButtonIndex = 13; break;
                        case 15: currentButtonIndex = 13; break;
                    }
                    break;
                case ViewController.UIStep.Game:
                    
                    break;
                case ViewController.UIStep.Win:
                    currentButtonIndex--;
                    if (currentButtonIndex < 18)
                    {
                        currentButtonIndex = 20;
                    }
                    break;
                case ViewController.UIStep.Lose:
                   
                    break;
                case ViewController.UIStep.Pause:
                    currentButtonIndex = currentButtonIndex == 16 ? 17 : 16;
                    break;
                case ViewController.UIStep.Shop:
                    if (shop.type == 0)
                    {
                        switch (currentButtonIndex)
                        {
                            case 21: currentButtonIndex = 23; break;
                            case 22: currentButtonIndex = 21; break;
                            case 23: currentButtonIndex = 22; break;

                            case 24: currentButtonIndex = 21 + shop.type; break;
                            case 25: currentButtonIndex = 21 + shop.type; break;
                            case 26: currentButtonIndex = 21 + shop.type; break;
                            case 27: currentButtonIndex = 21 + shop.type; break;
                        }
                    }
                    else if (shop.type == 1)
                    {
                        switch (currentButtonIndex)
                        {
                            case 21: currentButtonIndex = 23; break;
                            case 22: currentButtonIndex = 21; break;
                            case 23: currentButtonIndex = 22; break;

                            case 24: currentButtonIndex = 21 + shop.type; break;
                            case 25: currentButtonIndex = 21 + shop.type; break;
                            case 26: currentButtonIndex = 21 + shop.type; break;
                            case 27: currentButtonIndex = 21 + shop.type; break;
                        }
                    }
                    else
                    {
                        switch (currentButtonIndex)
                        {
                            case 21: currentButtonIndex = 23; break;
                            case 22: currentButtonIndex = 21; break;
                            case 23: currentButtonIndex = 22; break;

                            case 24: currentButtonIndex = 21 + shop.type; break;
                            case 25: currentButtonIndex = 21 + shop.type; break;
                            case 26: currentButtonIndex = 21 + shop.type; break;
                            case 27: currentButtonIndex = 21 + shop.type; break;
                        }
                    }
                    break;
            }
            //transform.position = allButton[currentButtonIndex].transform.position;
        }
        //else if (Input.GetKeyUp(KeyCode.LeftArrow))
        //{
        //    switch (ViewController.GetInstance().currentUIStep)
        //    {
        //        case ViewController.UIStep.Game:
        //            break;
        //    }
        //    //transform.position = allButton[currentButtonIndex].transform.position;
        //}
    }

    public void ClickRight()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            switch (ViewController.GetInstance().currentUIStep)
            {
                case ViewController.UIStep.Menu:
                    switch (currentButtonIndex)
                    {
                        case 0:
                            currentButtonIndex = 1;
                            break;
                        case 1:
                            currentButtonIndex = 2;
                            break;
                        case 2:
                            currentButtonIndex = 0;
                            break;
                        case 3:
                            currentButtonIndex = 4;
                            break;
                        case 4:
                            currentButtonIndex = 3;
                            break;
                    }
                    break;
                case ViewController.UIStep.ExitPanel:
                    currentButtonIndex = currentButtonIndex == 5 ? 6 : 5;
                    break;
                case ViewController.UIStep.SelectLevel:
                    switch (currentButtonIndex)
                    {
                        case 7: currentButtonIndex = 8; break;
                        case 8: currentButtonIndex = 7; break;
                        case 9: currentButtonIndex = 12; break;
                        case 10: currentButtonIndex = 12; break;
                        case 11: currentButtonIndex = 12; break;
                        case 12: currentButtonIndex = 9; break;
                    }
                    break;
                case ViewController.UIStep.SelectMap:
                    switch (currentButtonIndex)
                    {
                        case 13: currentButtonIndex = 14; break;
                        case 14: currentButtonIndex = 13; break;
                        case 15: currentButtonIndex = 13; break;
                    }
                    break;
                case ViewController.UIStep.Game:
                   
                    break;
                case ViewController.UIStep.Win:
                    currentButtonIndex++;
                    if (currentButtonIndex > 20)
                    {
                        currentButtonIndex = 18;
                    }
                    break;
                case ViewController.UIStep.Lose:
                   
                    break;
                case ViewController.UIStep.Pause:
                    currentButtonIndex = currentButtonIndex == 16 ? 17 : 16;
                    break;
                case ViewController.UIStep.Shop:
                    if (shop.type == 0)
                    {
                        switch (currentButtonIndex)
                        {
                            case 21: currentButtonIndex = 22; break;
                            case 22: currentButtonIndex = 23; break;
                            case 23: currentButtonIndex = 21; break;

                            case 24: currentButtonIndex = 21 + shop.type; break;
                            case 25: currentButtonIndex = 21 + shop.type; break;
                            case 26: currentButtonIndex = 21 + shop.type; break;
                            case 27: currentButtonIndex = 21 + shop.type; break;
                        }
                    }
                    else if (shop.type == 1)
                    {
                        switch (currentButtonIndex)
                        {
                            case 21: currentButtonIndex = 22; break;
                            case 22: currentButtonIndex = 23; break;
                            case 23: currentButtonIndex = 21; break;

                            case 24: currentButtonIndex = 21 + shop.type; break;
                            case 25: currentButtonIndex = 21 + shop.type; break;
                            case 26: currentButtonIndex = 21 + shop.type; break;
                            case 27: currentButtonIndex = 21 + shop.type; break;
                        }
                    }
                    else
                    {
                        switch (currentButtonIndex)
                        {
                            case 21: currentButtonIndex = 22; break;
                            case 22: currentButtonIndex = 23; break;
                            case 23: currentButtonIndex = 21; break;

                            case 24: currentButtonIndex = 21 + shop.type; break;
                            case 25: currentButtonIndex = 21 + shop.type; break;
                            case 26: currentButtonIndex = 21 + shop.type; break;
                            case 27: currentButtonIndex = 21 + shop.type; break;
                        }
                    }
                    break;
            }
            transform.position = allButton[currentButtonIndex].transform.position;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            switch (ViewController.GetInstance().currentUIStep)
            {
                case ViewController.UIStep.Game:                    
                    break;
            }
            //transform.position = allButton[currentButtonIndex].transform.position;
        }
    }
    public void ClickReturn()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (ViewController.GetInstance().currentUIStep)
            {
                case ViewController.UIStep.Menu:
                   
                    
                    break;
                case ViewController.UIStep.ExitPanel:
                    ClickBack(gameExit.ButtonNo);
                    break;
                case ViewController.UIStep.SelectLevel:
                    ClickBack(select.ButtonBack);
                    break;
                case ViewController.UIStep.SelectMap:
                    ClickBack(selectMap.ButtonBack);
                    break;
                case ViewController.UIStep.Game:
                    ClickBack(game.buttonPause);
                    break;
                case ViewController.UIStep.Pause:
                    ClickBack(pause.btnYse);
                    break;
                case ViewController.UIStep.Win:
                    ClickBack(win.buttonBack);
                    break;
                case ViewController.UIStep.Shop:
                    ClickBack(shop.buttonBack);
                    break;
                default:
                    break;
            }
        }
    }

    private void ClickBack(Button btn)
    {
        btn.onClick.Invoke();
    }
    
}
