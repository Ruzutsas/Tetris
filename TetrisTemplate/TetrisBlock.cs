using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Tetris
{
    class TetrisBlock
    {
        static Random randomblocks = new Random();
        Texture2D emptyCell;
        protected Boolean[,] tetrisblock;
        Vector2 startposition;
        protected Color color;

        public Color Blockcolor
        {
            get { return color; }
        }

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
                        Cellpos = new Vector2(emptyCell.Width * a + startposition.X, emptyCell.Height * k + startposition.Y); //Spawnt de tetromino op de startpositie
                        Cellpos.Y = (Cellpos.Y) + ((int)gameTime.TotalGameTime.Seconds * emptyCell.Height);
                        spriteBatch.Draw(emptyCell, Cellpos, color);
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
    }
}

