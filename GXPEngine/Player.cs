using GXPEngine;
using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;

public class Player : AnimationSpriteAddOn
{
    private float ySpeed;

    public Player(TiledObject tiledObjectPlayer = null) : base("barry.png", 7, 1, -1, false, true)
    {
        if (tiledObjectPlayer != null)
        {
            ySpeed = tiledObjectPlayer.GetFloatProperty("ySpeed", 1f);
        }
        width = DesignerClass.playerWidth;
        height = DesignerClass.playerHeight;
        //x = DesignerClass.playerSpawnX;
        //y = DesignerClass.playerSpawnY;

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
            y -= 1;
            ySpeed = (float)(ySpeed + DesignerClass.playerGravity);
        }
    }
}
