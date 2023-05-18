using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShootExtinguisher : MonoBehaviour
{
    [SerializeField] ParticleSystem extinguisherParticle;
    [SerializeField] float extinguisherAmount;
    float extinguisherRemainging;
    bool isShooting;

    void Start()
    {
        extinguisherRemainging = extinguisherAmount;
        XRGrabInteractable grabInteratable = GetComponent<XRGrabInteractable>();
        grabInteratable.activated.AddListener(Shoot);
        grabInteratable.deactivated.AddListener(StopShoot);
    }

    private void Update()
    {
        if (isShooting)
        {
            if (extinguisherRemainging > 0)
            {
                extinguisherRemainging -= Time.deltaTime;
                extinguisherParticle.Play();
            }
            else
            {
                extinguisherParticle.Stop();
            }
        }
        else
        {
            extinguisherParticle.Stop();
        }
    }

    void Shoot(ActivateEventArgs args)
    {
        isShooting = true;
    }

    void StopShoot(DeactivateEventArgs args) 
    {
        isShooting = false;
    }
}
