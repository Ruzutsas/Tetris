using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tetris
{
    class BlockL : TetrisBlock
    {
        public BlockL()
        {
            tetrisblock = new bool[4, 4] 
          { {true,true,false,false},
            {false,true,false,false},
            {false,true,false,false},
            {false,false,false,false}};
            color = Color.DarkBlue;
        }

    }
}
