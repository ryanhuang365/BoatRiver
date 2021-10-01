using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChunkSpawner : MonoBehaviour
{
    public GameObject chunkToSpawn;
    public GameObject[] levelOneChunks;
    public GameObject[] levelTwoChunks;
    public GameObject[] levelThreeChunks;
    public GameObject[] levelFourChunks;
    public GameObject[] levelFiveChunks;

    public Text scoreText;


    private GameObject[] currentChunkSet;
    public GameObject player;
    float spawnTimer = 0f;
    private float movedLength = 0;
    private float prevLoc = 0;
    public static int chunkIdx = 0;
    public static int prevScore = 0;
    private GameObject[] prevChunks = new GameObject[3];
    void Start()
    {
        chunkIdx = 0;
        spawnChunk(new Vector3(0, player.transform.position.y + 5, 0));
        spawnChunk(new Vector3(0, player.transform.position.y + 17, 0));
        currentChunkSet = levelOneChunks;

    }

    // Update is called once per frame
    void Update()
    {
        movedLength += player.transform.position.y - prevLoc;
        prevLoc = player.transform.position.y;
        if (movedLength >= 12) {
            chunkToSpawn = currentChunkSet[Random.Range(0, currentChunkSet.Length)];
            spawnChunk(new Vector3(0, Mathf.Floor(player.transform.position.y)+15, 0));
            scoreText.text = (chunkIdx-2).ToString();
            movedLength-= 12;
        }
    }
    void spawnChunk(Vector3 location) {
        if (chunkIdx > 2)
        {
            GameObject.Destroy(prevChunks[chunkIdx % 3]);
        }
        prevChunks[chunkIdx%3] = GameObject.Instantiate(chunkToSpawn, location, player.transform.rotation);
        
        chunkIdx++;
        updateChunkSet();
    }
    void updateChunkSet() {
        switch (chunkIdx)
        {
            case 5:
                currentChunkSet = levelTwoChunks;
                break;
            case 10:
                currentChunkSet = levelThreeChunks;
                break;
            case 20:
                currentChunkSet = levelFourChunks;
                break;
            case 30:
                currentChunkSet = levelFiveChunks;
                break;
            default:
                break;
        }
    }
}
