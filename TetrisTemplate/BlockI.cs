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
        public BlockI()
        {
            tetrisblock = new bool[4, 4]
              {{true,false,false,false},
            {true,false,false,false},
            {true,false,false,false},
            {true,false,false,false}};
            color = Color.LightSkyBlue;             //Kleur van BlockI
        }
    }
}
