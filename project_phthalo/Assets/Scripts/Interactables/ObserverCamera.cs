using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverCamera : MonoBehaviour
{
    [HideInInspector]
    public Transform model;
    public Transform rig;
    
    public float sensitivity = 3f;

    private Quaternion modelRotation;
    private Quaternion rigRotation;
    
    void Update()
    {
        if (Input.GetMouseButton(0) && (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0))
        {
            if (model == null)
            {
                return;
            }

            modelRotation = model.rotation;
            rigRotation = rig.rotation;
            ObjectRotation();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            //close out of object observer
        }
        
    }

    public void ObjectRotation()
    {
        //for touch controls in future
        // float yRot = CrossPlatformInputManager.GetAxis("Mouse X") * XSensitivity;
        // float xRot = CrossPlatformInputManager.GetAxis("Mouse Y") * YSensitivity;
        
        float yRotation = Input.GetAxis("Mouse X") * sensitivity;
        float xRotation = Input.GetAxis("Mouse Y") * sensitivity;

        modelRotation *= Quaternion.Euler (0f, -yRotation, 0f);
        rigRotation *= Quaternion.Euler (xRotation, 0f, 0f);
        
        rigRotation = ClampRotationAroundXAxis (rigRotation);
        
        model.rotation = modelRotation;
        rig.rotation = rigRotation;

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

        //maybe turn back into variables for min and max for more precise changes between props
        angleX = Mathf.Clamp (angleX, -80f, 80f);

        q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }
}
