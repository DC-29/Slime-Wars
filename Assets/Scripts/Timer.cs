using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{   
    float timer;
    public TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
       timer = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        TimeString();
    }

    void TimeString(){
        float minutes = Mathf.FloorToInt(timer / 60);  
        float seconds = Mathf.FloorToInt(timer % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
