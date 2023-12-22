using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera vcam;
    public float shakeIntensity = 2f;
    public float shakeTime = 0.1f;

    private float timer;
    private CinemachineBasicMultiChannelPerlin cbmcp;

    void Awake()
    { 
      vcam = GetComponent<CinemachineVirtualCamera>();  
    }

    private void Start() {
        StopShake();
    }

    public void ShakeCam(){
        cbmcp = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cbmcp.m_AmplitudeGain = shakeIntensity;
        timer = shakeTime;
    }

    private void StopShake(){
        cbmcp = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cbmcp.m_AmplitudeGain = 0;
        timer = 0;
    }


    private void Update() {
        if (timer>0){
            timer -= Time.deltaTime;
            if (timer<=0){
                StopShake();
            }
        }
    }
}
