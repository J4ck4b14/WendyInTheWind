using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    float [] v = { 1, 1.2f, 1.65f };
    public int n = 1; // We'll use this to know which of the previously stated speeds we'll be using
    // The following are just to be sure that it works
    public bool cPressed = false;
    public bool shiftPressed = false;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.C))
        {
            if (cPressed)
            {
                cPressed = false;
                return;
            }
            if (shiftPressed) { shiftPressed = false; }
            cPressed = true;
            n = 0;
        }
        if (Input.GetKey(KeyCode.LeftShift)|| Input.GetKey(KeyCode.RightShift))
        {
            if (shiftPressed)
            {
                shiftPressed = false;
                return;
            }
            if (cPressed) { cPressed = false; }
            shiftPressed = true;
            n = 2;
        }
        if (!cPressed && !shiftPressed) { n=1; }

        Vector3 playerMov = new Vector3(hor, 0f,ver) * v[n] * Time.deltaTime;
        transform.Translate(playerMov, Space.Self);
    }

    
}
