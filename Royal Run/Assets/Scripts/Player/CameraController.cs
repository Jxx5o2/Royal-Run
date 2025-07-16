using System.Collections;
using UnityEngine;
using Unity.Cinemachine;
using System;
using Unity.VisualScripting;
using System.IO.IsolatedStorage;

public class CameraController : MonoBehaviour
{
    [SerializeField] float minFOV = 20f;
    [SerializeField] float maxFOV = 120f;
    [SerializeField] float zoomDuration = 1f;
    [SerializeField] float zoomSpeedModfier = 5f;
    [SerializeField] ParticleSystem speedUpParticleSystem;

    CinemachineCamera cinemachineCamera;

    void Awake()
    {
        cinemachineCamera = GetComponent<CinemachineCamera>();
    }

    public void ChangeCameraFOV(float speedAmount)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeFOVRoutine(speedAmount));

        if (speedAmount > 0)
        {
            speedUpParticleSystem.Play();
        }
    }

    IEnumerator ChangeFOVRoutine(float speedAmount)
    {
        float startFOV = cinemachineCamera.Lens.FieldOfView;
        float targetFOV = Mathf.Clamp(startFOV + speedAmount * zoomSpeedModfier, minFOV, maxFOV);

        float elaspedTime = 0f;

        while (elaspedTime < zoomDuration)
        {
            float t = elaspedTime / zoomDuration;
            elaspedTime += Time.deltaTime;

            cinemachineCamera.Lens.FieldOfView = Mathf.Lerp(startFOV, targetFOV, t);
            yield return null;
        }

        cinemachineCamera.Lens.FieldOfView = targetFOV;

    } 
}
 