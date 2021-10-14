using UnityEngine;
using System.Collections;

public class GameDb : MonoBehaviour
{
    public int ID;

    public int indexLineBoldParent = -1;

    public bool isJh;

    public bool isHide;

    void Start()
    {

    }

    public void InitData()
    {
        gameObject.SetActive(true);
        isJh = false;
        isHide = false;
        gameObject.transform.localScale = Vector3.one;
        indexLineBoldParent = ID;

    }

    public void StartJh()
    {
        isJh = true;
        if (indexLineBoldParent != -1)
        {
            Debug.Log(">>>>>>>>>挡板激活"+ID);
            ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.StartJhBoldLine(indexLineBoldParent, "lineBoldParent");
            LeanTween.scaleY(gameObject, 2, 0.1f).setLoopCount(1);
            AudioManager.GetInstance().PlaySound(AudioManager.SoundClick0);
        }
    }

    public void ResetJh()
    {
        if (isJh)
        {
            LeanTween.scale(gameObject, Vector3.one, 0.2f).setLoopCount(1);
        }
    }

    public void ResetStateJh()
    {
        isJh = false;
    }


    public void StartHide()
    {
        if (isHide == false)
        {
            isHide = true;
            AudioManager.GetInstance().PlaySound(AudioManager.SoundMoveEnd);
            LeanTween.scaleY(gameObject, 0, 0.3f).setLoopCount(1);
            Invoke("HideActive", 0.3F);
        }
    }

    public void HideActive()
    {
        Debug.Log(GameController.GetInstance().totalHideDbNum + ">>>>>>>>>>>>>>>>>>挡板数量");
        gameObject.SetActive(false);
        GameController.GetInstance().stateDb[ID] = 0;
        GameController.GetInstance().totalHideDbNum--;
        if (GameController.GetInstance().totalHideDbNum <= 0)
        {
            ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.HideAll();
            Invoke("GameWin", 0.5F);
        }
        else
        {
            ViewController.GetInstance().game.GetComponent<ViewGame>().mapCon.ExamineHide();
        }
    }

    private void GameWin()
    {
        ViewController.GetInstance().game.GetComponent<ViewGame>().SetGameState(ViewGame.GameState.GameWin);
    }

}
