using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerController : MonoBehaviour
{
    // ENCAPSULATION
    private float horizontalInput;
    private float verticallInput;

    [SerializeField] float xRange = 19f;
    [SerializeField] float xRangeNegative = -2.5f;
    [SerializeField] float yRange = 9f;
    [SerializeField] float yRangeNegative = -3f;

    [SerializeField] float speed = 20.0f;
    [SerializeField] AudioSource fireAudio;
    [SerializeField] AudioClip fireClip;

    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform firingPosition;
    [SerializeField] GameObject playerModel;
    [SerializeField] GameObject boomVFX;
    [SerializeField] GameObject gameOverText;


    public bool gameOver = false;

    private void Update()
    {
        // ABSTRACTION
        PlayerControls();
    }

    private void PlayerControls()
    {
        if (gameOver == false)
        {         // Check for left and right bounds
            if (transform.position.x < xRangeNegative)
            {
                transform.position = new Vector3(xRangeNegative, transform.position.y, transform.position.z);
            }

            if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }

            // Check for up and down bounds
            if (transform.position.y < yRangeNegative)
            {
                transform.position = new Vector3(transform.position.x, yRangeNegative, transform.position.z);
            }

            if (transform.position.y > yRange)
            {
                transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
            }

            // Player movement left to right
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.forward * Time.deltaTime * speed * horizontalInput);


            // Player movement up and down
            verticallInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.up * Time.deltaTime * speed * verticallInput);


            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(projectilePrefab, firingPosition.position, projectilePrefab.transform.rotation);
                fireAudio.PlayOneShot(fireClip, 0.7f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        gameOver = true;
        playerModel.SetActive(false);
        boomVFX.SetActive(true);
        gameOverText.SetActive(true);
    }
}
