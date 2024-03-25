using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed = 20;
    private Vector3 mousePos;
    [SerializeField] float delayBetweenBullets = 0.15f;
    private float timer = 0f;

    void Start(){
        // mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public void Fire(Vector3 targetPos){
        GameObject newProjectile = Instantiate(bullet,transform.position,Quaternion.identity);
        newProjectile.transform.rotation = Quaternion.LookRotation(transform.forward,targetPos - transform.position);
        newProjectile.GetComponent<Rigidbody2D>().velocity = newProjectile.transform.up * bulletSpeed;
        Destroy(newProjectile,6);
    }

    void Update(){
        // mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Vector3 rotation = mousePos;
        // float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.Euler(0,0,rotZ);
         if (Input.GetMouseButton(0)){ 
            // Fire(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            timer += Time.deltaTime;
  
                // if(Time.time - timeLastShot >= delayBetweenBullets){
                if(timer >= delayBetweenBullets){
                    // canFire = true;
                    // timeLastShot = Time.time;      
                    Fire(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    // canFire = false;
                    timer = 0f;
                    
                }
        }

    }
}
