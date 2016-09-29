using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExercise
{
    class FirstItemOfStack : Item
    {
        #region Overrides of Item

        public override Item Anterior()
        {
            throw new Exception(Stack.STACK_EMPTY_DESCRIPTION);
        }

        public override object Contenido()
        {
            throw new Exception(Stack.STACK_EMPTY_DESCRIPTION);
        }

        public override int Posicion()
        {
            return 0;
        }

        public override bool isEmpty()
        {
            return true;
        }

        #endregion
    }
}
