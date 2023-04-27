using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguisherCollision : MonoBehaviour
{

    [SerializeField] List<GameObject> gameObjects = new List<GameObject>();

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(1);

        foreach(GameObject obj in gameObjects)
        {
            if (obj.transform.localScale != Vector3.zero)
                obj.transform.localScale -= Time.deltaTime * Vector3.one;

            if (obj.transform.localScale.x <= 0)
                obj.transform.localScale = Vector3.zero;
        }
    }
}
