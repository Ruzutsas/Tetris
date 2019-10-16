using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tetris
{
    class BlockJ : TetrisBlock
    {
        public BlockJ()
        {
            tetrisblock = new bool[3, 3]
          { {false,true,false},
            {false,true,false},
            {true,true,false}};
            color = Color.Orange;               //Kleur van BlockJ
        }
    }
}
