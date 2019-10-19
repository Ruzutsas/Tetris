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
        Console.WriteLine("10");
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

    public void DetectFullLine()
    {
        System.Diagnostics.Debug.WriteLine("1");
        int amountfullrows = 0;
        int ylowestrow = 0;
        for (int y = 19; y > 1; y--)
        {           
            bool fullrow = true;
            for (int x = 0; x < 11; x++)
            {              
                if (grid[x, y] == 0)                        //Checkt of er een leeg blokje is in de row
                {
                    fullrow = false;                    
                }                
            } 
            if (fullrow)
            {
                System.Diagnostics.Debug.WriteLine("7");
                if (ylowestrow == 0)
                {
                    ylowestrow = y;
                    System.Diagnostics.Debug.WriteLine("3");
                }
                amountfullrows++;
            }                                                                   
        }
        if (amountfullrows > 0)
        {
            System.Diagnostics.Debug.WriteLine("4");           
            for (int y = ylowestrow; y > 1; y--)
            {           
                for (int x = 0; x < 11; x++)
                {
                    grid[x, y] = grid[x, y - amountfullrows];                    
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

