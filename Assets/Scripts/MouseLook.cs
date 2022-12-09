using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private GameObject player;
    public float minClamp = -45;
    public float maxClamp = 45;
    [HideInInspector]
    public Vector2 rotation;
    private Vector2 currentLookRot;
    private Vector2 rotationV = new Vector2(0, 0);
    public float lookSensitivity = 2;
    public float lookSmoothDamp = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        //Access the player game Obj.
        player = transform.parent.gameObject;

    }



    // Update is called once per frame
    void Update()
    {
        rotation.y += Input.GetAxis("Mouse Y") * lookSensitivity;
        //clamp angle at which to look up and down
        rotation.y = Mathf.Clamp(rotation.y, minClamp, maxClamp);
        //rotate the character around based on mouseX position
        player.transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X") * lookSensitivity);
        //smooth the current Yrotation for looking up and down
        currentLookRot.y = Mathf.SmoothDamp(currentLookRot.y, rotation.y, ref rotationV.y, lookSmoothDamp);
        //update the cameraX rotation based on the value generated
        transform.localEulerAngles = new Vector3(-currentLookRot.y, 0, 0);
    }
}
