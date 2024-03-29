using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingEvent : MonoBehaviour
{
    private float FOV;

    private Camera cachedCamera;
    private Vector3 zeroPos = Vector3.zero;

    public Slider FOVSlider;
    public Slider audioSlider;


    private void Awake()
    {
        SetAttrFOVSlider();
        SetAttrAudioSlider();
    }

    private void SetAttrFOVSlider()
    {
        if (FOVSlider != null)
        {
            cachedCamera = Camera.allCameras[1];
            FOV = 45;
            cachedCamera.fieldOfView = FOV;


            FOVSlider.minValue = -15f;
            FOVSlider.maxValue = 15f;

            FOVSlider.value = 0;
        }
    }

    private void SetAttrAudioSlider()
    {
        audioSlider.value = 0.5f;
    }

    public void OnFOVSlide()
    {
        cachedCamera.fieldOfView = FOV - FOVSlider.value;
    }

    public void OnAudioSlide()
    {
        AudioManager.Instance.SetVolumne(audioSlider.value);
    }
}
