using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tetris
{
    class BlockI : TetrisBlock
    {
        Boolean tetrisblock = new bool[] { {1, 1, 1, 1},
                                           {0, 0, 0, 0},
                                           {0, 0, 0, 0},
                                           {0, 0, 0, 0}
                                         };
    }
}
