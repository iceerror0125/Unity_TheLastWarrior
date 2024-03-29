using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public Vector2 vectro;
    public float speed = 2;
    public GameObject bg;
    public bool isClickable;
    [Header("Constraint")]
    private RectTransform rectTransform;

    public Vector2 limitMin;
    public Vector2 limitMax;


    private void Start()
    {
        if (bg != null)
        {

            rectTransform = bg.GetComponent<RectTransform>();
        }

        BlackScreen.instance.FadeOut();

        GameObject continueBtn = transform.Find("Continue").gameObject;

        if (SaveManager.instance.ExistsFileSave())
        {
            continueBtn.SetActive(true);
        }
        else
        {
            continueBtn.SetActive(false);
        }
      


    }
    private void Update()
    {
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            var target = new Vector2(bg.transform.position.x + Input.GetAxis("Mouse X") * -1, bg.transform.position.y + Input.GetAxis("Mouse Y") * -1);
            bg.transform.position = Vector2.MoveTowards(bg.transform.position, target, speed);
          
            CheckConstraint();
        }

    }

    private void CheckConstraint()
    {
        rectTransform.offsetMin = new Vector2(
           Mathf.Clamp(rectTransform.offsetMin.x, limitMin.x, limitMax.x),
           Mathf.Clamp(rectTransform.offsetMin.y, limitMin.y, limitMax.y)
       );
        rectTransform.offsetMax = new Vector2(
            Mathf.Clamp(rectTransform.offsetMax.x, limitMin.x, limitMax.x),
            Mathf.Clamp(rectTransform.offsetMax.y, limitMin.y, limitMax.y)
        );
    }
}
