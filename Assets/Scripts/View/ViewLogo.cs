using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * 品牌LOGO页面、遥控器页面
 * @date 20200328 21:59 * 
 * **/
public class ViewLogo : MonoBehaviour
{
    AsyncOperation async;

    void Start()
    {
        async = SceneManager.LoadSceneAsync("Game");
        async.allowSceneActivation = false;
    }
    

    // Update is called once per frame
    void Update()
    {
        Debug.Log((int)(async.progress*100));
        KeyCode MIOkKeyCode = GameController.DEBUG ? KeyCode.Return : (KeyCode)10;//小米遥控器确认键
        if (Input.GetKeyUp(KeyCode.P) || Input.GetKeyUp(KeyCode.JoystickButton0) || Input.GetKeyUp(MIOkKeyCode))
        {
            async.allowSceneActivation = true;
            return;
        }
        if (Input.anyKeyDown)
        {
            async.allowSceneActivation = true;
        }
    }
}
