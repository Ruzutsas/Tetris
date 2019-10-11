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
        Boolean tetrisblock = new bool[] { {0, 0, 0, 1},
                                           {1, 1, 1, 1},
                                           {0, 0, 0, 0},
                                           {0, 0, 0, 0}
                                         }; 
    }
}
