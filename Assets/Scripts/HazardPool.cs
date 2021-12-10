using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HazardPool : MonoBehaviour
{
    [SerializeField] private GameObject hazardPrefab;

    private Queue<GameObject> _hazardsQueue = new Queue<GameObject>();
    
    private float spawnRate;
    
    
    public static HazardPool instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //keeps game object holding the game manager from getting removed from scene.
        }
    }

    private void Start()
    {
        spawnRate = Random.Range(3f, 5f); //sets spawn rate for hazard, random range.
        StartSpawning();
    }

    private void StartSpawning()
    {
        InvokeRepeating(nameof(SpawnMeteor), spawnRate,spawnRate); //invokes new spawns depending on spawnrate.
    }

    private void OnEnable()
    {
        AddHazards(10);
    }

    public GameObject Get()
    {
        if (_hazardsQueue.Count == 0)
        {
            AddHazards(1);
        }

        return _hazardsQueue.Dequeue();

    }

    private void AddHazards(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject hazard = Instantiate(hazardPrefab);
            hazard.gameObject.SetActive(false);
            _hazardsQueue.Enqueue(hazard);
        }
    }

    public void ReturnToPool(GameObject hazard)
    {
        hazard.gameObject.SetActive(false);
        _hazardsQueue.Enqueue(hazard);
    }

    private void SpawnMeteor()
    {
        var hazard = instance.Get();
        hazard.SetActive(true);
        Debug.Log("spawning");

    }
    
}




