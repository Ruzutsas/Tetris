using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class BlockI : TetrisBlock
    {
        public BlockI ()
        {
            Boolean tetrisblock = new bool [] {{1, 1, 1, 1},
                                                  {0, 0, 0, 0},
                                                  {0, 0, 0, 0},      
                                                  {0, 0, 0, 0}
                                                 };
        }

    }
}
