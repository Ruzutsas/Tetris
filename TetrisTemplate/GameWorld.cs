using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System;
using Tetris;

/// <summary>
/// A class for representing the game world.
/// This contains the grid, the falling block, and everything else that the player can see/do.
/// </summary>
class GameWorld
{
    /// <summary>
    /// An enum for the different game states that the game can have.
    /// </summary>
    enum GameState
    {
        Menu,
        Playing,
        GameOver
    }

    /// <summary>
    /// The random-number generator of the game.
    /// </summary>
    public static Random Random { get { return random; } }
    static Random random;

    /// <summary>
    /// The main font of the game.
    /// </summary>
    SpriteFont font;
    /// <summary>
    /// The current game state.
    /// </summary>
    GameState gameState;

    /// <summary>
    /// The main grid of the game.
    /// </summary>
   
    int blocksize = 30;
    TetrisGrid grid;
    public double counter = 0;    
    public TetrisBlock tetrisblock;
    readonly Random randomblocks = new Random();
    double levelspeed = 1;
    public int score = 0;   

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public GameWorld()
    {
        random = new Random();
        gameState = GameState.Playing;
        font = TetrisGame.ContentManager.Load<SpriteFont>("SpelFont");
        tetrisblock = GetRandomBlock();
        grid = new TetrisGrid();           
    }

    public void HandleInput(GameTime gameTime, InputHelper inputHelper)
    {
        if (inputHelper.KeyPressed(Keys.Down))
        {
            counter++;
            if (Collision())
                counter--;
        }
        else if (inputHelper.KeyPressed(Keys.Space) && counter > 1)
        {
            while (!Collision())
            {
                tetrisblock.blockposition.Y++;
            }
        }
        else if (inputHelper.KeyPressed(Keys.Right)) //Beweegt de tetromino naar rechts
        {
            tetrisblock.blockposition.X += blocksize;
            if (Collision()) 
                tetrisblock.blockposition.X -= blocksize;
        }
        else if (inputHelper.KeyPressed(Keys.Left))
        {
            tetrisblock.blockposition.X -= blocksize;
            if (Collision())
                tetrisblock.blockposition.X += blocksize;
        }
        else if (inputHelper.KeyPressed(Keys.A))
        {
            tetrisblock.RotateL();
            if (Collision())
                tetrisblock.RotateR();
        }
        else if (inputHelper.KeyPressed(Keys.D))
        {
            tetrisblock.RotateR();
            if (Collision())
                tetrisblock.RotateL();
        }
        if (gameState == GameState.GameOver)
        {
            if (inputHelper.KeyPressed(Keys.Space) || inputHelper.KeyPressed(Keys.Enter))
                gameState = GameState.Playing;
        }

    }

    public void Update(GameTime gameTime)
    {
        if (Collision())
        {
            counter = 0;
            Merge();
        }
        if (gameState == GameState.GameOver)
        {
            counter = 0;
        }
        else
        {
            counter += gameTime.ElapsedGameTime.TotalSeconds * levelspeed;         
            tetrisblock.blockposition.Y = ((int)counter * blocksize);
        }
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        if (gameState == GameState.Playing)
        {
            grid.Draw(gameTime, spriteBatch);
            tetrisblock.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(font, "Score: " + Score , new Vector2(TetrisGame.ScreenSize.X / 2, 0), Color.Black);
        }
        else if (gameState == GameState.GameOver)
        {
            spriteBatch.DrawString(font, "GAME OVER", new Vector2(300, 500), Color.Blue);
            Reset();
        }
        spriteBatch.End();
    }

    public TetrisBlock GetRandomBlock()
    {
        int random = randomblocks.Next(1, 8);
        switch (random)
        {
            case 1:
                return new BlockI();
            case 2:
                return new BlockJ();
            case 3:
                return new BlockL();
            case 4:
                return new BlockO();
            case 5:
                return new BlockS();
            case 6:
                return new BlockT();
            default:
                return new BlockZ();
        }         
    }

    public bool Collision()
    {
        bool collision = false;
        int x = tetrisblock.tetrisblock.GetLength(0);
        for (int a = 0; a < x; a++)
        {
            for (int k = 0; k < x; k++)
            {                    
                int gridX = tetrisblock.blockposition.X / blocksize + a;
                int gridY = tetrisblock.blockposition.Y / blocksize + k;
                int blockX = tetrisblock.blockposition.X + a * blocksize;
                int blockY = tetrisblock.blockposition.Y + k * blocksize;
                if (tetrisblock.tetrisblock[a, k] != 0)
                {
                    if (blockX < 0 || blockX > blocksize * 11 || blockY < 0 || blockY >= blocksize * 19 || grid.grid[gridX , gridY + 1] != 0)
                        collision = true;
                }
            }
        }
        return collision;
    }

    public bool GameOver()
    {
        bool gameover = false;
        if (Collision() && tetrisblock.blockposition.Y == 0)
            gameover = true;
        return gameover;
    }

    public void Merge()
    {
        int x = tetrisblock.tetrisblock.GetLength(0);
        for (int a = 0; a < x; a++)
        {
            for (int k = 0; k < x; k++)
            {
                if (tetrisblock.tetrisblock[a, k] != 0)
                {
                    int gridX = tetrisblock.blockposition.X / tetrisblock.emptyCell.Width + a;
                    int gridY = tetrisblock.blockposition.Y / tetrisblock.emptyCell.Height + k;
                    grid.grid[gridX, gridY] = tetrisblock.tetrisblock[a, k];
                }
            }
        }
        if (GameOver())
            gameState = GameState.GameOver;               
        tetrisblock = GetRandomBlock();            
        grid.DetectFullLine();
        NextLevel();
    }

    public void NextLevel() //Verhoogt de valsnelheid van de blokken als er een bepaald aantal punten is behaald.
    {
        int NextLevelthreshold = 0;
        NextLevelthreshold += Score;
        if (NextLevelthreshold >= 200)
        {            
            levelspeed += 0.0;
            NextLevelthreshold = 0;
        }
    }
    public void Reset()
    {
        for (int i = 0; i < 12; i++)        //Clear Grid
        {
            for (int u = 0; u < 20; u++)
            {
                grid.grid[i, u] = 0;
            }
        }
        score = 0;
        levelspeed = 1;
    }
}

