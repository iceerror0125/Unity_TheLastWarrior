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
    public float left;
    public float top;
    public float right;
    public float bottom;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

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
            //Debug.Log(bg.transform.position);
            CheckConstraint();
        }

    }

    private void CheckConstraint()
    {
        float clampedX = Mathf.Clamp(bg.transform.position.x, left, right);
        float clampedY = Mathf.Clamp(bg.transform.position.y, bottom, top);

        bg.transform.position = new Vector2(clampedX, clampedY);

        /* if (bg.transform.position.x > right)
         {
             bg.transform.position = new Vector2(right, bg.transform.position.y);
         }
         else if (bg.transform.position.x < left)
         {
             bg.transform.position = new Vector2(left, bg.transform.position.y);
         }
         if (bg.transform.position.y > top)
         {
             bg.transform.position = new Vector2(bg.transform.position.x, top);
         }
         else if (bg.transform.position.y < bottom)
         {
             bg.transform.position = new Vector2(bg.transform.position.x, bottom);

         }*/
    }
}
