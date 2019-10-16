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
            tetrisblock = new bool[3, 3]
          { {false,true,false},
            {true,true,false},
            {true,false,false}};
            color = Color.Red;              //Kleur van BlockZ
        }
    }
}
