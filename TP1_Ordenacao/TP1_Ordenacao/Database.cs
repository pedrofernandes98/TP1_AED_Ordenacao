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

        public static void lerTxt()
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

        
    }
}
