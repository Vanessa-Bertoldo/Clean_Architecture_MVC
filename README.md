To run the migrations :

```bash
    add-migration initial
```

If you encounter difficulties, specify where the DbContext file is located:

```bash
     add-migration Initial -Project CleanArchMvc.Infra.Data -StartupProject CleanArchMvc.WebUI
```