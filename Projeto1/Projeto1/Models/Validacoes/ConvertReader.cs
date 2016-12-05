using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto1.Models.Validacoes
{
    public class ConvertReader
    {
        public static Int32 ConverteInt(object Valor)
        {
            Int32 newValor = 0;

            try
            {
                newValor = Convert.ToInt32(Valor);
            }
            catch
            {
                newValor = 0;
            }

            return newValor;
        }

        /// <summary>
        /// Converte Reader para Double verificando se é nulo
        /// </summary>
        /// <param name="Valor">Valor vindo de seu reader</param>
        /// <param name="canNull">Caso o valor seja nulo se pode retornar como nulo</param>
        /// <returns>double com o resultado</returns>
        public static double? ConverteDouble(object Valor, Boolean canNull = false)
        {
            double? newValor = null;

            if (canNull && Valor == null)
            {
                return newValor;
            }

            try
            {
                newValor = Convert.ToDouble(Valor);
            }
            catch
            {
                newValor = 0;
            }

            return newValor;
        }

        /// <summary>
        /// Converte Reader para Decimal verificando se é nulo
        /// </summary>
        /// <param name="Valor">Valor vindo de seu reader</param>
        /// <param name="canNull">Caso o valor seja nulo se pode retornar como nulo</param>
        /// <returns>Decimal com o resultado</returns>
        public static decimal? ConverteDecimal(object Valor, Boolean canNull = false)
        {
            decimal? newValor = null;

            if (canNull && Valor == null)
            {
                return newValor;
            }

            try
            {
                newValor = Convert.ToDecimal(Valor);
            }
            catch
            {
                newValor = 0;
            }

            return newValor;
        }

        /// <summary>
        /// Converte Reader para DateTime verificando se é nulo
        /// </summary>
        /// <param name="Valor">Valor vindo de seu reader</param>
        /// <param name="canNull">Caso o valor seja nulo se pode retornar como nulo</param>
        /// <returns>double</returns>
        public static DateTime? ConverteDateTime(object Valor, Boolean canNull = false)
        {
            DateTime? newValor = null;

            if (canNull && Valor == null)
            {
                return newValor;
            }

            try
            {
                newValor = Convert.ToDateTime(Valor);
            }
            catch
            {
                newValor = DateTime.MinValue;
            }

            return newValor;
        }

        /// <summary>
        /// Converte Reader para Boolean verificando se é nulo
        /// </summary>
        /// <param name="Valor">Valor vindo de seu reader</param>
        /// <param name="canNull">Caso o valor seja nulo se pode retornar como nulo</param>
        /// <returns>Boolean com o resultado</returns>
        public static Boolean? ConverteBoolean(object Valor, Boolean canNull = false)
        {
            Boolean? newValor = null;

            if (canNull && Valor == null)
            {
                return newValor;
            }

            try
            {
                newValor = Convert.ToBoolean(Valor);
            }
            catch
            {
                newValor = false;
            }

            return newValor;
        }

        /// <summary>
        /// Converte Reader para string verificando se é nulo
        /// </summary>
        /// <param name="Valor">Valor vindo de seu reader</param>
        /// <param name="canNull">Caso o valor seja nulo se pode retornar como nulo</param>
        /// <returns>string com o resultado</returns>
        public static string ConverteString(object Valor, Boolean canNull = false)
        {
            string newValor = null;

            if (canNull && Valor == null)
            {
                return newValor;
            }

            newValor = (string)Valor ?? "";

            return newValor;
        }
    }
}