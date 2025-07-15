using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;

    public Transform ShotSpawn;
    
    
    void Update()
    {
       if (Input.GetKeyDown (KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = ShotSpawn.position;
    }
}
