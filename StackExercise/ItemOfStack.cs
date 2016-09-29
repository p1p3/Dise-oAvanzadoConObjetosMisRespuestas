using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExercise
{
    class ItemOfStack : Item
    {
        private Item anterior;
        private object contenido;
        private int posicion;

        public ItemOfStack(Item anterior, object contenido, int posicion)
        {
            this.anterior = anterior;
            this.contenido = contenido;
            this.posicion = posicion;
        }

        #region Overrides of Item

        public override Item Anterior()
        {
            return anterior;
        }

        public override object Contenido()
        {
            return contenido;
        }

        public override int Posicion()
        {
            return posicion;
        }

        public override bool isEmpty()
        {
            return false;
        }

        #endregion
    }
}
