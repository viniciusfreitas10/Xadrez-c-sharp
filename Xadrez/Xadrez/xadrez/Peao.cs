using tabuleiro;

namespace xadrez
{

    class Peao : Peca
    {

        private PartidaDeXadrez partida;

        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool existeInimigo(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.cor != cor;
        }

        private bool livre(Posicao pos)
        {
            return tab.peca(pos) == null;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca)
            {
                pos.DefinirValores(posicao.linha - 1, posicao.Coluna);
                if (tab.PosicaoValida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.Coluna] = true;
                }
                pos.DefinirValores(posicao.linha - 2, posicao.Coluna);
                Posicao p2 = new Posicao(posicao.linha - 1, posicao.Coluna);
                if (tab.PosicaoValida(p2) && livre(p2) && tab.PosicaoValida(pos) && livre(pos) && qtdeMovimentos == 0)
                {
                    mat[pos.linha, pos.Coluna] = true;
                }
                pos.DefinirValores(posicao.linha - 1, posicao.Coluna - 1);
                if (tab.PosicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.Coluna] = true;
                }
                pos.DefinirValores(posicao.linha - 1, posicao.Coluna + 1);
                if (tab.PosicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.Coluna] = true;
                }

                // #jogadaespecial en passant
                if(posicao.linha == 3)
                {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.Coluna - 1);
                    if (tab.PosicaoValida(esquerda) && existeInimigo(esquerda) && tab.peca(esquerda) == partida.vulneravelEnPassant)
                    {
                        mat[esquerda.linha - 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(posicao.linha, posicao.Coluna + 1);
                    if (tab.PosicaoValida(direita) && existeInimigo(direita) && tab.peca(direita) == partida.vulneravelEnPassant)
                    {
                        mat[direita.linha - 1, direita.Coluna] = true;
                    }
                }
                
            }
            else
            {
                pos.DefinirValores(posicao.linha + 1, posicao.Coluna);
                if (tab.PosicaoValida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.Coluna] = true;
                }
                pos.DefinirValores(posicao.linha + 2, posicao.Coluna);
                Posicao p2 = new Posicao(posicao.linha + 1, posicao.Coluna);
                if (tab.PosicaoValida(p2) && livre(p2) && tab.PosicaoValida(pos) && livre(pos) && qtdeMovimentos == 0)
                {
                    mat[pos.linha, pos.Coluna] = true;
                }
                pos.DefinirValores(posicao.linha + 1, posicao.Coluna - 1);
                if (tab.PosicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.Coluna] = true;
                }
                pos.DefinirValores(posicao.linha + 1, posicao.Coluna + 1);
                if (tab.PosicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.Coluna] = true;
                }
                // #jogadaespecial en passant
                if (posicao.linha == 4)
                {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.Coluna - 1);
                    if (tab.PosicaoValida(esquerda) && existeInimigo(esquerda) && tab.peca(esquerda) == partida.vulneravelEnPassant)
                    {
                        mat[esquerda.linha + 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(posicao.linha, posicao.Coluna + 1);
                    if (tab.PosicaoValida(direita) && existeInimigo(direita) && tab.peca(direita) == partida.vulneravelEnPassant)
                    {
                        mat[direita.linha + 1, direita.Coluna] = true;
                    }
                }
            }

            return mat;
        }
    }
}