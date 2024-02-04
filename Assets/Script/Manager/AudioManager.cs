using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioPlayer player;
    public AudioEnvironment environment;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(instance.gameObject);
    }
}