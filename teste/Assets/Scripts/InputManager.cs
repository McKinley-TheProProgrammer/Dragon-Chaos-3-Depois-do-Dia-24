using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public delegate void KeyboardActionDash();
    public static event KeyboardActionDash Dash;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(Dash != null)
                {
                    Dash();
                    return;
                }
            }
        }
    }
}
