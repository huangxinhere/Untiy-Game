using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawn : MonoBehaviour
{
    //public GameObject fruitPrefab;
    public Transform[] spawnPoints;
    public GameObject[] wordsPrefabs;

    public float minDelay = .1f;
    public float maxDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    IEnumerator SpawnFruits(){
        while(true){
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            int wordIndex = Random.Range(0, wordsPrefabs.Length);
            GameObject curWord = wordsPrefabs[wordIndex];//到时候更换为字

            GameObject spawnedFruit = Instantiate(curWord, spawnPoint.position, spawnPoint.rotation);
            Destroy(spawnedFruit, 5f);
        }
    }
}
