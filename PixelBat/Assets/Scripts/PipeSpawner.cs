using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public static PipeSpawner instance;

    [SerializeField] private float maxTime = 3f;
    [SerializeField] private float heightRange = 1.2f;
    [SerializeField] private float maxHeightRange = 2.2f;
    [SerializeField] private GameObject[] pipe;

    private int currentPipe = 0;
    private int maxPipes = 3;
    private float timer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        SpawnPipe();
    }

    private void Update()
    {
        if (timer > maxTime)
        {
            SpawnPipe();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        GameObject _pipe = Instantiate(pipe[currentPipe], spawnPos, Quaternion.identity);
        Destroy(_pipe, 10f);
    }

    public void IncreaseDifficulty()
    {
        if (heightRange < maxHeightRange)
        {
            heightRange += 0.25f;
        }
    }

    public void ChangePipeColor()
    {
        if (currentPipe < maxPipes)
        {
            currentPipe++;
        }
    } 
}
