using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions
using System.Collections.Generic;

public class MyGame : Game {

	public static Player player;
	List<Ground> ground;
	List<PlaceHolder> placeHolder;
    //PlaceHolder placeHolder;
    //List<Block> block;
    public static Block block;
    public Spike spike;

    Hud hud;
    EndPoint endPoint;

    public static bool currentObstacleOnScreen = false;

    ControlClass controlClass;

    
    string levelToLoad = null;
    public string currentLevel;
    private SoundChannel backgroundMusicSC;
    //public readonly PlayerData playerData;
    Level level;

    public static bool hitSpike = false;

    public MyGame() : base(DesignerClass.wWidth, DesignerClass.wHeight, DesignerClass.fullScreen, false, -1, -1, false)
	{
        //playerData = new PlayerData();
        LoadLevel(DesignerClass.startLevel);
        OnAfterStep += CheckLoadLevel;
        EndPoint.EndLevelEvent += EndPoint_EndPointEndLevelEvent;

        // Initialize the classes
        //player = new Player();

        ground = new List<Ground>();

        placeHolder = new List<PlaceHolder>();
        //block = new List<Block>();

		hud = new Hud();

        // Create the ground
        for (int i = 0; i < (width / DesignerClass.groundWidth) + 1; i++)
		{
            for (int j = 0; j < DesignerClass.groundCountDefault; j++)
            {
                //ground.Add(new Ground());
            }
        }

		// Load the ground
        int groundId = 0;
        foreach (Ground x in ground)
		{
            /*
			x.GroundSpawnEvent += Ground_GroundSpawnEvent;
			x.BlockObstacleSpawnEvent += Ground_BlockObstacleSpawnEvent;
            x.GroundDestroyEvent += Ground_GroundDestroyEvent;
            */

            x.x += 50 * (groundId / DesignerClass.groundCountDefault);
			AddChild(x);
			groundId++;
		}
		groundId = 0;
		
		//AddChild(player);
		AddChild(hud);
        SetChildIndex(hud, -1);

		Console.WriteLine("MyGame initialized");
	}

	// For every game object, Update is called every frame, by the engine:
	void Update() {
        /*
		if (placeHolder.Count > 0)
		{
			Ground.canSpawnObstacle = false;
		}
		else
		{
			Ground.canSpawnObstacle = true;
		}
        */

        if (hitSpike) ResetCurrentLevel();
    }

    /*
    private void Ground_GroundSpawnEvent()
    {
        for (int j = 0; j < DesignerClass.groundCountDefault; j++)
        {
            ground.Add(new Ground(width, j)); 
			ground[ground.Count - 1].GroundSpawnEvent += Ground_GroundSpawnEvent;
			ground[ground.Count - 1].BlockObstacleSpawnEvent += Ground_BlockObstacleSpawnEvent;
            ground[ground.Count - 1].GroundDestroyEvent += Ground_GroundDestroyEvent;
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
                ground[ground.Count - 1].GroundDestroyEvent += Ground_GroundDestroyEvent;
                AddChild(ground[ground.Count - 1]);

                placeHolder.Add(new PlaceHolder(width, 1));
                placeHolder[placeHolder.Count - 1].PlaceHolderReplaceWithBlockEvent += PlaceHolder_PlaceHolderReplaceWithBlockEvent;
                placeHolder[placeHolder.Count - 1].PlaceHolderDestroyEvent += PlaceHolder_PlaceHolderDestroyEvent;
                AddChild(placeHolder[placeHolder.Count - 1]);

                placeHolder.Add(new PlaceHolder(width, 0));
                placeHolder[placeHolder.Count - 1].PlaceHolderReplaceWithBlockEvent += PlaceHolder_PlaceHolderReplaceWithBlockEvent;
                placeHolder[placeHolder.Count - 1].PlaceHolderDestroyEvent += PlaceHolder_PlaceHolderDestroyEvent;
                AddChild(placeHolder[placeHolder.Count - 1]);
			}
		}
    }

    private void PlaceHolder_PlaceHolderReplaceWithBlockEvent()
    {
        for (int j = 0; j < placeHolder.Count; j++)
        {
            block.Add(new Block(placeHolder[j].x, placeHolder[j].y));
            AddChild(block[block.Count - 1]);
            block[block.Count - 1].BlockDestroyEvent += Block_BlockDestroyEvent;

            placeHolder[j].Remove();
        }
    }
    private void Ground_GroundDestroyEvent()
    {
        ground[0].LateDestroy();
		ground[0].Remove();
    }

    private void PlaceHolder_PlaceHolderDestroyEvent()
    {
		placeHolder[0].LateDestroy();
		placeHolder.Remove(placeHolder[0]);
    }

    private void Block_BlockDestroyEvent()
    {
        block[0].LateDestroy();
		block[0].Remove();
    }
    */

    private void EndPoint_EndPointEndLevelEvent()
    {
        ResetCurrentLevel();
    }

    void DestroyAll()
    {
        List<GameObject> children = GetChildren();
        foreach (GameObject child in children)
        {
            child.Destroy();
        }
    }
    void CheckLoadLevel()
    {
        if (levelToLoad != null)
        {
            DestroyAll();
            AddChild(new Level(levelToLoad));
            if (levelToLoad != "EndScreen.tmx" && levelToLoad != "MainMenu.tmx")
                AddChild(new Hud());
                AddChild(new ControlClass());
            levelToLoad = null;
        }
    }
    public void LoadLevel(string filename, int currentLevelSoundTrack = 0)
    {
        if (backgroundMusicSC != null)
            backgroundMusicSC.Stop();
        //Sound backgroundMusic = new Sound(DesignerClass.levelSoundTrack[currentLevelSoundTrack]);
        //backgroundMusicSC = backgroundMusic.Play();
        levelToLoad = filename;
        currentLevel = filename;
    }

    public void ResetCurrentLevel()
    {
        DestroyAll();
        //playerData.Reset();
        AddChild(new Level(currentLevel));
        AddChild(new Hud());
        AddChild(new ControlClass());
        hitSpike = false;
    }

    static void Main()                          // Main() is the first method that's called when the program is run
	{
		new MyGame().Start();                   // Create a "MyGame" and start it
	}
}