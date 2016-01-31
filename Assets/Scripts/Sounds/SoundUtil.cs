using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class SoundUtil : MonoBehaviour {

    [SerializeField]
    private AudioMixerGroup audioMixerMusic;
    [SerializeField]
    private AudioMixerGroup audioMixerAmbiance;

    [SerializeField]
    private AudioSource ploufSource;

    // Use this for initialization
    void Start () {
        var source = SoundsManager.Instance.playMusic("ambiance", transform, 0, 1);
        source.loop = true;
        SoundsManager.Instance.fadeIn(source);
        source.outputAudioMixerGroup = audioMixerAmbiance;
        source = SoundsManager.Instance.playMusic("Frozen Pinguin loop", transform, 0, 1);
        source.loop = true;
        SoundsManager.Instance.fadeIn(source);
        source.outputAudioMixerGroup = audioMixerMusic;

        EventManager.AddListener(EnumEvent.PlayPlouf, playPlouf);
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void playPlouf()
    {
        ploufSource.Stop();
        ploufSource.Play();
    }
}
