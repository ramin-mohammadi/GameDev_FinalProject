using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    // [SerializeField] private GameObject enemyPrefab;
    private float[,] spawnLocations = { {-56,1f} , {38,1}, {-56,9.5f}, {-55.25f, 20.5f}, {36, 9} }; // (x,y) spawn locations
    private int count = 0; //cycles through spawn locations

    [SerializeField] int enemiesPerWave = 20;
    private int enemiesSpawned = 0;
    private int increaeEnemyCount = 5;
    private int waveCount = 1;
    private int maxEnemies = 70;
    [SerializeField] float waveCooldown = 10f;
    private float timePassed = 0f;
    // [SerializeField] EnemiesDeadCounter enemiesDeadCounter;
    [SerializeField] TextMeshProUGUI text_wave_counter;
    [SerializeField] TextMeshProUGUI text_enemies_remaining;
    bool firstWave=true;

    public static EnemySpawner singleton; 

    Coroutine coroutineSpawner;

    void Awake(){
        if(singleton == null){
            singleton = this;
        }
        else{
            Destroy(this.gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {        
        EnemiesDeadCounter.singleton.total_enemies = enemiesPerWave;
        text_enemies_remaining.text = "Enemies Remaining: " + EnemiesDeadCounter.singleton.total_enemies.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(firstWave){
            coroutineSpawner = StartCoroutine(SpawnEnemiesRoutine());    
            firstWave=false;
        }

        //enemies done spawning for that wave
        if(enemiesSpawned >= enemiesPerWave){
            StopCoroutine(coroutineSpawner);
        }

        // no enemies left  
        if(EnemiesDeadCounter.singleton.enemiesDead  >= enemiesSpawned){   
            timePassed += Time.deltaTime; 
            //intermission time between waves
            if(timePassed >= waveCooldown){      
                timePassed = 0f;     
                if(enemiesPerWave <= maxEnemies) // max of 50 enemies per wave                
                    enemiesPerWave += increaeEnemyCount;
                enemiesSpawned = 0;
                waveCount += 1;
                text_wave_counter.text = "Wave: " + waveCount.ToString();
                EnemiesDeadCounter.singleton.enemiesDead = 0;          
                EnemiesDeadCounter.singleton.total_enemies = enemiesPerWave;
                text_enemies_remaining.text = "Enemies Remaining: " + EnemiesDeadCounter.singleton.total_enemies.ToString();
                coroutineSpawner = StartCoroutine(SpawnEnemiesRoutine());
            }
        }

    }


    void SpawnEnemy(){
        // GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(spawnLocations[count, 0], spawnLocations[count, 1], 0) ,Quaternion.identity);
        ObjectPooler.singleton.SpawnFromPool("Enemy", new Vector3(spawnLocations[count, 0], spawnLocations[count, 1], 0) ,Quaternion.identity);

        count++;
        if(count == 5) // there are 5 different spawn locations, this resets the counter which iterates through the spawn points
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
    
    public int GetWaveCount(){
        return waveCount;
    }
}
