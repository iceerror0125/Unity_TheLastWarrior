using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Dimond : MonoBehaviour
{
    private TextMeshProUGUI text;
    private SkillManager manager;
    private void Start()
    {
        manager = SkillManager.instance;
        text = GetComponent<TextMeshProUGUI>();
        manager.UpdateDimondUI += UpdateDimond;
        text.text = manager.dimond.ToString();
    }

    public void UpdateDimond()
    {
        text.text = manager.dimond.ToString();
    }

   
}
