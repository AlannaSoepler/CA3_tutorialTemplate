
using UnityEngine;

public class ActivateProjectile : MonoBehaviour
{
    public GameObject projectile;
    public float lifeTime = 2.0f;
    private GameObject clone;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("projectile");
            clone = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);

            //destroy bullet after 2sec
            Destroy(clone, lifeTime);
        }
    }
}

