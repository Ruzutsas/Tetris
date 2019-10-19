using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tetris
{
    class BlockT : TetrisBlock
    {
        public BlockT()
        {
            tetrisblock = new int[3, 3]
          { {0,6,0},
            {6,6,0},
            {0,6,0} };
            color = Color.Magenta;               //Kleur van BlockT
        }
    }
}
