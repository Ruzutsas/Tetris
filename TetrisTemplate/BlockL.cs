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
            tetrisblock = new bool[3, 3]
          { {true,true,false},
            {false,true,false},
            {false,true,false}};
            color = Color.Blue;         //Kleur van BlockL
        }

    }
}
