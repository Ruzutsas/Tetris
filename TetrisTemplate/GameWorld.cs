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
        tetrisblock.HandleInput(gameTime, inputHelper);
        if (inputHelper.KeyPressed(Keys.Down))
        {
            counter++;
            if (tetrisblock.Collision())
                counter--;
        }
    }

    public void Update(GameTime gameTime)
    {
            if (tetrisblock.Collision())
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
        grid.Draw(gameTime, spriteBatch);
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
