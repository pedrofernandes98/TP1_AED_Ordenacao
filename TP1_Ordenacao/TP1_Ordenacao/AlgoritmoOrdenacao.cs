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
            int[] vetOrder = vetor;
            //int maior = 0;
            int aux;
            bool troca;

            for(int i=0; i<vetor.Length - 1; i++)
            {
                troca = false;
                for(int j = i + 1; j < vetor.Length; j++)
                {
                    if(vetOrder[i] > vetOrder[j])
                    {
                        aux = vetOrder[j];
                        vetOrder[j] = vetOrder[i];
                        vetOrder[i] = aux;
                        troca = true;
                    }
                }

                if(!troca)
                {
                    break;
                }

                
            }

            return vetOrder;

        }


        public int[] OrdenacaoSelecao(int[] vetor)
        {
            int posMenor = 0;
            int[] vetOrder = vetor;
            

            for (int i = 0; i < vetor.Length - 2; i++)
            {
                posMenor = i;

                for(int j = i + 2; j < vetor.Length; j++)
                {
                    if(vetOrder[j] < vetOrder[posMenor])
                    {
                        posMenor = j;
                    }
                }

                vetOrder[i] = vetOrder[posMenor];
            }

            return vetOrder;
        }

        public int[] OrdenacaoInsercao(int[] vetor)
        {
            int[] vetOrder = vetor;
            int sentinela;
            int j;            
            for(int i = 2; i <= vetor.Length - 1; i++)
            {
                sentinela = vetOrder[i];
                j = i - 1;
                //vetOrder[0] = sentinela;

                while(sentinela < vetOrder[j])
                {
                    vetOrder[j + 1] = vetOrder[j];
                    j--;
                }
                vetOrder[j + 1] = sentinela;
            }

            return vetOrder;
        }
    }
}
