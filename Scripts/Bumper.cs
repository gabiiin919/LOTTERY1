using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// バンパーにボールが当たったときの跳ね返りの実装
/// </summary>
public class Bumper : MonoBehaviour
{
    float bumperPower = 100.0f;
    float speedLimit = 5.0f;

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Ball"))
        {
            Rigidbody ballRigid = other.transform.GetComponent<Rigidbody>();
            Vector3 ballVelocityPower = -ballRigid.velocity * bumperPower;
            //ボールが早くなりすぎないようにする
            while (ballVelocityPower.magnitude > speedLimit)
            {
                ballVelocityPower *= 0.8f;
            }

            ballRigid.velocity = ballVelocityPower;

        }
    }
}
