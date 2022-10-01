using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;
    [HideInInspector]
    public Node currentNode;

    //bad singleton, but the tutorial said to do this for now
    void Awake()
    {
        ins = this;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && currentNode.GetComponent<Prop>() != null)
        {
            currentNode.GetComponent<Prop>().location.Arrive();
        }
    }
}
