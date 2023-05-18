using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClampPosition : MonoBehaviour
{
    [Header("Minimum Movement")]
    public float maxx=0.85f,maxy=1.0f,minz=1.0f;
    [SerializeField] XRDirectInteractor interactor1;
    [SerializeField] XRDirectInteractor interactor2;
    Transform ogTranform;
    // Start is called before the first frame update

    private void Awake()
    {
        ogTranform = transform;
    }

    private void OnEnable()
    {
        interactor1.selectExited.AddListener(resetTransform);
        interactor2.selectExited.AddListener(resetTransform);
    }

    private void OnDisable()
    {
        interactor1.selectExited.RemoveListener(resetTransform);
        interactor2.selectExited.RemoveListener(resetTransform);
    }

    private void resetTransform(SelectExitEventArgs arg0)
    {
        transform.position = ogTranform.position;
    }


    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, 0.23f, maxx), Mathf.Clamp(transform.localPosition.y, 0, maxy),transform.localPosition.z);
    }


}
