using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PrefabButtonLevel : MonoBehaviour {
    private int index;

    public Text textNum;

    public Image imageLock;

    public Image imageStar0, imageStar1, imageStar2;

    // Use this for initialization
    void Start () {
        GetComponent<Button>().onClick.AddListener(ClickLevel);
	}

    public void InitData(int _index)
    {
        index = _index;
        textNum.text = (index + 1) +"";
        if(LocalData.GetInstance().levelCurMax <= index)
        {
            imageLock.gameObject.SetActive(true);
        }
        else
        {
            textNum.gameObject.SetActive(true);
            imageLock.gameObject.SetActive(false);
            if(LocalData.GetInstance().levelStar[index] >= 1)
            {
                imageStar0.gameObject.SetActive(true);
            }
            if (LocalData.GetInstance().levelStar[index] >= 2)
            {
                imageStar1.gameObject.SetActive(true);
            }
            if (LocalData.GetInstance().levelStar[index] >= 3)
            {
                imageStar2.gameObject.SetActive(true);
            }
        }
    }

    public void ClickLevel()
    {
        AudioManager.GetInstance().PlaySound(AudioManager.SoundButtonClick);
        Debug.Log("view select level" + index);
        if (LocalData.GetInstance().levelCurMax <= index)
        {
            ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.TipsPanel,
            true, "level is locked");
        }
        else
        {
            GameController.GetInstance().currentLevel = index;
            ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.SelectLevel, false);
            ViewController.GetInstance().ShowOrHideUI(ViewController.UIStep.Game, true);
        }
    }



}
