using Microsoft.EntityFrameworkCore;
using Mashup.Models;
using System;
public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}

	public DbSet<PlantModel> Plants { get; set; }
	public DbSet<SpeciesModel> Species { get; set; }
	public DbSet<UserModel> Users { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<PlantModel>(entity =>
		{
			entity.ToTable("tbl_plants");
			entity.HasKey(p => p.PlantID);
			entity.Property(p => p.PlantName).HasColumnName("plant_name");
			entity.Property(p => p.Watering).HasColumnName("watering");
			entity.Property(p => p.Sunlight).HasColumnName("sunlight");
			entity.Property(p => p.Indoor).HasColumnName("indoor");
			entity.Property(p => p.Hardiness).HasColumnName("hardiness");
		});

		modelBuilder.Entity<SpeciesModel>(entity =>
		{
			entity.ToTable("tbl_species");
			entity.HasKey(s => s.SpeciesID);
			entity.Property(s => s.API_PlantID).HasColumnName("api_plant_id");
			entity.Property(s => s.SpeciesName).HasColumnName("species_name");
			entity.Property(s => s.Watering).HasColumnName("watering_freq");
			entity.Property(s => s.Sunlight).HasColumnName("sunlight");
			entity.Property(s => s.HardinessMin).HasColumnName("hardiness_min");
			entity.Property(s => s.HardinessMax).HasColumnName("hardiness_max");
		});

		modelBuilder.Entity<UserModel>(entity =>
		{
			entity.ToTable("tbl_users");
			entity.HasKey(u => u.UserID);
			entity.Property(u => u.Username).HasColumnName("username");
			entity.Property(u => u.PasswordHash).HasColumnName("password_hash");
			entity.Property(u => u.City).HasColumnName("city");
			entity.Property(u => u.Latitude).HasColumnName("latitude");
			entity.Property(u => u.Longitude).HasColumnName("longitude");
		});
	}
}