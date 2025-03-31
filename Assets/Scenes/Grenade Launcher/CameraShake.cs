using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public static CameraShake Instance { get; private set; }

    private CinemachineCamera cinemachineCam;
    private CinemachineBasicMultiChannelPerlin noise;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        cinemachineCam = GetComponent<CinemachineCamera>();
        noise = cinemachineCam.GetComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCamera(float intensity, float duration)
    {
        noise.AmplitudeGain = intensity;
        noise.FrequencyGain = duration;

    }

    private void Update()
    {

        if(noise.AmplitudeGain > 0)
        {
            noise.AmplitudeGain -= 2 * Time.deltaTime;
        }
        else
        {
            noise.AmplitudeGain = 0;
        }

        
    }


}
