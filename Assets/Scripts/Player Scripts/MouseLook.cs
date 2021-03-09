using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //[SerializeField] makes the variables visible in the inspector panel even if you call them private 
    [SerializeField]
    private Transform playerRoot, lookRoot;

    [SerializeField]
    private bool invert;

    [SerializeField]
    private bool can_unlock = true;

    [SerializeField]
    private float sensitivity = 5f;

    [SerializeField]
    private int smooth_steps = 10;

    [SerializeField]
    private float smooth_weight = 0.4f;

    [SerializeField]
    private float roll_angle = 10f;

    [SerializeField]
    private float roll_speed = 3f;

    [SerializeField]
    private Vector2 default_look_limits = new Vector2(-70f, 80f);

    private Vector2 look_angels;

    private Vector2 current_mouse_look;
    private Vector2 smooth_move;

    private float current_roll_angle;

    private int last_look_frame; 


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;



    }//Start

    // Update is called once per frame
    void Update()
    {
        LockAndUnlockCursor();

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            LookAround();
        }
        
    }//Update


    void LockAndUnlockCursor()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }//Lock And Unlock Cursor




    //Move the mouse to see
    void LookAround()
    {
        current_mouse_look = new Vector2(Input.GetAxis(MouseAxis.MOUSE_Y), Input.GetAxis(MouseAxis.MOUSE_X));

        look_angels.x += current_mouse_look.x * sensitivity * (invert ? 1f : -1f);
        look_angels.y += current_mouse_look.y * sensitivity;

        //determines the limits of how far the player can look --- done using Clamp
        look_angels.x = Mathf.Clamp(look_angels.x, default_look_limits.x, default_look_limits.y);

        //This makes current_roll_angle go to, Input.GetAxisRaw value, in linear time interval ---- Purpose is to smooth out the moition when looking around
        //current_roll_angle = Mathf.Lerp(current_roll_angle, Input.GetAxisRaw(MouseAxis.MOUSE_X) * roll_angle, Time.deltaTime * roll_speed);


        lookRoot.localRotation = Quaternion.Euler(look_angels.x, 0f, 0f);
        playerRoot.localRotation = Quaternion.Euler(0f, look_angels.y, 0f);
    }//Look Around
    


}//class
