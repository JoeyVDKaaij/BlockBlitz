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
    public const int playerJumpHeight = 5;
    public const double playerGravity = 0.2;

    // Ground Variables
    public const int groundWidth = 50;
    public const int groundHeight = 50;

    // How many grounds from the bottom of the screen are there at default
    public const int groundCountDefault = 3;

    // How much faster the game goes per pixel each frame
    public const double XSpeedUp = 0.001;

    // Which level the game starts with
    // Note that reaching the end doesn't send you to the next level
    public static string startLevel =
    "testmap.tmx";

    // Add the songs for each level in this array (if two songs are the same name the same file twice)
    // Doesn't work yet
    public static string[] levelSoundTrack = { "", "", "" };

    // Change the image, sprite and animationsprite in ArtistClass.cs
}