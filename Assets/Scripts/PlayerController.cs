﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f;
    public float jumpForce;
    public float speed;

    private Vector3 _moveVector;
    private float _fallVelocity = 0;

    private CharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Movement
        _moveVector = Vector3.zero;

        if(Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.forward;
        }
         if(Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.forward;
        }
         if(Input.GetKey(KeyCode.S))
        {
            _moveVector += transform.right;
        }
         if(Input.GetKey(KeyCode.W))
        {
            _moveVector -= transform.right;
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Movement
        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);

        //Fall and jump
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        //Spop fall if on the grouhd
        if(_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
}
