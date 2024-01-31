using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    public GameManager gm;
    public Transform center;
    public Transform simon;
    public Transform player;

    public Vector3 targetPosition;
    public Vector3 smoothPosition;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        center = GameObject.Find("CenterTarget").GetComponent<Transform>();
        simon = GameObject.Find("SimonTarget").GetComponent<Transform>();
        player = GameObject.Find("PlayerTarget").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.isGameOver)
        {
            transform.position = center.position;
            smoothPosition = Vector3.Lerp(transform.position, targetPosition, 0.1f);
            transform.position = smoothPosition;
        }
        else if(gm.simonsTurn && !gm.isGameOver)
        {
            transform.position = simon.position;
            smoothPosition = Vector3.Lerp(transform.position, targetPosition, 0.1f);
            transform.position = smoothPosition;
        }
        else if(!gm.simonsTurn && !gm.isGameOver)
        {
            transform.position = player.position;
            smoothPosition = Vector3.Lerp(transform.position, targetPosition, 0.1f);
            transform.position = smoothPosition;
        }
        else 
        {
            transform.position = center.position;
            smoothPosition = Vector3.Lerp(transform.position, targetPosition, 0.1f);
            transform.position = smoothPosition;
        }
    }
}
