using Audio;
using UnityEngine;


public class Triggers : MonoBehaviour
{
    public static bool outOfBound; //using to check if the player leaves the grid area.

    private void OnTriggerExit2D(Collider2D other) //checks if the player exits any 2d colliders.
    {
        if (gameObject != null)
        {
            if (other.tag == "Body")
            {
                FindObjectOfType<AudioManager>().Play("GameOver");
                GameManager.instance.GameOver();
            }
            if(other.tag == "GridArea")
            {
                outOfBound = true;
            }
        }
    }

}
