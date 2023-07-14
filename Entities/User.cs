﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shop.API.Entities
{
    //Padre de client y admin 
    //Clase abstracta: no se puede instanciar, solo heredar de ella (no me interesa que se cree un usuario sin Role)
    public abstract class User
    {
        //Key: clave primaria o llave de la entidad 
        [Key]
        //Autogenero un Key por entidad creada en la BD: La opción Identity es que es autoincremental
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        //Requerido
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Role { get; set; }

        [MaxLength(20)]
        public string? Name { get; set; }
        [MaxLength(30)]
        public string? LastName { get; set; }
        public string? Adress { get; set; }

    }
}
