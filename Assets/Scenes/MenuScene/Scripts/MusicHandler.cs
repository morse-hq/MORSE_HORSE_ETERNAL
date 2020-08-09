using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour {
    private AudioSource menuMusic;

    // Start is called before the first frame update
    void Start() {
        GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<MusicHandler>().PlayMusic();
    }

    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
        menuMusic = GetComponent<AudioSource>();
    }

    public void PlayMusic() {
        if (menuMusic.isPlaying) return;
        menuMusic.Play();
    }

    public void StopMusic() {
        menuMusic.Stop();
    }
}
