﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EDM
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class OpleidingenEntities : DbContext
    {
        public OpleidingenEntities()
            : base("name=OpleidingenEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Campus> Campussen { get; set; }
        public DbSet<Docent> Docenten { get; set; }
        public DbSet<Voorraad> Voorraden { get; set; }
        public DbSet<Boek> Boeken { get; set; }
        public DbSet<BoekCursus> BoekenCursussen { get; set; }
        public DbSet<Cursus> Cursussen { get; set; }
        public DbSet<Cursist> Cursisten { get; set; }
        public DbSet<Cursus1> Cursussen4 { get; set; }
        public DbSet<BestBetaaldeDocentPerCampus> BestBetaaldeDocentenPerCampus { get; set; }
    
        public virtual ObjectResult<Campus> CampussenVanTotPostcode(string vanPostcode, string naarPostcode)
        {
            var vanPostcodeParameter = vanPostcode != null ?
                new ObjectParameter("vanPostcode", vanPostcode) :
                new ObjectParameter("vanPostcode", typeof(string));
    
            var naarPostcodeParameter = naarPostcode != null ?
                new ObjectParameter("naarPostcode", naarPostcode) :
                new ObjectParameter("naarPostcode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Campus>("CampussenVanTotPostcode", vanPostcodeParameter, naarPostcodeParameter);
        }
    
        public virtual ObjectResult<Campus> CampussenVanTotPostcode(string vanPostcode, string naarPostcode, MergeOption mergeOption)
        {
            var vanPostcodeParameter = vanPostcode != null ?
                new ObjectParameter("vanPostcode", vanPostcode) :
                new ObjectParameter("vanPostcode", typeof(string));
    
            var naarPostcodeParameter = naarPostcode != null ?
                new ObjectParameter("naarPostcode", naarPostcode) :
                new ObjectParameter("naarPostcode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Campus>("CampussenVanTotPostcode", mergeOption, vanPostcodeParameter, naarPostcodeParameter);
        }
    
        public virtual ObjectResult<AantalDocentenPerVoornaam_Result> AantalDocentenPerVoornaam()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AantalDocentenPerVoornaam_Result>("AantalDocentenPerVoornaam");
        }
    
        public virtual int WeddeVerhoging(Nullable<decimal> percentage)
        {
            var percentageParameter = percentage.HasValue ?
                new ObjectParameter("Percentage", percentage) :
                new ObjectParameter("Percentage", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("WeddeVerhoging", percentageParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> AantalDocentenMetFamilienaam(string familienaam)
        {
            var familienaamParameter = familienaam != null ?
                new ObjectParameter("Familienaam", familienaam) :
                new ObjectParameter("Familienaam", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("AantalDocentenMetFamilienaam", familienaamParameter);
        }
    }
}
