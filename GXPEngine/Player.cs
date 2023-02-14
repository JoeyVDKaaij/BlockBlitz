using GXPEngine;
using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player : AnimationSpriteAddOn
{
    private float ySpeed = 1;

    public Player() : base(ArtistClass.playerFileName, ArtistClass.playerColumn, ArtistClass.playerRow, -1, false, true)
    {
        width = DesignerClass.playerWidth;
        height = DesignerClass.playerHeight;
        x = DesignerClass.playerSpawnX;
        y = DesignerClass.playerSpawnY;

        SetCycle(0, 3);
    }

    void Update()
    {
        Animate((float)0.2);
        Collision c = MoveUntilCollision(0, (float)ySpeed);
        if (c != null)
        {
            ySpeed = 1;
            if (ControlClass.jump)
            {
                y -= 1;
                ySpeed = -DesignerClass.playerJumpHeight;
            }
        }
        else
        {
            ySpeed = (float)(ySpeed + DesignerClass.playerGravity);
        }
    }
}
