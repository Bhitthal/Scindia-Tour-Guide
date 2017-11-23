using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour {


    public string url;
    public AudioSource source;
	// Use this for initialization
	void Start () {
         WWW www = new WWW(url);
        source = GetComponent<AudioSource>();
        //source.clip = www.audioClip;
	}
	
	// Update is called once per frame
	void Update () {
        if (!source.isPlaying && source.clip.isReadyToPlay)
            source.Play();
	}
}
