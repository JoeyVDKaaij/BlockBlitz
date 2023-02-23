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
    private double xSpeed = DesignerClass.xStartingSpeed;

    public Ground(string fileName, int colums, int rows, TiledObject groundObject = null) : base(fileName, colums, rows, -1, false, true)
    {
        if (groundObject != null)
        {
            visible = false;
        }
    }

    void Update()
    {
        if (x < Player.playerX + 1920 && x > Player.playerX - 64 * 4)
        {
            visible = true;
        }
        else
        {
            visible = false;
        }
    }
}
