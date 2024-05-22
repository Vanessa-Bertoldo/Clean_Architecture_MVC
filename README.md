Check the appsettings.json file and modify it according to the database used

```bash
    "ConnectionStrings": {
        "DefaultConnection": "Data Source=DESKTOP-T5ODAG3;Initial Catalog=Mercado;Integrated Security=True;TrustServerCertificate=True"
    },
```

To run the migrations :

```bash
    add-migration initial
```

If you encounter difficulties, specify where the DbContext file is located:

```bash
     add-migration Initial -Project CleanArchMvc.Infra.Data -StartupProject CleanArchMvc.WebUI
```

After that, run the command so that the tables are created in your database:

```bash
    update-database
```
