using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusPips : MonoBehaviour
{
   public int value;
    int cachedValue;
    public GameObject prefab;
    public List<GameObject> pips;
    int counter=0;


    void Update(){
        // FillBar();
    }

    // void FillBar(){
    //     if(cachedValue != value){
    //         foreach (GameObject g in pips){
    //             Destroy(g);
    //         }
    //         pips.Clear();
    //         for(int i = 0; i<value; i++){
    //             pips.Add(Instantiate(prefab,transform));
    //         }
    //         cachedValue = value;
    //     }
    // }
    public void RemoveHeart(){
        if(counter != value){
            Destroy(pips[counter]);
            counter++;
        }
    }

}
