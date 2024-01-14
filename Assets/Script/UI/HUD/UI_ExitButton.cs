using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ExitButton : UI_ConfirmButton
{
    protected override void HandleConfirmKey()
    {
        base.HandleConfirmKey();
        // back to main menu
        // delete below code when complete back to main menu fuction
        transform.parent.gameObject.SetActive(false);

    }
}
