using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 Position;
    private Vector3 Direction;
    private float speed = 1f;
    public float MoveTimer;
    public float MoveTimerMax = 1f; 


    private bool allowQ = true;
    private bool allowD = true;
    private bool allowA = true;
    private bool allowE = true;

    private float horizontalInput, verticalInput;




    private void Awake()
    {
        startPosition = new Vector3(0, 0, 0);
        Position = startPosition;

        Direction = new Vector3(1, 1, 0); 

    }

    private void Update() 
    {
        PlayerDirection();
        Movement();

    }

    private void Movement()
    {
        MoveTimer += Time.deltaTime;
        if (MoveTimer >= MoveTimerMax)
        {
            Position += Direction;
            MoveTimer -= MoveTimerMax;
        }

        transform.position = Vector3.MoveTowards(transform.position, Position, Time.deltaTime);
    }

    

    private void PlayerDirection()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);

        transform.position = transform.position + moveDirection * speed * Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.Q) && allowQ == true)
        {

            Direction = new Vector3(-1, 1, 0);
            allowA = true;
            allowD = false;
            allowE = true;
            
        }

        if (Input.GetKeyDown(KeyCode.A) && allowA == true)
        {
            Direction = new Vector3(-1, -1, 0);
            allowD = true;
            allowE = false;
            allowQ = true;
        }

        if (Input.GetKeyDown(KeyCode.D) && allowD == true)
        {
            Direction = new Vector3(1, -1, 0);
            allowQ = false;
            allowA = true;
            allowE = true;

        }

        if (Input.GetKeyDown(KeyCode.E) && allowE == true)
        {
            Direction = new Vector3(1, 1, 0);
            allowQ = true;
            allowD = true;
            allowA = false;
        }





    }

}
