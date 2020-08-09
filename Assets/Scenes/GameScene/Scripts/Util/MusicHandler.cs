using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    private AudioSource unpausedMusic;
    private AudioSource pausedMusic;

    // Start is called before the first frame update
    void Start() {
        // GameObject.FindGameObjectWithTag("UnpausedMusic").GetComponent<MusicHandler>().PlayMusic();
    }

    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
        unpausedMusic = GetComponent<AudioSource>();
        pausedMusic = GetComponent<AudioSource>();
    }

    public void PlayPausedMusic() {
        if (pausedMusic.isPlaying) return;
        pausedMusic.Play();
    }

    public void PlayUnpausedMusic() {
        if (unpausedMusic.isPlaying) return;
        unpausedMusic.Play();
    }

    public void StopPausedMusic() {
        unpausedMusic.Stop();
    }

    public void StopUnpausedMusic() {
        unpausedMusic.Stop();
    }
}
