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
            tetrisblock = new bool[3, 3] 
          { {true,false,false},
            {true,true,false},
            {false,true,false}};
            color = Color.LimeGreen;               //Kleur van BlockS
        }
    }
}
