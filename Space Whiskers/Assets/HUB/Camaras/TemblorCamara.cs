using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TemblorCamara : MonoBehaviour
{
    public static TemblorCamara Instance;
    private CinemachineVirtualCamera cvCamera;
    private CinemachineBasicMultiChannelPerlin cinemachineBMP;

    private float tiempoMov;
    private float tiempoMovTotal;
    private float tiempoMovInicial;
    private float intencidadInicial;

    private void Awake()
    {
        Instance = this;
        cvCamera = GetComponent<CinemachineVirtualCamera>();
        cinemachineBMP = cvCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void moverCamara(float intensidad, float frecuencia, float tiempo)
    {
        cinemachineBMP.m_AmplitudeGain = intensidad;
        cinemachineBMP.m_FrequencyGain = frecuencia;
        intencidadInicial = intensidad;
        tiempoMovTotal = tiempo;
        tiempoMov = tiempo;
    }

    private void Update()
    {
        if(tiempoMov > 0f) 
        {
            tiempoMov -= Time.deltaTime;
            cinemachineBMP.m_AmplitudeGain = Mathf.Lerp(intencidadInicial, 0, 1 - (tiempoMov / tiempoMovTotal));
        }
    }
}
