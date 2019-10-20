using Microsoft.Xna.Framework;

namespace Tetris
{
    class BlockJ : TetrisBlock
    {
        public BlockJ()
        {
            tetrisblock = new int[3, 3]
          { {3,3,0},
            {0,3,0},
            {0,3,0}};
            color = Color.Blue;         //Kleur van BlockL
        }

    }
}
