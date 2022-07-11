using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez partida;
        public Rei(Tabuleiro tab, PartidaDeXadrez partida, Cor cor) : base(tab, cor)
        {
            this.partida = partida;
        }
        public override string ToString()
        {
            return "R";
        }
        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }
        private bool testeTorreParaRoque(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p is Torre && p.cor == cor && p.qtdeMovimentos == 0;
        }
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            // acima
            pos.DefinirValores(posicao.linha - 1, posicao.Coluna);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.Coluna] = true;
            }
            // ne
            pos.DefinirValores(posicao.linha - 1, posicao.Coluna + 1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.Coluna] = true;
            }
            // direita
            pos.DefinirValores(posicao.linha, posicao.Coluna + 1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.Coluna] = true;
            }
            // se
            pos.DefinirValores(posicao.linha + 1, posicao.Coluna + 1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.Coluna] = true;
            }
            // abaixo
            pos.DefinirValores(posicao.linha + 1, posicao.Coluna);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.Coluna] = true;
            }
            // so
            pos.DefinirValores(posicao.linha + 1, posicao.Coluna - 1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.Coluna] = true;
            }
            // esquerda
            pos.DefinirValores(posicao.linha, posicao.Coluna - 1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.Coluna] = true;
            }
            // no
            pos.DefinirValores(posicao.linha - 1, posicao.Coluna - 1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.Coluna] = true;
            }

            //jogada especial 
            #region
            if(qtdeMovimentos == 0 && !partida.xeque)
            {
                //roque pequeno
                Posicao posT1 = new Posicao(posicao.linha, posicao.Coluna + 3);
                if (testeTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.Coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.Coluna + 2);
                    if(tab.peca(p1) == null && tab.peca(p2) == null)
                    {
                        mat[posicao.linha, posicao.Coluna + 2] = true;
                    }
                }
                //roque grande
                Posicao posT2 = new Posicao(posicao.linha, posicao.Coluna - 4);
                if (testeTorreParaRoque(posT2))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.Coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.Coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.Coluna - 3);
                    if (tab.peca(p1) == null && tab.peca(p2) == null && tab.peca(p3) == null)
                    {
                        mat[posicao.linha, posicao.Coluna - 2] = true;
                    }
                }
            }
            #endregion
            return mat;
        }



    }

}
