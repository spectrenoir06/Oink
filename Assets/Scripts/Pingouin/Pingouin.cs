﻿using UnityEngine;
using System.Collections;

public class Pingouin : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Banquise").transform);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
