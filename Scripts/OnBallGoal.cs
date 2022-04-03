using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 抽選の実装
/// </summary>
public class OnBallGoal : MonoBehaviour
{
    string result;
    GameObject userInterface;

    void Start()
    {
        userInterface = GameObject.Find("UI");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Ball"))
        {
            //子の子オブジェクトを取得する
            GameObject child = other.GetComponent<Transform>().transform.GetChild(0).gameObject;
            GameObject grandChild = child.GetComponent<Transform>().transform.GetChild(0).gameObject;
            gameObject.SetActive(false);
            result = grandChild.GetComponent<TextMesh>().text;
            userInterface.GetComponent<UIController>().LotteryResult(result);
        }
    }
}
