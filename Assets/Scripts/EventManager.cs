using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action stomp;
    public static event Action stopStomp;


    public static void StartStomp(){
        stomp?.Invoke();
    } 

     public static void StopStomp(){
        stopStomp?.Invoke();
    } 
}
