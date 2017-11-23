using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class sound_controller : MonoBehaviour {

    public static sound_controller instance;
    
    private string url = "http://vw123.000webhostapp.com/sounds/";
    public AudioSource source;
    private WWW www = null;

    private string clip_Name;

    private int flag_www = 1;

    private bool streamPlayStart = false;

    public AudioClip[] clips0;

    public AudioClip[] clips1;

    public int lang_flag = 0;

    void Awake(){
        MakeInstance();
        lang_flag = appManage.instance.get_lang();
    
    }
    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
       // WWW www = new WWW(url);
        //source = GetComponent<AudioSource>();
        //source.clip = www.GetAudioClip();
    }
    void Update()
    {
        /*
        if (www != null && flag_www == 0 && www.progress > 0.1f)
        {
            Debug.Log("progress " + www.progress);
            Debug.Log(source.isPlaying + " _ " + source.clip.isReadyToPlay);
            //if (!source.isPlaying && source.clip.loadState == AudioDataLoadState.Failed)
           // if (!source.isPlaying && source.clip.isReadyToPlay)
            {
             //   source.Play();
               // App_controller.instance.debug_text("audio play " + clip_Name);
                //Debug.Log("paly");

            }
        }*/
       // if (streamPlayStart) {
         //   source.Play();
          //  App_controller.instance.debug_text("audio play " + clip_Name);
            //Debug.Log("paly");

       // }
        if (!source.isPlaying)
            flag_www = 1;

    }

    public void play_clip(string clip_name)
    {
        //StartCoroutine(DownloadAndPlay(clip_name));
        if(flag_www == 1)
            StartCoroutine(DownloadAndPlay_local(clip_name));
       /* try
        {
            clip_Name = clip_name; 
            www = new WWW(url + clip_name + ".ogg");
            //source = GetComponent<AudioSource>();
            Debug.Log("www.error " + www.error);
            while (www.progress < 1.0f) { }
            Debug.Log(www.progress);
            source.clip = www.GetAudioClip(false, true, AudioType.OGGVORBIS);
            flag_www = 0;
            
        }
        catch (Exception e)
        {
            Debug.Log("Exception www1 " + e);
            flag_www = 1;
        }*/
    }


    IEnumerator DownloadAndPlay_local(string clip_name)
    {
        clip_Name = clip_name;
        //www = new WWW(url + clip_name + ".ogg");
        //source.clip = (AudioClip)Resources.Load("sounds/" + clip_name + ".ogg");
        if(lang_flag == 0)
            source.clip = clips0[int.Parse(clip_name)-1];
        else
            source.clip = clips1[int.Parse(clip_name)-1];

        Debug.Log("play:" + clip_name);

        source.Play();

        flag_www = 0;

        yield return new WaitForSeconds(0.1f);
        //WWW www1 = new WWW(url + "5.ogg");
        //source = GetComponent<AudioSource>();
        /*Debug.Log("www.error " + www.error);
        while (www.progress < 0.1)
        {
            Debug.Log(www.progress);
            yield return new WaitForSeconds(0.1f);
        }
        while (!www.isDone)
        {
            Debug.LogFormat("Progress loading {0}: {1}", clip_name, www.progress);
            yield return null;
        }*/

        //source.clip = www.GetAudioClip(false, false, AudioType.OGGVORBIS);
        //source.clip = www1.GetAudioClip(false, true, AudioType.OGGVORBIS);
        //streamPlayStart = true;
    }

    IEnumerator DownloadAndPlay(string clip_name)
    {
        clip_Name = clip_name;
        www = new WWW(url + clip_name + ".ogg");
        //WWW www1 = new WWW(url + "5.ogg");
        //source = GetComponent<AudioSource>();
        Debug.Log("www.error " + www.error);
        while (www.progress < 0.1)
        {
            Debug.Log(www.progress);
            yield return new WaitForSeconds(0.1f);
        }
        while (!www.isDone)
        {
            Debug.LogFormat("Progress loading {0}: {1}", clip_name, www.progress);
            yield return null;
        }

        source.clip = www.GetAudioClip(false, false, AudioType.OGGVORBIS);
        //source.clip = www1.GetAudioClip(false, true, AudioType.OGGVORBIS);
        streamPlayStart = true;
    }

    public void end_clip() {

        www = null;
        flag_www = 1;
    }

    public void pause() {
        if (source.isPlaying)
        {
            source.Pause();
            flag_www = 1;
        }
        //else
            //flag_www = 1;
    }

    public void resume() {
        if (!source.isPlaying)
        {
            source.Play();
            flag_www = 0;
        }
    }


}
