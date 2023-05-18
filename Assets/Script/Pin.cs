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
    [SerializeField] Material mat;
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LeftHand") || other.gameObject.CompareTag("RightHand"))
        {
            GetComponent<Renderer>().material.color = new Color(0, 1, 0);
            Debug.Log("In first if");
        }

        if ((other.gameObject.CompareTag("LeftHand") && LeftGrabActivateAction.action.ReadValue<float>() >= 0.9f) || (other.gameObject.CompareTag("RightHand") && RightGrabActivateAction.action.ReadValue<float>() >= 0.9f))
        {
            Debug.Log("Safety off");
            GetComponent<ParentConstraint>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("LeftHand") || other.gameObject.CompareTag("RightHand"))
            GetComponent<Renderer>().material= mat;
    }
}
