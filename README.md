# Orbital Strike

Orbital strike is a small 2D space shooter including 2 different enemies and a final boss.

## Build the game

If you need to build the game, open the project in unity (preferably version 2018.2.x or more advanced). go into file, build settings, make sure the menu scene is in build as the first scene, and the game scene as the second one, select your platform and press build.

## Getting Started

To start the game, launch Space Shooter.exe in the build directory, choose your desired resolution and press play. You will then be able to choose between the normal game mode and the bullet hell game mode, and the game will start.

## Controls

The default game controls consist of the four directional arrows used for up, down, left and right, and the space bar to shoot. This can all be modified in the configuration screen, by changing the first four controls for directions, and the Fire1 control for shooting

## Code Review

### GameManager

Singleton script that is kept between scenes, containing the game Mode information, also contains the start game function that loads the main game asynchronously.

### MainMenu

Attached to the menu scene's canvas, calls the GameManager's StartGame function.

### ShipController

Controls the movement of the ship, the shooting button, the damage taken on hit, and the current level of upgrades.
This script is attached to the ship.

### EnemyController

This script calls the ScoreManager every time a ship gets destroyed by a bullet, and takes care of the linear vertical movement of the enemy ships.
This script is attached to a wave of enemies

### MissileController

Sets the velocity of the bullet's rigidbody according to rotation and speed.
Handles destruction of enemies and the explosion particles.

### ScoreManager

Script attached to a UI text, tracks the score and changes the text on screen to reflect it.

### WaveSpawner

Takes care of randomly spawning one of the two different possible waves of enemies for 30 seconds, then instantiates the boss.

### SinusoidalEnemy

Takes care of making an enemy move from the left of the screen to the right, and shoots a bullet aimed at the player, at a random moment between 0.2 and 2 seconds.
Attached to every enemy ship in the sinusoidal wave.

### FinalBossBehaviour

This script takes care of all of the boss behaviour.
It will first make him move to the center of the screen, then move around the screen.
At the same time it makes the boss shoot towards the player a random interval (between 0.5s and 2s).
It also takes care of enabling either the 2 weakPoints, or the core for a certain amount of seconds once both weakPoints have been hit.
It handles the health bar of the boss, that decreases if the core gets hit.
Attached to the final boss.

### BossPartHit

This script, attached to both weakPoints as well as the core, relays the collision event back to the finalBoss, telling that either a weakPoint or the core has been hit.

### UpgradeBehaviour

Takes care of making the upgrade rotate, and disappear after 10 seconds.
Attached to all upgrades.

### MoveBackground

This object has two similar baground sprites attached, makes them both move down constantly, while moving the lower one above the higher one once it gets too low, at to simulate an infinite moving background.

### PauseMenu

Script activating the menu, and pausing the game, when pressing escape, or once the game is over (player or final boss died). Contains all the functions to quit the game, go back to the main menu, resume the game, or start the game over (according to if the game is paused or finished).

### BulletHellTeleporter

This script teleports, a certain number of times, a bullet to the other side of the screen, if the GameManager's bulletHell variable is set to true.
Attached to all bullets.

### DestroyByTime

Destroys an object after a certain time (used with the particle system objects).

### DestroyWhenLeavesCamera

Destroys an object when it leaves the camera vision (used for enemies not killed by the player).

### EnableColliderOnEntrance

Enables the enemy ships colliders once they enter the camera view.

## Authors

**Jonathan Manassen**