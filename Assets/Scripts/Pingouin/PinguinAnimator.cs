﻿using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class PinguinAnimator : MonoBehaviour
{
    private enum StateAnimationPinguin
    {
        Walk,
        Throw,
        Dive,
        Eat,
        DanceThenDive,
        DanceThenEat
    }

    public enum newStateAnimationPinguin
    {
        Throw,
        Dive,
        Eat,
        DanceThenDive,
        DanceThenEat
    }

    [SerializeField]
    private AudioClip ploufAudio;

    [SerializeField]
    private AudioMixerGroup audioMixer;

    [SerializeField]
    private NPCAIController iaController;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject ploufPrefab;

    private GameObject ploufParticles;

    private StateAnimationPinguin currentState;

    // Use this for initialization
    void Start()
    {
        currentState = StateAnimationPinguin.Walk;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void playAnimation(newStateAnimationPinguin state)
    {
        switch (state)
        {
            case newStateAnimationPinguin.Throw:
                animator.SetTrigger("Throw");
                currentState = StateAnimationPinguin.Throw;
                break;
            case newStateAnimationPinguin.Dive:
                animator.SetTrigger("Dive");
                currentState = StateAnimationPinguin.Dive;
                break;
            case newStateAnimationPinguin.Eat:
                animator.SetTrigger("Eat");
                currentState = StateAnimationPinguin.Eat;
                break;
            case newStateAnimationPinguin.DanceThenDive:
                animator.SetTrigger("DiveAfterDance");
                animator.SetTrigger("Dance");
                currentState = StateAnimationPinguin.DanceThenDive;
                break;
            case newStateAnimationPinguin.DanceThenEat:
                animator.SetTrigger("EatAfterDance");
                animator.SetTrigger("Dance");
                currentState = StateAnimationPinguin.DanceThenEat;
                break;
        }
    }

    public void Dive()
    {
        plouf();
        Destroy(transform.parent.gameObject);
    }


    public void OnStartWalk()
    {
        if (currentState != StateAnimationPinguin.Walk)
        {
            iaController.startWalking();
            currentState = StateAnimationPinguin.Walk;
        }
    }

    private void plouf()
    {
        ploufParticles = Instantiate(ploufPrefab) as GameObject;
        ploufParticles.transform.position = transform.position;
        ploufParticles.GetComponent<ParticleSystem>().Play();
        ploufParticles.AddComponent<AudioSource>();
        ploufParticles.GetComponent<AudioSource>().clip = ploufAudio;
        ploufParticles.GetComponent<AudioSource>().outputAudioMixerGroup = audioMixer;
        ploufParticles.GetComponent<AudioSource>().Play();
    }
}
