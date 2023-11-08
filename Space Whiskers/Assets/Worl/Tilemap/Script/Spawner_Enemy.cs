using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Enemy : MonoBehaviour
{
    public float SpawnRate = 1f;
    public GameObject[] enemyMelee;
    public bool canSpawn = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    
    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(SpawnRate);

        while (canSpawn) 
        {
            yield return wait;

            int rand = Random.Range(0, enemyMelee.Length);  
            GameObject enemyToSpawn = enemyMelee[rand];

            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        }
    }
}
