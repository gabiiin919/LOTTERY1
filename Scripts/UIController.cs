using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// UIの実装
/// </summary>
public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject mainPanel;
    [SerializeField]
    private GameObject inLotteryPanel;
    [SerializeField]
    private GameObject resultPanel;
    [SerializeField]
    private GameObject inputText;
    [SerializeField]
    private GameObject goalObject;
    [SerializeField]
    private GameObject resultText;

    GameObject spawnerObject;

    string lotteryText;

    void Start()
    {
        mainPanel.SetActive(true);
        inLotteryPanel.SetActive(false);
        resultPanel.SetActive(false);
        spawnerObject = GameObject.Find("Spawner1");
        
    }

    public void OnClickStart()
    {
        lotteryText = inputText.GetComponent<Text>().text;
        spawnerObject.GetComponent<BallSpawn>().StartLottery(lotteryText);
        mainPanel.SetActive(false);
        inLotteryPanel.SetActive(true);
        resultPanel.SetActive(false);
    }

    public void OnClickExit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnClickRetry()
    {
        //Ballとタグ付けされたオブジェクトの破壊
        GameObject[] ballObjects = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject ballObject in ballObjects)
        {
            Destroy(ballObject);
        }
        goalObject.SetActive(true);
        mainPanel.SetActive(false);
        inLotteryPanel.SetActive(true);
        resultPanel.SetActive(false);
        spawnerObject.GetComponent<BallSpawn>().StartLottery(lotteryText);
    }

    public void LotteryResult(string result)
    {

        mainPanel.SetActive(false);
        inLotteryPanel.SetActive(false);
        resultPanel.SetActive(true);
        resultText.GetComponent<Text>().text = "抽選結果：" + result;
    }
}
