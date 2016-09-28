using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacmanExcercise.Blocks;

namespace PacmanExcercise.Actors
{
    public class Ghost : Actor
    {
        private Point actualPosition;

        public Ghost(Point initialPosition)
        {
            actualPosition = initialPosition;
        }

        #region Overrides of Actor

        public override Point position()
        {
            return actualPosition;
        }

        public override Point moveToBlockType(ConstructionBlockType block, Point aMove)
        {
            return block.nextPositionForGoingGhost(this, aMove);
        }


        #endregion
    }
}
