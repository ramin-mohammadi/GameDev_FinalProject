using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
// using UnityEditor.Search;
public class Enemy : MonoBehaviour
{
    int health = 2;
    // [SerializeField] static EnemiesDeadCounter enemiesDeadCounter;
    [SerializeField] TextMeshProUGUI text_enemies_remaining;
    // [SerializeField] GameObject particle;
    // [SerializeField] static EnemySpawner enemySpawner;
    int incEnemyHealth = 0;

    public AudioSource audio_sfx;

    // Start is called before the first frame update
    void Start()
    {
        // AudioSource[] audio_list = GetComponents<AudioSource>();
        // audio_sfx = audio_list[1];
        // myResults = enemiesDeadCounter.GetComponent<ComponentType>()
        //increase enemy health
        // if(EnemySpawner.singleton.GetWaveCount() >= 3 && EnemySpawner.singleton.GetWaveCount() % 2 != 0){ // after wave 2, every odd wave will increae the enemy health by 1
        //     incEnemyHealth += EnemySpawner.singleton.GetWaveCount() / 2;
        //     IncreaseEnemyHealth(incEnemyHealth);
        // }
        if(EnemySpawner.singleton.GetWaveCount() >= 3 && EnemySpawner.singleton.GetWaveCount() % 2 != 0){ // after wave 2, every odd wave will increae the enemy health by 1
            incEnemyHealth += EnemySpawner.singleton.GetWaveCount() / 2;
            IncreaseEnemyHealth(incEnemyHealth);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Damage()
    {
        health -= 1;
        if(health <= 0){
            // Destroy(this.gameObject);
            // GameObject new_particle = Instantiate(particle, transform.position, transform.rotation);
            // Destroy(new_particle, 2);            
            audio_sfx.Play();

            ObjectPooler.singleton.ReturnToPool("Enemy", this.gameObject);
            ObjectPooler.singleton.SpawnFromPool("Particle_EnemyDie", transform.position, transform.rotation);

            EnemiesDeadCounter.singleton.enemiesDead += 1;
            text_enemies_remaining.text = "Enemies Remaining: " + (EnemiesDeadCounter.singleton.total_enemies - EnemiesDeadCounter.singleton.enemiesDead).ToString();
        }
    }

    public void IncreaseEnemyHealth(int incEnemyHealth){
        health += incEnemyHealth;
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
