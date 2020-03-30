using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Ordenacao
{
    static class AlgoritmoOrdenacao
    {
        static public int[] OrdenacaoBolha(int[] vetor)
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


        static public int[] OrdenacaoSelecao(int[] vetor)
        {
            int posMenor = 0;
            int[] vetOrder = vetor;
            int aux;
            

            for (int i = 0; i < vetor.Length - 1; i++)
            {
                posMenor = i;

                for(int j = i + 1; j < vetor.Length; j++)
                {
                    if(vetOrder[j] < vetOrder[posMenor])
                    {
                        posMenor = j;
                    }
                }

                aux = vetOrder[i];
                vetOrder[i] = vetOrder[posMenor];
                vetOrder[posMenor] = aux;
            }

            return vetOrder;
        }

        static public int[] OrdenacaoInsercao(int[] vetor)
        {
            int[] vetOrder = vetor;
            int sentinela;
            int j;            
            for(int i = 1; i < vetor.Length; i++)
            {
                sentinela = vetOrder[i];
                //j = i;
                //vetOrder[0] = sentinela;

                //while(sentinela < vetOrder[j - 1] && j > 0)
                //{
                //    vetOrder[j] = vetOrder[j - 1];
                //    j--;
                //}
                //vetOrder[j] = sentinela;

                for( j = i; j > 0 && sentinela < vetOrder[j - 1]; j--)
                {
                    vetOrder[j] = vetOrder[j - 1];
                }

                vetOrder[j] = sentinela;
            }

            return vetOrder;
        }

        //public int[] quickSort(int[] vetor, int esquerda, int direita)
        //{
        //    int[] vetOrder = vetor;

        //    int pivo;
        //    int aux;
        //    int part = -1;
        //    pivo = vetOrder.Length - 1;
        //    int final;

        //    for (int i=1; i < vetOrder.Length - 1; i++)
        //    {

        //        if(vetOrder[i] < vetOrder[pivo])
        //        {
        //            Avançar part
        //            ++part;
        //            Troca i com part
        //            aux = vetOrder[i];
        //            vetOrder[i] = vetOrder[part];
        //            vetOrder[part] = aux;
        //        }

        //        if (i == pivo)
        //        {
        //            ++part;

        //            aux = vetOrder[pivo];
        //            vetOrder[pivo] = vetOrder[part];
        //            vetOrder[part] = aux;
        //        }
        //    }

        //    //Ao final
        //    ++part;

        //    aux = vetOrder[pivo];
        //    vetOrder[pivo] = vetOrder[part];
        //    vetOrder[part] = aux;




        //}


        //public static int[] quickSort(int[] vetor)
        //{
        //    int inicio = 0;
        //    int fim = vetor.Length - 1;

        //    quickSort(vetor, inicio, fim);

        //    return vetor;
        //}

        //private static void quickSort(int[] vetor, int inicio, int fim)
        //{
        //    if (inicio < fim)
        //    {
        //        int pivo = vetor[inicio];
        //        int i = inicio + 1;
        //        int f = fim;

        //        while (i <= f)
        //        {
        //            if (vetor[i] <= pivo)
        //            {
        //                i++;
        //            }
        //            else if (pivo < vetor[f])
        //            {
        //                f--;
        //            }
        //            else
        //            {
        //                int troca = vetor[i];
        //                vetor[i] = vetor[f];
        //                vetor[f] = troca;
        //                i++;
        //                f--;
        //            }
        //        }

        //        vetor[inicio] = vetor[f];
        //        vetor[f] = pivo;

        //        quickSort(vetor, inicio, f - 1);
        //        quickSort(vetor, f + 1, fim);
        //    }
        //}
        static public int[] MergeSort(int[] Aleatorio)
        {
            if (Aleatorio.Length <= 1)
                return Aleatorio;


            int[] ordenado = new int[Aleatorio.Length];
            int[] esquerdo;
            int[] direito;

            int meio = Aleatorio.Length / 2;

            esquerdo = new int[meio];


            if (Aleatorio.Length % 2 == 0)
                direito = new int[meio];

            else
                direito = new int[meio + 1];


            for (int i = 0; i < meio; i++)
            {
                esquerdo[i] = Aleatorio[i];
            }

            int j = 0;

            for (int i = meio; i < Aleatorio.Length; i++)
            {
                direito[j] = Aleatorio[i];
                j++;
            }

            esquerdo = MergeSort(esquerdo);
            direito = MergeSort(direito);
            ordenado = Merge(esquerdo, direito);
            return ordenado;
        }

        static private int[] Merge(int[] esquerdo, int[] direito)
        {
            int resultjuncao = esquerdo.Length + direito.Length;

            int[] resultfinal = new int[resultjuncao];

            int auxesquerdo = 0, auxdireito = 0, auxResult = 0;

            while (auxesquerdo < esquerdo.Length || auxdireito < direito.Length)
            {
                if (auxesquerdo < esquerdo.Length && auxdireito < direito.Length)
                {
                    if (esquerdo[auxesquerdo] <= direito[auxdireito])
                    {
                        resultfinal[auxResult] = esquerdo[auxesquerdo];
                        auxesquerdo++;
                        auxResult++;

                    }

                    else
                    {
                        resultfinal[auxResult] = direito[auxdireito];
                        auxdireito++;
                        auxResult++;
                    }
                }

                else if (auxesquerdo < esquerdo.Length)
                {

                    resultfinal[auxResult] = esquerdo[auxesquerdo];
                    auxesquerdo++;
                    auxResult++;

                }

                else if (auxdireito < direito.Length)
                {
                    resultfinal[auxResult] = direito[auxdireito];
                    auxdireito++;
                    auxResult++;
                }


            }

            return resultfinal;
        }

        static public int[] QuickSort(int[] vetor)
        {
            quicksort(vetor, 0, vetor.Length - 1);

            return vetor;
        }


        static private void quicksort(int[] vetor, int inicio, int fim)
        {
            int part;
            

            if(inicio < fim)
            {
                part = calculaPart(vetor, inicio, fim);
                quicksort(vetor, inicio, part - 1);
                quicksort(vetor, part + 1, fim);
            }

            
            //quickSort(vetor, inicio, fim);

            
        }

        static private int calculaPart(int[] vetor, int inicio, int fim)
        {
            int aux;
            int pivo = vetor[fim];
            int part = inicio - 1;

            for(int i = inicio; i <= fim - 1; i++)
            {
                if(vetor[i] < pivo)
                {
                    part++;

                    aux = vetor[part];
                    vetor[part] = vetor[i];
                    vetor[i] = aux;
                }
            }

            aux = vetor[part + 1];
            vetor[part + 1] = vetor[fim];
            vetor[fim] = aux;

            return part + 1;

        }


    }
}
