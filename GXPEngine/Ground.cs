using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;

public class Ground : AnimationSpriteAddOn
{
    public event Action GroundSpawnEvent;
    public event Action BlockObstacleSpawnEvent;
    public event Action GroundDestroyEvent;

    public static bool spawnObstacle = false;
    private int obstacle = 0;
    public static int abilityToSpawnCooldown = 2;
    public static bool canSpawnObstacle = true;

    public Ground(string fileName, int colums, int rows, TiledObject groundObject = null) : base(fileName, colums, rows, -1, false, true)
    {
        if (groundObject != null)
        {
            
        }
    }

    void Update()
    {
        /*
        x -= 1;
        /*
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

        if (Hud.score % 100 == 1 && Hud.score > 80 && canSpawnObstacle)
        {
            spawnObstacle = true;
            abilityToSpawnCooldown = 2;
        }
        */
    }
}
