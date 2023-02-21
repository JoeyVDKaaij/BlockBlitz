using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DesignerClass
{
    // Game Window Variables
    public const int wWidth = 800;
    public const int wHeight = 600;
    public const bool fullScreen = false;

    // Player Variable
    public const int playerSpawnX = 100;
    public const int playerSpawnY = 0;
    public const int playerWidth = 50;
    public const int playerHeight = 50;
    public const int playerJumpHeight = 11;
    public const double playerGravity = 0.5;

    // How fast the player goes for the first frame when the player crouches
    public const float playerCrouchStartingSpeed = 4;

    // How much the speed decreases per frame. Keep the f at the end for it to work
    public const float playerCrouchSpeedDecrease = 0.2f;

    // Will the player sit still after crouching for a long enough time
    public const bool crouchStill = false;

    // Minimum speed that the player slides (keep the f at the end)
    public const float crouchMinSpeed = 0.1f;

    // Ground Variables
    public const int amountOfObstacles = 3;

    // How many grounds from the bottom of the screen are there at default
    public const int groundCountDefault = 3;

    // Set the starting speed per pixel
    public const double xStartingSpeed = 5;

    // How much faster the game goes per pixel each frame
    public const double XSpeedUp = 0.001;

    // Which level the game starts with
    // Note that reaching the end doesn't send you to the next level
    public static string startLevel =
    "testmap.tmx";
    //"level1.tmx";

    // Position of the coin counter
    public const int coinCounterX = 50;
    public const int coinCounterY = 50;

    // Add the songs for each level in this array (if two songs are the same name the same file twice)
    // Doesn't work yet
    public static string[] levelSoundTrack = { "", "", "" };

    public static int[,,,] blocks =
        {
            {
                {
                    { 0, 1, 0, 0, 0, 0, 0 },
                    { 1, 1, 1, 1, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 1, 0, 0, 0, 0, 0, 0 },
                    { 1, 1, 1, 1, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 1, 1, 0, 0, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 1, 1, 0, 0, 0, 0, 0 },
                    { 1, 0, 1, 1, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                }
            },
            {
                {
                    { 0, 1, 0, 0, 0, 0, 0 },
                    { 1, 1, 1, 1, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 1, 0, 0, 0, 0, 0, 0 },
                    { 1, 1, 1, 1, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 1, 1, 0, 0, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 1, 1, 0, 0, 0, 0, 0 },
                    { 1, 0, 1, 1, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                }
            },
            {
                {
                    { 0, 1, 0, 0, 0, 0, 0 },
                    { 1, 1, 1, 1, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 1, 0, 0, 0, 0, 0, 0 },
                    { 1, 1, 1, 1, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 1, 1, 0, 0, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                },
                {
                    { 1, 1, 0, 0, 0, 0, 0 },
                    { 1, 0, 1, 1, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                }
            },
        };
    // Change the image, sprite and animationsprite in ArtistClass.cs
}