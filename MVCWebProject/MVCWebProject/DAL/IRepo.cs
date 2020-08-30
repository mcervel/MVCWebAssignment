using MatejCervelinMvcProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatejCervelinMvcProjekt.DAL
{
    public interface IRepo
    {
        List<Drzava> DohvatiDrzave();
        List<Grad> DohvatiGradove(int idDrzava);
        Drzava DohvatiDrzavu(int drzavaID);
        List<Kupac> DohvatiKupce(int idGrad);
        Grad DohvatiGrad (int gradId);
        IEnumerable<RowForTableRacun> DohvatiRacune(int idKupac);
        IEnumerable<RowForTableStavka> DohvatiStavke(int idRacun);
        void AzurirajDrzavu(Drzava drzava);
        void AzurirajGrad(Grad grad);
        List<Grad> DohvatiGradoveZaKupca();
        Kupac DohvatiKupca(int IDKupac);
        void AzurirajKupca(Kupac kupac);
        void UbaciDrzavu(Drzava drzava);
        void UbaciGrad(Grad grad);
        void UbaciKupca(Kupac kupac);
        List<Kupac> DohvatiKupce();
        List<Komercijalist> DohvatiKomercijaliste();
        List<KreditnaKartica> DohvatiKreditneKartice();
        List<Racun> DohvatiRacune();
        List<Proizvod> DohvatiProizvode();
        void UbaciRacun(Racun racun);
        void AzurirajRacun(Racun racun);
        void UbaciStavku(Stavka stavka);
        void AzurirajStavku(Stavka stavka);
        Racun DohvatiRacun(int idRacun);
        Stavka DohvatiStavku(int idStavka);

    }
}