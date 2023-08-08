using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camerashake : MonoBehaviour
{
    private CinemachineVirtualCamera CinemachineVirtualCamera;
    private float ShakeIntensity = 1f;
    private float ShakeTime = 0.2f;
    public float timer;
    private CinemachineBasicMultiChannelPerlin _cbmcp;

    public Transform player;

    private float defaultCamera;
    private float nextCamera;
    
    private void Awake() {
        CinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    private void Start() {
        StopShake();
    }

    private void Update() {
        defaultCamera = transform.position.x;
            transform.position = new Vector3(player.transform.position.x,

            player.transform.position.y+2, transform.position.z);
    }
    private void LateUpdate() {
          nextCamera = transform.position.x;
    }
    
    public void ShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin _cbmcp = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = ShakeIntensity;

        timer = ShakeTime;
    }

    public void StopShake()
    {
         CinemachineBasicMultiChannelPerlin _cbmcp = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
          _cbmcp.m_AmplitudeGain = 0;
          timer = 0;
    }

}
