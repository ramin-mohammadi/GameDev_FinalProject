using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private float[,] spawnLocations = { {-56,1f} , {38,1}, {-56,9.5f}, {-55.25f, 20.5f}, {36, 9} }; // (x,y) spawn locations
    private int count = 0; //cycles through spawn locations

    [SerializeField] int enemiesPerWave = 20;
    private int enemiesSpawned = 0;
    private int increaeEnemyCount = 5;
    private int waveCount = 1;
    [SerializeField] float waveCooldown = 10f;
    private float timePassed = 0f;
    [SerializeField] EnemiesDeadCounter enemiesDeadCounter;
    Coroutine coroutineSpawner;

    // Start is called before the first frame update
    void Start()
    {
        coroutineSpawner = StartCoroutine(SpawnEnemiesRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        //enemies done spawning for that wave
        if(enemiesSpawned >= enemiesPerWave){
            StopCoroutine(coroutineSpawner);
        }

        // no enemies left  
        if(enemiesDeadCounter.enemiesDead  >= enemiesSpawned){   
            timePassed += Time.deltaTime; 
            //intermission time between waves
            if(timePassed >= waveCooldown){      
                timePassed = 0f;     
                enemiesPerWave += increaeEnemyCount;
                if(increaeEnemyCount <= 30) // max of 50 enemies per wave
                    increaeEnemyCount += 5;
                enemiesSpawned = 0;
                waveCount += 1;
                enemiesDeadCounter.enemiesDead = 0;                
                coroutineSpawner = StartCoroutine(SpawnEnemiesRoutine());
            }
        }

    }


    void SpawnEnemy(){
        GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(spawnLocations[count, 0], spawnLocations[count, 1], 0) ,Quaternion.identity);
        count++;
        if(count == 5)
            count = 0;
        // Destroy(newEnemy,10);       
    }

    IEnumerator SpawnEnemiesRoutine(){
        while(enemiesSpawned < enemiesPerWave){ 
            SpawnEnemy();
            enemiesSpawned++;                  
            yield return new WaitForSeconds(0.2f); // THIS MUST BE THE LAST LINE IN THE LOOP so enemiesSpawned can be incremented
        }
    }
    

}
