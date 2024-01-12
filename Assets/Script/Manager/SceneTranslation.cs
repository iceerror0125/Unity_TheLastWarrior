using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTranslation : MonoBehaviour
{
    [SerializeField] private string transitionTo;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Vector2 startDir;
    [SerializeField] private float delay;

    void Start()
    {
        if (transitionTo == GameManager.Instance.transitionFromScene)
        {
            PlayerManager.instance.player.transform.position = startPoint.transform.position;
            StartCoroutine(PlayerManager.instance.WalkToNewScene(startDir, delay));
            BlackScreen.instance.FadeOut();

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            // debug here to confirm trigger or start print log first
            GameManager.Instance.transitionFromScene = SceneManager.GetActiveScene().name;
            GameManager.Instance.isCutScene = true;

            StartCoroutine(WaitFadeIn());

        }
    }

    IEnumerator WaitFadeIn()
    {
        BlackScreen.instance.FadeIn();
        while(!BlackScreen.instance.IsFill())
        {
            yield return null;
        }
        SceneManager.LoadScene(transitionTo);
    }
}
