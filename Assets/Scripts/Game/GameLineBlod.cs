using UnityEngine;
using System.Collections;

/// <summary>
/// 粗线 父类:子类包含（直线 半圆）
/// </summary>
public class GameLineBlod : MonoBehaviour
{
    public int ID;

    public bool isHit = false;

    void Start()
    {

    }

    public void InitData()
    {
        isHit = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hited(collision, 0);
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //Hited(collision, 1);
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    Hited(collision, 2);
    //}

    private void Hited(Collider2D collision, int _type)
    {
        if (isHit)
        {
            return;
        }
        if (GameController.GetInstance().stateJhBold[ID] == 1)
        {
            if (collision.gameObject.GetComponent<GameLineBlod>() != null)
            {
                if (collision.gameObject.GetComponent<GameLineBlod>().ID != ID)//自己不检测和自己的碰撞
                {
                    if (collision.gameObject.tag == "lineBold" || collision.gameObject.tag == "lineBoldCicle")
                    {
                        // Debug.Log("*******************碰撞了"+ collision.gameObject.GetComponent<GameLineBlod>().ID+ collision.gameObject.tag);

                        if (isHit == false)
                        {
                            isHit = true;
                            ViewController.GetInstance().game.GetComponent<ViewGame>().LifeSubtract();
                        }
                    }
                }
            }
        }
    }


}
