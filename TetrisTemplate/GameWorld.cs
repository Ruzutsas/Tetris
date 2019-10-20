using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
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
    static Random random;

    public static Random Random { get { return random; } }

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

    const int blocksize = 30;
    TetrisGrid grid;
    public double counter = 0;
    public TetrisBlock tetrisblock, nextTetrisBlock;
    readonly Random randomblocks = new Random();
    public static SoundEffect clearrow;
    protected static SoundEffect fall;
    protected SoundEffect explosion;
    double levelspeed = 0.5;
    public int score = 0;
    private int leveltimer;
    private int level;
    public int NextLevelthreshold = 0;
    Texture2D logo;
    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public GameWorld(ContentManager Content)
    {
        random = new Random();
        gameState = GameState.Menu;
        clearrow = Content.Load<SoundEffect>("clear");
        fall = Content.Load<SoundEffect>("fall");
        font = TetrisGame.ContentManager.Load<SpriteFont>("SpelFont");
        explosion = Content.Load<SoundEffect>("Explosion");
        logo = Content.Load<Texture2D>("tetrislogo");
    }



    public void HandleInput(GameTime gameTime, InputHelper inputHelper)
    {

        switch (gameState)
        {
            case GameState.Menu:
                if (inputHelper.KeyPressed(Keys.Space) || inputHelper.KeyPressed(Keys.Enter))
                    gameState = GameState.Playing;
                break;

            case GameState.Playing:
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
                else if (inputHelper.KeyPressed(Keys.Escape))
                {
                    gameState = GameState.Menu;
                }
                break;

            case GameState.GameOver:
                {
                    if (inputHelper.KeyPressed(Keys.Space) || inputHelper.KeyPressed(Keys.Enter))
                        gameState = GameState.Playing;
                    else if (inputHelper.KeyPressed(Keys.Escape))
                    {
                        gameState = GameState.Menu;
                    }
                }
                break;
        }
    }

    public void Update(GameTime gameTime)
    {
        if (gameState == GameState.Playing)
        {
            if (Collision())
            {
                counter = 0;
                Merge(gameTime);
            }

            else
            {
                counter = counter * levelspeed + gameTime.ElapsedGameTime.TotalSeconds;
                tetrisblock.blockposition.Y = ((int)counter * blocksize);
            }
        }
        if (gameState == GameState.GameOver)
        {
            counter = 0;
        }
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        if (gameState == GameState.Menu)
        {
            spriteBatch.Draw(logo, new Vector2(TetrisGame.ScreenSize.X / 3 - 10, 30),Color.White);
            spriteBatch.DrawString(font, "Press SPACE To Start Game", new Vector2(TetrisGame.ScreenSize.X / 3, TetrisGame.ScreenSize.Y / 2), Color.Black);
        }
        else if (gameState == GameState.Playing)
        {
            grid.Draw(gameTime, spriteBatch);
            tetrisblock.Draw(gameTime, spriteBatch);
            nextTetrisBlock.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(font, "Score: " + Score, new Vector2(TetrisGame.ScreenSize.X / 2, 0), Color.Black);
            spriteBatch.DrawString(font, "Level: " + level, new Vector2(TetrisGame.ScreenSize.X - (TetrisGame.ScreenSize.X / 3), 0), Color.Black);
            if (leveltimer + 1 > gameTime.TotalGameTime.Seconds && leveltimer != 0)
                spriteBatch.DrawString(font, "LEVEL UP!", new Vector2(TetrisGame.ScreenSize.X / 2, 320), Color.Black);
        }

        else if (gameState == GameState.GameOver)
        {
            spriteBatch.DrawString(font, "GAME OVER", new Vector2(TetrisGame.ScreenSize.X / 3 + 75, TetrisGame.ScreenSize.Y / 2), Color.Blue);
            spriteBatch.DrawString(font, "Press SPACE To Try Again", new Vector2(TetrisGame.ScreenSize.X / 4 + 75, TetrisGame.ScreenSize.Y / 2 + 50), Color.Blue);
            Reset();
        }
        spriteBatch.End();
    }

    public void GenerateRandomBlock()
    {
        int random = randomblocks.Next(1, 9);
        switch (random)
        {
            case 1:
                nextTetrisBlock = new BlockI();
                break;
            case 2:
                nextTetrisBlock = new BlockJ();
                break;

            case 3:
                nextTetrisBlock = new BlockL();
                break;

            case 4:
                nextTetrisBlock = new BlockO();
                break;

            case 5:
                nextTetrisBlock = new BlockS();
                break;

            case 6:
                nextTetrisBlock = new BlockT();
                break;

            case 7:
                nextTetrisBlock = new BlockB();
                break;

            default:
                nextTetrisBlock = new BlockZ();
                break;

        }
        nextTetrisBlock.blockposition = new Point(14 * blocksize, blocksize);
    }

    public bool Collision()
    {
        bool collision = false;
        int tetrisShapeLength = tetrisblock.tetrisblock.GetLength(0);
        for (int x = 0; x < tetrisShapeLength; x++)
        {
            for (int y = 0; y < tetrisShapeLength; y++)
            {
                int gridX = tetrisblock.blockposition.X / blocksize + x;
                int gridY = tetrisblock.blockposition.Y / blocksize + y;
                int blockX = tetrisblock.blockposition.X + x * blocksize;
                int blockY = tetrisblock.blockposition.Y + y * blocksize;
                if (tetrisblock.tetrisblock[x, y] != 0)
                {
                    if (blockX < 0 || blockX > blocksize * 11 || blockY < 0 || blockY >= blocksize * 19 || grid.grid[gridX, gridY + 1] != 0)
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

    public void Merge(GameTime gameTime)
    {
        int x = tetrisblock.tetrisblock.GetLength(0);
        for (int a = 0; a < x; a++)
        {
            for (int k = 0; k < x; k++)
            {
                int gridX = tetrisblock.blockposition.X / blocksize + a;
                int gridY = tetrisblock.blockposition.Y / blocksize + k;
                if (tetrisblock.tetrisblock[a, k] != 0 && tetrisblock.tetrisblock[a, k] != 8)
                {
                    grid.grid[gridX, gridY] = tetrisblock.tetrisblock[a, k];
                }
                if (tetrisblock.tetrisblock[a, k] == 8)
                {
                    Explode(gridX, gridY);
                }
            }
        }
        if (GameOver())
            gameState = GameState.GameOver;
        tetrisblock = nextTetrisBlock;
        tetrisblock.blockposition = new Point(4 * blocksize, 0);
        fall.Play(0.2f, 0, 0);
        grid.DetectFullLine();
        NextLevel(gameTime);
        GenerateRandomBlock();
    }

    public void NextLevel(GameTime gameTime) //Verhoogt de valsnelheid van de blokken als er een bepaald aantal punten is behaald.
    {
        if (NextLevelthreshold >= 200)
        {
            levelspeed += 0.2;
            NextLevelthreshold = 0;
            level++;
            leveltimer = gameTime.TotalGameTime.Seconds;
        }
    }
    public void Reset()
    {
        GenerateRandomBlock();
        tetrisblock = nextTetrisBlock;
        tetrisblock.blockposition = new Point(4 * blocksize, 0);
        grid = new TetrisGrid();
        GenerateRandomBlock();
        score = 0;
        leveltimer = 0;
        levelspeed = 1;
    }
    public void Explode(int gridX, int gridY)
    {
        try
        {
            if (gridX > 2)
                grid.grid[gridX - 2, gridY] = 0;
            if (gridX < 10)
                grid.grid[gridX + 2, gridY] = 0;
            if (gridY < 18)
                grid.grid[gridX, gridY + 2] = 0;
            if (gridY > 2)
                grid.grid[gridX, gridY - 2] = 0;

            if (gridX > 1)
                grid.grid[gridX - 1, gridY] = 0;
            if (gridX < 11)
                grid.grid[gridX + 1, gridY] = 0;
            if (gridY < 19)
                grid.grid[gridX, gridY + 1] = 0;
            if (gridY > 1)
                grid.grid[gridX, gridY - 1] = 0;

            if (gridX < 11 && gridY < 19)
                grid.grid[gridX + 1, gridY + 1] = 0;
            if (gridX < 10 && gridY < 18)
                grid.grid[gridX + 2, gridY + 2] = 0;
            if (gridX < 10 && gridY < 19)
                grid.grid[gridX + 2, gridY + 1] = 0;
            if (gridX < 11 && gridY < 18)
                grid.grid[gridX + 1, gridY + 2] = 0;

            if (gridX > 1 && gridY > 1)
                grid.grid[gridX - 1, gridY - 1] = 0;
            if (gridX > 2 && gridY > 2)
                grid.grid[gridX - 2, gridY - 2] = 0;
            if (gridX > 2 && gridY > 1)
                grid.grid[gridX - 2, gridY - 1] = 0;
            if (gridX > 1 && gridY > 2)
                grid.grid[gridX - 1, gridY - 2] = 0;

            if (gridX > 1 && gridY < 19)
                grid.grid[gridX - 1, gridY + 1] = 0;
            if (gridX > 2 && gridY < 18)
                grid.grid[gridX - 2, gridY + 2] = 0;
            if (gridX > 2 && gridY < 19)
                grid.grid[gridX - 2, gridY + 1] = 0;
            if (gridX > 1 && gridY < 18)
                grid.grid[gridX - 1, gridY + 2] = 0;

            if (gridX < 11 && gridY > 1)
                grid.grid[gridX + 1, gridY - 1] = 0;
            if (gridX < 10 && gridY > 2)
                grid.grid[gridX + 2, gridY - 2] = 0;
            if (gridX < 10 && gridY > 1)
                grid.grid[gridX + 2, gridY - 1] = 0;
            if (gridX < 11 && gridY > 2)
                grid.grid[gridX + 1, gridY - 2] = 0;
        }

        catch (System.IndexOutOfRangeException e)
        {

        }

        explosion.Play(0.6f, 0, 0);
    }
}

