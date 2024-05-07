using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Weapon : MonoBehaviour
{
    public float bulletSpeed = 20;
    [SerializeField] float delayBetweenBullets = 0.15f;
    private float timer = 0f;

    void Start(){
    }

    public void Fire(Vector3 targetPos){
        Quaternion rot = Quaternion.LookRotation(transform.forward, targetPos - transform.position);
        rot *= Quaternion.Euler(0,0,90f);

        GameObject newProjectile = ObjectPooler.singleton.SpawnFromPool("PlayerBullet", transform.position, rot);

        newProjectile.GetComponent<Rigidbody2D>().velocity = newProjectile.transform.right * bulletSpeed;

        GetComponent<AudioSource>().Play();
    }

    void Update(){
         if (Input.GetMouseButton(0)){ 

            timer += Time.deltaTime;
  
                if(timer >= delayBetweenBullets){
                    Fire(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    timer = 0f;
                    
                }
        }

    }
}
