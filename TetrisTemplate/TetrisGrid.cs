using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// A class for representing the Tetris playing grid.
/// </summary>
class TetrisGrid
{
    int[,] grid = new int[12, 20];
    int[,] iblock = new int[1, 4]
        {{1, 1, 1, 1}};

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
    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {

        for (int i = 0; i < 12; i++)
        {
            for (int u = 0; u < 20; u++)
            {
                if (grid[i, u] == 0)
                {
                    position = new Vector2(i * emptyCell.Width, u * emptyCell.Height);
                    spriteBatch.Draw(emptyCell, position, Color.White);
                }
                else if (grid[i, u] == 1)
                {
                    position = new Vector2(i * emptyCell.Width, u * emptyCell.Height);
                    spriteBatch.Draw(emptyCell, position, Color.Orange);
                }
                 else if (iblock[i, u] == 0 && grid[i, u] == 0)
                {
                    position = new Vector2(i * emptyCell.Width, u * emptyCell.Height);
                    spriteBatch.Draw(emptyCell, position, Color.Yellow);
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

