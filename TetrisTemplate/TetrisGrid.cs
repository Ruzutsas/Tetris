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

    public void ClearLine()
    {
        for (int i = 0; i < 12; i++)
        {
            for (int u = 0; u < 20; u++)
            {
            Lineposition = new Vector2(i * emptyCell.Width, u * emptyCell.Height);
                for (int u = 0; i < Lineposition.X; u++ )
                {
                    fullrow = true;
                    for (int i = 0; i < Lineposition.Y; i++)
                    {
                        if (grid[i, u] == 0)
                            fullrow = false;
                    }                
                }                                                     
            }
        }
    }

    /*public void ClearLine() //gaat elke rij na of deze een leeg block bevat, als dit niet een geval is, is de rij dus vol en wordt er een collapse in werking gestelt
    {
        Vector2 LinePos = position;
        for (int y = 19; y != 0; y--)
        {
            bool fullrow = true;
            for (int x = 0; x != 12; x++)
            {
                if (grid[x, y] == 0)
                {
                    fullrow = false;
                }
                LinePos.X += emptyCell.Width;
            }
            if (fullrow)
            {
                Collapse(y);
                y++; //anders skipt ie rijen als er meerdere tegelijk zijn               
            }
            LinePos.X = 0;
            LinePos.Y += emptyCell.Height;
        }
    }

    protected void Collapse(int yArg) //maakt van een volle rij een rij met lege blocks en schuift deze als het ware omhoog door continu met de rij erboven te swappen, hierdoor schuiven de rijen erboven dus ook meteen naar beneden.
    {
        Vector2 LinePos = position;
        for (int y = yArg; y != 0; y--)
        {
            for (int x = 0; x != 12; x++)
            {
                grid[x, y] = grid[x, y-1];
                grid[x, y-1] = 0;
                LinePos.X += emptyCell.Width;
            }
            LinePos.X = 0;
            LinePos.Y += emptyCell.Height;
        }
    }*/

    /// <summary>
    /// Clears the grid.
    /// </summary>
    public void Clear()
    {
    }
}

