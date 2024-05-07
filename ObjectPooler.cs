using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool 
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static ObjectPooler singleton;

    void Awake(){
         if(singleton == null){
            singleton = this;
        }
        else{
            Destroy(this.gameObject);
        }
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    // public Queue<Rigidbody2D> rb_PlayerBullet;
    // public Queue<Rigidbody2D> rb_EnemyBullet;



    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools){
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for(int i=0; i < pool.size; i++){
                GameObject obj = Instantiate(pool.prefab);
                
                // cache rigid body components
                // if(pool.tag == "PlayerBullet"){
                //     rb_PlayerBullet.Enqueue(obj.GetComponent<Rigidbody2D>());
                // }
                // else if(pool.tag == "EnemyBullet"){
                //     rb_EnemyBullet.Enqueue(obj.GetComponent<Rigidbody2D>());
                // }
                obj.SetActive(false);
                objectPool.Enqueue(obj);
                
            } 
            poolDictionary.Add(pool.tag, objectPool);

            
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if(!poolDictionary.ContainsKey(tag)){
            // Debug.LogWarning("Pool with tag: " + tag + " doesnt exist.");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;    
        objectToSpawn.transform.rotation = rotation;


        // NOTE: if do enque in ReturnToPool() there is possibility of trying to dequeue from an empty queue 
        //(solution is either make size bigger or enqueue by default as is now)

        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;   
    }


    public void ReturnToPool(string tag, GameObject objectReturn){
        if(!poolDictionary.ContainsKey(tag)){
            // Debug.LogWarning("Pool with tag: " + tag + " doesnt exist.");
            return;
        }

        // poolDictionary[tag].Enqueue(objectReturn);     //--> DO NOT PUT Enqueue() here, have it in SpawnFromPool()   
        objectReturn.SetActive(false);
        // Debug.Log("Added back to queue");
    }

    // public Rigidbody2D getPlayerRB(){
    //     Rigidbody2D rb = rb_PlayerBullet.Dequeue();
    //     return rb;
    // }
    // public void returnPlayerRB(Rigidbody2D rb){
    //     rb_PlayerBullet.Enqueue(rb);
    // }

    // public Rigidbody2D getEnemyRB(){
    //     Rigidbody2D rb = rb_EnemyBullet.Dequeue();
    //     return rb;
    // }
    // public void returnEnemyRB(Rigidbody2D rb){
    //     rb_EnemyBullet.Enqueue(rb);
    // }

}

