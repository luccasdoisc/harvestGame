﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float runSpeed = 8.0f;

    private Rigidbody2D rig;

    private float initialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private Vector2 _direction;

    public Vector2 direction
    {
        get {return _direction; }
        set { _direction = value;}
    }

    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRunning = value; }
    }

    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }   
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    private void Update()
    {
        OnInput();

        OnRun();

        OnRolling();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    #region Movement

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            _isRunning = false;
        }
    }

    void OnRolling()
    {
        if(Input.GetMouseButtonDown(1))
        {
            _isRolling = true;
        }

        if(Input.GetMouseButtonUp(1))
        {
            _isRolling = false;
        }
    }
    #endregion
}
