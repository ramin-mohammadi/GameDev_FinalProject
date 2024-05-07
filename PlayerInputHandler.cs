using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            input.x += -1;

        }

        if (Input.GetKey(KeyCode.D))
        {
            input.x += 1;

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Main_Character.singleton.Jump();
        }

        Main_Character.singleton.Move(input);
        
    }
}
