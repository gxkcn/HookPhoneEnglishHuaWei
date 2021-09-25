using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// 暂停页面
/// </summary>
public class ViewPause : MonoBehaviour
{
    public Button btnYse;
    public Button btnNo;

    public ViewGame.GameState upState;

    // Use this for initialization
    void Start()
    {
        btnYse.onClick.AddListener(YseClick);
        btnNo.onClick.AddListener(NoClick);
    }

    private void YseClick()
    {
        if (ViewController.GetInstance().currentUIStep == ViewController.UIStep.Pause)
        {
            LeanTween.scale(btnNo.gameObject, new Vector3(0.6f, 0.6f, 0.6f), 0.1f).setLoopPingPong(1);
            AudioManager.GetInstance().PlaySound(AudioManager.SoundButtonClick);
            AudioManager.GetInstance().PlaySound(AudioManager.SoundButtonClick);
            ViewController.GetInstance().currentUIStep = ViewController.UIStep.Game;
            ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.Pause, false);
            //继续游戏
            ViewController.GetInstance().game.GetComponent<ViewGame>().SetGameState(upState);
            ViewController.GetInstance().hand.imgHand.SetActive(false);
            AudioManager.GetInstance().RePlayMusic();
        }
    }

    private void NoClick()
    {
        if (ViewController.GetInstance().currentUIStep == ViewController.UIStep.Pause)
        {
            LeanTween.scale(btnYse.gameObject, new Vector3(0.6f, 0.6f, 0.6f), 0.1f).setLoopPingPong(1);
            AudioManager.GetInstance().PlaySound(AudioManager.SoundButtonClick);
            ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.Pause, false);
            ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.Game, false);
            ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.SelectLevel, true);
            AudioManager.GetInstance().PlayMusic(AudioManager.MusicUI);
            //退出游戏
            ViewController.GetInstance().game.GetComponent<ViewGame>().Clear();
        }
    }
       
}
