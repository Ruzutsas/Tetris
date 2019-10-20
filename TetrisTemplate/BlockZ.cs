using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tetris
{
    class BlockZ : TetrisBlock
    {
        public BlockZ()
        {
            tetrisblock = new int[3, 3] 
          { {7,0,0},
            {7,7,0},
            {0,7,0}};
            color = Color.Red;               //Kleur van BlockS
        }
    }
}
