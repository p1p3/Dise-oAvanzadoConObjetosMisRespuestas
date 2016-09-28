using System;

namespace NumerosExercise
{
    public class Fraccion : Numero
    {
        protected Entero numerador;
        protected Entero denominador;

        public static Numero dividir(Entero dividendo, Entero divisor)
        {

            if (divisor.esCero()) throw new Exception(Numero.DESCRIPCION_DE_ERROR_NO_SE_PUEDE_DIVIDIR_POR_CERO);
            if (dividendo.esCero()) return dividendo;

            Entero maximoComunDivisor = dividendo.maximoComunDivisorCon(divisor);
            Entero numerador = dividendo.divisionEntera(maximoComunDivisor);
            Entero denominador = divisor.divisionEntera(maximoComunDivisor);

            if (denominador.esUno()) return numerador;

            return new Fraccion(numerador, denominador);

        }

        private Fraccion(Entero numerador, Entero denominador)
        {
            this.numerador = numerador;
            this.denominador = denominador;
        }

        public Entero getNumerador()
        {
            return numerador;
        }

        public Entero getDenominador()
        {
            return denominador;
        }

        public override bool esCero()
        {
            return false;
        }

        public override bool esUno()
        {
            return false;
        }

        public override bool Equals(Object anObject)
        {
            if (typeof(Fraccion) == anObject.GetType())
                return equals((Fraccion)anObject);
            else
                return false;
        }

        public bool equals(Fraccion aFraccion)
        {
            return numerador.por(aFraccion.getDenominador()).Equals(denominador.por(aFraccion.getNumerador()));
        }

        public override int GetHashCode()
        {
            return numerador.GetHashCode() / denominador.GetHashCode();
        }

        public override Numero mas(Numero sumando)
        {


            Numero denominadorSumando;
            Numero numeradorSumando;


            if (sumando is Fraccion)
            {
                var sumandoComoFraccion = (Fraccion)sumando;
                denominadorSumando = sumandoComoFraccion.getDenominador();
                numeradorSumando = sumandoComoFraccion.getNumerador();
            }
            else
            {
                var valorEntero = (Entero)sumando;
                denominadorSumando = new Entero(1);
                numeradorSumando = valorEntero;
            }


            Numero nuevoDenominador = denominador.por(denominadorSumando);
            Numero nuevoNumerador1 = numerador.por(denominadorSumando);
            Numero nuevoNumerador2 = denominador.por(numeradorSumando);
            Numero nuevoNumerador = nuevoNumerador1.mas(nuevoNumerador2);

            return nuevoNumerador.dividido(nuevoDenominador);


        }

        public override Numero mas(Fraccion sumando)
        {


            Numero denominadorSumando;
            Numero numeradorSumando;


            var sumandoComoFraccion = (Fraccion)sumando;
            denominadorSumando = sumandoComoFraccion.getDenominador();
            numeradorSumando = sumandoComoFraccion.getNumerador();



            Numero nuevoDenominador = denominador.por(denominadorSumando);
            Numero nuevoNumerador1 = numerador.por(denominadorSumando);
            Entero nuevoNumerador2 = (Entero)denominador.por(numeradorSumando);
            Numero nuevoNumerador = nuevoNumerador1.mas(nuevoNumerador2);

            return nuevoNumerador.dividido(nuevoDenominador);


        }

        public override Numero mas(Entero sumando)
        {


            Numero denominadorSumando;
            Numero numeradorSumando;

            var valorEntero = (Entero)sumando;
            denominadorSumando = new Entero(1);
            numeradorSumando = valorEntero;



            Numero nuevoDenominador = denominador.por(denominadorSumando);
            Numero nuevoNumerador1 = numerador.por(denominadorSumando);
            Entero nuevoNumerador2 = (Entero)denominador.por(numeradorSumando);
            Numero nuevoNumerador = nuevoNumerador1.mas(nuevoNumerador2);

            return nuevoNumerador.dividido(nuevoDenominador);


        }

        public override Numero por(Numero multiplicador)
        {
            Numero denominadorMultiplicador;
            Numero numeradorMultiplicador;


            if (multiplicador is Fraccion)
            {
                var sumandoComoFraccion = (Fraccion)multiplicador;
                denominadorMultiplicador = sumandoComoFraccion.getDenominador();
                numeradorMultiplicador = sumandoComoFraccion.getNumerador();
            }
            else
            {
                var valorEntero = (Entero)multiplicador;
                denominadorMultiplicador = new Entero(1);
                numeradorMultiplicador = valorEntero;
            }

            var resultado = numerador.por(numeradorMultiplicador).
                dividido(denominador.por(denominadorMultiplicador));


            return resultado;


        }

        public override Numero dividido(Numero divisor)
        {

            if (divisor is Fraccion)
            {

                Fraccion divisorComoFraccion = (Fraccion)divisor;
                return numerador.por(divisorComoFraccion.getDenominador()).
                    dividido(denominador.por(divisorComoFraccion.getNumerador()));
            }
            else
            {
                var valorEntero = (Entero)divisor;
                var enteroComoFraccion = Fraccion.dividir(new Entero(1), valorEntero);
                return this.por(enteroComoFraccion);
            }

        }

    }
}
