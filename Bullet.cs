using System.Collections;
using System.Collections.Generic;
using Pathfinding.Util;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // [SerializeField] GameObject particle;
    public Rigidbody2D rb;
    private float bulletSpeed = 20f;

    void Start(){
        // rb = ObjectPooler.singleton.getPlayerRB();

        // rb.velocity = transform.right * bulletSpeed;
        
        // rb = GetComponent<Rigidbody2D>();

        // rb.velocity = transform.right * bulletSpeed;

    }

    void OnEnable(){
        // rb = ObjectPooler.singleton.getPlayerRB();

        // rb.velocity = transform.right * bulletSpeed;

    }
    

    void Update(){

    }

    void OnTriggerEnter2D(Collider2D other){
        // GameObject new_particle = Instantiate(particle, transform.position, transform.rotation);
        // Destroy(new_particle, 2);
        ObjectPooler.singleton.SpawnFromPool("Particle_PlayerBullet", transform.position, transform.rotation);


        switch(other.gameObject.tag){
            case "Block":
                ObjectPooler.singleton.ReturnToPool("PlayerBullet", this.gameObject);
                // ObjectPooler.singleton.returnPlayerRB(rb);
                
                // Destroy(this.gameObject);
                break;
            case "Enemy":
                ObjectPooler.singleton.ReturnToPool("PlayerBullet", this.gameObject);
                // ObjectPooler.singleton.returnPlayerRB(rb);
                // Destroy(this.gameObject);

                //damage Enemy's health
                other.GetComponent<Enemy>().Damage();
                break;
         }
   
    }
}
