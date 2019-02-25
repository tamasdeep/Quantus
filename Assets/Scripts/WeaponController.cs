﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // Start is called before the first frame update
    bool weaponToggle = false;
    GameObject astergun;
    GameObject lasergun;
    private float timeCount = 0.0f;
    void Start()
    {
        astergun = gameObject.transform.GetChild(0).gameObject;
        lasergun = gameObject.transform.GetChild(1).gameObject;
        lasergun.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        //var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            lasergun.SetActive(!weaponToggle);
            //Transform to = lasergun.transform;
            //to.transform.Rotate(0.0f, 1.0f, 0.0f);
            //lasergun.transform.rotation = Quaternion.Slerp(lasergun.transform.rotation, to.rotation, timeCount);
            //timeCount = timeCount + Time.deltaTime;
            astergun.SetActive(weaponToggle);
            weaponToggle = !weaponToggle;
        }
    }
}