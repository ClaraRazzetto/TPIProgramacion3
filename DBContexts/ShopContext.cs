using Microsoft.EntityFrameworkCore;
using Shop.API.Entities;

namespace Shop.API.DBContexts
{
    public class ShopContext : DbContext
    {
        //db set y get de cada entidad 

        //lo que hagamos con LINQ sobre estos DbSets lo va a transformar en consultas SQL cuando vuelve la data se transforma a objeto de c#
        
        //Los warnings los podemos obviar porque DbContext se encarga de eso.
        
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<SaleOrder> SaleOrders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        //constructor del contexto
        //Llamo al constructor de dbContext que es el que acepta las opciones
        //Cuando pongo base:() se llama al constructor de la clase padre con el parametro que le mando entre ()
        public ShopContext (DbContextOptions<ShopContext> options) : base(options) 
        {

        }

        //Seeding: rellenar la base de datos con un conjunto inicial de datos
        //para hacerlo extendemos el metodo onmodelcreating el metodo .hashdata
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator(u => u.Role);

            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Id = 1,
                    Name = "Clara",
                    LastName = "Razzetto",
                    UserName = "ClaraRazzetto",
                    Password = "Password",
                    Email = "clararazzetto@gmail.com",
                    Adress = "Alem 1333",

                },
                new Client
                {
                    Id = 2,
                    Name = "Nicolas",
                    LastName = "Perez",
                    UserName = "NicolasPerez",
                    Password = "Password1",
                    Email = "nicop@gmail.com",
                    Adress = "Urquiza 800",
                },
                new Client
                {
                    Id = 10,
                    Name = "Roxana",
                    LastName = "Perez",
                    UserName = "RoxanaPerez",
                    Password = "Password3",
                    Email = "rox@gmail.com",
                    Adress = "Alem 1400",
                });

            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 3,
                    UserName = "admin",
                    Password = "Password2",
                    Email = "admin@gmail.com",
                });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 4,
                    Name = "Remera basic",
                    Category = Enums.ProductCategories.Remera,
                    Price = 10000,
                    Size = Enums.ProductSizes.L,
                    Stock = 3,
                },
                new Product
                {
                    Id = 5,
                    Name = "Jean recto",
                    Category = Enums.ProductCategories.Pantalón,
                    Price = 50000,
                    Size = Enums.ProductSizes.M,
                    Stock = 2,
                },
                new Product
                {
                    Id = 6,
                    Name = "Campera basic",
                    Category = Enums.ProductCategories.Abrigo,
                    Price = 60000,
                    Size = Enums.ProductSizes.M,
                    Stock = 1,
                },
                new Product
                {
                    Id = 7,
                    Name = "Remera Nation",
                    Category = Enums.ProductCategories.Remera,
                    Price = 30000,
                    Size = Enums.ProductSizes.S,
                    Stock = 0,
                });

            modelBuilder.Entity<SaleOrder>()
                .HasOne(s => s.Product)
                .WithMany(p => p.SaleOrders)
                .HasForeignKey(s => s.ProductId);
              
            modelBuilder.Entity<SaleOrder>()
                .HasOne(s => s.Client)
                .WithMany(c => c.SaleOrders)
                .HasForeignKey(c => c.ClientId);
              
            base.OnModelCreating(modelBuilder);
        }
    }
}
