﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
    public Transform target;
    public float speed;

    private Rigidbody2D playerObject;
    private GameObject[] nonTraversables;
    private GameObject mapBoundary;

    private Boolean waiting;
    private float timestamp;

    // Use this for initialization
    void Start() {
        playerObject = GetComponent<Rigidbody2D>();
        nonTraversables = GameObject.FindGameObjectsWithTag("nontraversable");
//        mapBoundary = GameObject.FindGameObjectWithTag("mapboundary");

//        foreach (GameObject nonTraversable in nonTraversables)
//        {
//            Transform pos = nonTraversable.GetComponent<Transform>();
//            Boundary boundary = new Boundary(pos);
//            Debug.Log(boundary.left);
//
//        }
    }

    void Update() {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if (timestamp > 4) {
            speed = 5;
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "bullet") {
            timestamp = Time.time;
            speed = 0;
        }
    }

    public class Boundary{
        public float left { get; set; }
        public float right { get; set; }
        public float top { get; set; }
        public float bottom { get; set; }

        public Boundary(Transform transform) {
            left = transform.position.x - (transform.lossyScale.x / 2);
            right = transform.position.x + (transform.lossyScale.x / 2);
            top = transform.position.y + (transform.lossyScale.y / 2);
            bottom = transform.position.y - (transform.lossyScale.y / 2);
        }


        public override string ToString() {
            return "left: " + left + ", right: " + right;
        }
    }
}