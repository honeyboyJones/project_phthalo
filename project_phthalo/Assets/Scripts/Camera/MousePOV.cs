using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput; //potential for touch controls

[RequireComponent(typeof(CameraRig))]
public class MousePOV : MonoBehaviour
{
    public float XSensitivity = 2f;
    public float YSensitivity = 2f;
    public bool clampVerticalRotation = true;
    public float MinimumX = -90F;
    public float MaximumX = 90F;
    // public bool clampHorizontalRotation = true;
    // public float MinimumY = -90F;
    // public float MaximumY = 90F;
    public bool smooth;
    public float smoothTime = 5f;
    //public bool lockCursor = true;
    
    private Quaternion yAxis;
    private Quaternion xAxis;
    //private bool m_cursorIsLocked = true;

    private CameraRig cameraRig;

    
    void Start()
    {
        cameraRig = GetComponent<CameraRig>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0))
        {
            if (GameManager.instance.imageviewerCanvas.gameObject.activeInHierarchy || 
                GameManager.instance.observerCamera.gameObject.activeInHierarchy)
            {
                return;
            }
            yAxis = cameraRig.y_axis.localRotation;
            xAxis = cameraRig.x_axis.localRotation;
            LookRotation();
        }
    }

    public void LookRotation()
    {
        //for touch controls in future
        // float yRot = CrossPlatformInputManager.GetAxis("Mouse X") * XSensitivity;
        // float xRot = CrossPlatformInputManager.GetAxis("Mouse Y") * YSensitivity;
        
        float yRotation = Input.GetAxis("Mouse X") * XSensitivity;
        float xRotation = Input.GetAxis("Mouse Y") * YSensitivity;

        yAxis *= Quaternion.Euler (0f, yRotation, 0f);
        xAxis *= Quaternion.Euler (-xRotation, 0f, 0f);

        if(clampVerticalRotation)
            xAxis = ClampRotationAroundXAxis (xAxis);
        
        // if(clampHorizontalRotation)
        //     yAxis = ClampRotationAroundYAxis (yAxis);

        if(smooth)
        {
            cameraRig.y_axis.localRotation = Quaternion.Slerp (cameraRig.y_axis.localRotation, yAxis,
                smoothTime * Time.deltaTime);
            cameraRig.x_axis.localRotation = Quaternion.Slerp (cameraRig.x_axis.localRotation, xAxis,
                smoothTime * Time.deltaTime);
        }
        else
        {
            cameraRig.y_axis.localRotation = yAxis;
            cameraRig.x_axis.localRotation = xAxis;
        }

        //UpdateCursorLock();
    }

    // public void SetCursorLock(bool value)
    // {
    //     lockCursor = value;
    //     if(!lockCursor)
    //     {//we force unlock the cursor if the user disable the cursor locking helper
    //         Cursor.lockState = CursorLockMode.None;
    //         Cursor.visible = true;
    //     }
    // }
    //
    // public void UpdateCursorLock()
    // {
    //     //if the user set "lockCursor" we check & properly lock the cursos
    //     if (lockCursor)
    //         InternalLockUpdate();
    // }
    //
    // private void InternalLockUpdate()
    // {
    //     if(Input.GetKeyUp(KeyCode.Escape))
    //     {
    //         m_cursorIsLocked = false;
    //     }
    //     else if(Input.GetMouseButtonUp(0))
    //     {
    //         m_cursorIsLocked = true;
    //     }
    //
    //     if (m_cursorIsLocked)
    //     {
    //         Cursor.lockState = CursorLockMode.Locked;
    //         Cursor.visible = false;
    //     }
    //     else if (!m_cursorIsLocked)
    //     {
    //         Cursor.lockState = CursorLockMode.None;
    //         Cursor.visible = true;
    //     }
    // }

    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.x);

        angleX = Mathf.Clamp (angleX, MinimumX, MaximumX);

        q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }
    
    // Quaternion ClampRotationAroundYAxis(Quaternion q)
    // {
    //     q.x /= q.w;
    //     q.y /= q.w;
    //     q.z /= q.w;
    //     q.w = 1.0f;
    //
    //     float angleY = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.y);
    //
    //     angleY = Mathf.Clamp (angleY, MinimumY, MaximumY);
    //
    //     q.y = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleY);
    //
    //     return q;
    // }
}
