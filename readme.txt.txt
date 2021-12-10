Karl Berglund

A very simple snake game with basic interface, highscore and some sounds. Wanted a
smooth snake game that rewarded long survival and quick play, so quick and sequential
collects would be rewarded by incrementing total score.

Patterns:
- Singleton, used a few for game objects that I just wanted one instance of, like
Game Manager, object pool and Audio Manager. The AudioManager implementation is
AudioManager.cs in class AudioManager as Audiomanager.instance
Used to make sounds easy to play from everywhere and to keep the sound manager playing
music between menu / game scene.

-Observer pattern, used in GameManager.cs in class GameManager as the events gameOver,
 collectablesCollected, gameStarted. Used to get easier communication in scripts for
automatic and smoother updates when events happened, like collecting would trigger
snake to grow, play sound, effect etc.

-Pooling, Used in hazards in HazardPool.cs, class HazardPool as
HazardPool.instance. Used for spawning multiple hazards(comets) into the scene and
keep them inactive for later re-use to increase performance.

