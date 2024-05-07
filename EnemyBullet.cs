using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Pathfinding.Util;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    private float force = 8f;
    Vector3 direction;

    bool isSet = false;


    // Start is called before the first frame update
    void Start()
    {
        // rb = ObjectPooler.singleton.getEnemyRB();
        // direction = Main_Character.singleton.transform.position - transform.position;

        // rb.velocity = new Vector2(direction.x, direction.y).normalized * force;


        // rb = GetComponent<Rigidbody2D>();  
        // direction = Main_Character.singleton.transform.position - transform.position;
        // rb.velocity = new Vector2(direction.x, direction.y).normalized * force;


    }

    void OnEnable(){
        // rb = ObjectPooler.singleton.getEnemyRB();
        // direction = Main_Character.singleton.transform.position - transform.position;
        // rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

    }

    // Update is called once per frame
    void Update()
    {
        // if(!isSet){
        //             rb = ObjectPooler.singleton.getEnemyRB();
        // direction = Main_Character.singleton.transform.position - transform.position;

        // rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        //     isSet=true;
        // }
    }

     void OnTriggerEnter2D(Collider2D other){
        ObjectPooler.singleton.SpawnFromPool("Particle_EnemyBullet", transform.position, transform.rotation);

        switch(other.gameObject.tag){
            case "Block":
                ObjectPooler.singleton.ReturnToPool("EnemyBullet", this.gameObject);
                // ObjectPooler.singleton.returnEnemyRB(rb);



                // Destroy(this.gameObject);
                break;
            case "Player":
                ObjectPooler.singleton.ReturnToPool("EnemyBullet", this.gameObject);
                // ObjectPooler.singleton.returnEnemyRB(rb);


                // Destroy(this.gameObject);
                break;
        }

    }
}
