# GDIM_61_Project


## Team member names <br />
  Lawson Michael McCoy <br />
  Yen Chi Nguyen <br />
  Sebastian Amirola <br />
  Aaron Luevano <br />
  Alexander Adam Rodriguez <br />
  Miguel Angel Jr. Aleman <br />
  
## Description <br />
  _Strike Team Penguin_ is a first person shooter with an explorable and interactable (work in progress) environment. 
  
## Starting the game <br />
   Press "start" button on the main menu.
    
## Win condition <br />
  Player needs to reach the end of map where the gazebo is placed in a circular area. Player needs to approach the gazebo and find a white cylinder to interact with. Press _button E_ to win the game.
    
## Death condition <br />
   If the enemies shoot the player, then the health bard will decrease. Once health drops below zero, the player will die. This will trigger a game over screend to pop up on the screen. From this screen you can restart or quit the game.
   
## How To Play <br />
    Player walks around the map and shoots the enemies to kill them. 
    Player can switch between 2 firing modes: primary (projectile) and secondary (hit scan). 
    The enemies are  white rectangles that will get aggravated if the player approaches them too close.
    The white rectangles will also continue following the player, as long as they are within the firing range.
    To win the game, the player needs to interact with a white cylinder placed inside a gazebo at the end of the map.
    Player can reach it by walking out the house, and finding the big stairs to the left. Going up those stairs will lead to the fallen door.
    At the end of that path, player will find the cylinder in a gazebo in the middle of a large open circular area of the map. 
    
    p.s.: If these instructions are not clear, just follow the trail of angry rectangles. Upon interacting with the cylinder, you will be presented with the win screen where you can return to main menu or quit the game. 

## Control schemes
  Strike Team Penguin can be played using either keyboard, mouse, or controller. 
  
  ### Keyboard and mouse
    Move: WASD
    Look: Mouse
    Jump: Space
    Belly Slide (Sprinting): Shift
    Interact: E
    Primary Fire: Left Click
    Secondary Fire: Right Click 
    Pause: ESC
  
  ### Controller (controls given for Deulshook 4, but should be mappable to other controllers)
    Move: Left Stick
    Look: Right Stick
    Jump: X
    Belly Slide (Sprinting): L3 
    Interact: Square
    Primary Fire: R2
    Secondary Fire: L2
    
## Things we plan to implement 
  - More weapons for both enemies and player 
  - Weapons pickup, so the player can change their weapon 
  - Special abilities for weapons
  - Implementing crosshair to improve aiming
  - Animate gun kickback
  

## Known major bugs
  - Walking up to a wall allows the player to look through the wall 
  - Walking up the first set of stairs can cause quite a bit of lag
  - The player will ocassionally get stuck on a stair and you have to jump to get past the step 
  - Currently cannot pause the game from the controller, you must use the keyboard 
  - No visual feedback from hitscan bullets except damaging the enemy 


## Big questions you have.
1. Are there any areas in the map that can trespassed but are not supposed to be? (buildings, concrete walls, tress, etc.)
   How do we fix that?
