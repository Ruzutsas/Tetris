using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
    TetrisGrid grid;
    public double counter = 0;

    public TetrisBlock tetrisblock;
    static readonly Random randomblocks = new Random();
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
       else if (inputHelper.KeyPressed(Keys.Right))
        {
            tetrisblock.blockposition.X += tetrisblock.emptyCell.Width;
            if (Collision())
                tetrisblock.blockposition.X -= tetrisblock.emptyCell.Width;
        }
        else if (inputHelper.KeyPressed(Keys.Left))
        {
            tetrisblock.blockposition.X -= tetrisblock.emptyCell.Width;
            if (Collision())
                tetrisblock.blockposition.X += tetrisblock.emptyCell.Width;
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
        

    }

    public void Update(GameTime gameTime)
    {
            if (Collision())
            {
                counter = 0;
                Merge();
            }
            else
            {
                counter += gameTime.ElapsedGameTime.TotalSeconds;
                tetrisblock.blockposition.Y = ((int)counter * tetrisblock.emptyCell.Height);
            }
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        grid.Draw(gameTime, spriteBatch, tetrisblock);
        tetrisblock.Draw(gameTime, spriteBatch);
        spriteBatch.DrawString(font, "", Vector2.Zero, Color.Blue);
        spriteBatch.End();
    }

     public static TetrisBlock GetRandomBlock()
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
                if (tetrisblock.tetrisblock[a, k] == true)
                {
                    int gridX = tetrisblock.blockposition.X / tetrisblock.emptyCell.Width + a;
                    int gridY = tetrisblock.blockposition.Y / tetrisblock.emptyCell.Height + k;
                    int blockX = tetrisblock.blockposition.X + a * tetrisblock.emptyCell.Width;
                    int blockY = tetrisblock.blockposition.Y + k * tetrisblock.emptyCell.Height;
                    if (blockX < 0 || blockX > tetrisblock.emptyCell.Width * 11 || blockY < 0 || blockY > tetrisblock.emptyCell.Height * 18 || grid.grid[gridX, gridY + 1] == true)
                        collision = true;
                }
            }

        }
        return collision;
    }

    public void Merge()
    {
        int x = tetrisblock.tetrisblock.GetLength(1);
        for (int a = 0; a < x; a++)
        {
            for (int k = 0; k < x; k++)
            {
                if (tetrisblock.tetrisblock[a, k] == true)
                {
                        int blockX = tetrisblock.blockposition.X / tetrisblock.emptyCell.Width + a;
                        int blockY = tetrisblock.blockposition.Y / tetrisblock.emptyCell.Height + k;
                        grid.grid[blockX,blockY] = tetrisblock.tetrisblock[a, k];
                }
            }
        }
        tetrisblock =  GetRandomBlock();
    }  

    public void Reset()
    {
    }
}
