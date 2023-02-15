using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions
using System.Collections.Generic;

public class MyGame : Game {

	public static Player player;
	List<Ground> ground;
	List<PlaceHolder> placeHolder;
	List<Block> block;
	Hud hud;

	ControlClass controlClass = new ControlClass();

	public MyGame() : base(DesignerClass.wWidth, DesignerClass.wHeight, DesignerClass.fullScreen, false, -1, -1, false)
	{
		// Initialize the classes
		player = new Player();
		
		ground = new List<Ground>();

        placeHolder = new List<PlaceHolder>();
        block = new List<Block>();

		hud = new Hud();

		// Create the ground
		for (int i = 0; i < (width / DesignerClass.groundWidth) + 1; i++)
		{
            for (int j = 0; j < DesignerClass.groundCountDefault; j++)
            {
                ground.Add(new Ground(0, j));
            }
        }

		// Load the ground
        int groundId = 0;
        foreach (Ground x in ground)
		{
			x.GroundSpawnEvent += Ground_GroundSpawnEvent;
			x.BlockObstacleSpawnEvent += Ground_BlockObstacleSpawnEvent;
            x.x += 50 * (groundId / DesignerClass.groundCountDefault);
			AddChild(x);
			groundId++;
		}
		groundId = 0;
		
		AddChild(player);
		AddChild(hud);
        SetChildIndex(hud, -1);
        AddChild(controlClass);

		Console.WriteLine("MyGame initialized");
	}

	// For every game object, Update is called every frame, by the engine:
	void Update() {

	}

    private void Ground_GroundSpawnEvent()
    {
        for (int j = 0; j < DesignerClass.groundCountDefault; j++)
        {
            ground.Add(new Ground(width, j)); 
			ground[ground.Count - 1].GroundSpawnEvent += Ground_GroundSpawnEvent;
			ground[ground.Count - 1].BlockObstacleSpawnEvent += Ground_BlockObstacleSpawnEvent;
            AddChild(ground[ground.Count - 1]);
        }
    }

	private void Ground_BlockObstacleSpawnEvent()
	{
		for (int j = 0; j < DesignerClass.groundCountDefault; j++)
		{
			if (j == 2)
			{
				ground.Add(new Ground(width, j));
				ground[ground.Count - 1].GroundSpawnEvent += Ground_GroundSpawnEvent;
				ground[ground.Count - 1].BlockObstacleSpawnEvent += Ground_BlockObstacleSpawnEvent;
				AddChild(ground[ground.Count - 1]);

                placeHolder.Add(new PlaceHolder(width, 1));
                placeHolder[placeHolder.Count - 1].PlaceHolderReplaceWithBlockEvent += PlaceHolder_PlaceHolderReplaceWithBlockEvent;
                AddChild(placeHolder[placeHolder.Count - 1]);
			}
		}
    }
    private void PlaceHolder_PlaceHolderReplaceWithBlockEvent()
    {
        for (int j = 0; j < DesignerClass.groundCountDefault; j++)
        {
            block.Add(new Block(width, j));
            AddChild(block[block.Count - 1]);
        }
    }

    static void Main()                          // Main() is the first method that's called when the program is run
	{
		new MyGame().Start();                   // Create a "MyGame" and start it
	}
}