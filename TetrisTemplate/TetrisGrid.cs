using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tetris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

/// <summary>
/// A class for representing the Tetris playing grid.
/// </summary>
class TetrisGrid
{

    public int[,] grid = new int[12, 20];

    /// The sprite of a single empty cell in the grid.
    Texture2D emptyCell;

    /// The position at which this TetrisGrid should be drawn.
    Vector2 position;
    /// The number of grid elements in the x-direction.
    public int Width { get { return 12; } }

    /// The number of grid elements in the y-direction.
    public int Height { get { return 20; } }

    /// <summary>
    /// Creates a new TetrisGrid.
    /// </summary>
    /// <param name="b"></param>
    public TetrisGrid()
    {
        emptyCell = TetrisGame.ContentManager.Load<Texture2D>("block");
        position = Vector2.Zero;
        Clear();
    }

    /// <summary>
    /// Draws the grid on the screen.
    /// </summary>
    /// <param name="gameTime">An object with information about the time that has passed in the game.</param>
    /// <param name="spriteBatch">The SpriteBatch used for drawing sprites and text.</param>
    public void Draw(GameTime gameTime, SpriteBatch spriteBatch, TetrisBlock tetrisBlock)
    {

        for (int i = 0; i < 12; i++)
        {
            for (int u = 0; u < 20; u++)
            {
                position = new Vector2(i * emptyCell.Width, u * emptyCell.Height);

                switch (grid[i, u])
                {
                    case 0:
                        spriteBatch.Draw(emptyCell, position, Color.White);
                        break;
                    case 1:
                        spriteBatch.Draw(emptyCell, position, Color.LightSkyBlue);
                        break;
                    case 2:
                        spriteBatch.Draw(emptyCell, position, Color.Orange);
                        break;
                    case 3:
                        spriteBatch.Draw(emptyCell, position, Color.Blue);
                        break;
                    case 4:
                        spriteBatch.Draw(emptyCell, position, Color.Yellow);
                        break;
                    case 5:
                        spriteBatch.Draw(emptyCell, position, Color.LimeGreen);
                        break;
                    case 6:
                        spriteBatch.Draw(emptyCell, position, Color.Magenta);
                        break;
                    case 7:
                        spriteBatch.Draw(emptyCell, position, Color.Red);
                        break;
                }
            }
        }


    }

    /// <summary>
    /// Clears the grid.
    /// </summary>
    public void Clear()
    {
    }
}

