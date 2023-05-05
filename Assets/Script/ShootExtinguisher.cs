using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShootExtinguisher : MonoBehaviour
{
    [SerializeField] ParticleSystem extinguisherParticle;

    void Start()
    {
        XRGrabInteractable grabInteratable = GetComponent<XRGrabInteractable>();
        grabInteratable.activated.AddListener(Shoot);
        grabInteratable.deactivated.AddListener(StopShoot);
    }

    void Shoot(ActivateEventArgs args)
    {
        extinguisherParticle.Play();
    }

    void StopShoot(DeactivateEventArgs args) 
    { 
        extinguisherParticle.Stop();
    }
}
