using System;

class Gerador
{
    static void Main(string[] args)
    {
        string cpf = GerarCPF();
        Console.WriteLine("CPF Gerado: " + cpf);
    }

    static string GerarCPF()
    {
        Random random = new Random();
        int soma = 0;
        int resto = 0;
        int[] numeros = new int[9];

        for (int i = 0; i < 9; i++)
        {
            numeros[i] = random.Next(0, 9);
            soma += numeros[i] * (10 - i);
        }

        resto = soma % 11;
        if (resto < 2)
        {
            resto = 0;
        }
        else
        {
            resto = 11 - resto;
        }

        int primeiroDigitoVerificador = resto;
        soma = 0;

        for (int i = 0; i < 9; i++)
        {
            soma += numeros[i] * (11 - i);
        }

        soma += primeiroDigitoVerificador * 2;
        resto = soma % 11;

        if (resto < 2)
        {
            resto = 0;
        }
        else
        {
            resto = 11 - resto;
        }

        int segundoDigitoVerificador = resto;

        return string.Format("{0}{1}{2}.{3}{4}{5}.{6}{7}{8}-{9}{10}", 
            numeros[0], numeros[1], numeros[2], 
            numeros[3], numeros[4], numeros[5], 
            numeros[6], numeros[7], numeros[8], 
            primeiroDigitoVerificador, segundoDigitoVerificador);
    }
}