using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tetris
{
    class BlockO : TetrisBlock
    {
        public BlockO()
        {
            tetrisblock = new int[2, 2] 
          { {4,4},
            {4,4}};
            color = Color.Yellow;               //Kleur van BlockO
        }
    }
}
