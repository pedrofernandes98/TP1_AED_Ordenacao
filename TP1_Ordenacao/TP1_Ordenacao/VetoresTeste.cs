using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Ordenacao
{
    class VetoresTeste
    {
        public int[] VetorAleatorio;
        public int[] VetorCrescente;
        public int[] VetorDescrescente;

        public VetoresTeste(int tamanho)
        {
            preencheVetorAleatorio(tamanho);
            preencheVetorCrescente(tamanho);
            preencheVetorDecrescente(tamanho);
            //VetorCrescente = new int[tamanho];
            //VetorDescrescente = new int[tamanho];


        }

        public void preencheVetorAleatorio(int tamanho)
        {
            VetorAleatorio = Database.retornaVetorDadosComTamanho(tamanho);
        }

        public void preencheVetorCrescente(int tamanho)
        {
            VetorCrescente = Database.retornaVetorOrderCrescente(tamanho);
        }

        public void preencheVetorDecrescente(int tamanho)
        {
            VetorDescrescente = Database.retornaVetorOrderDecrescente(tamanho);
        }

        //public int[] preencheVetorDescrescente(int[] vetor)
        //{
        //    int[] vetorDecrescente = new int[vetor.Length];

        //    for(int i=0;i < vetor.Length; i++)
        //    {
        //        vetorDecrescente[vetor.Length - 1 - i] = vetor[i];
        //    }

        //    return VetorDescrescente;
        //}





    }
}
