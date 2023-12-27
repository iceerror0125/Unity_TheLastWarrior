using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;
    [SerializeField] List<Checkpoint> checkpoints;
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
    }
    void Start()
    {
        
    }

    public void TurnOffAllCheckpoint()
    {
        foreach (var checkpoint in checkpoints)
        {
            checkpoint.UnActiveCheckpoint();
        }
    }
}
