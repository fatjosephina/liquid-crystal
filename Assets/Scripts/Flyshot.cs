using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyshot : Bullet
{
    private void Update()
    {
        transform.Translate(transform.forward * bulletSpeed * Time.deltaTime);
    }
}
