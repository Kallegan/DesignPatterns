using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HazardPool : MonoBehaviour
{
    [SerializeField] private GameObject hazardPrefab;
    
    public BoxCollider2D gridArea;

    private Queue<GameObject> _hazardsQueue = new Queue<GameObject>();

    public float spawnRate = 4f;
    public static HazardPool instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartSpawning();
    }

    private void StartSpawning()
    {
        RandomPosition();
        InvokeRepeating(nameof(SpawnMeteor), spawnRate,spawnRate); //invokes new spawns depending on spawnrate.
    }

    private void OnEnable()
    {
        AddHazards(3); //preloads 3 hazards before anything spawns.
    }

    public GameObject Get()
    {
        if (_hazardsQueue.Count == 0)
        {
            AddHazards(3);
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
        hazard.transform.position = transform.position;
        hazard.SetActive(true);
        RandomPosition(); //after each hazard hazard activation, the spawner will relocate with a new x position
        // so each spawn will get a different spawn location.
    }

    private void RandomPosition() 
    {
        Bounds bounds = gridArea.bounds; //getting the bounds for  the grid area.
        float x = Random.Range(bounds.min.x, bounds.max.x); //randomizing the position on the x-axis for the spawner.
        float y = bounds.max.y; //position of the outer y-axis.
        transform.position = new Vector3(x, y, 0.0f); //setting new pos.
    }

}




