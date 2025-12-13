using UnityEngine;

public class StarSpawn : MonoBehaviour
{
    public GameObject star, player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("SpawnStar", 1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    float DetermineStarXPos()
    { 
        return Random.Range(player.transform.position.x-3f, player.transform.position.x+3f);
    }
    void SpawnStar()
    {
        Vector3 spawnPoint = new Vector3(DetermineStarXPos(), 3.5f);
        Instantiate(star, spawnPoint, Quaternion.identity);
    }
}
