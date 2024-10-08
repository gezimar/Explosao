namespace Explosao;
using System.Threading;

class Program
{
    static int N=11;
    static int [,] matriz = new int [N,N];
    static int IntenInicial = 5;

    static void PropagarExplosao (int x, int y, int intensidade){
        if (intensidade <= 0 || x<0 ||x>=N || y<0||y>=N)
            return;
        if (matriz[x, y] < intensidade)
        matriz[x, y] = intensidade;

        Thread[] threads= new Thread[4];
        threads[0] = new Thread(()=>PropagarExplosao(x+1,y,intensidade-1));
        threads[1] = new Thread(()=>PropagarExplosao(x-1,y,intensidade-1));
        threads[2] = new Thread(()=>PropagarExplosao(x,y+1,intensidade-1));
        threads[3] = new Thread(()=>PropagarExplosao(x,y-1,intensidade-1));

        foreach (var thread in threads){
            thread.Start();
        }

        foreach(var thread in threads){
            thread.Join();
        }
    }
    static void Main(string[] args)

    {
        int x=5, y=5;

        PropagarExplosao(x,y,IntenInicial);
        for (int i=0; i < N; i++){
            for(int j=0;j<N;j++){
                Console.Write(matriz[i,j]+"\t");
            }
            Console.WriteLine();
            
        }
    }
}
