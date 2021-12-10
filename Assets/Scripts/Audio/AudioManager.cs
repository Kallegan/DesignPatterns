using System;
using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour

    {
        public Sound[] sounds;

        public static AudioManager instance; //used singleton to avoid audio duplicates and sound problems when
                                             //changing scene + to give access to sound scripts.
       

        private void Awake() //checks if an audio manager is in scene, and destroys to avoid multiple.
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
        
            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;

                s.source.loop = s.loop;
            }
        }

        void Start() //starts the music when starting game / entering menu.
        {
            Play("Music");
        }
    
        public void Play(string name) //finds the sound in array to play.
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            s?.source.Play(); 
        }
    }
}
