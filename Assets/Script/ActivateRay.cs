using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateRay : MonoBehaviour
{
    [SerializeField] GameObject RightHandRay;

    [SerializeField] InputActionProperty RightActivateAction;

    // Update is called once per frame
    void Update()
    {
        RightHandRay.SetActive(RightActivateAction.action.ReadValue<float>() > 0.1f);
    }
}
