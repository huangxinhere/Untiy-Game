using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;
    [Header("相机滚动缩放数值")]
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 20f;
    [Header("相机左右摇摆数值")]
    public float yawSpeed = 100f;
    private float currentYaw = 0f;

    private float currentZoom = 20f;

    private void Update() {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    //对象移动后摄像机才移动
    private void LateUpdate() {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position);

        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }

    public void InitCam(float changedZoom){
        currentZoom = changedZoom;
    }




}
