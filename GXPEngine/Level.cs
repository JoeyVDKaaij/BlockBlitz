using System;
using TiledMapParser;
using GXPEngine;
using System.Collections.Generic;

class Level : GameObject
{
    Player player;
    TiledLoader loader;
    string currentLevelName;
    public Level(string filename)
    {
        currentLevelName = filename;
        loader = new TiledLoader(filename);
        CreateLevel();
    }
    void CreateLevel(bool IncludeImageLayer = true)
    {
        loader.rootObject = this;

        loader.addColliders = false;
        loader.LoadImageLayers();
        loader.LoadTileLayers();
        loader.addColliders = true;
        loader.autoInstance = true;
        loader.LoadObjectGroups();

        player = FindObjectOfType<Player>();
        if(player != null ) { AddChild(player); }
    }
    //public void PlayerDeath()
    //{
    //    Console.WriteLine("Player dies");
    //    PlayerData data = ((MyGame)game.playerData);

    //    //Prevent the die-twice bug
    //    if (respawn || data.lives <= 0)
    //    {
    //        Console.WriteLine("...for the second time");
    //        return;
    //    }

    //    data.lives--;

    //    if (data.lives <= 0)
    //    {
    //        ((MyGame)game).LoadLevel("nameOfLevel/currentLevel");
    //    }
    //    else
    //    {
    //        //repawn=true; //for smart respawn
    //        ((MyGame)game).LoadLevel(currentLevelName);
    //    }
    //}
    void Update()
    {
        if(player!= null)
        {
            Scrolling();
        }
    }
    void Scrolling()
    {
        int boundries = 128;  //The screen boudries for scrolling
        if (player.x + x > game.width - boundries)
            x = (game.width - boundries) - player.x;
        if (player.x + x < boundries)
            x = boundries - player.x;
        if (player.y + y > game.height - boundries)
            y = (game.height - boundries) - player.y;
        if (player.y + y < boundries)
            y = boundries - player.y;
    }
}
