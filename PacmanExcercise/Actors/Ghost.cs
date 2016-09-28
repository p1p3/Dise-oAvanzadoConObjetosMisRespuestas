using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanExcercise.Actors
{
    public class Ghost :Actor
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

        #endregion
    }
}
