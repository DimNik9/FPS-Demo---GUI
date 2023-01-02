using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXandY;
    public float sensitivityHor = 8.0f;                    //Declares how fast will the player rotate horizontally
    public float sensitivityVert = 8.0f;                   //Declares how fast will the player rotate vertically

    public float minimumVert = -45.0f;                     
    public float maximumVert = 45.0f;

    private float verticalRot = 0;
    private bool IsPopUpOpen = false;
    // Start is called before the first frame update
    void Start()
    {  
    }
    private void OnEnable()
    {
        Messenger.AddListener(GameEvent.SETTINGS_OPEN, settingsOpen);
        Messenger.AddListener(GameEvent.SETTINGS_CLOSE, settingsClose);
    }

    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.SETTINGS_OPEN, settingsOpen);
        Messenger.RemoveListener(GameEvent.SETTINGS_OPEN, settingsClose);
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseX)    //Horizontal Rotation
        {
            if (IsPopUpOpen == false)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);  //Instantly rotate, because we dont want to manipulate this rotation
            }
        }
        else if (axes == RotationAxes.MouseY)
        {
            //vertical rotation
            if (IsPopUpOpen == false)
            {
                verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert;       //Stores the rotation angle
                verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);    //Restricts verticalRot between min & max

                float horizontalRot = transform.localEulerAngles.y;

                transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);    //Angles property of transform is a Vector3, we create a new one
            }                                                                                  
        }
        else
        {
            //both horizontal and vertical
            if (IsPopUpOpen == false)
            {
                verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert;
                verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

                float delta = Input.GetAxis("Mouse X") * sensitivityHor;
                float horizontalRot = transform.localEulerAngles.y + delta;
                transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
            }
        }
    }

    void settingsOpen()
    {
        IsPopUpOpen = true;
    }
    void settingsClose()
    {
        IsPopUpOpen = false;
    }
}
