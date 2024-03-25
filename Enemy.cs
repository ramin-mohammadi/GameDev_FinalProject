using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 5;
    [SerializeField] EnemiesDeadCounter enemiesDeadCounter;


    // Start is called before the first frame update
    void Start()
    {
        // myResults = enemiesDeadCounter.GetComponent<ComponentType>()
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Damage()
    {
        health -= 1;
        if(health <= 0){
            Destroy(this.gameObject);
            enemiesDeadCounter.enemiesDead += 1;
        }
    }

    // void OnTriggerEnter2D(Collider2D other){
    //     switch(other.gameObject.tag){
    //         case "Player":
    //             //damage Player's health
    //             other.GetComponent<Main_Character>().Damage();
    //             break;
    //     }
   
    // }
}
