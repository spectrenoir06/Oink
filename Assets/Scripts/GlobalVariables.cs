﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Enum_creditRole
{
    role1,
    role2,
    role3,
    role4
}

public class GlobalVariables : MonoBehaviour {

    public List<string> list_creditMembers = new List<string>();
    public static List<string> LIST_CREDIT_MEMBERS;

    public GameObject go_creditText;
    public static GameObject GO_CREDIT_TEXT;

    void Awake()
    {
        LIST_CREDIT_MEMBERS = list_creditMembers;
        GO_CREDIT_TEXT = go_creditText;
    }
}
