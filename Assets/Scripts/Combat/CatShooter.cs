using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatShooter : Shooter
{
    public override void Shoot(GameObject shellPrefab, float fireForce, float lifespan)
    {
        //spawn in bullet
        GameObject newShell = Instantiate(shellPrefab, firePoint.transform.position, firePoint.transform.rotation) as GameObject;
        //give bullet data
        Projectile bullet = newShell.GetComponent<Projectile>();
        Rigidbody rb = newShell.GetComponent<Rigidbody>();
        if (rb)
        {
            rb.AddForce(firePoint.transform.forward * fireForce);
        }
        Destroy(newShell, lifespan);

    }
}
