using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageViewer : Interactable
{
    public Sprite picture;
    
    public override void Interact()
    {
        GameManager.instance.imageviewerCanvas.Activate(picture);
    }
}
