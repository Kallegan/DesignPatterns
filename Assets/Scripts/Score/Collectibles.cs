using Audio;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Score
{
    public class Collectibles : MonoBehaviour
    {
        public BoxCollider2D gridArea; 
       
        public GameObject effect;
  

        public void Start()
        {
            GameManager.instance.gameOver += OnDestroy;
            RandomizePosition();
        }

        public void RandomizePosition()
        {
            Bounds bounds = gridArea.bounds;
            //used random.range and the bounds +1/-1 to avoid collectables clipping outside of bounds. 
            float x = Random.Range(bounds.min.x+1, bounds.max.x-1); 
            float y = Random.Range(bounds.min.y+1, bounds.max.y-1);

            transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
        }

        private void OnDestroy()
        {
            GameManager.instance.gameOver -= OnDestroy;
            
        }
    
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player")) //compares tag to player (the head), to do effects, new pos and change bool.
            {
                FindObjectOfType<AudioManager>().Play("Food");
                Instantiate(effect, transform.position, quaternion.identity);
                RandomizePosition();
                GameManager.instance.CollectiblesCollect();
            }
            else
            {
                RandomizePosition(); //if triggered by the body or some other tag like hazard to avoid
                //instant collect or collects stuck in hazards.
            }
        }

    }
}
