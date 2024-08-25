using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private Queue<AudioSource> queueSource;

    [SerializeField] private List<AudioSource> audioSources;

    public List<AudioClip> listClip;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        queueSource = new Queue<AudioSource>(audioSources);
    }

    public void Play(AudioClip clip)
    {
        AudioSource newSource = queueSource.Dequeue();

        if(newSource)
        {
            newSource.PlayOneShot(clip);
            queueSource.Enqueue(newSource);
        }
    }
}
