using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Enemy : MonoBehaviour
{
    public float SpawnTime;
    public GameObject[] Bullet;
    public bool canSpawn = true;

    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(SpawnTime);

        while (canSpawn)
        {
            yield return wait;

            int rand = Random.Range(0, Bullet.Length);
            GameObject enemyToSpawn = Bullet[rand];

            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        }
    }
}
