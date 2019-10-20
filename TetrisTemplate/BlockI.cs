using Microsoft.Xna.Framework;

namespace Tetris
{
    class BlockI : TetrisBlock
    {
        public BlockI()
        {
            tetrisblock = new int[4, 4]
           {{0,0,0,0},
            {0,0,0,0},
            {1,1,1,1},
            {0,0,0,0}};            
            color = Color.LightSkyBlue;             //Kleur van BlockI
        }
    }
}
