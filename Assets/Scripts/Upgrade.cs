using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    float currentXP;
    float maxXP = 5;
    public Slider xpSlider;
    public GameObject upgradeCanvas;

    void Start()
    {
        xpSlider.maxValue = maxXP;
        xpSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        xpSlider.value = currentXP;
        xpSlider.maxValue = maxXP;
        if (xpSlider.value >= xpSlider.maxValue){
            Time.timeScale = 0;
            Instantiate(upgradeCanvas);
            currentXP = 0;
            maxXP += 10; 
        }
    }


    public void IncreaseXP(float XP){
        currentXP += XP;
    }
}
