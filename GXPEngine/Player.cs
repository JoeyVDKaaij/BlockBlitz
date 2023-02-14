using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player : AnimationSpriteAddOn
{
    public Player() : base(ArtistClass.playerFileName, ArtistClass.playerColumn, ArtistClass.playerRow, -1, false, true)
    {
        width = 50;
        height = 50;
        x = 100;
        y = 100;

        SetCycle(0, 3);
    }

    void Update()
    {
        Animate((float)0.2);
        MoveUntilCollision(0, 1);
    }
}
