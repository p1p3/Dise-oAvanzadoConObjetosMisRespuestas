using System;

namespace NumerosExercise
{
    public class Entero : Numero
    {
        protected int value;

        public Entero(int value)
        {
            this.value = value;
        }

        public int getValue()
        {
            return value;
        }

        public override Numero mas(Numero sumando)
        {
            if (sumando is Entero)
            {
                return new Entero(value + ((Entero)sumando).getValue());
            }
            else
            {
                return ((Fraccion)sumando).mas(this);
            }
        }

        public override Numero mas(Entero sumando)
        {

                return new Entero(value + ((Entero)sumando).getValue());

 
        }


        public override Numero mas(Fraccion sumando)
        {
            return (sumando).mas(this);
        }

        public override Numero por(Numero multiplicador)
        {
            if (multiplicador is Entero)
            {
                return new Entero(value * ((Entero)multiplicador).getValue());
            }
            else
            {
                return ((Fraccion)multiplicador).por(this);
            }


        }

        public override Numero dividido(Numero divisor)
        {
            if (divisor is Entero)
            {
                return Fraccion.dividir(this, (Entero)divisor);
            }
            else
            {
                var fraccion = (Fraccion)divisor;
                var representacionInversa = Fraccion.dividir(fraccion.getDenominador(), fraccion.getNumerador());
                return representacionInversa.por(this);
            }
        }

        public Entero maximoComunDivisorCon(Entero otroEntero)
        {
            if (otroEntero.esCero())
                return this;
            else
                return otroEntero.maximoComunDivisorCon(this.restoCon(otroEntero));
        }

        public Entero restoCon(Entero divisor)
        {
            return new Entero(value % divisor.getValue());
        }

        public Entero divisionEntera(Entero divisor)
        {
            return new Entero(value / divisor.getValue());
        }

        public override bool esCero()
        {
            return value == 0;
        }

        public override bool esUno()
        {
            return value == 1;
        }

        public override bool Equals(Object anObject)
        {
            if (typeof(Entero) == anObject.GetType())
                return value == ((Entero)anObject).getValue();
            else
                return false;
        }

        public override int GetHashCode()
        {
            return value;
        }
    }
}
