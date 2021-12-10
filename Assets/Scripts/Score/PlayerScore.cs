using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace Score
{
    public class PlayerScore : MonoBehaviour
    {
        private double _scoreCount;
        private float bonusTimer = 5f;

        private double bonusScoreMultiplier = 1;

        private double streak = 0;

        public Text scoreCountLog;
        public Text bonusCounter;

        private void Start()
        {
            GameManager.instance.collectebleCollected += AddToScore; //subscribes to collectables 
            UpdateGUI(); //updates interface with current score/ gained body size.
        }

        public void Update()
        {
            if (bonusTimer >= 0)
            {
                bonusTimer -= Time.deltaTime;
            }

            if (PlayerPrefs.GetFloat("high score") < _scoreCount) //if current score is greater than high score.
            {
                HighScore();
            }

            bonusCounter.text = "Countdown: " + Math.Round(bonusTimer)+ "\n Bonus : " + (streak) + " / 5";

        }
        
        private void AddToScore()
        {
            
            double tempBonusScoreMultiplier = bonusScoreMultiplier;
            
            _scoreCount += 100; //gives player 100 score when collecting.

            if (bonusTimer > 0) //if timer hasn't run out, gives additional 5% score, stacking up to 5 times.
            {
                if (streak < 5)
                {
                    streak++;
                }

                _scoreCount /= (tempBonusScoreMultiplier + (-0.05*streak));
            }
            else
            {
                streak = 1;
            }
            
            bonusTimer = 5; //resets bonus timer when collecting new after streak has ended.
            
            UpdateGUI();
        }
        
        private void UpdateGUI() //updates interface with new values for text.
        {
            scoreCountLog.text = "Score: " + Math.Round(_scoreCount); //rounds the score count to whole numbers into gui.
        }

        private void HighScore() //updates float in playerprefs to set new high score using current score.
        {
            PlayerPrefs.SetFloat("high score", (float) (_scoreCount)); //stores local high score and round it.
        }

        private void OnDestroy()
        {
            GameManager.instance.collectebleCollected -= AddToScore;
        }
    }
}