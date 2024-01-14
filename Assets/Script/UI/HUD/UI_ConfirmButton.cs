using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ConfirmButton : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            int child = transform.childCount;
            if (child == 0) // don't have a cursor
                return;
            HandleConfirmKey();
        }
    }

    protected virtual void HandleConfirmKey() { }
   
}
