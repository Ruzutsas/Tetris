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
            tetrisblock = new int[3, 3]
          { {3,3,0},
            {0,3,0},
            {0,3,0}};
            color = Color.Blue;         //Kleur van BlockL
        }

    }
}
