using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

public class Menu : Sprite
{
    public static int currentScore = 0;
    public static int coinCounter = 0;

    public Menu() : base(ArtistClass.mainMenuFileName, false, false)
    {
        width = (int)(game.width / 3 * 2.4);
        height = (int)(game.height / 3 * 2.4);
        x = 0;
        y = 0;
    }

    void Update()
    {
        if (ControlClass.plus)
        {
            MyGame.plus = true;
        }
    }
}
