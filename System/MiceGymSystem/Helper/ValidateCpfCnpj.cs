using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MiceGymSystem.Helper
{
    internal class ValidateCpfCnpj
    {
        public static string ValidateCPF(string cpf)
        {
            // Remove a máscara e deixa apenas os números
            string cpfNumeros = Regex.Replace(cpf, "[^0-9]", "");

            if (cpfNumeros.Length != 11)
            {
                return "Erro";
            }

            // Fórmula de validação de CPF
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpfNumeros[i].ToString()) * (10 - i);
            }
            int resto = soma % 11;
            int digitoVerificador1 = (resto < 2) ? 0 : (11 - resto);

            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(cpfNumeros[i].ToString()) * (11 - i);
            }
            resto = soma % 11;
            int digitoVerificador2 = (resto < 2) ? 0 : (11 - resto);

            // Verifica os dígitos verificadores
            if (int.Parse(cpfNumeros[9].ToString()) == digitoVerificador1 &&
                int.Parse(cpfNumeros[10].ToString()) == digitoVerificador2)
            {
                // Formata e retorna o CPF com máscara
                return string.Format("{0}.{1}.{2}-{3}",
                    cpfNumeros.Substring(0, 3),
                    cpfNumeros.Substring(3, 3),
                    cpfNumeros.Substring(6, 3),
                    cpfNumeros.Substring(9, 2));
            }
            else
            {
                return "Erro";
            }
        }

        public static string ValidateCNPJ(string cnpj)
        {
            // Remove a máscara e deixa apenas os números
            string cnpjNumeros = Regex.Replace(cnpj, "[^0-9]", "");

            if (cnpjNumeros.Length != 14 || IsSequenciaInvalida(cnpjNumeros))
            {
                return "Erro";
            }

            // Fórmulas de validação de CNPJ
            int[] pesosPrimeiroDigito = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] pesosSegundoDigito = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma = 0;
            for (int i = 0; i < 12; i++)
            {
                soma += int.Parse(cnpjNumeros[i].ToString()) * pesosPrimeiroDigito[i];
            }
            int digitoVerificador1 = soma % 11;
            digitoVerificador1 = (digitoVerificador1 < 2) ? 0 : (11 - digitoVerificador1);

            soma = 0;
            for (int i = 0; i < 13; i++)
            {
                soma += int.Parse(cnpjNumeros[i].ToString()) * pesosSegundoDigito[i];
            }
            int digitoVerificador2 = soma % 11;
            digitoVerificador2 = (digitoVerificador2 < 2) ? 0 : (11 - digitoVerificador2);

            // Verifica os dígitos verificadores
            if (int.Parse(cnpjNumeros[12].ToString()) == digitoVerificador1 &&
                int.Parse(cnpjNumeros[13].ToString()) == digitoVerificador2)
            {
                // Formata e retorna o CNPJ com máscara
                return FormatCNPJ(cnpjNumeros);
            }
            else
            {
                return "Erro";
            }
        }

        private static string FormatCNPJ(string cnpjNumeros)
        {
            return string.Format("{0}.{1}.{2}/{3}-{4}",
                cnpjNumeros.Substring(0, 2),
                cnpjNumeros.Substring(2, 3),
                cnpjNumeros.Substring(5, 3),
                cnpjNumeros.Substring(8, 4),
                cnpjNumeros.Substring(12, 2));
        }

        private static bool IsSequenciaInvalida(string cnpjNumeros)
        {
            string[] sequenciasInvalidas = {
            "00000000000000", "11111111111111", "22222222222222",
            "33333333333333", "44444444444444", "55555555555555",
            "66666666666666", "77777777777777", "88888888888888",
            "99999999999999"
        };
            foreach (string seq in sequenciasInvalidas)
            {
                if (cnpjNumeros == seq)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
