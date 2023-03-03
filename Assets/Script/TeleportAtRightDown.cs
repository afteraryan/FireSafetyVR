using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class TeleportAtRightDown : MonoBehaviour
{
    [SerializeField] InputActionProperty StickDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(StickDown.action.ReadValue<Vector2>());
    }
}
