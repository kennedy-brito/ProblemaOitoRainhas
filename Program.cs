using static System.Console;

// conta a quantidade de soluções
int numSolucoes = 0;
// número de rainhas
const int NUM_RAINHAS = 8;

// tabuleiro
int[][] tab = new int[NUM_RAINHAS][];

// iniciando o tabuleiro
for (int i = 0; i < tab.Length; i++)
{
  tab[i] = new int[NUM_RAINHAS];
}

resolver(tab, 0);

/// <sumario> 
///   função recursiva que tenta por força bruta encontrar as soluções
///   
/// </sumario> 
/// <param name="tab">matriz que representa o tabuleiro</param>
/// <param name="coluna">coluna em que a peça deve ser inserida</param>
/// <returns></returns>
void resolver(int[][] tab, int coluna)
{
  //não existem mais colunas para tentar
  if (coluna == tab.Length)
  {
    numSolucoes++;
    WriteLine($"===========SOLUÇÃO {numSolucoes}============");
    mostrarTabuleiro(tab);
    WriteLine($"=================================\n");
    return;
    //Pausa para conferir a solução
    // ReadKey();
  }

  //percorre cada linha e tenta inserir em uma das colunas
  //para isso ele verifica se a posição é segura
  for (int i = 0; i < tab.Length; i++)
  {
    if (ehSeguro(tab, i, coluna))
    {

      //inseri uma rainha na posição, 1 representa uma rainha
      tab[i][coluna] = 1;

      //tenta a próxima coluna
      resolver(tab, coluna + 1);

      //desfaz a movimentação da rainha
      tab[i][coluna] = 0;

    }
  }

}

/// <sumario> 
///   exibe o tabuleiro
/// </sumario> 
/// <param name="tab">matriz que representa o tabuleiro</param>
/// <returns>nada</returns>

void mostrarTabuleiro(int[][] tab)
{
  foreach (var linha in tab)
  {
    foreach (var casa in linha)
    {
      if (casa == 1)
      {
        Write($"| R ");

      }
      else
      {
        Write($"|   ");

      }
    }
    Write("|");
    WriteLine();

  }
}

/// <sumario> 
///   verifica se a posição do tabuleiro é segura
///   ela não é segura se:
///     existe uma rainha na posição
///     existe uma rainha na mesma linha, coluna
///     ou diagonais
/// </sumario> 
/// <param name="tab">matriz que representa o tabuleiro</param>
/// <param name="linha">linha que deve ser verificada</param>
/// <param name="coluna">coluna que deve ser verificada</param>
/// <returns>um booleano informando se a posição é segura</returns>
bool ehSeguro(int[][] tab, int linha, int coluna)
{
  int i, j;

  //verifica a linha
  for (i = 0; i < tab.Length; i++)
  {
    if (tab[linha][i] == 1)
    {
      return false;
    }
  }

  //verifica a coluna
  for (i = 0; i < tab.Length; i++)
  {
    if (tab[i][coluna] == 1)
    {
      return false;
    }
  }

  //verifica a diagonal principal da posição
  //acima e abaixo
  for (i = linha, j = coluna; i >= 0 && j >= 0; i--, j--)
  {
    if (tab[i][j] == 1)
    {
      return false;
    }
  }
  for (i = linha, j = coluna; i < tab.Length && j < tab.Length; i++, j++)
  {
    if (tab[i][j] == 1)
    {
      return false;
    }
  }

  //verifica a diagonal secundaria acima e abaixo
  for (i = linha, j = coluna; i >= 0 && j < tab.Length; i--, j++)
  {
    if (tab[i][j] == 1)
    {
      return false;
    }
  }
  for (i = linha, j = coluna; i < tab.Length && j >= 0; i++, j--)
  {
    if (tab[i][j] == 1)
    {
      return false;
    }
  }

  return true;
}
