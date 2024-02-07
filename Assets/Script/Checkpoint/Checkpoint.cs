using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject halo;
    public bool isActivated { get; private set; }

    private void Start()
    {
        if (!isActivated)
        {
            halo.SetActive(false);
        }
    }
    private void Update()
    {
        if (key.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                ActiveCheckpoint();
            }
        }
    }

    public void ActiveCheckpoint()
    {
        CheckpointManager.instance.TurnOffAllCheckpoint();
        isActivated = true;
        CheckpointManager.instance.data.scene = SceneManager.GetActiveScene().name;
        halo.SetActive(true);
    }
    public void UnActiveCheckpoint()
    {
        isActivated = false;
        if (halo != null)
            halo.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            key.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        key.SetActive(false);
    }
}
