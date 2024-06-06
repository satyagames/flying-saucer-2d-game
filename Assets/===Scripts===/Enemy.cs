using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // ENCAPSULATION
    private float m_startDely = 1.5f;
    public float startDely
    {
        get { return m_startDely; } 
        set
        {
            if (value < 0.0f)
            {
                Debug.LogError("You can't set a negative Start Dely!");
            }
            else
            {
                m_startDely = value; 
            }
        } 
    }

    // ENCAPSULATION
    private float m_startInterval = 2f;
    public float startInterval
    {
        get { return m_startInterval; } 
        set
        {
            if (value < 0.0f)
            {
                Debug.LogError("You can't set a negative start Interval!");
            }
            else
            {
                m_startInterval = value; 
            }
        } 
    }

    [SerializeField] GameObject boomVFX;

    public AudioSource fireAudio;
    public AudioClip fireClip;
    public GameObject enemyProjectile;
    public Transform firingPosition;


 
    void Start()
    {
        InvokeRepeating("FirePlayer", startDely, startInterval);
    }

    // ENCAPSULATION
    protected virtual void FirePlayer()
    {
        
        Instantiate(enemyProjectile, firingPosition.transform.position, enemyProjectile.transform.rotation);
        fireAudio.PlayOneShot(fireClip, 1f);
    }
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(boomVFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
