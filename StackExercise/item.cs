using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExercise
{
    abstract class Item
    {
        public abstract Item Anterior();

        public abstract object Contenido();

        public abstract int Posicion();

        public abstract bool isEmpty();
    }
}
