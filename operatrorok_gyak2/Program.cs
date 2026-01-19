namespace operatrorok_gyak2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             olyan class ami egész számokat tárol egy listában, egy tömböt átadva, listában tarolja, az operatoroknal az objektumokat összeadjuk akkor a
            listakat fuzze össze, ha szamot akkor fuzze hozza a lisahoz azt a szamot, ha szamhoz adjuk hozza akkor a lista összeget adja a szamhoz, kivonás, objektumból
            másik objektum, a masodik objektum szamainak eltavolitasa az elso listából, ha tobb van az elsoben akkor csak 1db ot vegyen ki, ha szamot vonunk ki akkor azt a szamot
            törölje ki az elso olyan szamot objektumból, ha szambol akkor a lista összeget, szorzas, ha két objektumot összeszorzunk, akkor a lista elemeit szorozza össze, ha valamelyik
            nem egyforma hosszu akkor ott ne legyen elem, ha szammal szorozzuk akkor a lista minden elemet megszorozzuk azzal a szammal, ha szamot szorzunk akkor az összegel
            (lista elemeinek összegével) szorozzuk meg
            */

            SzamLista a1 = new SzamLista(new List<int>() { 1, 16, 13, 26, 1 });
            SzamLista a2 = new SzamLista(new List<int>() { 1, 1, 5, 13, 1 });
            //Tesztelés
            //Összeadás obj+obj
            Console.WriteLine(String.Join(" ",(a1+a2).szamok));


            SzamLista kivon = a1 - a2;
            Console.WriteLine(String.Join(' ',kivon.szamok));

        }
    }
}
