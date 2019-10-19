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
            tetrisblock = new int[4, 4]
              {
            {0,0,0,0},
            {0,0,0,0},
            {1,1,1,1},
            {0,0,0,0}};
            color = Color.LightSkyBlue;             //Kleur van BlockI
        }
    }
}
