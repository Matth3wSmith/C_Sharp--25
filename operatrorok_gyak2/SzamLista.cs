using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace operatrorok_gyak2
{
    /*
    olyan class ami egész számokat tárol egy listában, egy tömböt átadva, listában tarolja, 
    az operatoroknal:
        az objektumokat összeadjuk akkor a listakat fuzze össze, 
        ha szamot akkor fuzze hozza a lisahoz azt a szamot, 
        ha szamhoz adjuk hozza akkor a lista összeget adja a szamhoz, 
        kivonás, objektumból másik objektum, a masodik objektum szamainak eltavolitasa az elso listából, ha tobb van az elsoben akkor csak 1db ot vegyen ki, 
        ha szamot vonunk ki akkor azt a szamot törölje ki az elso olyan szamot objektumból, 
        ha szambol akkor a lista összeget, 
        szorzas, ha két objektumot összeszorzunk, akkor a lista elemeit szorozza össze, 
            ha valamelyik  nem egyforma hosszu akkor ott ne legyen elem, 
        ha szammal szorozzuk akkor a lista minden elemet megszorozzuk azzal a szammal, 
        ha szamot szorzunk akkor az összegel (lista elemeinek összegével) szorozzuk meg
    */
    internal class SzamLista
    {
        public List<int> szamok;
        public SzamLista(List<int> szamok)
        {
            this.szamok = szamok;
        }
        //az objektumokat összeadjuk akkor a listakat fuzze össze, 
        public static SzamLista operator +(SzamLista a1, SzamLista a2)
        {
            List<int> ujSzamok = new List<int>(a1.szamok);
            return new SzamLista(ujSzamok.Concat(a2.szamok).ToList());
        }
        //ha szamot akkor fuzze hozza a lisahoz azt a szamot
        public static SzamLista operator +(SzamLista a1, int a2)
        {
            List<int> ujSzamok = new List<int>(a1.szamok);
            ujSzamok.Add(a2);
            return new SzamLista(ujSzamok);
        }
        //ha szamhoz adjuk hozza akkor a lista összeget adja a szamhoz
        public static int operator +(int a1, SzamLista a2)
        {
            return a1 + a2.szamok.Sum();
        }
        //kivonás, objektumból másik objektum, a masodik objektum szamainak eltavolitasa az elso listából, ha tobb van az elsoben akkor csak 1db ot vegyen ki
        public static SzamLista operator -(SzamLista a1, SzamLista a2)
        {
            List<int> ujSzamok = new List<int>(a1.szamok);
            ujSzamok = ujSzamok.Except(a2.szamok).ToList();
            return new SzamLista(ujSzamok);

        }
        //ha szamot vonunk ki akkor azt a szamot törölje ki az elso olyan szamot objektumból,
        public static SzamLista operator -(SzamLista a1, int a2)
        {
            List<int> ujSzamok = new List<int>(a1.szamok);
            ujSzamok.Remove(a2);
            return new SzamLista(ujSzamok);
        }
        //ha szambol akkor a lista összeget
        public static int operator -(int a1, SzamLista a2)
        {
            return a1 - a2.szamok.Sum();
        }
        //szorzas, ha két objektumot összeszorzunk, akkor a lista elemeit szorozza össze, 
        //ha valamelyik  nem egyforma hosszu akkor ott ne legyen elem,
        public static SzamLista operator *(SzamLista a1, SzamLista a2)
        {
            List<int> b1 = new List<int>(a1.szamok);
            List<int> b2 = new List<int>(a2.szamok);
            //Ha első kisebb
            if (b1.Count < b2.Count)
            {
                //Kisebbet járjuk be
                return new SzamLista(b1.Select((x, i) => x * b2[i]).ToList());
            }
            //Ha második kisebb 
            else if (b1.Count > b2.Count)
            {
                return new SzamLista(b2.Select((x, i) => x * b1[i]).ToList());
            }
            else
            {
                return new SzamLista(b1.Select((x, i) => x * b2[i]).ToList());
            }
        }
        //ha szammal szorozzuk akkor a lista minden elemet megszorozzuk azzal a szammal
        public static SzamLista operator *(SzamLista a1, int a2)
        {
            List<int> ujszamok = new List<int>(a1.szamok);
            return new SzamLista(ujszamok.Select(x => x * a2).ToList());
        }
        //ha szamot szorzunk akkor az összegel (lista elemeinek összegével) szorozzuk me
        public static int operator *(int a1, SzamLista a2)
        {
            return a1*a2.szamok.Sum();
        }        


    }
}
