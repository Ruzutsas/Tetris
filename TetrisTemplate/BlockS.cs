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
            tetrisblock = new bool[4, 4] 
          { {false,true,false,false},
            {false,true,true,false},
            {false,false,true,false},
            {false,false,false,false}};
            color = Color.LimeGreen;               //Kleur van BlockS
        }
    }
}
