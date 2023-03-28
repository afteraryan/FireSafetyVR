using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateRay : MonoBehaviour
{
    [SerializeField] GameObject RightHandRay;

    [SerializeField] InputActionProperty RightActivateAction;

    [SerializeField] InputActionProperty GrabActivateAction;

    // Update is called once per frame
    void Update()
    {
        RightHandRay.SetActive(GrabActivateAction.action.ReadValue<float>() == 0 && RightActivateAction.action.ReadValue<Vector2>().y <= -0.5f);
    }
}
