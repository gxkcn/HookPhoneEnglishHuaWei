using UnityEngine;
using System.Collections;

public class GameMapBase : MonoBehaviour
{
    public GameObject[] objChild;

    public Vector3[] vecChild;

    // Use this for initialization
    void Start()
    {
    }

    public void InitData()
    {
        Debug.Log("GameMapBase InitData");
        //第一次玩记录原始坐标，第二次进入游戏后后复位坐标
        if (GameController.GetInstance().playLevelTimes[GameController.GetInstance().currentLevel] == 1)
        {
            vecChild = new Vector3[objChild.Length];
            for (int i = 0; i < objChild.Length; i++)
            {
                vecChild[i] = objChild[i].transform.localPosition;
                InitChildData(i);
                //Debug.Log("vecChild[i]" + objChild[i].transform.localPosition);
            }
        }
        else
        {
            for (int i = 0; i < objChild.Length; i++)
            {
                objChild[i].SetActive(true);
                objChild[i].transform.localPosition = vecChild[i];
                InitChildData(i);
            }
        }
        Debug.Log("current level has buttonCicle "+GameController.GetInstance().totalHideDbNum);
    }

    private void InitChildData(int _index)
    {
        string _tag = objChild[_index].tag;
        switch (_tag)
        {
            case "btnCicle": objChild[_index].GetComponent<GameButtonCicle>().InitData(); break;
            case "lineBoldParent": objChild[_index].GetComponent<GameLineBlodParent>().InitData(); break;
            case "db": objChild[_index].GetComponent<GameDb>().InitData(); GameController.GetInstance().totalHideDbNum++; break;            
            case "line": objChild[_index].GetComponent<GameLine>().InitData(); break;
            case "btnLj0": objChild[_index].GetComponent<GameButtonLj0>().InitData(); break;
            case "btnLj1": objChild[_index].GetComponent<GameButtonLj1>().InitData(); break;
            case "btnLj2": objChild[_index].GetComponent<GameButtonLj2>().InitData(); break;
            case "btnLj3": objChild[_index].GetComponent<GameButtonLj3>().InitData(); break;
            case "sp": objChild[_index].GetComponent<GameSp>().InitData(); break;
        }
    }
    
   
}
