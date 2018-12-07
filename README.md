# PhysicsEngines_Final_Platformer

It is a physics driven 3rd person view platformer.
The objective is to get to the end of the level. 

## The platformer starts with the player running to a launchpad, the launchpad will launch the player to the beginning of the game. (10%)

The level must consist of the following obstacles/challenges.

## Pits as traps, the player must be able to jump over pits. There must also be one pit which forces the player to interact with a rigid body(disable gravity or make it kinematic) in order to make it over.(15%)
- demonstrate the ability to attach and detach the player to a rigid body in the world

## There will be falling platforms, they are solid, as soon as the player is on them they will begin to fall. (5%)

## There must be a rotating trap ( i will give an example in class) (10%)
- Imagine a player trying to jump into the window of a house..but that house is rotating on the y axis.. if they do not time the jump correctly they will hit the brick wall and die.
- Imagine a windmill, if the player gets hit by a blade they will die.

## There must be power ups that give a brief speed or jump increase. (15%)

## There must be projectiles that aim at the player. (15%)

## Player loses if they fall in a pit, get hit by a projectile or the rotating trap.

## The camera must also be driven by physics and can not be child of the player(rotations can be done through the transform, and using lookAt is fine) (10%)

There has to be a wall or some static object in the game world to demonstrate the cameras ability to detect and avoid said static object.

## Gameplay (20%) 
-Start/End game
-Ability to restart
-Intuitive
