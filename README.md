# Tails-Sky-Adventure

## Table of Contents
* [Builds](#builds)
* [Project Overview](#project-overview)
* [About the Game](#about-the-game)
* [Technical Details](#technical-details)
* [Tools and Technologies](#tools-and-technologies)
* [Gifs](#gifs)

------
## Builds
* [WebGL](https://alsandbox.github.io/Tails-Sky-Adventure/)
* [Windows](https://github.com/alsandbox/Tails-Sky-Adventure/releases/tag/v0.2)

------
## Project Overview
I recreated a handheld LCD game called «Tails' Sky Adventure», which was originally released as a McDonald's Happy Meal giveaway toy for a limited time in 2005. As a personal childhood favorite, I've always wanted to bring back this game, so I took it upon myself to recreate it.

------
## About the Game
If you're not familiar with «Tails' Sky Adventure», you can find more information [here](https://sonic.fandom.com/wiki/Tails_Sky_Adventure). To give you a quick idea of the gameplay, here's a summary:
* Turn the game on/off using the switch on the back.
* Start the game by pressing any button.
* Move left and right to position your ship in front of enemy ships.
* Press the button to shoot down enemy ships.
* Advance to the next level after eliminating fifteen enemy ships.
* If you collide with an enemy ship or let five ships pass you in a level, you lose a play.
* If you lose all your plays, the game is over.
* After completing all levels, you win the game, accompanied by celebratory character animations and sounds.
* To play again, simply press any button.

------
## Technical Details
Here's a breakdown of the technical aspects of the game:
* **Emulating Low Frame Rate**: Recreating the game's low frame rate was both challenging and fascinating. LCD games use a sequential activation and deactivation of screen segments for animation, and I replicated this effect.
* **Coroutines for Player Action and Enemy Movement**: The illusion of enemy movement and firing is achieved through the use of coroutines. Thanks to this game I really learned how to use them.
* **Scriptable Object for Game States**: To maintain clean and organized code, I utilized Scriptable Objects to store game states in properties. This separation of data from behavior adheres to the Single Responsibility Principle (SRP) in OOP.
```csharp
[CreateAssetMenu(menuName = "My Assets/GameStates", fileName = "GameStates")]
public class GameStates : ScriptableObject
{
    public bool IsPaused { get; set; }
    public bool IsGameOver { get; set; }
    public bool EnemyIsDestroyed { get; set; }
    public bool PlayerIsCollided { get; set; }
}
```
* **Animations**: I added simple animations for various aspects of the game, including menus, screen transitions, and the enemy's behavior when he's hit.
* **Menu**: Implemented a convenient menu that displays the keys used in the game and provides a restart option. This replaces the need to manually switch the game state (physical keys).

------
## Tools and Technologies
##### Development Tools
* Unity game engine (version 2021.3.7f1)
* Visual Studio 2022
* Audacity and Adobe Premiere Pro 2020 to clean up noise in audio files
* Adobe Photoshop CC 2019 to create sprites from SVG file

##### Graphics and Art
* Sounds and SVG files (enemy, Tails, fire) are from the amazing project [«Sonic McOrigins»](https://tvc-16.science/mcorigins.html) by [@Difegue](https://www.github.com/Difegue). This is a simulator engine for reproducing LCD games made by McDonald's in the 2000s. [Here](https://github.com/Difegue/LCDonald) is the project's source code.
* The background was repainted by artist [Sergei Knish](https://www.artstation.com/sergeiknish).

------
## Gifs
Similar (but better quality) videos can be downloaded and viewed ![https://github.com/alsandbox/Tails-Sky-Adventure/tree/readme/ReadmeMedia/Videos].

#### Gameplay
![](https://github.com/alsandbox/Tails-Sky-Adventure/blob/readme/ReadmeMedia/Gifs/gameplay.gif)


#### You can use either the mouse or the keyboard to navigate through the menus.
![](https://github.com/alsandbox/Tails-Sky-Adventure/blob/readme/ReadmeMedia/Gifs/mouse-keyboards.gif)


#### Pause screen
![](https://github.com/alsandbox/Tails-Sky-Adventure/blob/readme/ReadmeMedia/Gifs/pause-screen.gif)


#### Win screen
![](https://github.com/alsandbox/Tails-Sky-Adventure/blob/readme/ReadmeMedia/Gifs/win-screen.gif)


#### Game over screen
![](https://github.com/alsandbox/Tails-Sky-Adventure/blob/readme/ReadmeMedia/Gifs/gameover-screen.gif)


