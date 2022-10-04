using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class Node : MonoBehaviour
{
    public Transform cameraPosition;
    public List<Node> reachableNodes = new List<Node>();

    [FormerlySerializedAs("col")] [HideInInspector]
    public new Collider collider;
    
    
    void Awake()
    {
        collider = GetComponent<Collider>();
        collider.enabled = false;
    }

    private void OnMouseDown()
    {
        Arrive();
    }

    public virtual void Arrive()
    {
        //leave existing currentNode
        if (GameManager.instance.currentNode != null)
        {
            GameManager.instance.currentNode.Leave();
        }

        //set currentNode
        GameManager.instance.currentNode = this;
        
        //move the camera
        GameManager.instance.cameraRig.AlignTo(cameraPosition);
        
        // Camera.main.transform.position = cameraPosition.position;
        // Camera.main.transform.rotation = cameraPosition.rotation;
        
        //turn off our own collider
        if (collider != null)
        {
            collider.enabled = false;
        }
        
        //turn on all reachable node colliders
        SetReachableNodes(true);
    }

    public virtual void Leave()
    {
        //turn off all reachable node colliders
        SetReachableNodes(false);
    }

    public void SetReachableNodes(bool set)
    {
        //turn on or off all reachable node colliders
        foreach (Node node in reachableNodes)
        {
            if (node.collider != null)
            {
                if (node.GetComponent<Prerequisite>() && node.GetComponent<Prerequisite>().nodeAccess)
                {
                    if (node.GetComponent<Prerequisite>().Complete)
                    {
                        node.collider.enabled = set;
                    }
                }
                else
                {
                    node.collider.enabled = set;
                }
            }
        }
    }
}
