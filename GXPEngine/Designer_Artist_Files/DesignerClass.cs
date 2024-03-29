﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DesignerClass
{
    // Game Window Variables
    public const int wWidth = 1920;
    public const int wHeight = 1080;
    public const bool fullScreen = true;

    // Player Variable;
    public const int playerSpawnX = 100;
    public const int playerSpawnY = 0;
    public const int playerWidth = 50;
    public const int playerHeight = 50;
    public const int playerJumpHeight = 17;
    public const double playerGravity = 1.0;

    public const int virusWidth = 200;
    public const int virusHeight = 1080;

    // How fast the player goes for the first frame when the player crouches
    public const float playerCrouchStartingSpeed = 2;

    // How much the speed decreases per frame. Keep the f at the end for it to work
    public const float playerCrouchSpeedDecrease = 0.1f;

    // Will the player sit still after crouching for a long enough time
    public const bool crouchStill = false;

    // Minimum speed that the player slides (keep the f at the end)
    public const float crouchMinSpeed = 1.5f;

    // Ground Variables
    public const int amountOfObstacles = 3;

    // How many grounds from the bottom of the screen are there at default
    public const int groundCountDefault = 3;

    // Set the starting speed per pixel
    public const double xStartingSpeed = 5;

    // How much faster the game goes per pixel each frame
    public const double XSpeedUp = 0.0015;

    // Which level the game starts with
    // Note that reaching the end doesn't send you to the next level
    public static string startLevel =
    //"testmap.tmx";
    //"level1 backup.tmx";
    "MainMenu.tmx";
    //"level1.tmx";

    // Position of the coin counter
    public const int coinCounterX = 50;
    public const int coinCounterY = 50;

    public static int[,,,] blocks =
        {
            {
            //Obstacle 0
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 1, 1, 1, 1, 1, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 1, 0, 0, 0, 0, 0, 0 },
                    { 1, 1, 1, 1, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 1, 1, 1, 1, 1, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 1, 1, 0, 0, 0, 0, 0 },
                    { 1, 0, 1, 1, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                }
            },
            {
            //Obstacle 1
                {
                    { 0, 0, 0, 0, 1, 0, 0 },
                    { 0, 0, 0, 0, 1, 0, 0 },
                    { 1, 1, 1, 1, 1, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 1, 1, 1, 1, 1, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 1, 1, 0, 0 },
                    { 1, 1, 0, 1, 1, 0, 0 },
                    { 1, 1, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 1, 0, 0, 0, 0, 0, 0 },
                    { 1, 0, 0, 0, 0, 0, 0 },
                    { 1, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                }
            },
            {
            //Obstacle 2
                {
                    { 1, 1, 1, 1, 1, 1, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 1, 1, 1, 1, 1, 1, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 1, 0, 0, 0 },
                    { 1, 1, 1, 1, 1, 1, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 1, 1, 1, 1, 1, 1, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 1, 1, 1, 1, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                }
            },
            {
            //Obstacle 3
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 1, 1, 0, 0, 1, 1, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 1, 0, 0, 0, 0, 0, 0 },
                    { 1, 1, 1, 0, 0, 0, 0 },
                    { 1, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0, 1, 1, 0 },
                    { 0, 0, 1, 1, 1, 0, 0 },
                    { 1, 1, 1, 0, 1, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                }
            },
            {
            //Obstacle 4
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 1, 1, 0, 0, 0, 0 },
                    { 0, 1, 1, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 1, 1, 1, 1, 1, 1, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0, 1, 1, 0 },
                    { 0, 0, 1, 1, 1, 0, 0 },
                    { 1, 1, 1, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                }
            },
            {
            //Obstacle 5
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 1, 0, 0, 0 },
                    { 1, 1, 1, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 1, 1, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 1, 1, 1, 1, 0, 0, 0 },
                    { 1, 1, 1, 1, 0, 0, 0 },
                    { 1, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 0, 1, 1, 0, 0, 0, 0 },
                    { 0, 1, 1, 0, 0, 0, 0 },
                    { 0, 1, 1, 0, 0, 0, 0 },
                    { 0, 1, 1, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                }
            },
            {
            //Obstacle 6
                {
                    { 1, 1, 1, 1, 1, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 1, 0, 0, 0, 0, 0 },
                    { 1, 1, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 1, 1, 1, 1, 1, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0, 1, 0, 0 },
                    { 0, 1, 1, 1, 1, 0, 0 },
                    { 1, 1, 1, 1, 1, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                }
            },
            {
            //Obstacle 7
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 1, 1, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 1, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 1, 1, 1, 1, 0, 0, 0 },
                    { 1, 0, 0, 1, 0, 0, 0 },
                    { 1, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 1, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                }
            },
            {
            //Obstacle 8
                {
                    { 1, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 1, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 1, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 1, 0, 0, 1, 0, 0, 0 },
                    { 1, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                }
            },
            {
            //Obstacle 9
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 1, 1, 1, 1, 0, 0, 0 },
                    { 0, 1, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 1, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 1, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 1, 0, 0, 0, 0, 0, 0 },
                    { 1, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                }
            },
            {
            //Obstacle 10
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 1, 0, 0, 0, 0, 1, 0 },
                    { 1, 1, 1, 1, 1, 1, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 1, 1, 1, 1, 1, 1, 0 },
                    { 1, 1, 0, 1, 0, 1, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 1, 1, 1, 1, 1, 1, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 1, 1, 0, 0, 1, 1, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                }
            },
            {
            //Obstacle 11
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 1, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 1, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 1, 1, 0, 0 },
                    { 0, 0, 0, 0, 1, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 1, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                }
            }

        };



    // Add the songs for the title screen, level and possibly the end screen in that order from left to right.
    // If not changed you should hear the Goat simulator dance music.
    public static string[] levelSoundTrack = { "Menu rizz final.wav", "Background music full version.wav", "Goat_Simulator_Dance_Song.mp3" };

    public const float backgroundMusicVolume = 0.5f;

    public const float soundEffectVolume = 0.5f;

    public static string[] jumpSoundEffect = { "Jumping sound 1.wav", "Jumping sound 2.wav", "Jumping sound 3.wav" };
    public const float jumpSoundEffectVolume = 1f;

    public const string slideSoundEffect = "Slide.wav";
    public const float slideSoundEffectVolume = 1f;

    public const string grabCoinSoundEffect = "Coin collect.wav";
    public const float grabCoinSoundEffectVolume = 1f;

    public const string deathSoundEffect = "Death.wav";
    public const float deathSoundEffectVolume = 1f;

    public const string placeBlockSoundEffect = "Block placement.wav";
    public const float placeBlockSoundEffectVolume = 1f;

    // Change the image, sprite and animationsprite in ArtistClass.cs
}