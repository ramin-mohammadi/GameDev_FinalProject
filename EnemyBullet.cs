using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] Main_Character player;
    [SerializeField] GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D other){
        GameObject new_particle = Instantiate(particle, transform.position, transform.rotation);
        Destroy(new_particle, 2);
        switch(other.gameObject.tag){
            case "Block":
                Destroy(this.gameObject);
                break;
            case "Player":
                Destroy(this.gameObject);
                //damage Player's health
                player.Damage();
                break;
        }
   
    }
}
