using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public GameObject particle;

    // Start is called before the first frame update
    void OnCollisionEnter(Collision other) {
        Debug.Log("bullet collision");

        ContactPoint contact = other.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        Instantiate(particle, pos, rot);
        
        gameObject.SetActive(false);
    }
}
