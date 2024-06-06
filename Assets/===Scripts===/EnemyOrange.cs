using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOrange : Enemy
{
    // INHERITANCE, POLYMORPHISM:
    private void Start()
    {
        startDely -= 1;
        startInterval -= 1.5f;
        InvokeRepeating("FirePlayer", startDely, startInterval);
    }
}
