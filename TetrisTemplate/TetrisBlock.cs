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
        protected bool[,] tetrisblock;
        Vector2 startposition;
        protected Color color;
        double counter;
       
        enum blockstate {moving, blocked};
        blockstate currentblockstate = blockstate.moving;
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

        public void HandleInput(GameTime gameTime, InputHelper inputHelper)
        {
            if (inputHelper.KeyPressed(Keys.Right))
            {
               startposition.X += emptyCell.Width;
            }
            else if (inputHelper.KeyPressed(Keys.Left))
            {   
                startposition.X -= emptyCell.Width;
                Console.WriteLine(startposition.X);
            }
            else if (inputHelper.KeyPressed(Keys.Down))
            {
                counter += 1;
            }
            else if (inputHelper.KeyPressed(Keys.Down))
            {
                startposition.Y += emptyCell.Height;
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
            if (startposition.Y >= emptyCell.Height * 20)
            {
                startposition.Y = emptyCell.Height * 20;
                currentblockstate = blockstate.blocked;
            }
            else
            {
                counter += gameTime.ElapsedGameTime.TotalSeconds;
                startposition.Y = ((int)counter * emptyCell.Height);
            }
                
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            int x = tetrisblock.GetLength(0);
            for (int a = 0; a < x; a++)
            {
                for (int k = 0; k < x; k++)
                {
                    if (tetrisblock[a, k] == true)
                    {    
                        Cellpos.X = emptyCell.Width * a + startposition.X; //Spawnt de tetromino op de startpositie
                        Cellpos.Y = emptyCell.Height * k + startposition.Y;
                        spriteBatch.Draw(emptyCell, Cellpos, color);
                    }
                }
            }
        }
        public void RotateL()
        {
            int x = tetrisblock.GetLength(0);
            bool[,] Lrblock = new bool [x,x];
            for (int a = 0; a < x; a++)
            {
                for (int k = 0; k < x; k++)
                {      
                    Lrblock[a, k] = tetrisblock[k, x- 1 - a];
                }             
            }
            tetrisblock = Lrblock;
        }
        
        public void RotateR()
        {
            int x = tetrisblock.GetLength(0);
            bool[,] Rrblock = new bool [x,x];
            for (int a = 0; a < x; a++)
            {
                for (int k = 0; k < x; k++)
                {      
                    Rrblock[a, k] = tetrisblock[x-1- k, a];
                }             
            }
            tetrisblock = Rrblock;
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

