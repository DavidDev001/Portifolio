using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aula_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Matrix é muito comparada ao Plano Cartesiano 

            /* Variáveis */
            string jogador, inimigo, inimigo2,inimigo3;
            string desafio;
            string[,] cenario; // Matrix de 2 dimensões
            bool vitoria;

            int x, y; // Variáveis para definirmos onde irá começar 
            int x1, y1; // Variaveis para definirmos onde irá começar
            int x2, y2;
            int x3, y3;

            /* Instruções (Teclado + Comando) */
            ConsoleKeyInfo teclado; // Comando do Teclado
            string comando; // Para podermosa armazenar os comandos nesta variável
            Random aleatorio;
            Random aleatorio2;
            Random aleatorio3;
            int sorte;
            int sorte2;
            int sorte3;

            /* Inicializar a Variável */

            jogador = "C";
            inimigo= "+";
            inimigo2= "O";
            inimigo3= "O";
            vitoria = false; // começa com uma condição, nesse caso tem que ser falço porque o
                             // objetivo é ganhar então o Verdadeiro seria o Ganhar, então ele
                             // tem que começar com falso para ele poder ganhar.

            desafio = "+";

            /* Vetor ou Matrix */
            cenario = new string[10,10 ] // Criação da Fase(Cenário)
            {
                //0   1   2   3   4   5   6   7    8   9               10 colunas 
                {"#","#","#","#","#","#","#","#","#","#"}, // 0      10 linhas 
                {"#"," "," "," "," "," "," "," "," ","#"}, // 1
                {"#"," "," "," "," "," "," "," "," ","#"}, // 2
                {"#"," "," "," "," "," "," "," "," ","#"}, // 3
                {"#"," "," ","_"," "," "," ","_"," ","#"}, // 4
                {"#"," "," ","|"," "," "," ","|"," ","#"}, // 5
                {"#"," "," ","|"," ","_"," ","|"," ","#"}, // 6
                {"#"," "," "," "," "," "," "," "," ","#"}, // 7
                {"#"," "," "," "," "," "," "," "," ","#"}, // 8
                {"#","#","#","#","#","#","#","#","#","#"}, // 9

            };

            x = 1;
            y = 1;
            x1 = 6;
            y1 = 8;
            x2= 4;
            y2 = 8;
            x3 = 8;
            y3 = 4;

            /* Fluxo de Dados */
            /* Entrada <=> Processamento <=> Saída */

            Console.Title = "Nome do meu jogo";
            Console.WriteLine("Tecle 'I' para Iniciar o Jogo");
            comando = Console.ReadLine();
            //exibe cena 0
            ExibeCena(6);
            ExibeCena(0);
            ExibeCena(1);
            ExibeCena(3);

            /* Execução Durante o Jogo, estrutura de Repetição (Gameplay) */
            do
            {
                
                //Define o valor inicial para o aleatorio (sorte)
                //Inicializa o objeto randomico (instancia)
                aleatorio = new Random();
                aleatorio2 = new Random();
                aleatorio3 = new Random();
                //configurar

                //armaznar o valor sorteado
                sorte = aleatorio.Next(2, 8);
                sorte2 = aleatorio.Next(4, 7);
                sorte3 = aleatorio.Next(3, 6);

                //Exibir o jogador
                cenario[y, x] = jogador;

                cenario[sorte, sorte] = inimigo;
                cenario[sorte2, sorte2] = inimigo2;
                cenario[sorte3, sorte3] = inimigo2;
              
                /* Limpando a Tela Inicial */
                Console.Clear();

                /* Inicia (instância) o objeto do Teclado */
                teclado = new ConsoleKeyInfo();

                /* Verifica se a Tecla for Igual a I, para Iniciar o Jogo */
                if (comando.ToUpper() == "I") // ToUpper é um SubMétodo(), ele converte a Letra que o Usuário digitou em Maísculo
                {

                    /* Limpa Tela */
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    // Condição de vitoria
                    // Encerra o jogo
                    if (cenario[sorte, sorte] == cenario[y, x])
                    {
                        Console.Clear();
                        ExibeCena(4);
                        Console.WriteLine("Meus parabens guerreiro voce capturou os fantasmas!!!Aperte enter para jogar novamente!!");
                    }
                    else if (cenario[sorte2, sorte2] == cenario[y, x] || cenario[sorte3, sorte3] == cenario[y, x])
                    {
                        Console.Clear();
                        ExibeCena(5);
                        Console.WriteLine("Nao deu para voce");
                    }  

                    /* Exibir o Cenário */
                    // Lê as linhas pois invertemos(y) e as colunas(x) da Matriz
                    for (int linha = 0; linha < 10; linha++) // Chamando o Cenário = as Linhas
                    {
                        for (int coluna = 0; coluna < 10; coluna++)// Chamando o Cenário = as colunas
                        {
                            /* Exibe a informação da Coluna */
                            Console.Write(cenario[linha, coluna]);
                            }

                        /* Ir para a próxima Linha */
                        Console.WriteLine();
                    }
                    Console.ForegroundColor = ConsoleColor.Green;

                    /* Exibe Menu de Comandos para Personagem */
                    Console.WriteLine("Comandos");
                    Console.WriteLine("(W) => Para Cima");
                    Console.WriteLine("(S) => Para Baixo");
                    Console.WriteLine("(A) => Para Esquerda");
                    Console.WriteLine("(D) => Para Direita");
                    Console.WriteLine("(Esc) => Para Sair");
                    Console.WriteLine("Tecle o Comando: ");
                    //Obtem a tecla do teclado informado
                    teclado = Console.ReadKey(); // Para pegar o comando que o Usuário digitou

                    //Verificar a tecla informada

                    cenario[sorte, sorte] = " ";
                    cenario[sorte2, sorte2] = " ";
                    cenario[sorte3, sorte3] = " ";

                    switch (teclado.Key)
                    {
                        case ConsoleKey.W:
                            if (cenario[y - 1, x ] != "#" && cenario[y - 1, x] != "|" && cenario[y - 1, x] != "_" )
                            {
                                
                                //Limpa o movimento anterior
                                cenario[y, x] = " ";
                                y--;
                            }
                            break;
                        case ConsoleKey.S:
                            if (cenario[y + 1, x ] != "#" && cenario[y + 1, x] != "|" && cenario[y + 1, x] != "_")
                            {
                                cenario[y, x] = " ";
                                y++;
                            }
                            break;

                        case ConsoleKey.A:
                            if (cenario[y ,x - 1 ] != "#" && cenario[y, x - 1] != "|" && cenario[y, x - 1] != "_")
                            {
                                cenario[y, x] = " ";
                                x--;
                            }
                            break;

                        case ConsoleKey.D:
                            if (cenario[y , x + 1 ] != "#" && cenario[y, x + 1] != "|" && cenario[y, x + 1] != "_")
                            {
                                cenario[y, x] = " ";
                                x++;
                            }
                            break;

                        default:
                            Console.WriteLine("Comando invalido tente novamente!");
                            Console.ReadKey();
                            break;

                    }
                }
                else
                {

                    Console.WriteLine("Digite a teacla (ESQ) para Sair! e " + "\nTente Novamente");
                    teclado = Console.ReadKey();

                }
                Console.ReadKey();
                if (cenario[sorte, sorte] == "O" || cenario[sorte2, sorte2] == "+" || cenario[sorte3, sorte3] == "+")
                {
                    cenario[sorte, sorte] = "O";
                    cenario[sorte3, sorte3] = "+";
                    cenario[sorte2, sorte2] = "+";
                }
            }
            while (teclado.Key != ConsoleKey.Escape); // pegando a tecla do Teclado que o Usuário irá digitar desde que seja igual ao Esque

        }

        static void ExibeCena(int codigoCena)
        {
            //Verifica a cena 
            switch (codigoCena)
            {
                default:
                    Console.WriteLine("cena invalida");
                    break;

                case 0:
                    Console.Clear();
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.BackgroundColor= ConsoleColor.Black;
                    Console.Write("             ..............               \r\n           ...,,****////******,,..           \r\n         ..,**//#@&########@@(//*,,..        \r\n       ..,**/@#(*,,*,**#########@/**,.       \r\n      ..,*(&#,,,,,(###############@/*,..     \r\n      .,*@#/**,/@@%#################@*,.     \r\n     .,*@##,,@    @@#######%      ,##%,,.    \r\n    ..,*@#,,,/       ######@@@     @#@*,.    \r\n    ..,*@#,,,*&,   @########&    ,&#/@*,..   \r\n    .,*/@#,,,*######################*@*,..   \r\n    .,*/&#,,,,#####################,*@/,,.   \r\n    .,*/&#*,,,####################,*#@**,.   \r\n    .,*/&##*,*###################,,,#@/*,.   \r\n    .,*/&#########################,,#@**,.   \r\n    ..,/@####&#######@@@%######%@@###@*,..   \r\n    ..,*@#@(///@&#%@*/***/@##@(*///@%@,,.    \r\n      .,,,,,,,,,,,......................     \r\n         ..       ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Jogo falcificado do pac man !!");
                    Console.ReadKey();  
                    break;

                case 1:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("                          ,&                                         \r\n                                  /***&*****&/%.                                \r\n                               **(&&*****/*****&/*.                             \r\n         ..                 ***%&&&/*****(&**********                           \r\n        */(##             ******%&/*****&************//                         \r\n         ./*///((#/      ****%&&%***,*/&**************//.                       \r\n         //////((##%    ***********//*(/*************////                       \r\n         ///////(##%%  .@@*******((((*,,,************///**                      \r\n          //////(##%%  ,&@@@@@&**********************/*//*                      \r\n          .(((((#%%%/  ,*@@@@@@@%%&@@@@@@@@@@@@@%**/////******                  \r\n            ##%%%%%(////**@&@@(((((######%@@@@@**////(((/,*****                 \r\n                         ,**&&&#(/////((#&&@&*/////((((##((/(/                  \r\n                           *****&@@@@@&@#/*//////(((((///((#%%(                 \r\n                             ,///////////////((((((((/////(##.                  \r\n                                ,/(((((((((((((/((((/////(#%/                   \r\n                                 ***/(   ***// (%#((((/(##%%#                   \r\n                                 *////%%/./*///&%%.#%#####%#                    \r\n                               ,###(#%%&%%##((##%%,    .*.                      \r\n                                (####%%%&#########%                             \r\n                          /(#######(#%%%%%#((######(                            \r\n                        ##(((((((######%%#(((((((((##,                          \r\n                       /(((//(((#####%%%%((/////((((##,.....                    \r\n                       ,#((//((#%%%%%(/**#((////((####*,.... ");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("AHHHHH  Não podemos deixar os fantasmas escaparem me ajude !!");
                    Console.ReadKey();
                    break;

                    case 3:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("                                                            \r\n                                              .             \r\n                                            .               \r\n.                                                           \r\n                         .                           .      \r\n            /%%,**,,,,***,*%#/                              \r\n        .%******,***,*******,***%,                          \r\n      %/*..******,#%,************,/%                        \r\n    %/***********%%%%***********,***%%                    . \r\n   %****************************%#                          \r\n  #*************************%#        .,           ,        \r\n  &*********************%%         /(*(////.   ./*.,***#    \r\n  #****************//%.            %((%/(&(%   %/*%**#(#    \r\n  %*/**************/****&%         %#((((((& . %(/*/***#    \r\n  (/////*//*****/*////******%%.    %#%###&#%   %(%#((%(%    \r\n   %*///////*/////////////////**%&                    .     \r\n  . *%//////////////////////////////%*.                     \r\n      (%//////////////////////////%#                        \r\n    .    %#(///////////////////#&.                          \r\n  .          %%%*/////////%%% .                            .\r\n                                                            \r\n           .                                                \r\n                                                            \r\n                                                            \r\n");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Vou capturar vocés ahhhhhh");
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                   /,@*                                                               \r\n                                                                                                                                                      \r\n             %&#.,,,%&@    %&#/%%&& /@% ,,.%&&( *&%&%&%&# ,, #&%&&&&&*     .,.*#((/*/      %&*,,,,&&%//*((    (@% ,, %@&*       #&/ .. &              \r\n                * . (        /(&           @                 %             . @     *//(,     . . */   **(((          &           . .  % @             \r\n                 ,   #      /*@            &                 %               @     ,////     .   */  . *((#          &               % . (            \r\n                  *@@#&    ,(&,        *@@&&             *@@#%           /@@(@     ,///(.    *&@@.     (@(       *@@#%          /@@%%    (.           \r\n                   .   &, ,**#/,     ,*/  .,*.         ,,/  *,.        (@.,,(%(   ,@    (  .#*. ./(.   *((@    .,/  ,,,      (** ,./,  ,(,%/          \r\n                   ,,*,., ,,.&          ,*,*              ,*,#           @ **,     @#  .@    .,**.*   ,/((%,      ,*,#        ** ,#      **(          \r\n                    ,      .@         ,.   .#           *.  .,(           %  (&#%@*   ,@.   .,   .(     //*     *.  .,#   //..   ,*,    *(.//,        \r\n                  .*(%@@@@.../       @/&@@(  (.        @*@@@(  #            %@/**/&&  %    #(#@@@. ,(/* #. **  @/&@@/  #   #&&@@*@&       @@@*        \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                    .                                                                 \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Voce ganhou meus parabens. Aperte enter e + uma tecla de movimentação para joga novamente");
                    Console.ReadKey();
                    break;

                    case 5:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                      .////.                                                          \r\n                                                                                    */(%%.                                                            \r\n                /((##(       .(((/             ,///////*****.   .,**       ,***  (/((((/((((##/        .#%%%/      #%%%(                              \r\n               (///(##%       ,,,/.          .,,.,.,.   .,....  ..,,       .,,.  ##(#                  ###%(#     /##((#                              \r\n              #(#(#%%%(%     ,%%%#.         (((((           //. ,*//       ,///  ((((                 (((##%%&   (%%%%%%&                             \r\n             ,.,.,..***,/     ....         .....     .........  ..,,       ....  ,,,,,,,,,,,,,.       ,//////(/ .*/(/(((#/                            \r\n            /*(*((((((((*#   .//((.        ,,*/*     ,********. ,///       ,//*  ((((*********,      //((,./(((*####,(#%#%*                           \r\n          .**,,*.    .***,/  .****          */**,         ,,**  .,//       ,//*  (///               ////,  ,*((((##*  #*##%.                          \r\n         .***.,.      .,,,.* .,,.,.          ,,.,..       ..,,   ....      ...   ,..,               ....    .......    ...,.                          \r\n        /%%%#&,         **//&*(///****//////#  .///(////((((((.   ,(((((((((*    (/**/////(((/*   .(//(.     (//##.    %%%%%(                         \r\n                                                                                                                                                      \r\n                                     /**//(/(/////.  ,***/////////  *//////////*    *////////////,     ,/**,*/(######   (/(//     .(///*              \r\n                                     ..,.,     ,,... ,**,           .,**     ,****  /*/(      ,*****,   ....            (//*/     ./*///              \r\n                                     ****.     .***, .,,,           ..,,      ,,,,. ,***         ***** .****            *,,,*      *,**,              \r\n                                     //*,,*//////*/  *(/**********  */(/(((((//((*  /((/          ((((*,((/////(##%%%   %/###     .%#%%(              \r\n                                     ,,,,,.......    ....           *//////////.    *///          *///.,////            (*/((     .(///*              \r\n                                     /(((/           *///           *(// //(//      ///(         ///// .((((            (((##     .#(##/              \r\n                                     ,***,           ,///           *((/   /((((.   /(((/***/((((#(#,  ,#(((/*/(((#(*    *%##%/ *###((%               \r\n                                     */((*           ,************  /(((     ,((((. /((((((//**/**     .########%%%&%      .*(#%%%%%/.                \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n                                                                                                                                                      \r\n");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Infelismente nao conseguiu pegar o fantasma a tempo de ser pego pelo O, tente novamente!!!");
                    Console.ReadKey();
                    break;

                    case 6:
                    Console.ForegroundColor= ConsoleColor.Magenta;
                    Console.Write("\r\n.......................... ...................................................... .........              \r\n,             .,                    .,  .                 ..                    , .       /.             \r\n.      . ,.. ., (,.,,...,* .*..,.. .. (,.,*,..,, .,,.,,. .. /..,/..,.. ,,,.,,..../*,      /.             \r\n.    ..  .           .                                                           ...      /.             \r\n.  .,,/..                                                                       . ,.,    ./.             \r\n.    .,.         .                                                                 ,      /.             \r\n.       (          /(/.                  ,..,,     ..,..,,   ..         ,         .,      /.             \r\n.     ,           &* &           .        #@. .@(   &%   *   /@/       @&         ,       /.             \r\n,   .,*.          ,&,    ., ..   ,        #@, #&    &%       %(@%    .&*@          .,    ./,             \r\n.      ..       ,/(. .&.@(/ &/.@//@ .     #@.  %@*  &%   *   @  @@  *% .@,        .*.     /.             \r\n.      .#*    ,%     (@     @.            #@,   @@  &%      *%   @@#(   @%       (,/      /,             \r\n,     ,           .. .   / (/            *@&@&&/   #@@@&&& *&@#   ,*    @&&*       *.     /,             \r\n.   ,./.                                                                          ..,    ./.  \r\n.     ,.      .((//.    *((/ *///   .       .,.. /(///((/.        ,#&&@#.         .*     ./.             \r\n.       /        @@     .@    %&   ,@@#      ##   &@      %@/  /@.      .@#       .,     ./.             \r\n.     ,           @&   .@     %&   ,% *@@.   ##   &@       ,@(*@,         @(      ..     ./.             \r\n,   .,*,           &% ,&      %&   ,&   .&@, ##   &@       .@/*@(         @(       .*     (,\r\n,       .           &@%       %&   ,@      %@@(   &@      .@/  .@#       @#      ..(      /,      \r\n,      ./,           (       ****.,/*/.      .,  ,*/((((*.        ,/##/,         ,**      (,             \r\n.    ,,.                                                                         . /.     (,          \r\n.   ,,*   .                                                                        .,     (,          \r\n.    .,..            ,                     ,      .              ,                *,      /.          \r\n.       *   * ,,*.  ,.*,.,.,, ,. ./ .,,.  . /, *.., ,.  / ..,. .. (, ,,., ,, .*..,,,.     /.          \r\n.                              .                   .                       .              /.          \r\n.*/((((((((((((////(((((((((/((/(((((((((/////////////((((((((((((/////((((((((/////////(/*. \r\n                                       ");
                    Console.ReadKey ();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Bem vindo ao jogo PacFauce você tera que pegar o simbolo do + para poder ganha o jogo");
                    Console.ReadKey ();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("E não pode deixa a letra O te pegar pois você perdera o jogo");
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("O simbolo do + representa os (Fantasmas) e o O os do  (Guardiões) do fantasma");
                    Console.ReadKey ();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("O Fantasma em dado momento do jogo pode esconder o Guardião você pode aproveitar dessa brecha, tome cuidado pois vc pode perde o jogo seja esperto e pegue o Fantasma antes que os Guardiões te peguem bom jogo");
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Tem locais no mapa que facilita você a pegar o Fantasma ah e tome cuidado que os Guardiões podem esconder o fantasma tbm porem eles ficom vuneraveis.");
                    Console.ReadKey();
                    break;
            }
        }

    }
}
