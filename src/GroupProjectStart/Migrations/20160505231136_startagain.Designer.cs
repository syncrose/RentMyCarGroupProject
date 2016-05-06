using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using GroupProjectStart.Models;

namespace GroupProjectStart.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160505231136_startagain")]
    partial class startagain
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GroupProjectStart.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<decimal>("AverageRating");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("DisplayName");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<bool>("HasDamageInsurance");

                    b.Property<bool>("HasLicense");

                    b.Property<bool>("HasTheftInsurance");

                    b.Property<string>("Image");

                    b.Property<bool>("IsAdmin");

                    b.Property<bool>("IsLoaner");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("GroupProjectStart.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<decimal>("AverageRating");

                    b.Property<string>("Condition");

                    b.Property<int>("CtyMpg");

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Description");

                    b.Property<int>("Door");

                    b.Property<int>("HwyMpg");

                    b.Property<string>("Image");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Make")
                        .IsRequired();

                    b.Property<int>("Miles");

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.Property<int>("Seats");

                    b.Property<string>("Transmission");

                    b.Property<string>("UserId");

                    b.Property<int>("Year");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("GroupProjectStart.Models.CarReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CarId");

                    b.Property<bool>("IsViewable");

                    b.Property<string>("Message")
                        .IsRequired();

                    b.Property<DateTime>("TimeCreated");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");
                });

            modelBuilder.Entity("GroupProjectStart.Models.DriverReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<bool>("IsViewable");

                    b.Property<string>("Message")
                        .IsRequired();

                    b.Property<DateTime>("TimeCreated");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");
                });

            modelBuilder.Entity("GroupProjectStart.Models.RatingCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CarId");

                    b.Property<int>("DeliveryExperience");

                    b.Property<int>("ElectricalFunctions");

                    b.Property<int>("EngineOperation");

                    b.Property<int>("IndoorAirQuality");

                    b.Property<int>("InsideCleanliness");

                    b.Property<int>("OutsideCleanliness");

                    b.Property<int>("OverallRating");

                    b.Property<int>("ProfessionalismOfOwner");

                    b.Property<int>("SafetyFeatures");

                    b.Property<int>("TireQuality");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("GroupProjectStart.Models.RatingDriver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<int>("ConditionOfReturnedCar");

                    b.Property<int>("DeliveryExperience");

                    b.Property<int>("OverallRating");

                    b.Property<int>("PaymentExperience");

                    b.Property<int>("ProfessionalismOfDriver");

                    b.Property<int>("PromptReplies");

                    b.Property<int>("SchedulingExperience");

                    b.Property<int>("Trustworthiness");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("GroupProjectStart.Models.SentimentInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CarReviewId");

                    b.Property<string>("Count");

                    b.Property<int?>("DriverReviewId");

                    b.Property<string>("EntityType");

                    b.Property<string>("Relevance");

                    b.Property<string>("SentimentScore");

                    b.Property<string>("SentimentType");

                    b.Property<string>("Text");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("GroupProjectStart.Models.Car", b =>
                {
                    b.HasOne("GroupProjectStart.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("GroupProjectStart.Models.CarReview", b =>
                {
                    b.HasOne("GroupProjectStart.Models.Car")
                        .WithMany()
                        .HasForeignKey("CarId");
                });

            modelBuilder.Entity("GroupProjectStart.Models.DriverReview", b =>
                {
                    b.HasOne("GroupProjectStart.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("GroupProjectStart.Models.RatingCar", b =>
                {
                    b.HasOne("GroupProjectStart.Models.Car")
                        .WithMany()
                        .HasForeignKey("CarId");
                });

            modelBuilder.Entity("GroupProjectStart.Models.RatingDriver", b =>
                {
                    b.HasOne("GroupProjectStart.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("GroupProjectStart.Models.SentimentInfo", b =>
                {
                    b.HasOne("GroupProjectStart.Models.CarReview")
                        .WithMany()
                        .HasForeignKey("CarReviewId");

                    b.HasOne("GroupProjectStart.Models.DriverReview")
                        .WithMany()
                        .HasForeignKey("DriverReviewId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GroupProjectStart.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GroupProjectStart.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("GroupProjectStart.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
