using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public float L_HSpeed = 2f;
    public float L_VSpeed = 2f;
    public float viewrange = 85;

    private float yaw = 0f;
    private float pitch = 0f;
    private Transform maincamera;

    void Start()
    {
        yaw = transform.rotation.eulerAngles.y;
        pitch = transform.rotation.eulerAngles.z;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        maincamera = transform.GetChild(0);
    }

    void Update()
    {
        yaw += L_HSpeed * Input.GetAxisRaw("Mouse X");
        pitch -= L_VSpeed * Input.GetAxisRaw("Mouse Y");
        pitch = Mathf.Clamp(pitch, -viewrange, viewrange);
        transform.localEulerAngles = new Vector3(0f, yaw, 0f);
        maincamera.localEulerAngles = new Vector3(pitch, 0, 0f);
    }
}
