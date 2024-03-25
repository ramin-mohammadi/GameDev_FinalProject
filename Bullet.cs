using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // [SerializeField] Main_Character main_Character;
    void OnTriggerEnter2D(Collider2D other){
        switch(other.gameObject.tag){
            case "Block":
                Destroy(this.gameObject);
                break;
            case "Enemy":
                Destroy(this.gameObject);
                //damage Enemy's health
                other.GetComponent<Enemy>().Damage();
                break;
            // case "Player":
            //     Destroy(this.gameObject);
            //     //damage Player's health
            //     main_Character.Damage();
            //     break;
        }
   
    }
}
