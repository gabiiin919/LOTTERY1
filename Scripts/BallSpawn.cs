using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ボールの範囲内ランダムスポーンの実装
/// </summary>
public class BallSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab;
    [SerializeField]
    private Transform spawnArea1;
    [SerializeField]
    private Transform spawnArea2;

    public void StartLottery(string ballCandidate)
    {
        //全角スペースで文字を区切る
        string[] ballArray = ballCandidate.Split('　');
        for (int i = 0; i < ballArray.Length; i++)
        {
            float x = Random.Range(spawnArea1.position.x, spawnArea2.position.x);
            float y = Random.Range(spawnArea1.position.y, spawnArea2.position.y);
            float z = Random.Range(spawnArea1.position.z, spawnArea2.position.z);
            //子の子オブジェクトを取得
            GameObject child = ballPrefab.GetComponent<Transform>().transform.GetChild(0).gameObject;
            GameObject grandChild = child.GetComponent<Transform>().transform.GetChild(0).gameObject;
            grandChild.GetComponent<TextMesh>().text = ballArray[i];
            Instantiate(ballPrefab, new Vector3(x,y,z), ballPrefab.transform.rotation);
            
        }
    }

}