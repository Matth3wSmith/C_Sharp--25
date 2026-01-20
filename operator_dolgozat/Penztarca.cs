using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operator_dolgozat
{
    internal class Penztarca
    {
        /*Jelenetünk főszereplője Jürgen, az osztrák kőműves.
        Jürgen rendelkezik egy pénztárcával, amiben van valamennyi pénz.
        Néha megjelenik nála a fia, Hansi, aki szeretné a zsebpénzét készpénzben (nem pénztárcába) megkapni (Jürgenek ennyivel kevesebb pénze marad). => kivonás (jürgenPenztaraca-HansiPenztarca)
        Frau Maria is rendelkezik pénztárcával, ami a hiteleket gyűjti, és a férjének kell kifizetnie (a férjnek kevesebb lesz) (FrauPenztarca+JurgenPenztarca).(>) Ha több a tartozás, mint a pénz, akkor baj van, jön a veszekedés, és a törlesztés későbbre halasztása.
        
        A munkák során kőművesünknek fizetni is szoktak, néha készpénzzel, néha teli bukszával (pénztárcával).
        A család egyszer hivatalos lett egy lakodalomba, ahol a kézpénzes ajándékokat növelték egy tömött briftasnival.
        Nem sokkal ezután Jürgen testvére, Günter hatalmas (készpénz) adósságba keveredett, és Jürgen ezt az adósságot csökkentette egy pénztárcával.*/
        double osszeg;
        public Penztarca(double osszeg)
        {
            this.osszeg = osszeg;
        }
        //Néha megjelenik nála a fia, Hansi, aki szeretné a zsebpénzét készpénzben(nem pénztárcába) megkapni(Jürgenek ennyivel kevesebb pénze marad).
        //=> kivonás(jürgenPenztaraca-hnasiPenz)
        static public Penztarca operator -(Penztarca a1, int a2)
        {
            a1.osszeg -= a2;
            Penztarca a3 = new Penztarca(a1.osszeg);
            return a3;
        }
        //Frau Maria is rendelkezik pénztárcával, ami a hiteleket gyűjti, és a férjének kell kifizetnie (a férjnek kevesebb lesz) (FrauPenztarca+JurgenPenztarca).
        //(>) Ha több a tartozás, mint a pénz, akkor baj van, jön a veszekedés, és a törlesztés későbbre halasztása.
                                            
        static public Penztarca operator -(Penztarca a1, Penztarca a2)
        {
            return new Penztarca(a1.osszeg-a2.osszeg);

        }
        static public bool operator <(Penztarca a1, Penztarca a2)
        {
            return a1.osszeg < a2.osszeg;

        }
        static public bool operator >(Penztarca a1, Penztarca a2)
        {
            return a1.osszeg > a2.osszeg;
        }
        //A munkák során kőművesünknek fizetni is szoktak, néha készpénzzel, néha teli bukszával(pénztárcával).
        static public Penztarca operator +(Penztarca a1, Penztarca a2)
        {
            return new Penztarca(a1.osszeg+a2.osszeg);
        }
        static public Penztarca operator +(Penztarca a1, int a2)
        {
            return new Penztarca(a1.osszeg+a2);
        }

        static public Penztarca operator -(int a1, Penztarca a2)
        {
            return new Penztarca(a1-a2.osszeg);
            
        }
    }
}
