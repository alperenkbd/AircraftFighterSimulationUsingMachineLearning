using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera overheadCamera;

    private void Start()
    {
        ShowFirstPersonView();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) {
            ShowOverheadView();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            ShowFirstPersonView();
        }

    }


    public void ShowOverheadView()
    {
        firstPersonCamera.enabled = false;
        overheadCamera.enabled = true;
    }

    
    public void ShowFirstPersonView()
    {
        firstPersonCamera.enabled = true;
        overheadCamera.enabled = false;
    }



}
