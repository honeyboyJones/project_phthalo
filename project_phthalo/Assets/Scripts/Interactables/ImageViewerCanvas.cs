using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageViewerCanvas : MonoBehaviour
{
    public Image imageHolder;
    
    public void Activate(Sprite picture)
    {
        GameManager.instance.currentNode.SetReachableNodes(false);
        GameManager.instance.currentNode.collider.enabled = false;
        gameObject.SetActive(true);
        imageHolder.sprite = picture;
    }

    public void Close()
    {
        GameManager.instance.currentNode.SetReachableNodes(true);
        GameManager.instance.currentNode.collider.enabled = true;
        gameObject.SetActive(false);
        imageHolder.sprite = null;
    }
}
