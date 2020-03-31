using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Ordenacao
{
    static class Database
    {
        static private string[,] database;
        static private int[] vetorDados;
        static private int[] vetorCrescente;
        static private int[] vetorDecrescente;

        public static void lerTxt()
        {
            lerTxtAleatorio();
            lerTxtCrescente();
            lerTxtDecrescente();
        }


        private static void lerTxtAleatorio()
        {
            
            string path = @"dados_airbnb.txt";
            string[] getlinhas = File.ReadAllLines(path); //Classe estática de um FileStream
            string[] headers = getlinhas[0].Split('\t'); //Split pelo caracter de Tabulação
            string[] linha;

            database = new string[getlinhas.Length, headers.Length];
            

            for (int i = 1; i < getlinhas.Length; i++)
            {
                linha = getlinhas[i].Split('\t');
                

                for(int j=0; j< linha.Length; j++)
                {
                    database[i - 1, j] = linha[j];
                }

                
            }

        }

        private static void lerTxtCrescente()
        {

            string path = @"DadosCrescente.txt";
            string[] getlinhas = File.ReadAllLines(path); //Classe estática de um FileStream
            //string[] headers = getlinhas[0].Split('\t'); //Split pelo caracter de Tabulação
            

            vetorCrescente = new int[getlinhas.Length - 1];
            

            for (int i = 1; i < getlinhas.Length - 1; i++)
            {
                vetorCrescente[i] = int.Parse(getlinhas[i].Trim());
            }

        }

        private static void lerTxtDecrescente()
        {

            string path = @"DadosDecrescente.txt";
            string[] getlinhas = File.ReadAllLines(path); //Classe estática de um FileStream
            //string[] headers = getlinhas[0].Split('\t'); //Split pelo caracter de Tabulação


            vetorDecrescente = new int[getlinhas.Length - 1];


            for (int i = 1; i < getlinhas.Length - 1; i++)
            {
                vetorDecrescente[i] = int.Parse(getlinhas[i].Trim());
            }

        }

        public static void preencheVetorDados()
        {
            vetorDados = new int[database.GetLength(0)];

            for(int i=0; i< database.GetLength(0) - 1; i++)
            {
                if(database[i, 0] != null)
                {
                    vetorDados[i] = int.Parse(database[i, 0]);
                }
                
                
            }
        }

        public static int[] retornaVetorDadosComTamanho(int tamanho)
        {
            int[] vetor = new int[tamanho];

            for(int i=0; i<tamanho; i++)
            {
                vetor[i] = vetorDados[i];
            }

            return vetor;
        }

        public static int[] retornaVetorOrderCrescente(int tamanho)
        {
            int[] vetor = retornaVetorDadosComTamanho(tamanho);

            //vetor.OrderBy(i => i);//Alterar este método 

            //Alteradodo -- 30/03/2020 -- Trecho de Código antigo comentado

            for (int i = 0; i < tamanho; i++)
            {
                vetor[i] = vetorCrescente[i];
            }

            return vetor;
        }

        public static int[] retornaVetorOrderDecrescente(int tamanho)
        {
            int[] vetor = retornaVetorDadosComTamanho(tamanho);

            //vetor.OrderByDescending(i => i);//Alterar este método

            for (int i = 0; i < tamanho; i++)
            {
                vetor[i] = vetorDecrescente[i];
            }

            return vetor;
        }



    }
}
