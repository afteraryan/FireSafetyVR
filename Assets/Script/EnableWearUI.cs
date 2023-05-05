using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWearUI : MonoBehaviour
{
    [SerializeField] GameObject mannequineUI;
    [SerializeField] GameObject listUI;

    private void OnTriggerEnter(Collider other)
    {
        mannequineUI.SetActive(true);
        listUI.SetActive(true);
    }
}
