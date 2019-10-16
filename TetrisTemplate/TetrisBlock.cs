using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Tetris
{
    class TetrisBlock
    {
        static readonly Random randomblocks = new Random();
        public Texture2D emptyCell;
        public bool[,] tetrisblock;
        Point blockposition;
        protected Color color;
        double counter;
        public Color Blockcolor
        {
            get { return color; }
        }

        public TetrisBlock()
        {
            emptyCell = TetrisGame.ContentManager.Load<Texture2D>("block");
            blockposition = new Point(emptyCell.Width * 4, 0);
            Clear();
        }

        public void HandleInput(GameTime gameTime, InputHelper inputHelper)
        {
            if (inputHelper.KeyPressed(Keys.Right))
            {
                blockposition.X += emptyCell.Width;
                if (Collision())
                    blockposition.X -= emptyCell.Width;
            }
            else if (inputHelper.KeyPressed(Keys.Left))
            {
                blockposition.X -= emptyCell.Width;
                if (Collision())
                    blockposition.X += emptyCell.Width;
            }
            else if (inputHelper.KeyPressed(Keys.Down))
            {
                counter++;
                if (Collision())
                    blockposition.Y -= emptyCell.Height;
            }
            else if (inputHelper.KeyPressed(Keys.A))
            {
                RotateL();
            }
            else if (inputHelper.KeyPressed(Keys.D))
            {
                RotateR();
            }
        }
        public void Update(GameTime gameTime)
        {
            if (Collision())
                blockposition.Y -= emptyCell.Height;

            else
            {
                counter += gameTime.ElapsedGameTime.TotalSeconds;
                blockposition.Y = ((int)counter * emptyCell.Height);

            }

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Vector2 Cellpos;
            int x = tetrisblock.GetLength(0);
            for (int a = 0; a < x; a++)
            {
                for (int k = 0; k < x; k++)
                {
                    if (tetrisblock[a, k] == true)
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
            bool[,] Lrblock = new bool[x, x];
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
            bool[,] Rrblock = new bool[x, x];
            for (int a = 0; a < x; a++)
            {
                for (int k = 0; k < x; k++)
                {
                    Rrblock[a, k] = tetrisblock[x - 1 - k, a];
                }
            }
            tetrisblock = Rrblock;
        }

        public bool Collision()
        {
            bool collision = false;
            int x = tetrisblock.GetLength(0);
            for (int a = 0; a < x; a++)
            {
                for (int k = 0; k < x; k++)
                {
                    if (tetrisblock[a, k] == true)
                    {
                        if (blockposition.X < 0 || blockposition.X > emptyCell.Width * 9 || blockposition.Y > emptyCell.Height * 20)
                            collision = true;
                        if (x == 4)
                            if (blockposition.X < -2)
                                collision = true;
                    }
                }

            }
            return collision;

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

        public void Reset()
        {

        }
    }
}

