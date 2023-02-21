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
    public static float playerXStartPosition;

    public Player(TiledObject tiledObjectPlayer = null) : base("barry.png", 7, 1, -1, false, true)
    {
        if (tiledObjectPlayer != null)
        {
            ySpeed = tiledObjectPlayer.GetFloatProperty("ySpeed");
            playerXStartPosition = tiledObjectPlayer.GetFloatProperty("X");
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

            if (c.other is Spike)
            {
                Console.WriteLine("YAY");
                MyGame.hitSpike = true;
            }
        }
        else
        {
            y -= 1;
            ySpeed = (float)(ySpeed + DesignerClass.playerGravity);
        }
    }
}
