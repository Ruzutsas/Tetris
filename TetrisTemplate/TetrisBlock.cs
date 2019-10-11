using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Tetris
{
    class TetrisBlock
    {
            Texture2D emptyCell;
            public Boolean[,] tetrisblock;
            Vector2 startposition;

            public TetrisBlock()
            {
            emptyCell = TetrisGame.ContentManager.Load<Texture2D>("block");
            startposition = new Vector2(emptyCell.Width * 4, 0);
                Clear();
            }
            public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
            {
            Vector2 Cellpos;
                for (int a = 0; a < 4; a++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        if (tetrisblock[a, k] == true)
                        {
                            Cellpos = new Vector2(emptyCell.Width * a + startposition.X, emptyCell.Height * k + startposition.Y); 
                            Cellpos.Y = (Cellpos.Y) + ((int)gameTime.TotalGameTime.Seconds * emptyCell.Height);
                            spriteBatch.Draw(emptyCell, Cellpos, Color.Yellow);
                        }
                    }
                }

            }
            public void Clear()
            {
            }

             public virtual bool CheckBlock()
        {
            return false;
        }
        }
}

