using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// ボールを上に上げるリフトの実装
/// </summary>
public class Lift : MonoBehaviour
{
    [SerializeField]
    private GameObject lift;
    [SerializeField]
    private Vector3 floor1Position;
    [SerializeField]
    private Vector3 floor2Position;
    float liftTime = 3.0f;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Ball"))
        {
            lift.transform.DOMove(floor2Position, liftTime).SetDelay(0.2f);
            lift.transform.DOMove(floor1Position, liftTime).SetDelay(liftTime+7.0f);

        }
    }
}
