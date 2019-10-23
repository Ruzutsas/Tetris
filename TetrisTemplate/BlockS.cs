using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tetris
{
    class BlockS : TetrisBlock
    {
        public BlockS()
        {
            tetrisblock = new int[3, 3]
          { {0,5,0},
            {5,5,0},
            {5,0,0}};
            color = Color.LimeGreen;              //Kleur van BlockZ
        }
    }
}
