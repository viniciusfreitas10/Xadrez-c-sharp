using tabuleiro;

namespace xadrez
{

    class Cavalo : Peca
    {

        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "C";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            pos.DefinirValores(posicao.linha - 1, posicao.Coluna - 2);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.Coluna] = true;
            }
            pos.DefinirValores(posicao.linha - 2, posicao.Coluna - 1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.Coluna] = true;
            }
            pos.DefinirValores(posicao.linha - 2, posicao.Coluna + 1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.Coluna] = true;
            }
            pos.DefinirValores(posicao.linha - 1, posicao.Coluna + 2);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.Coluna] = true;
            }
            pos.DefinirValores(posicao.linha + 1, posicao.Coluna + 2);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.Coluna] = true;
            }
            pos.DefinirValores(posicao.linha + 2, posicao.Coluna + 1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.Coluna] = true;
            }
            pos.DefinirValores(posicao.linha + 2, posicao.Coluna - 1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.Coluna] = true;
            }
            pos.DefinirValores(posicao.linha + 1, posicao.Coluna - 2);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.Coluna] = true;
            }

            return mat;
        }
    }
}