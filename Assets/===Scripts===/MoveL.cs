using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveL: MonoBehaviour
{
    public float speed = 30;

    private PlayerController playerController;
    private float leftBound = -15;
    private float rightBound = 30;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // ABSTRACTION
        MoveObject();
    }

    void MoveObject()
    {
        if (playerController.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (gameObject.tag != "Background" && transform.position.x < leftBound || gameObject.tag != "Background" && transform.position.x > rightBound || gameObject.tag != "Background" && playerController.gameOver == true)
        {
            Destroy(gameObject);
        }
    }
}
