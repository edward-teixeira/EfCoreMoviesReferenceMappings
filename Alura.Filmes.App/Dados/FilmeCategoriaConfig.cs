﻿using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Filmes.App.Dados
{
    public class FilmeCategoriaConfig : IEntityTypeConfiguration<FilmeCategoria>
    {
        public void Configure(EntityTypeBuilder<FilmeCategoria> builder)
        {
            builder.ToTable("film_category");
            builder.Property<int>("film_id");
            builder.Property<byte>("category_id");
            builder.Property<DateTime>("last_update").HasDefaultValueSql("getdate()");
            builder.HasKey("film_id", "category_id");

            builder
                .HasOne<Categoria>(fc => fc.Categoria)
                .WithMany(c => c.Filmes)
                .HasForeignKey("category_id");

            builder
                .HasOne<Filme>(fc => fc.Filme)
                .WithMany(c => c.Categorias)
                .HasForeignKey("film_id");

        }
    }
}