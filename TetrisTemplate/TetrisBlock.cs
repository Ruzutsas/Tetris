using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;


namespace Tetris
{  
    class TetrisBlock 
    {
        public Texture2D emptyCell;
        public int[,] tetrisblock;
        public Point blockposition;
        public Color color;
        private int blocksize = 30;      

        public Color Blockcolor
        {
            get { return color; }
        }

        public TetrisBlock()
        {
            emptyCell = TetrisGame.ContentManager.Load<Texture2D>("block");
            blockposition = new Point(4 * blocksize, 0);
            Clear();
        }


        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Vector2 Cellpos;
            int x = tetrisblock.GetLength(0);
            for (int a = 0; a < x; a++)
            {
                for (int k = 0; k < x; k++)
                {
                    if (tetrisblock[a, k] != 0)
                    {
                        Cellpos.X = emptyCell.Width * a + blockposition.X; //Spawnt de tetromino op de startpositie
                        Cellpos.Y = emptyCell.Height * k + blockposition.Y;
                        spriteBatch.Draw(emptyCell, Cellpos, color);
                    }                    
                }
            }
        }
        public void RotateL()
        {
            int x = tetrisblock.GetLength(0);
            int[,] Lrblock = new int[x, x];
            for (int a = 0; a < x; a++)
            {
                for (int k = 0; k < x; k++)
                {
                    Lrblock[a, k] = tetrisblock[k, x - 1 - a];
                }
            }
            tetrisblock = Lrblock;
        }

        public void RotateR()
        {
            int x = tetrisblock.GetLength(0);
            int[,] Rrblock = new int[x, x];
            for (int a = 0; a < x; a++)
            {
                for (int k = 0; k < x; k++)
                {
                    Rrblock[a, k] = tetrisblock[x - 1 - k, a];
                }
            }
            tetrisblock = Rrblock;
        }

        public void Clear()
        {
        }


        public void Reset()
        {

        }
    }
}

