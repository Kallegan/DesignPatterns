using System;
using UnityEngine;
using Random = UnityEngine.Random;
using Audio;


public class Hazard : MonoBehaviour
{
    private float speed;
    void Start()
    {
        speed = Random.Range(50, 100); //wanted different speed for meteor after each "respawn" so used random.
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

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "GridArea")
        {
            HazardPool.instance.ReturnToPool(gameObject);
        }
    }

}
