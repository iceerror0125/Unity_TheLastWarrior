using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_InfoDialog : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI description;
    
    public void ShowDialog(ItemData _item)
    {
        gameObject.SetActive(true);
        image.sprite = _item.Img;
        description.text = _item.Description;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            gameObject.SetActive(false);
        }
    }
}
