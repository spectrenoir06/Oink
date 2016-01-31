﻿using UnityEngine;
using System.Collections;

public class Pingouin : MonoBehaviour
{
    [SerializeField]
    private PingouinNavigation navigation;

    [SerializeField]
    private PinguinAnimator animator;

    [SerializeField]
    private NPCAIController iaController;

    [SerializeField]
    private GameObject marker;

    private bool currentMark;

    private GameObject banquise;

    private bool isOnBorder;
    // Use this for initialization
    void Start ()
    {
        isOnBorder = true;
        currentMark = false;
        marker.SetActive(currentMark);
        banquise = GameObject.FindGameObjectWithTag("Banquise");
    }
    
    IEnumerator popFish()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            throwFish();
        }
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, banquise.transform.position) > 12)
        {
            if (!isOnBorder)
            {
                iaController.onBorderBanquise();
            }
            isOnBorder = true;
        }
        else
            isOnBorder = false;

        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit) && hit.transform == transform)
        {
            throwFish();
        }

        if (Input.GetMouseButtonDown(1) && Physics.Raycast(ray, out hit) && hit.transform == transform)
        {
            currentMark = !currentMark;
            marker.SetActive(currentMark);
        }
    }

    public void throwFish()
    {
        animator.playAnimation(PinguinAnimator.newStateAnimationPinguin.Throw);
        FishManager.Instance.createPrefabAtPosition(transform.position);
    }}
