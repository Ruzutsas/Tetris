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
    TetrisBlock tetrisblock;
    public GameWorld()
    {
        random = new Random();
        gameState = GameState.Playing;
        font = TetrisGame.ContentManager.Load<SpriteFont>("SpelFont");
        tetrisblock = new BlockI();
        grid = new TetrisGrid();
    }

    public void HandleInput(GameTime gameTime, InputHelper inputHelper)
    {
        tetrisblock.HandleInput(gameTime, inputHelper);
    }

    public void Update(GameTime gameTime)
    {
        tetrisblock.Update(gameTime);
        
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        grid.Draw(gameTime, spriteBatch);
        tetrisblock.Draw(gameTime, spriteBatch);
        spriteBatch.DrawString(font, "", Vector2.Zero, Color.Blue);
        spriteBatch.End();
    }

    public void Reset()
    {
    }
}
