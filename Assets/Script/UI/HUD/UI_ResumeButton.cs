using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ResumeButton : UI_ConfirmButton
{
    protected override void HandleConfirmKey()
    {
        base.HandleConfirmKey();
       
        transform.parent.gameObject.SetActive(false);
    }
}
