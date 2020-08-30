using MatejCervelinMvcProjekt.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Linq;
using System.Web;

namespace MatejCervelinMvcProjekt.DAL
{
    public class Repository : IRepo
    {
        public static DataSet ds { get; set; }
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public Repository()
        {

        }

        public List<Drzava> DohvatiDrzave()
        {
            List<Drzava> drzave = new List<Drzava>();

            ds = SqlHelper.ExecuteDataset(cs, "DohvatiDrzave");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                drzave.Add(new Drzava
                {
                    IDDrzava = (int)row[nameof(Drzava.IDDrzava)],
                    Naziv = row[nameof(Drzava.Naziv)].ToString()
                });
            }

            return drzave;

        }

        public List<Grad> DohvatiGradove(int idDrzava)
        {
            List<Grad> gradovi = new List<Grad>();

            ds = SqlHelper.ExecuteDataset(cs, "DohvatiGradoveZaDrzavu", idDrzava);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                gradovi.Add(new Grad
                {
                    IDGrad = (int)row[nameof(Grad.IDGrad)],
                    Naziv = row[nameof(Grad.Naziv)].ToString(),
                    DrzavaID = (int)row[nameof(Grad.DrzavaID)]
                });
            }

            return gradovi;
        }

        public Drzava DohvatiDrzavu(int idDrzava)
        {
            ds = SqlHelper.ExecuteDataset(cs, "DohvatiDrzavu", idDrzava);
            DataRow row = ds.Tables[0].Rows[0];

            Drzava d = new Drzava();
            d.IDDrzava = idDrzava;
            d.Naziv = row["Naziv"].ToString();

            return d;
        }

        public List<Kupac> DohvatiKupce(int idGrad)
        {
            List<Kupac> kupci = new List<Kupac>();

            ds = SqlHelper.ExecuteDataset(cs, "DohvatiKupceZaGrad", idGrad);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                kupci.Add(new Kupac
                {
                    IDKupac = (int)row[nameof(Kupac.IDKupac)],
                    Email = row[nameof(Kupac.Email)].ToString(),
                    Ime = row[nameof(Kupac.Ime)].ToString(),
                    Prezime = row[nameof(Kupac.Prezime)].ToString(),
                    Telefon = row[nameof(Kupac.Telefon)].ToString(),
                    GradID = (int)row[nameof(Kupac.GradID)]
                });
            }

            return kupci;
        }

        public Grad DohvatiGrad(int idGrad)
        {
            ds = SqlHelper.ExecuteDataset(cs, "DohvatiGrad", idGrad);
            DataRow row = ds.Tables[0].Rows[0];

            Grad g = new Grad();
            g.IDGrad = idGrad;
            g.Naziv = row["Naziv"].ToString();
            g.DrzavaID = (int)row["DrzavaID"];

            return g;
        }

        public IEnumerable<RowForTableRacun> DohvatiRacune(int idKupac)
        {

            ds = SqlHelper.ExecuteDataset(cs, "DohvatiRacuneZaKupca", idKupac);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return new RowForTableRacun
                {
                    IDRacun = (int)row[nameof(RowForTableRacun.IDRacun)],
                    BrojRacuna = row[nameof(RowForTableRacun.BrojRacuna)].ToString(),
                    DatumIzdavanja = DateTime.Parse(row[nameof(RowForTableRacun.DatumIzdavanja)].ToString()),
                    Broj = row[nameof(RowForTableRacun.Broj)].ToString(),
                    Ime = row[nameof(RowForTableRacun.Ime)].ToString(),
                    Prezime = row[nameof(RowForTableRacun.Prezime)].ToString(),
                    Tip = row[nameof(RowForTableRacun.Tip)].ToString()
                };
            }
        }

        public IEnumerable<RowForTableStavka> DohvatiStavke(int idRacun)
        {

            ds = SqlHelper.ExecuteDataset(cs, "DohvatiStavkeZaRacun", idRacun);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return new RowForTableStavka
                {
                    IDStavka = (int)row[nameof(RowForTableStavka.IDStavka)],
                    BrojProizvoda = row[nameof(RowForTableStavka.BrojProizvoda)].ToString(),
                    CijenaPoKomadu = (decimal)row[nameof(RowForTableStavka.CijenaPoKomadu)],
                    PopustUPostocima = (decimal)row[nameof(RowForTableStavka.PopustUPostocima)],
                    UkupnaCijena = (decimal)row[nameof(RowForTableStavka.UkupnaCijena)],
                    NazivProizvoda = row[nameof(RowForTableStavka.NazivProizvoda)].ToString(),
                    NazivKategorije = row[nameof(RowForTableStavka.NazivKategorije)].ToString(),
                    NazivPotkategorije = row[nameof(RowForTableStavka.NazivPotkategorije)].ToString(),
                    CijenaBezPDV = (decimal)row[nameof(RowForTableStavka.CijenaBezPDV)],
                    Kolicina = (short)row[nameof(RowForTableStavka.Kolicina)]
                };
            }
        }

        public void AzurirajDrzavu(Drzava drzava)
        {
            SqlHelper.ExecuteNonQuery(cs, "AzurirajDrzavu", drzava.Naziv, drzava.IDDrzava);
        }

        public void AzurirajGrad(Grad grad)
        {
            SqlHelper.ExecuteNonQuery(cs, "AzurirajGrad", grad.Naziv, grad.IDGrad, grad.DrzavaID);
        }

        public List<Grad> DohvatiGradoveZaKupca()
        {
            List<Grad> kolekcija = new List<Grad>();

            ds = SqlHelper.ExecuteDataset(cs, "DohvatiGradoveZaKupca");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                kolekcija.Add(new Grad
                {
                    IDGrad = int.Parse(row["IDGrad"].ToString()),
                    Naziv = row["Naziv"].ToString()
                });
            }
            return kolekcija;
        }

        public Kupac DohvatiKupca(int IDKupac)
        {
            ds = SqlHelper.ExecuteDataset(cs, "DohvatiKupca", IDKupac);
            DataRow row = ds.Tables[0].Rows[0];

            Kupac k = new Kupac();
            k.IDKupac = IDKupac;
            k.Ime = row["Ime"].ToString();
            k.Prezime = row["Prezime"].ToString();
            k.Email = row["Email"].ToString();
            k.Telefon = row["Telefon"].ToString();
            k.GradID = (int)row["GradID"];

            return k;
        }

        public void AzurirajKupca(Kupac kupac)
        {
            SqlHelper.ExecuteNonQuery(cs, "AzurirajKupca", kupac.IDKupac, kupac.Ime, kupac.Prezime, kupac.Email, kupac.Telefon, kupac.GradID);
        }

        public void UbaciDrzavu(Drzava drzava)
        {
            SqlHelper.ExecuteNonQuery(cs, "DodajDrzavu", drzava.Naziv);
        }

        public void UbaciGrad(Grad grad)
        {
            SqlHelper.ExecuteNonQuery(cs, "DodajGrad", grad.Naziv, grad.DrzavaID);
        }

        public void UbaciKupca(Kupac kupac)
        {
            SqlHelper.ExecuteNonQuery(cs, "DodajKupca", kupac.Ime, kupac.Prezime, kupac.Email, kupac.Telefon, kupac.GradID);
        }

        public List<Kupac> DohvatiKupce()
        {
            List<Kupac> kolekcija = new List<Kupac>();

            ds = SqlHelper.ExecuteDataset(cs, "DohvatiKupce");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                kolekcija.Add(new Kupac
                {
                    IDKupac = int.Parse(row["IDKupac"].ToString()),
                    Ime = row["Ime"].ToString(),
                    Prezime = row["Prezime"].ToString()
                });
            }
            return kolekcija;
        }

        public List<Komercijalist> DohvatiKomercijaliste()
        {
            List<Komercijalist> kolekcija = new List<Komercijalist>();

            ds = SqlHelper.ExecuteDataset(cs, "DohvatiKomercijaliste");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                kolekcija.Add(new Komercijalist
                {
                    IDKomercijalist = int.Parse(row["IDKomercijalist"].ToString()),
                    Ime = row["Ime"].ToString(),
                    Prezime = row["Prezime"].ToString()
                });
            }
            return kolekcija;
        }

        public List<KreditnaKartica> DohvatiKreditneKartice()
        {
            List<KreditnaKartica> kolekcija = new List<KreditnaKartica>();

            ds = SqlHelper.ExecuteDataset(cs, "DohvatiKreditneKartice");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                kolekcija.Add(new KreditnaKartica
                {
                    IDKreditnaKartica = int.Parse(row["IDKreditnaKartica"].ToString()),
                    Broj = row["Broj"].ToString(),
                    Tip = row["Tip"].ToString()
                });
            }
            return kolekcija;
        }

        public List<Racun> DohvatiRacune()
        {
            List<Racun> kolekcija = new List<Racun>();

            ds = SqlHelper.ExecuteDataset(cs, "DohvatiRacune");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                kolekcija.Add(new Racun
                {
                    IDRacun = int.Parse(row["IDRacun"].ToString()),
                    BrojRacuna = row["BrojRacuna"].ToString()
                });
            }
            return kolekcija;
        }

        public List<Proizvod> DohvatiProizvode()
        {
            List<Proizvod> kolekcija = new List<Proizvod>();

            ds = SqlHelper.ExecuteDataset(cs, "DohvatiProizvode");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                kolekcija.Add(new Proizvod
                {
                    IDProizvod = int.Parse(row["IDProizvod"].ToString()),
                    Naziv = row["Naziv"].ToString()
                });
            }
            return kolekcija;
        }

        public void UbaciRacun(Racun racun)
        {
            SqlHelper.ExecuteNonQuery(cs, "DodajRacun", racun.DatumIzdavanja, racun.BrojRacuna, racun.KupacID, racun.KomercijalistID, racun.KreditnaKarticaID, racun.Komentar);
        }

        public void AzurirajRacun(Racun racun)
        {
            SqlHelper.ExecuteNonQuery(cs, "AzurirajRacun", racun.IDRacun, racun.DatumIzdavanja, racun.BrojRacuna, racun.KupacID, racun.KomercijalistID, racun.KreditnaKarticaID, racun.Komentar);
        }

        public void UbaciStavku(Stavka stavka)
        {
            SqlHelper.ExecuteNonQuery(cs, "DodajStavku", stavka.RacunID, stavka.Kolicina, stavka.ProizvodID, stavka.CijenaPoKomadu, stavka.PopustUPostocima, stavka.UkupnaCijena);
        }

        public void AzurirajStavku(Stavka stavka)
        {
            SqlHelper.ExecuteNonQuery(cs, "AzurirajStavku", stavka.IDStavka, stavka.RacunID, stavka.Kolicina, stavka.ProizvodID, stavka.CijenaPoKomadu, stavka.PopustUPostocima, stavka.UkupnaCijena);
        }

        public Racun DohvatiRacun(int idRacun)
        {
            ds = SqlHelper.ExecuteDataset(cs, "DohvatiRacun", idRacun);
            DataRow row = ds.Tables[0].Rows[0];

            Racun racun = new Racun();
            racun.IDRacun = idRacun;
            racun.BrojRacuna = row["BrojRacuna"].ToString();
            racun.DatumIzdavanja = (DateTime)row["DatumIzdavanja"];
            racun.Komentar = row["Komentar"].ToString();
            racun.KomercijalistID = (int)row["KomercijalistID"];
            racun.KreditnaKarticaID = (int)row["KreditnaKarticaID"];
            racun.KupacID = (int)row["KupacID"];

            return racun;
        }

        public Stavka DohvatiStavku(int idStavka)
        {
            ds = SqlHelper.ExecuteDataset(cs, "DohvatiStavku", idStavka);
            DataRow row = ds.Tables[0].Rows[0];

            Stavka stavka = new Stavka();
            stavka.IDStavka = idStavka;
            stavka.CijenaPoKomadu = (decimal)row["CijenaPoKomadu"];
            stavka.UkupnaCijena = (decimal)row["UkupnaCijena"];
            stavka.PopustUPostocima = (decimal)row["PopustUPostocima"];
            stavka.Kolicina = (short)row["Kolicina"];
            stavka.ProizvodID = (int)row["ProizvodID"];
            stavka.RacunID = (int)row["RacunID"];

            return stavka;
        }
    }
}