using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Ordenacao
{
    class AlgoritmoOrdenacao
    {
        public int[] OrdenacaoBolha(int[] vetor)
        {
            //int[] vetorOrdenado = new int[vetor.Length];
            int maior = 0;
            int aux;
            bool troca;

            for(int i=0; i<vetor.Length - 1; i++)
            {
                troca = false;
                for(int j = i + 1; j < vetor.Length; j++)
                {
                    if(vetor[i] > vetor[j])
                    {
                        aux = vetor[j];
                        vetor[j] = vetor[i];
                        vetor[i] = aux;
                        troca = true;
                    }
                }

                if(!troca)
                {
                    break;
                }

                
            }

            return vetor;

        }


        //public int[] OrdenacaoInsercao(int[] vetor)
        //{

        //}
    }
}
