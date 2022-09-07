using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CaenBolas : MonoBehaviour
{
    private MyVector position;
    private MyVector gargantuaPosition;
    [SerializeField] private MyVector acceleration;
    [SerializeField] private MyVector velocity;

    [Header("world")]
    [SerializeField] private Camera camera;
    [SerializeField] private Transform gargantua;


    void Start()
    {
        position = new MyVector(transform.position.x, transform.position.y);
    }

    void FixedUpdate()
    {
        Move();
        position = new MyVector(transform.position.x, transform.position.y);
        gargantuaPosition = new MyVector(gargantua.position.x, gargantua.position.y);
        acceleration = gargantuaPosition - position;
    }
    void Update()
    {
        velocity = velocity + acceleration * Time.fixedDeltaTime;
        velocity.Draw(position, Color.blue);
        position.Draw(Color.green);
        acceleration.Draw(position, Color.red);
    }
    void Move()
    {
        position = position + velocity * Time.fixedDeltaTime;
        transform.position = new Vector3(position.x, position.y);
    }
}