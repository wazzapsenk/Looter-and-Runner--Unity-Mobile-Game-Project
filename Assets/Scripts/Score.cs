using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    void Start()
    {
        
    }

    void Update()
    {
        scoreText.text = PlayerTriggerEffects.counter.ToString();
    }
}
