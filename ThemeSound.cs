using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeSound : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource sound;
    private void Awake()
    {
        sound = GetComponent<AudioSource>();
    }
    void Start()
    {
        sound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (sound.isPlaying != true)
            sound.Play();
    }
}
