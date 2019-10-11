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
            tetrisblock = new bool[4, 4]
          { {false,true,false,false},
            {false,true,false,false},
            {true,true,false,false},
            {false,false,false,false}};
            color = Color.Orange;               //Kleur van BlockJ
        }
    }
}
