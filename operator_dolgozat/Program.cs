using System.Runtime.Intrinsics.X86;

namespace operator_dolgozat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Jelenetünk főszereplője Jürgen, az osztrák kőműves.
            Jürgen rendelkezik egy pénztárcával, amiben van valamennyi pénz.Néha megjelenik nála a fia, Hansi, aki szeretné a zsebpénzét készpénzben(nem pénztárcába) megkapni(Jürgenek ennyivel kevesebb pénze marad).
            A család egyszer hivatalos lett egy lakodalomba, ahol a kézpénzes ajándékokat növelték egy tömött briftasnival.
            Nem sokkal ezután Jürgen testvére, Günter hatalmas(készpénz) adósságba keveredett, és Jürgen ezt az adósságot csökkentette egy pénztárcával.*/

            Penztarca jurgenPenztarca = new Penztarca(1000);
            Penztarca frauPenztarca = new Penztarca(500);
            int hansiZseb = 800;
            //Jürgen rendelkezik egy pénztárcával, amiben van valamennyi pénz.Néha megjelenik nála a fia, Hansi,
            //aki szeretné a zsebpénzét készpénzben(nem pénztárcába) megkapni(Jürgenek ennyivel kevesebb pénze marad).
            jurgenPenztarca = jurgenPenztarca - hansiZseb;
            /*Frau Maria is rendelkezik pénztárcával, ami a hiteleket gyűjti, és a férjének kell kifizetnie(a férjnek kevesebb lesz). Ha több a tartozás, mint a pénz, akkor baj van, jön a veszekedés, és a törlesztés későbbre halasztása.
            A munkák során kőművesünknek fizetni is szoktak, néha készpénzzel, néha teli bukszával(pénztárcával).*/
            if (jurgenPenztarca < frauPenztarca)
            {
                Console.WriteLine("TE HITVÁNYSÁG");
            }
            else
            {
                frauPenztarca = jurgenPenztarca - frauPenztarca;
            }




        }
    }
}
