# Photo Album Application – PaaS alapú megoldás

## 1. Projekt célja

A projekt célja egy felhőben (PaaS környezetben) futó fényképalbum webalkalmazás létrehozása, amely lehetővé teszi:

- Fényképek feltöltését és törlését
- Fényképek listázását név és dátum szerint rendezve
- Képek megjelenítését
- Felhasználókezelést (regisztráció, bejelentkezés, kijelentkezés)

Az alkalmazás több rétegű, skálázható architektúrában működik.

---

## 2. Választott PaaS környezet

Az alkalmazás Microsoft Azure PaaS környezetben fut.

Felhasznált szolgáltatások:

- Azure App Service (Webalkalmazás futtatása)
- Azure SQL Database (Relációs adatbázis külön szerveren)
- Azure Blob Storage (Képfájlok tárolása)
- GitHub Actions (CI/CD – automatikus build és deploy)

---

## 3. Alkalmazott technológiák

- .NET 10
- ASP.NET Core (Blazor Server)
- Entity Framework Core
- Azure SQL
- Azure Blob Storage
- GitHub

---

## 4. Architektúra (Többrétegű felépítés)

Az alkalmazás három fő rétegből áll:

### Web réteg
- ASP.NET Core alkalmazás
- Azure App Service-ben fut
- Felhasználói felület és üzleti logika

### Adatbázis réteg
- Azure SQL Database
- Külön erőforrásként fut
- Tárolja:
  - Felhasználókat (ASP.NET Identity)
  - Fényképek metaadatait (név, dátum, elérési út)

### Fájl tárolási réteg
- Azure Blob Storage
- A feltöltött képfájlokat tárolja
- A webalkalmazás URL alapján éri el a képeket

A webalkalmazás:

- SQL kapcsolatot használ az adatbázishoz
- Blob Storage connection string segítségével tölti fel és törli a képeket

---

## 5. CI/CD folyamat

A projekt GitHub repository-ban található.

GitHub Actions workflow:

- Push esetén automatikus build
- Automatikus deploy Azure App Service-re
- Így a rendszer folyamatosan integrált és frissített

---

## 6. Funkcionális követelmények megvalósítása

- Fényképek feltöltése  
- Fényképek törlése  
- Maximum 40 karakter hosszú név  
- Feltöltési dátum tárolása (év-hó-nap óra:perc)  
- Rendezés név szerint  
- Rendezés dátum szerint  
- Kép megjelenítése listaelem kiválasztásakor dupla click-re 
- Regisztráció
- Bejelentkezés  
- Kijelentkezés  
- Feltöltés és törlés csak bejelentkezett felhasználónak  

---