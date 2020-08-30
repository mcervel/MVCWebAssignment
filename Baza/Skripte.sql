use AdventureWorksOBP

CREATE PROC DohvatiDrzave
as
begin
select * from Drzava
end

CREATE PROC DohvatiGradoveZaDrzavu
@DrzavaID int
as
begin
select * from Grad where Grad.DrzavaID = @DrzavaID
end

CREATE PROC DohvatiDrzavu
@DrzavaID int
as
begin
select * from Drzava as d where d.IDDrzava = @DrzavaID
end

CREATE PROC DohvatiKupceZaGrad
@GradID int
as
begin
select * from Kupac where Kupac.GradID = @GradID
end

CREATE PROC DohvatiGrad
@GradID int
as
begin
select * from Grad as g where g.IDGrad = @GradID
end

CREATE PROC DohvatiRacuneZaKupca
@KupacID int
as
begin
select * from Racun as r
inner join Komercijalist as k on r.KomercijalistID = k.IDKomercijalist
inner join KreditnaKartica as kk on r.KreditnaKarticaID = kk.IDKreditnaKartica
where r.KupacID = @KupacID
end

CREATE PROC DohvatiStavkeZaRacun
@RacunID int
as
begin
select s.IDStavka, s.Kolicina, s.CijenaPoKomadu, s.PopustUPostocima, s.UkupnaCijena, p.Naziv as NazivProizvoda, p.BrojProizvoda, p.CijenaBezPDV, pk.Naziv as NazivPotkategorije, k.Naziv as NazivKategorije from Stavka as s
inner join Proizvod as p on s.ProizvodID = p.IDProizvod
inner join Potkategorija as pk on p.PotkategorijaID = pk.IDPotkategorija
inner join Kategorija as k on pk.KategorijaID = k.IDKategorija
where s.RacunID = @RacunID
end

CREATE PROC AzurirajDrzavu
@Naziv nvarchar(50),
@IDDrzava int
as
begin
update Drzava set Naziv = @Naziv where IDDrzava = @IDDrzava
end

CREATE PROC AzurirajGrad
@Naziv nvarchar(50),
@IDGrad int,
@DrzavaID int
as
begin
update Grad set Naziv = @Naziv, DrzavaID = @DrzavaID  where IDGrad = @IDGrad
end

CREATE PROC DohvatiGradoveZaKupca
as
begin
select * from Grad
end

CREATE PROC DohvatiKupca
@IDKupac int
as
begin
select * from Kupac where IDKupac=@IDKupac
end

CREATE PROCEDURE AzurirajKupca
@IDKupac int,
@Ime nvarchar(50),
@Prezime nvarchar(50),
@Email nvarchar(50),
@Telefon nvarchar(25),
@GradID int
as
begin
update Kupac set Ime=@Ime, Prezime=@Prezime, Email=@Email, Telefon=@Telefon, GradID=@GradID where IDKupac=@IDKupac
end

CREATE PROC DodajDrzavu
@Naziv nvarchar(50)
as
begin
INSERT INTO Drzava(Naziv) VALUES (@Naziv)
end

CREATE PROC DodajGrad
@Naziv nvarchar(50),
@DrzavaID int
as
begin
INSERT INTO Grad(Naziv, DrzavaID) VALUES (@Naziv, @DrzavaID)
end

CREATE PROC DodajKupca
@Ime nvarchar(50),
@Prezime nvarchar(50),
@Email nvarchar(50),
@Telefon nvarchar(25) null,
@GradID int
AS
begin
insert into Kupac (Ime, Prezime, Email, Telefon, GradID) values(@Ime, @Prezime, @Email, @Telefon, @GradID)
end

CREATE PROC DodajRacun
@DatumIzdavanja datetime,
@BrojRacuna nvarchar(25),
@KupacID int,
@KomercijalistID int null,
@KreditnaKarticaID int null,
@Komentar nvarchar(128) null
as
begin
INSERT INTO Racun(DatumIzdavanja, BrojRacuna, KupacID, KomercijalistID, KreditnaKarticaID, Komentar)
VALUES (@DatumIzdavanja, @BrojRacuna, @KupacID, @KomercijalistID, @KreditnaKarticaID, @Komentar)
end

CREATE PROC AzurirajRacun
@IDRacun int,
@DatumIzdavanja datetime,
@BrojRacuna nvarchar(25),
@KupacID int,
@KomercijalistID int null,
@KreditnaKarticaID int null,
@Komentar nvarchar(128) null
as
begin
update Racun set DatumIzdavanja = @DatumIzdavanja, BrojRacuna = @BrojRacuna, KupacID = @KupacID, KomercijalistID = @KomercijalistID, KreditnaKarticaID = @KreditnaKarticaID, Komentar = @Komentar 
where IDRacun=@IDRacun
end

CREATE PROC DohvatiRacun
@IDRacun int
as
begin
select * from Racun where IDRacun=@IDRacun
end

drop proc DohvatiKupce

CREATE PROC DohvatiKupce
as
begin
select top 500 * from Kupac
order by Kupac.IDKupac desc
end

CREATE PROC DohvatiKomercijaliste
as
begin
select  * from Komercijalist
end

CREATE PROC DohvatiKreditneKartice
as
begin
select top 500 * from KreditnaKartica
end



CREATE PROC DodajStavku
@RacunID int,
@Kolicina smallint,
@ProizvodID int,
@CijenaPoKomadu money,
@PopustUPostocima money,
@UkupnaCijena numeric
as
begin
INSERT INTO Stavka(RacunID, Kolicina, ProizvodID, CijenaPoKomadu, PopustUPostocima, UkupnaCijena)
VALUES(@RacunID, @Kolicina, @ProizvodID, @CijenaPoKomadu, @PopustUPostocima, @UkupnaCijena)
end

CREATE PROC AzurirajStavku
@IDStavka int,
@RacunID int,
@Kolicina smallint,
@ProizvodID int,
@CijenaPoKomadu money,
@PopustUPostocima money,
@UkupnaCijena numeric
as
begin
update Stavka set RacunID = @RacunID, Kolicina = @Kolicina, ProizvodID = @ProizvodID, CijenaPoKomadu = @CijenaPoKomadu, PopustUPostocima = @PopustUPostocima, UkupnaCijena = @UkupnaCijena
where IDStavka = @IDStavka
end

CREATE PROC DohvatiStavku
@IDStavka int
as
begin
select * from Stavka where IDStavka=@IDStavka
end

CREATE PROC DohvatiRacune
as
begin
select top 100 * from Racun
end

CREATE PROC DohvatiProizvode
as
begin
select * from Proizvod
end
