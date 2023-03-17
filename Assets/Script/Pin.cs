using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Pin : MonoBehaviour
{

    [SerializeField] InputActionProperty RightGrabActivateAction;
    [SerializeField] InputActionProperty LeftGrabActivateAction;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("LeftHand") && LeftGrabActivateAction.action.ReadValue<float>() >= 0.9f) || (other.gameObject.CompareTag("RightHand") && RightGrabActivateAction.action.ReadValue<float>() >= 0.9f))
        {
            Debug.Log("Safety off");
            GetComponent<ParentConstraint>().enabled = false;
        }
    }
}
