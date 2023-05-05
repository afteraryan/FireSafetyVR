using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitWearRoom : MonoBehaviour
{
    [SerializeField] GameObject mannequineUI;
    [SerializeField] GameObject listUI;

    private void OnEnable()
    {
        WearKit.allKitWorn += ConvertToTrigger;
    }

    private void OnTriggerEnter(Collider other)
    {
        mannequineUI.SetActive(false);
        listUI.SetActive(false);
    }

    void ConvertToTrigger()
    {
        GetComponent<Collider>().isTrigger = true;
    }
}
