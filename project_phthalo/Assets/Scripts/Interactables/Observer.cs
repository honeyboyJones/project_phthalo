using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : Interactable
{
    public override void Interact()
    {
        //populate rig with object
        GameObject item = Instantiate(gameObject);
        item.transform.SetParent(GameManager.instance.observerCamera.rig);
        item.transform.localPosition = Vector3.zero;
        item.transform.GetChild(0).localPosition = Vector3.zero;
        
        //turn on observer camera
        GameManager.instance.observerCamera.model = item.transform;
        GameManager.instance.observerCamera.gameObject.SetActive(true);
    }
}
