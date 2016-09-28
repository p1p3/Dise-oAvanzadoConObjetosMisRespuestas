using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacmanExcercise.Actors;

namespace PacmanExcercise.Blocks
{
    public class Teleport : ConstructionBlockType
    {
        #region Overrides of ConstructionBlockType

        public override Point nextPositionForGoing(Actor anActor, Point aMovement)
        {
            if (anActor is Ghost)
            {
                return anActor.position();
            }
            else if (anActor is Pacman)
            {
                return new Point(10, 4);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
