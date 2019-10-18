using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tetris
{
    class BlockO : TetrisBlock
    {
        public BlockO()
        {
            tetrisblock = new bool[2, 2] 
          { {true,true},
            {true,true}};
            color = Color.Yellow;               //Kleur van BlockO
        }
    }
}
