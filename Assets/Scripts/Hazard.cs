using System;
using UnityEngine;
using Random = UnityEngine.Random;
using Audio;


public class Hazard : MonoBehaviour
{
    public BoxCollider2D gridArea;
    
    private float speed;
    void Start()
    {
        RandomPosition();
        speed = Random.Range(100, 200); //wanted different speed for meteor after each "respawn" so used random.
    }


    public void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.left * speed * Time.deltaTime; //very simple movement using speed
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("GameOver");
            GameManager.instance.GameOver();
        }
    }
    
    private void RandomPosition()
    {
        Bounds bounds = gridArea.bounds;
        float x = Random.Range(bounds.max.x, bounds.max.x+10);
        float y = bounds.max.y;
        transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
        Debug.Log("randompos");
    }
}
