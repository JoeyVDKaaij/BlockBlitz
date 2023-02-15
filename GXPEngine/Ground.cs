using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Ground : Sprite
{
    public event Action GroundSpawnEvent;
    public event Action BlockObstacleSpawnEvent;

    public static bool spawnObstacle = false;
    private int obstacle = 0;
    public static int abilityToSpawnCooldown = 2;

    public Ground(int pX, int pY) : base(ArtistClass.groundFileName, false, true)
    {
        width = DesignerClass.groundWidth;
        height = DesignerClass.groundHeight;
        x = pX;
        y = DesignerClass.wHeight - height * DesignerClass.groundCountDefault + pY * height;
    }

    void Update()
    {
        x -= 1;

        if (x + width < 0)
        {
            if (y >= DesignerClass.wHeight - height && spawnObstacle)
            {
                if (obstacle == 0)
                {
                    BlockObstacleSpawnEvent.Invoke();
                    abilityToSpawnCooldown--;
                }
            }
            else if (y >= DesignerClass.wHeight - height)
            {
                GroundSpawnEvent.Invoke();
            }
            LateDestroy();

            if (abilityToSpawnCooldown == 0) spawnObstacle = false;
        }

        if (Hud.score % 100 == 1 && Hud.score > 80)
        {
            spawnObstacle = true;
            abilityToSpawnCooldown = 2;
        }
    }
}
