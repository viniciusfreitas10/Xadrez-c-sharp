using System;
namespace tabuleiro
{
    class Posicao
    {
        public int linha { get; set; }
        public int Coluna { get; set; }

        public Posicao(int linha, int coluna)
        {
            this.linha = linha;
            Coluna = coluna;
        }
        public override string ToString()
        {
            return linha + " , " + Coluna;
        }
        public void DefinirValores(int linha, int coluna)
        {
            this.linha = linha;
            this.Coluna = coluna;
        }
    }
}
