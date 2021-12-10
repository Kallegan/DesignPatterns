using UnityEngine;
using UnityEngine.UI;

namespace Score
{
    public class HighScore : MonoBehaviour
    {
        public Text highScoreLog;
        
        private void Start() //high score that takes stored value in playerpref and displays it at start in menu.
        {
            CurrentHighScore();
        }

        private void CurrentHighScore()
        {
            highScoreLog.text = "High Score: " + PlayerPrefs.GetFloat("high score", 0);
        }

        public void ClearHighScore() //sets high score to 0 and prints new current to gui.
        {
            PlayerPrefs.SetFloat("high score", 0);
            CurrentHighScore();
        }

    }
}
    