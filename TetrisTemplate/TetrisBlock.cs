using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tetris
{
    class TetrisBlock
    {
            Texture2D emptyCell;
            public int[,] tetrisblock;
            Vector2 iblockposition;

            public TetrisBlock()
            {
                emptyCell = TetrisGame.ContentManager.Load<Texture2D>("block");
                Clear();
            }
            public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
            {
                for (int a = 0; a < 4; a++)
                {
                    for (int k = 0; k < 1; k++)
                    {
                        if (tetrisblock[a, k] == 0)
                        {
                            iblockposition = new Vector2(a * emptyCell.Width, k * emptyCell.Height);
                            iblockposition.Y = (iblockposition.Y) + ((int)gameTime.TotalGameTime.Seconds * emptyCell.Height);
                            spriteBatch.Draw(emptyCell, iblockposition, Color.Yellow);
                        }
                    }

                }

            }
            public void Clear()
            {
            }
        }
}
