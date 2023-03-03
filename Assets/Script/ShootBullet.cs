using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShootBullet : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabInteratable = GetComponent<XRGrabInteractable>();
        grabInteratable.activated.AddListener(Shoot);
    }

    void Shoot(ActivateEventArgs args)
    {
        GameObject spawnedBullet = Instantiate(bullet);
        bullet.transform.position = spawnPoint.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * speed;
        Destroy(spawnedBullet, 5);
    }
}
