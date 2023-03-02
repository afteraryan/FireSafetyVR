using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TeleportAtRightDown : MonoBehaviour
{
    private Vector2 axisValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var leftHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, leftHandDevices);

        if(leftHandDevices.Count > 0)
        {
            InputDevice device = leftHandDevices[0];

            device.TryGetFeatureValue(CommonUsages.primary2DAxis, out axisValue);
            Debug.Log(axisValue);
        }
        
    }
}
