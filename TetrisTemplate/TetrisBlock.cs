using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework.Input;

namespace Tetris
{
    class TetrisBlock
    {
        Texture2D emptyCell;
        protected Boolean[,] tetrisblock;
        Vector2 startposition;
        Vector2 Cellpos;  
        protected Color color;
        public Color Blockcolor
        {
            get{return color;}
        } 

        public TetrisBlock()
        {
            emptyCell = TetrisGame.ContentManager.Load<Texture2D>("block");
            startposition = new Vector2(emptyCell.Width * 4, 0);
                Clear();
        }
            
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //Cellpos is de positie van de tetromino
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

        public void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.KeyPressed(Keys.S))
            {
              Cellpos.Y = Cellpos.Y + emptyCell.Height;
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

