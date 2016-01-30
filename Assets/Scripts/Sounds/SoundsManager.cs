using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundsManager : MonoBehaviour
{
    private static SoundsManager instance;

    private List<Fish> fishList;

    private SoundsManager()
    {
    }

    public static SoundsManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindGameObjectWithTag("SoundsManager").GetComponent<SoundsManager>();
            }
            return instance;
        }
    }

    public void fadeOut(AudioSource source, float speed = 0.03f)
    {
        StartCoroutine(fadeCoroutine(source, speed));
    }

    private IEnumerator fadeCoroutine(AudioSource source, float speed)
    {
        while(source.volume > 0)
        {
            source.volume += speed;
            yield return null;
        }
    }

    public AudioSource playMusic(string clipName, Transform emitter, float volume, float pitch = 1f)
    {
        GameObject go = new GameObject("Audio: " + clipName);
        go.transform.position = emitter.position;
        go.transform.parent = emitter;

        AudioClip clip = Resources.Load(clipName) as AudioClip;
        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
        source.loop = true;
        source.Play();
        return source;
    }

    public AudioSource play(string clipName, Transform emitter, float volume, float pitch)
    {
        GameObject go = new GameObject("Audio: " + clipName);
        go.transform.position = emitter.position;
        go.transform.parent = emitter;

        AudioClip clip = Resources.Load("sounds/" + clipName) as AudioClip;
        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
        source.Play();
        Destroy(go, clip.length);
        return source;
    }

    public AudioSource play(string clipName, Transform emitter)
    {
        return play(clipName, emitter, 1f, 1f);
    }

    public AudioSource Play(string clipName, Transform emitter, float volume)
    {
        return play(clipName, emitter, volume, 1f);
    }

    public AudioSource play(string clipName, Vector3 point)
    {
        return play(clipName, point, 1f, 1f);
    }

    public AudioSource Play(string clipName, Vector3 point, float volume)
    {
        return play(clipName, point, volume, 1f);
    }

    public AudioSource play(string clipName, Vector3 point, float volume, float pitch)
    {
        //Create an empty game object
        GameObject go = new GameObject("Audio: " + clipName);
        go.transform.position = point;

        //Create the source
        AudioClip clip = Resources.Load("sounds/" + clipName) as AudioClip;
        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
        source.Play();
        Destroy(go, clip.length);
        return source;
    }
}
