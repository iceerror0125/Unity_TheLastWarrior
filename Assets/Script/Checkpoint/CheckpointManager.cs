using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;
    [SerializeField] List<Checkpoint> checkpoints;
    public CheckpointData data;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
        }
        if (data.scene.Equals(SceneManager.GetActiveScene().name))
        {
            checkpoints[0].ActiveCheckpoint();
        }
    }
    void Start()
    {
        if (checkpoints[0].isActivated)
        {
            BlackScreen.instance.FadeOut();
            PlayerManager.instance.player.transform.position = checkpoints[0].transform.position;
        }
        else if (!data.scene.Contains("Scene"))
        {
            BlackScreen.instance.FadeOut();
            PlayerManager.instance.player.transform.position = new Vector2(-10, -1);
        }
    }

    public bool HasCheckPoint()
    {
        for (int i = 0; i < checkpoints.Count; i++)
        {
            if (checkpoints[i].isActivated)
            {
                return true;
            }
        }
        return false;
    }

    public Checkpoint GetActiveCheckpoint()
    {
        for (int i = 0; i < checkpoints.Count; i++)
        {
            if (checkpoints[i].isActivated)
            {
                return checkpoints[i];
            }
        }
        return null;
    }

    public void TurnOffAllCheckpoint()
    {
        foreach (var checkpoint in checkpoints)
        {
            checkpoint.UnActiveCheckpoint();
        }
    }
}
