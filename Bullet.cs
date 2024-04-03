using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject particle;
    void OnTriggerEnter2D(Collider2D other){
        GameObject new_particle = Instantiate(particle, transform.position, transform.rotation);
        Destroy(new_particle, 2);

        switch(other.gameObject.tag){
            case "Block":
                Destroy(this.gameObject);
                break;
            case "Enemy":
                Destroy(this.gameObject);
                //damage Enemy's health
                other.GetComponent<Enemy>().Damage();
                break;
         }
   
    }
}
