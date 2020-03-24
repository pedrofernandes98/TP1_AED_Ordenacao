using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Ordenacao
{
    class Program
    {
        static void Main(string[] args)
        {
            InicializaPrograma();
            int[] vetor = Database.retornaVetorDadosComTamanho(10);
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0} |", vetor[i]);
            }

            AlgoritmoOrdenacao teste = new AlgoritmoOrdenacao();

            int[] vetorOrdenado = teste.OrdenacaoBolha(vetor);
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0} |", vetorOrdenado[i]);
            }



            Console.ReadKey();
        }

        static void InicializaPrograma()
        {
            Database.lerTxt();
            Database.preencheVetorDados();
        }
    }
}
