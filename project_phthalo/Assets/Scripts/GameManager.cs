using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public ImageViewerCanvas imageviewerCanvas;
    public ObserverCamera observerCamera;
    
    public Node startingNode;
    [HideInInspector]
    public Node currentNode;

    public CameraRig cameraRig;

    //bad singleton, but the tutorial said to do this for now
    void Awake()
    {
        instance = this;
        imageviewerCanvas.gameObject.SetActive(false);
        observerCamera.gameObject.SetActive(false);
    }

    void Start()
    {
        startingNode.Arrive();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && currentNode.GetComponent<Prop>() != null)
        {
            if (imageviewerCanvas.gameObject.activeInHierarchy)
            {
                imageviewerCanvas.Close();
                return;
            }
            currentNode.GetComponent<Prop>().location.Arrive();
        }
    }
}
