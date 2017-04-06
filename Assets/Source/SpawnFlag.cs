using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlag : MonoBehaviour {

    public GameObject FlagPrefab;

    private GameManager gameManager;
    public Transform[] spawnPoints;
    private Vector3 lastSpawnPos;
    private bool Initialized = false;
	
    public void SpawnNextFlag()
    {
        if (Initialized==false)
        {
            spawnPoints = GetComponentsInChildren<Transform>();
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }
        GameObject newFlag = Instantiate(FlagPrefab, GetNextSpawnLocation(), Quaternion.identity);
        newFlag.GetComponent<FlagTrigger>().gameManager = gameManager;        
    }

    private Vector3 GetNextSpawnLocation()
    {
        int tmp = Random.Range(0, spawnPoints.Length );

        Debug.LogWarning("random num" + tmp);
        Vector3 candidateSpawnPos = spawnPoints[Random.Range(0, spawnPoints.Length)].position;

        if (candidateSpawnPos != lastSpawnPos)
        {
            lastSpawnPos = candidateSpawnPos;
            return candidateSpawnPos;
        }

        else return GetNextSpawnLocation();
    }
}
