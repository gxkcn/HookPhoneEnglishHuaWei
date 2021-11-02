using UnityEngine;
using System.Collections;
/// <summary>
/// @Auther:Firefly
/// @Email:3026646869@qq.com
/// </summary>
public class TipsHand : MonoBehaviour {
    private void ClosePanel()
    {
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        gameObject.SetActive(true);
    }
    void Update()
    {
        //点击任意位置关闭本界面
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            ClosePanel();
        }
    }
}
