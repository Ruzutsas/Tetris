using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tetris;
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
    public static bool previoustetris;
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
                    case 8:
                        spriteBatch.Draw(emptyCell, position, Color.Black);
                        break;
                }
            }
        }
    }

    public void DetectFullLine()
    {        
        int amountfullrows = 0;
        int ylowestrow = 0;      
        for (int y = 19; y > 1; y--)
        {           
            bool fullrow = true;
            for (int x = 0; x < 12; x++)
            {              
                if (grid[x, y] == 0)                              //Checkt of er een leeg blokje is in de row
                {
                    fullrow = false;                                       
                }                        
            }            
            if (fullrow)
            {
                if (ylowestrow == 0)
                {
                    ylowestrow = y;
                }
                amountfullrows++;
            }                                                                   
        }       
        if (amountfullrows > 0)                            
        {          
            for (int y = ylowestrow; y > 1 + amountfullrows; y--)
            {           
                for (int x = 0; x < 12; x++)
                {
                    grid[x, y] = grid[x, y - amountfullrows];     //Als er een volle row is schuift de row erboven over de volle row.                  
                }             
            }             
            switch (amountfullrows)
            {                      
                case 1:
                    TetrisGame.gameWorld.Score += 100; //Verhoogt de score met 100 punten. 
                    TetrisGame.gameWorld.NextLevelthreshold += 100;                                                                             
                    previoustetris = false;
                    break;                
                case 2:
                    TetrisGame.gameWorld.Score += 200;
                    TetrisGame.gameWorld.NextLevelthreshold += 200;
                    previoustetris = false;
                    break;
                case 3:
                    TetrisGame.gameWorld.Score += 300;
                    TetrisGame.gameWorld.NextLevelthreshold += 300;
                    previoustetris = false;
                    break;
                case 4:
                    TetrisGame.gameWorld.Score += 800;
                    TetrisGame.gameWorld.NextLevelthreshold += 800;
                    if (previoustetris)
                    {
                        TetrisGame.gameWorld.Score += 400;      //Back-to-Back Tetris is 1200 points waard.
                        TetrisGame.gameWorld.NextLevelthreshold += 400;
                    }  
                    previoustetris = true;                      //Als er deze beurt een Tetris gemaakt wordt kan er in de volgende beurten een Back-to-Back Tetris gemaakt worden.
                    break;
            }
            GameWorld.clearrow.Play(0.2f, 0, 0);
        }
    } 

    /// <summary>
    /// Clears the grid.
    /// </summary>
    public void Clear()
    {
    }
}

