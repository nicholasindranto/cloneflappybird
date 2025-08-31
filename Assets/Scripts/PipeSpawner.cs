using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe; // reference ke prefab pipe nya
    public float spawnInterval; // setiap berapa detik sekali spawn nya
    public float yPosMax; // posisi paling atas
    public float yPosMin; // posisi paling bawah

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPipeCoroutine());
    }

    IEnumerator SpawnPipeCoroutine()
    {
        // setiap berapa detik sekali
        yield return new WaitForSeconds(spawnInterval);
        // dirandom posisi spawn nya
        Instantiate(pipe, transform.position + new Vector3(0, Random.Range(yPosMin, yPosMax), 0), Quaternion.identity);
        // biar spawnnya infinite (recursive)
        StartCoroutine(SpawnPipeCoroutine());
    }
}
