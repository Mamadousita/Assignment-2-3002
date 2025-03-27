using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetBar : MonoBehaviour
{
     public int scoreReward = 100;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ScoreManager.instance.AddScore(scoreReward);
        }
    }
}
