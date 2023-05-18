using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class WearKit : MonoBehaviour
{

    [SerializeField] GameObject UIIndicator;
    [SerializeField] GameObject tick;
    [SerializeField] GameObject task;
    [SerializeField] GameObject UIIndicator2;
    [SerializeField] GameObject UIIndicator3;
    [SerializeField] List<GameObject> mannequinParts = new List<GameObject>();
    [SerializeField] List<GameObject> ticks = new List<GameObject>();

    public static Action allKitWorn;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabInteratable = GetComponent<XRGrabInteractable>();
        grabInteratable.activated.AddListener(Wear);
    }

    void Wear(ActivateEventArgs args)
    {
        if (UIIndicator != null)
            UIIndicator.SetActive(true);
        UIIndicator2.SetActive(true);
        if(UIIndicator3 != null)
            UIIndicator3.SetActive(true);
        tick.SetActive(true);
        foreach(GameObject part in mannequinParts)
        {
            part.SetActive(true);
        }
        Destroy(gameObject);
        Invoke("RemoveTask", 1.0f);

        foreach(GameObject tick in ticks)
        {
            if (!tick.activeInHierarchy)
                return;
        }

        allKitWorn?.Invoke();
    }

    void RemoveTask()
    {
        task.SetActive(false);
    }
}
