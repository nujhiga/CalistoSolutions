
using Microsoft.EntityFrameworkCore;

namespace CalistoDbCore.U3FEntities
{
    //public interface INominalEntity : IEntity
    //{
    //    [EntityAttr(EntityMemberSign.Legajo)]
    //    double Legajo { get; set; }

    //    [EntityAttr(EntityMemberSign.Apellido)]
    //    string? Apellido { get; set; }

    //    [EntityAttr(EntityMemberSign.Nombres)]
    //    string? Nombres { get; set; }

    //    [EntityAttr(EntityMemberSign.Documento)]
    //    double? Documento { get; set; }

    //    [EntityAttr(EntityMemberSign.FecNac)]
    //    DateTime? FecNac { get; set; }

    //    [EntityAttr(EntityMemberSign.Mail)]
    //    string? Mail { get; set; }

    //    [EntityAttr(EntityMemberSign.SexoId)]
    //    char? SexoId { get; set; }
    //}

    //public class NominalEntity : INominalEntity
    //{
    //    public object EntityID => Legajo;
    //    public double Legajo { get; set; }
    //    public string? Apellido { get; set; }
    //    public string? Nombres { get; set; }
    //    public double? Documento { get; set; }
    //    public DateTime? FecNac { get; set; }
    //    public string? Mail { get; set; }
    //    public char? SexoId { get; set; }
    //}

    public abstract class U3FDbContext : DbContext
    {
        protected U3FDbContext() { }
        protected U3FDbContext(DbContextOptions<U3FDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            if (!optionsBuilder.IsConfigured) 
            { 
                optionsBuilder.UseSqlServer(@"Data Source=172.16.2.2;
                                              Initial Catalog=U3FVirtual;
                                              User ID=migrauser; 
                                              Password = JoaquinMigra;");
            }
        }
    }

    public partial class U3FContext : DbContext
    {
        public U3FContext()
        {
        }

        public U3FContext(DbContextOptions<U3FContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the FieldName= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=172.16.2.2; Initial Catalog=U3FVirtual; User ID=migrauser; Password = JoaquinMigra;");
            }
        }

        #region DbSets
        
        public virtual DbSet<Calendario> Calendarios { get; set; } = null!;
        public virtual DbSet<Carmating> Carmatings { get; set; } = null!;
        public virtual DbSet<Carmatingulp> Carmatingulps { get; set; } = null!;
        public virtual DbSet<Carrera> Carreras { get; set; } = null!;
        public virtual DbSet<ComisCar> ComisCars { get; set; } = null!;
        public virtual DbSet<ComisConv> ComisConvs { get; set; } = null!;
        public virtual DbSet<ComisCor> ComisCors { get; set; } = null!;
        public virtual DbSet<ComisDoc> ComisDocs { get; set; } = null!;
        public virtual DbSet<Comision> Comisions { get; set; } = null!;
        public virtual DbSet<Condicion> Condicions { get; set; } = null!;
        public virtual DbSet<Convcar> Convcars { get; set; } = null!;
        public virtual DbSet<Convenio> Convenios { get; set; } = null!;
        public virtual DbSet<Convpago> Convpagos { get; set; } = null!;
        public virtual DbSet<Docente> Docentes { get; set; } = null!;
        public virtual DbSet<Equivalencia> Equivalencias { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<ExpAre> ExpAres { get; set; } = null!;
        public virtual DbSet<ExpDe> ExpDes { get; set; } = null!;
        public virtual DbSet<ExpEnt> ExpEnts { get; set; } = null!;
        public virtual DbSet<ExpMae> ExpMaes { get; set; } = null!;
        public virtual DbSet<ExpMot> ExpMots { get; set; } = null!;
        public virtual DbSet<ExpMov> ExpMovs { get; set; } = null!;
        public virtual DbSet<ExpPa> ExpPas { get; set; } = null!;
        public virtual DbSet<ExpRut> ExpRuts { get; set; } = null!;
        public virtual DbSet<Folio> Folios { get; set; } = null!;
        public virtual DbSet<GuaLocalidade> GuaLocalidades { get; set; } = null!;
        public virtual DbSet<GuaPaise> GuaPaises { get; set; } = null!;
        public virtual DbSet<IExaman> IExamen { get; set; } = null!;
        public virtual DbSet<IMateria> IMaterias { get; set; } = null!;
        public virtual DbSet<KmatCarrera> KmatCarreras { get; set; } = null!;
        public virtual DbSet<KmatDetalle> KmatDetalles { get; set; } = null!;
        public virtual DbSet<KmatHora> KmatHoras { get; set; } = null!;
        public virtual DbSet<Licencia> Licencias { get; set; } = null!;
        public virtual DbSet<MatPro> MatPros { get; set; } = null!;
        public virtual DbSet<Materia> Materias { get; set; } = null!;
        public virtual DbSet<Notum> Nota { get; set; } = null!;
        public virtual DbSet<Parametro> Parametros { get; set; } = null!;
        public virtual DbSet<PdAud> PdAuds { get; set; } = null!;
        public virtual DbSet<PdHi> PdHis { get; set; } = null!;
        public virtual DbSet<PremioVistum> PremioVista { get; set; } = null!;
        public virtual DbSet<Presento> Presentos { get; set; } = null!;
        public virtual DbSet<Reingreso> Reingresos { get; set; } = null!;
        public virtual DbSet<Sede> Sedes { get; set; } = null!;
        public virtual DbSet<SedesCar> SedesCars { get; set; } = null!;
        public virtual DbSet<SedesConv> SedesConvs { get; set; } = null!;
        public virtual DbSet<Sedtut> Sedtuts { get; set; } = null!;
        public virtual DbSet<Sexo> Sexos { get; set; } = null!;
        public virtual DbSet<Subformulario> Subformularios { get; set; } = null!;
        public virtual DbSet<Subregularidad> Subregularidads { get; set; } = null!;
        public virtual DbSet<Turno> Turnos { get; set; } = null!;
        public virtual DbSet<TurnoIn> TurnoIns { get; set; } = null!;
        public virtual DbSet<U3fActa> U3fActas { get; set; } = null!;
        public virtual DbSet<U3fAlu> U3fAlus { get; set; } = null!;
        public virtual DbSet<U3fAxc> U3fAxcs { get; set; } = null!;
        public virtual DbSet<U3fMesa> U3fMesas { get; set; } = null!;
        public virtual DbSet<U3fMesasUlp> U3fMesasUlps { get; set; } = null!;
        public virtual DbSet<U3fMod> U3fMods { get; set; } = null!;
        public virtual DbSet<U3fPlane> U3fPlanes { get; set; } = null!;
        public virtual DbSet<UlpConvsedetut> UlpConvsedetuts { get; set; } = null!;
        public virtual DbSet<UlpSede> UlpSedes { get; set; } = null!;
        public virtual DbSet<UlpSedesTurno> UlpSedesTurnos { get; set; } = null!;
        public virtual DbSet<UtfAluxRen> UtfAluxRens { get; set; } = null!;
        public virtual DbSet<UvCod> UvCods { get; set; } = null!;
        public virtual DbSet<UvFecha> UvFechas { get; set; } = null!;
        public virtual DbSet<UvMov> UvMovs { get; set; } = null!;
        public virtual DbSet<UvPag> UvPags { get; set; } = null!;
        public virtual DbSet<UvPagomiscuenta> UvPagomiscuentas { get; set; } = null!;
        public virtual DbSet<UvPagosnps1> UvPagosnps1s { get; set; } = null!;
        public virtual DbSet<UvPlatot> UvPlatots { get; set; } = null!;
        public virtual DbSet<UvVisapag> UvVisapags { get; set; } = null!;
        public virtual DbSet<ViSede> ViSedes { get; set; } = null!;
        public virtual DbSet<VisAlu> VisAlus { get; set; } = null!;
        public virtual DbSet<VisExaCur> VisExaCurs { get; set; } = null!;
        public virtual DbSet<VisExaCurUlp> VisExaCurUlps { get; set; } = null!;
        public virtual DbSet<VisExaCuring> VisExaCurings { get; set; } = null!;
        public virtual DbSet<VisIn> VisIns { get; set; } = null!;
        public virtual DbSet<VisMat> VisMats { get; set; } = null!;
        public virtual DbSet<VisMatCur> VisMatCurs { get; set; } = null!;
        public virtual DbSet<VisTu1> VisTu1s { get; set; } = null!;
        public virtual DbSet<VisWeb> VisWebs { get; set; } = null!;
        public virtual DbSet<WebAprobaronCiclo> WebAprobaronCiclos { get; set; } = null!;
        public virtual DbSet<WebCubo01> WebCubo01s { get; set; } = null!;
        #endregion




        //protected static void OnNominalEntityCreated(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<NominalEntity>(entity =>
        //    {
        //        entity.HasNoKey();
                
        //        entity.ToView(EntitiesConstants.Nominals.VisAlu);

        //        entity.HasIndex(e => e.Legajo, EntitiesConstants.IndexOf.IxLegajo);

        //        entity.HasIndex(e => e.Documento, EntitiesConstants.IndexOf.IxDocumento);

        //        entity.Property(e => e.Nombres).HasMaxLength(EntitiesConstants.MaxLength.Fifty);

        //        entity.Property(e => e.Apellido).HasMaxLength(EntitiesConstants.MaxLength.Forty);

        //        entity.Property(e => e.SexoId).HasColumnName(EntitiesConstants.Nominals.SexoId);

        //        entity.Property(e => e.Mail).HasMaxLength(EntitiesConstants.MaxLength.HundredFifty);

        //        entity.Property(e => e.FecNac).HasColumnType(EntitiesConstants.TypeOf.SmallDatetime);

        //       // modelBuilder.Entity<NominalEntity>().ToTable(EntitiesConstants.Nominals.VisAlu);

        //    });
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            //  OnNominalEntityCreated(modelBuilder);

            modelBuilder.Entity<VisAlu>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIS_ALU");

                entity.Property(e => e.Abr)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ABR")
                    .IsFixedLength();

                entity.Property(e => e.AnoIngreso).HasMaxLength(4);

                entity.Property(e => e.Apellido).HasMaxLength(40);

                entity.Property(e => e.ApellidoAuto)
                    .HasMaxLength(40)
                    .HasColumnName("APELLIDO_AUTO");

                entity.Property(e => e.ApellidoDni)
                    .HasMaxLength(40)
                    .HasColumnName("APELLIDO_DNI");

                entity.Property(e => e.Bcoleg).HasColumnName("BCOLEG");

                entity.Property(e => e.CarreraId).HasColumnName("CarreraId_");

                entity.Property(e => e.Convenio).HasMaxLength(1);

                entity.Property(e => e.Cp)
                    .HasMaxLength(8)
                    .HasColumnName("CP");

                entity.Property(e => e.CuatrIngreso)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Cuit)
                    .HasMaxLength(25)
                    .HasColumnName("CUIT");

                entity.Property(e => e.CuotaIngreso)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Cuotacero)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CUOTACERO")
                    .IsFixedLength();

                entity.Property(e => e.Cuotaextr).HasColumnName("CUOTAEXTR");

                entity.Property(e => e.Curing)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CURING")
                    .IsFixedLength();

                entity.Property(e => e.Debedni)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DEBEDNI")
                    .IsFixedLength();

                entity.Property(e => e.Debetit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DEBETIT")
                    .IsFixedLength();

                entity.Property(e => e.Direccion).HasMaxLength(160);

                entity.Property(e => e.Dispos25)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DISPOS25")
                    .IsFixedLength();

                entity.Property(e => e.Docuextr)
                    .HasMaxLength(40)
                    .HasColumnName("DOCUEXTR");

                entity.Property(e => e.Documenta)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTA")
                    .IsFixedLength();

                entity.Property(e => e.Eg1)
                    .HasMaxLength(200)
                    .HasColumnName("EG1");

                entity.Property(e => e.Eg1cod).HasColumnName("EG1COD");

                entity.Property(e => e.Eg2)
                    .HasMaxLength(200)
                    .HasColumnName("EG2");

                entity.Property(e => e.Eg2cod).HasColumnName("EG2COD");

                entity.Property(e => e.Extranjero)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EXTRANJERO")
                    .IsFixedLength();

                entity.Property(e => e.FecIns).HasColumnType("smalldatetime");

                entity.Property(e => e.FecNac).HasColumnType("smalldatetime");

                entity.Property(e => e.FecRei).HasColumnType("smalldatetime");

                entity.Property(e => e.FecSec).HasColumnType("smalldatetime");

                entity.Property(e => e.Feclib)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FECLIB");

                entity.Property(e => e.Fectit)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FECTIT");

                entity.Property(e => e.FinDes).HasColumnType("smalldatetime");

                entity.Property(e => e.FinHas).HasColumnType("smalldatetime");

                entity.Property(e => e.Genero).HasColumnName("GENERO");

                entity.Property(e => e.Guabeca).HasColumnName("GUABECA");

                entity.Property(e => e.Guacuit)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("GUACUIT")
                    .IsFixedLength();

                entity.Property(e => e.Guadate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("GUADATE")
                    .IsFixedLength();

                entity.Property(e => e.Guainma).HasColumnName("GUAINMA");

                entity.Property(e => e.Guainpa).HasColumnName("GUAINPA");

                entity.Property(e => e.Gualoca).HasColumnName("GUALOCA");

                entity.Property(e => e.Guapnac).HasColumnName("GUAPNAC");

                entity.Property(e => e.Guapres).HasColumnName("GUAPRES");

                entity.Property(e => e.Guatrab).HasColumnName("GUATRAB");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Intercambio)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("INTERCAMBIO")
                    .IsFixedLength();

                entity.Property(e => e.LetraDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Libreta)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LIBRETA")
                    .IsFixedLength();

                entity.Property(e => e.LocalidadId).HasColumnName("LocalidadId_");

                entity.Property(e => e.LocalidadTxt).HasMaxLength(150);

                entity.Property(e => e.LugMundo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Mail).HasMaxLength(150);

                entity.Property(e => e.MotBaja).HasMaxLength(50);

                entity.Property(e => e.Nacio).HasMaxLength(50);

                entity.Property(e => e.Nombres).HasMaxLength(50);

                entity.Property(e => e.NombresAuto)
                    .HasMaxLength(50)
                    .HasColumnName("NOMBRES_AUTO");

                entity.Property(e => e.NombresDni)
                    .HasMaxLength(50)
                    .HasColumnName("NOMBRES_DNI");

                entity.Property(e => e.Observa)
                    .HasColumnType("text")
                    .HasColumnName("OBSERVA");

                entity.Property(e => e.Orienta).HasMaxLength(1);

                entity.Property(e => e.Pais).HasMaxLength(150);

                entity.Property(e => e.Partido).HasMaxLength(150);

                entity.Property(e => e.Present3).HasColumnName("PRESENT3");

                entity.Property(e => e.Promsec).HasColumnName("PROMSEC");

                entity.Property(e => e.Recibido).HasMaxLength(1);

                entity.Property(e => e.Recifecha)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("RECIFECHA");

                entity.Property(e => e.ReguAnt).HasMaxLength(1);

                entity.Property(e => e.Regular).HasMaxLength(1);

                entity.Property(e => e.ResAno).HasMaxLength(4);

                entity.Property(e => e.ResFec).HasColumnType("smalldatetime");

                entity.Property(e => e.Residente)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RESIDENTE")
                    .IsFixedLength();

                entity.Property(e => e.SexoDni).HasColumnName("SEXO_DNI");

                entity.Property(e => e.SexoId).HasColumnName("SexoId_");

                entity.Property(e => e.Suspcuatri)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("SUSPCUATRI")
                    .IsFixedLength();

                entity.Property(e => e.Suspendido)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SUSPENDIDO")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Suspfecha)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("SUSPFECHA");

                entity.Property(e => e.Suspproce).HasColumnName("SUSPPROCE");

                entity.Property(e => e.Telefono).HasMaxLength(50);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(1)
                    .HasColumnName("TIPO");

                entity.Property(e => e.TitSec).HasMaxLength(180);

                entity.Property(e => e.TitTer).HasMaxLength(180);

                entity.Property(e => e.TitUni).HasMaxLength(180);

                entity.Property(e => e.TraHrs).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TraTipo).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Trabaja).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TurnoId).HasColumnName("TurnoId_");

                entity.Property(e => e.UpcnafiliadoNro).HasColumnName("UPCNAfiliadoNro");

                entity.Property(e => e.UpcnafiliadoTipo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("UPCNAfiliadoTipo")
                    .IsFixedLength();

                entity.Property(e => e.Usualu)
                    .HasMaxLength(100)
                    .HasColumnName("USUALU")
                    .IsFixedLength();

                entity.Property(e => e.Usucla)
                    .HasMaxLength(20)
                    .HasColumnName("USUCLA");

                entity.Property(e => e.Vencresid).HasColumnName("VENCRESID");

                entity.Property(e => e.Visacod)
                    .HasMaxLength(8)
                    .HasColumnName("VISACOD")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Visapri)
                    .HasMaxLength(1)
                    .HasColumnName("VISAPRI")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Visatarjeta)
                    .HasMaxLength(16)
                    .HasColumnName("VISATARJETA")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Visatartipo)
                    .HasMaxLength(2)
                    .HasColumnName("VISATARTIPO")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");
            });

            modelBuilder.Entity<Calendario>(entity =>
            {
                entity.ToTable("Calendario");

                entity.Property(e => e.CalenDesc)
                    .HasMaxLength(100)
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");
            });

            modelBuilder.Entity<Carmating>(entity =>
            {
                entity.ToTable("CARMATING");

                entity.Property(e => e.Campus)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CAMPUS")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Carmatingulp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CARMATINGULP");

                entity.Property(e => e.Campus)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CAMPUS")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("Carrera");

                entity.HasIndex(e => e.Id, "Carrera_ID")
                    .IsUnique()
                    .IsClustered();

                entity.HasIndex(e => e.Carrera1, "Carrera_NOM");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Abr)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ABR")
                    .IsFixedLength();

                entity.Property(e => e.Canmat1).HasColumnName("CANMAT1");

                entity.Property(e => e.Canmat2).HasColumnName("CANMAT2");

                entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

                entity.Property(e => e.Carrera1)
                    .HasMaxLength(120)
                    .HasColumnName("Carrera");

                entity.Property(e => e.Certif)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CERTIF")
                    .IsFixedLength();

                entity.Property(e => e.Ciclo1)
                    .HasMaxLength(120)
                    .HasColumnName("CICLO1");

                entity.Property(e => e.Ciclo12)
                    .HasMaxLength(120)
                    .HasColumnName("CICLO12")
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Ciclo2)
                    .HasMaxLength(120)
                    .HasColumnName("CICLO2");

                entity.Property(e => e.Coordinador)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COORDINADOR")
                    .IsFixedLength();

                entity.Property(e => e.Coorditecni)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COORDITECNI")
                    .IsFixedLength();

                entity.Property(e => e.Coorsexo).HasColumnName("COORSEXO");

                entity.Property(e => e.Cuotaextr).HasColumnName("CUOTAEXTR");

                entity.Property(e => e.Curing)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CURING")
                    .IsFixedLength();

                entity.Property(e => e.Desde)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DESDE");

                entity.Property(e => e.Diplo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DIPLO")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Edubco).HasColumnName("EDUBCO");

                entity.Property(e => e.Edugru).HasColumnName("EDUGRU");

                entity.Property(e => e.Eduing).HasColumnName("EDUING");

                entity.Property(e => e.Edutca).HasColumnName("EDUTCA");

                entity.Property(e => e.Edutut).HasColumnName("EDUTUT");

                entity.Property(e => e.Eduulp).HasColumnName("EDUULP");

                entity.Property(e => e.Habiing)
                    .HasMaxLength(1)
                    .HasColumnName("HABIING")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Hasta)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("HASTA");

                entity.Property(e => e.Inshab)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("INSHAB")
                    .IsFixedLength();

                entity.Property(e => e.Orien1)
                    .HasMaxLength(50)
                    .HasColumnName("ORIEN1");

                entity.Property(e => e.Orien2)
                    .HasMaxLength(50)
                    .HasColumnName("ORIEN2");

                entity.Property(e => e.Orien3)
                    .HasMaxLength(50)
                    .HasColumnName("ORIEN3");

                entity.Property(e => e.Resanomin)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RESANOMIN")
                    .IsFixedLength();

                entity.Property(e => e.Resnromin).HasColumnName("RESNROMIN");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(1)
                    .HasColumnName("TIPO");

                entity.Property(e => e.Topecuota).HasColumnName("TOPECUOTA");

                entity.Property(e => e.Topeinsc).HasColumnName("TOPEINSC");

                entity.Property(e => e.Topema).HasColumnName("TOPEMA");

                entity.Property(e => e.Topeno).HasColumnName("TOPENO");

                entity.Property(e => e.Topeta).HasColumnName("TOPETA");

                entity.Property(e => e.Totalin).HasColumnName("TOTALIN");

                entity.Property(e => e.Totalma).HasColumnName("TOTALMA");

                entity.Property(e => e.Totalno).HasColumnName("TOTALNO");

                entity.Property(e => e.Totalta).HasColumnName("TOTALTA");

                entity.Property(e => e.Totinsmat).HasColumnName("TOTINSMAT");

                entity.Property(e => e.Ulpcuring)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ULPCURING")
                    .IsFixedLength();

                entity.Property(e => e.Ulping).HasColumnName("ULPING");

                entity.Property(e => e.Ulptca).HasColumnName("ULPTCA");

                entity.Property(e => e.Ulptut).HasColumnName("ULPTUT");
            });

            modelBuilder.Entity<ComisCar>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("COMIS_CAR");

                entity.Property(e => e.AnoIng)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Cuatrimestre)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Vale)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VALE")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");
            });

            modelBuilder.Entity<ComisConv>(entity =>
            {
                entity.ToTable("COMIS_CONV");

                entity.Property(e => e.Cuatrimestre)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Vale)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");
            });

            modelBuilder.Entity<ComisCor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("COMIS_COR");

                entity.Property(e => e.Comision).HasColumnName("COMISION");

                entity.Property(e => e.Cuatrimestre)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CUATRIMESTRE")
                    .IsFixedLength();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Titular)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TITULAR")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");
            });

            modelBuilder.Entity<ComisDoc>(entity =>
            {
                entity.ToTable("COMIS_DOC");

                entity.HasIndex(e => e.IdDocente, "IX_COMIS_DOC");

                entity.Property(e => e.Comision).HasColumnName("COMISION");

                entity.Property(e => e.Cuatrimestre)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CUATRIMESTRE")
                    .IsFixedLength();

                entity.Property(e => e.Titular)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Comision>(entity =>
            {
                entity.HasKey(e => e.Ide)
                    .IsClustered(false);

                entity.ToTable("COMISION");

                entity.HasIndex(e => e.Cuatrimestre, "COMISION_cuatrimestre_1");

                entity.HasIndex(e => new { e.Comision1, e.Cuatrimestre }, "Comision_2");

                entity.HasIndex(e => e.Profesor, "Comision_Profesor");

                entity.HasIndex(e => new { e.Materia, e.Comision1 }, "Comisiones_matCom")
                    .IsClustered();

                entity.Property(e => e.Ide).HasColumnName("ide");

                entity.Property(e => e.Abandono)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ABANDONO")
                    .IsFixedLength();

                entity.Property(e => e.Activa)
                    .HasMaxLength(1)
                    .HasColumnName("ACTIVA");

                entity.Property(e => e.Anoing).HasColumnName("ANOING");

                entity.Property(e => e.Anoing1).HasColumnName("ANOING1");

                entity.Property(e => e.Anoing2).HasColumnName("ANOING2");

                entity.Property(e => e.Anual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ANUAL")
                    .IsFixedLength();

                entity.Property(e => e.Asiaul)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ASIAUL")
                    .IsFixedLength();

                entity.Property(e => e.Asised).HasColumnName("ASISED");

                entity.Property(e => e.Aula)
                    .HasMaxLength(10)
                    .HasColumnName("AULA");

                entity.Property(e => e.Aulaid).HasColumnName("AULAID");

                entity.Property(e => e.Aulcap).HasColumnName("AULCAP");

                entity.Property(e => e.Campus)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CAMPUS")
                    .IsFixedLength();

                entity.Property(e => e.Carrera).HasColumnName("CARRERA");

                entity.Property(e => e.Carrera1).HasColumnName("CARRERA1");

                entity.Property(e => e.Carrera2).HasColumnName("CARRERA2");

                entity.Property(e => e.Cerrada)
                    .HasMaxLength(1)
                    .HasColumnName("CERRADA");

                entity.Property(e => e.Comaso).HasColumnName("COMASO");

                entity.Property(e => e.Coming).HasColumnName("COMING");

                entity.Property(e => e.Comision1).HasColumnName("Comision");

                entity.Property(e => e.Cuatrimestre)
                    .HasMaxLength(5)
                    .HasColumnName("CUATRIMESTRE");

                entity.Property(e => e.Cursada)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CURSADA")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Edugru).HasColumnName("EDUGRU");

                entity.Property(e => e.Fecdes)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FECDES");

                entity.Property(e => e.Fechas)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FECHAS");

                entity.Property(e => e.JueDes)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Jue_des")
                    .IsFixedLength();

                entity.Property(e => e.JueHas)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Jue_has")
                    .IsFixedLength();

                entity.Property(e => e.LunDes)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Lun_des")
                    .IsFixedLength();

                entity.Property(e => e.LunHas)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Lun_has")
                    .IsFixedLength();

                entity.Property(e => e.MarDes)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Mar_des")
                    .IsFixedLength();

                entity.Property(e => e.MarHas)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Mar_has")
                    .IsFixedLength();

                entity.Property(e => e.Materia).HasColumnName("MATERIA");

                entity.Property(e => e.MieDes)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Mie_des")
                    .IsFixedLength();

                entity.Property(e => e.MieHas)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Mie_has")
                    .IsFixedLength();

                entity.Property(e => e.Observa)
                    .HasMaxLength(40)
                    .HasColumnName("OBSERVA");

                entity.Property(e => e.Profe2).HasColumnName("PROFE2");

                entity.Property(e => e.Regularidad)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REGULARIDAD")
                    .IsFixedLength();

                entity.Property(e => e.SabDes)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Sab_des")
                    .IsFixedLength();

                entity.Property(e => e.SabHas)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Sab_has")
                    .IsFixedLength();

                entity.Property(e => e.Sede).HasColumnName("SEDE");

                entity.Property(e => e.Semide).HasColumnName("SEMIDE");

                entity.Property(e => e.Totaba).HasColumnName("TOTABA");

                entity.Property(e => e.Totalu).HasColumnName("TOTALU");

                entity.Property(e => e.Totins).HasColumnName("TOTINS");

                entity.Property(e => e.Totlic).HasColumnName("TOTLIC");

                entity.Property(e => e.Totsus).HasColumnName("TOTSUS");

                entity.Property(e => e.Turno)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TURNO")
                    .IsFixedLength();

                entity.Property(e => e.Verano)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VERANO")
                    .IsFixedLength();

                entity.Property(e => e.VieDes)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Vie_des")
                    .IsFixedLength();

                entity.Property(e => e.VieHas)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Vie_has")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Condicion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Condicion");

                entity.HasIndex(e => e.Id, "Condicion_Id")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Condicion1)
                    .HasMaxLength(50)
                    .HasColumnName("Condicion");
            });

            modelBuilder.Entity<Convcar>(entity =>
            {
                entity.ToTable("CONVCAR");

                entity.Property(e => e.Activa)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Cuatrimestre)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CurIng)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IngCuotas)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.IngMonto).HasColumnType("money");
            });

            modelBuilder.Entity<Convenio>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("CONVENIOS");

                entity.HasIndex(e => e.Id, "Convenios_Id")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.ConPag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Convenio1)
                    .HasMaxLength(50)
                    .HasColumnName("Convenio");

                entity.Property(e => e.Derexa)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DEREXA")
                    .IsFixedLength();

                entity.Property(e => e.Habicar)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("HABICAR")
                    .IsFixedLength();

                entity.Property(e => e.Habiexa)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("HABIEXA")
                    .IsFixedLength();

                entity.Property(e => e.Habimat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("HABIMAT")
                    .IsFixedLength();

                entity.Property(e => e.Habipre)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("HABIPRE")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE")
                    .IsFixedLength();

                entity.Property(e => e.Observa)
                    .HasMaxLength(50)
                    .HasColumnName("observa");
            });

            modelBuilder.Entity<Convpago>(entity =>
            {
                entity.ToTable("CONVPAGO");
            });

            modelBuilder.Entity<Docente>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("Docente");

                entity.HasIndex(e => e.Id, "Docende_ID")
                    .IsUnique()
                    .IsClustered();

                entity.HasIndex(e => new { e.DocApe, e.DocNom }, "Docente_Ape");

                entity.HasIndex(e => e.Docente1, "IX_Docente_docente_100");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DocApe).HasMaxLength(30);

                entity.Property(e => e.DocCar).HasMaxLength(25);

                entity.Property(e => e.DocDom).HasMaxLength(50);

                entity.Property(e => e.DocMai).HasMaxLength(50);

                entity.Property(e => e.DocNom).HasMaxLength(25);

                entity.Property(e => e.DocObs).HasMaxLength(50);

                entity.Property(e => e.DocPar).HasMaxLength(50);

                entity.Property(e => e.DocPos).HasMaxLength(8);

                entity.Property(e => e.DocTel).HasMaxLength(40);

                entity.Property(e => e.DocTit).HasMaxLength(6);

                entity.Property(e => e.Doccarrera).HasColumnName("DOCCARRERA");

                entity.Property(e => e.Docdepto).HasColumnName("DOCDEPTO");

                entity.Property(e => e.Docente1)
                    .HasMaxLength(50)
                    .HasColumnName("docente");

                entity.Property(e => e.Docsitu)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DOCSITU")
                    .IsFixedLength();

                entity.Property(e => e.Docusuario)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DOCUSUARIO")
                    .IsFixedLength();

                entity.Property(e => e.Precv)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PRECV")
                    .IsFixedLength();

                entity.Property(e => e.Predni)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PREDNI")
                    .IsFixedLength();

                entity.Property(e => e.Pretit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PRETIT")
                    .IsFixedLength();

                entity.Property(e => e.Reemplazo).HasColumnName("REEMPLAZO");

                entity.Property(e => e.Segusu).HasColumnName("SEGUSU");
            });

            modelBuilder.Entity<Equivalencia>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EQUIVALENCIAS");

                entity.HasIndex(e => e.MatReq, "Equiv_MatReq");

                entity.HasIndex(e => new { e.Carrera, e.PlanId, e.MatPre }, "Equiva_CarreraPlanPre")
                    .IsClustered();
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.Estado1)
                    .IsClustered(false);

                entity.ToTable("ESTADO");

                entity.HasIndex(e => e.Estado1, "Estado_Cod")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Estado1)
                    .HasMaxLength(1)
                    .HasColumnName("ESTADO");

                entity.Property(e => e.Estdes)
                    .HasMaxLength(30)
                    .HasColumnName("ESTDES");
            });

            modelBuilder.Entity<ExpAre>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EXP_ARE");

                entity.Property(e => e.Areacod).HasColumnName("AREACOD");

                entity.Property(e => e.Areades)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AREADES");
            });

            modelBuilder.Entity<ExpDe>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EXP_DES");

                entity.Property(e => e.Area).HasColumnName("AREA");

                entity.Property(e => e.Coddes).HasColumnName("CODDES");

                entity.Property(e => e.Desdes)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESDES");

                entity.Property(e => e.Observ)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExpEnt>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EXP_ENT");

                entity.Property(e => e.Area).HasColumnName("AREA");

                entity.Property(e => e.Codent).HasColumnName("CODENT");

                entity.Property(e => e.Desent)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DESENT");
            });

            modelBuilder.Entity<ExpMae>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("EXP_MAE");

                entity.HasIndex(e => e.Desarea, "AREACOD");

                entity.HasIndex(e => e.Nroexpe, "EXPE");

                entity.HasIndex(e => new { e.Fecexpe, e.Nronota }, "EXPNOTA");

                entity.HasIndex(e => new { e.Initip, e.Inileg }, "IX_EXP_MAE_INITIP_INILEG_39");

                entity.HasIndex(e => new { e.Initip, e.Inileg, e.Codmot }, "IX_EXP_MAE_INITIP_INILEG_CODMOT_74");

                entity.HasIndex(e => e.Nronota, "NOTA");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apynom)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("APYNOM");

                entity.Property(e => e.Carrera).HasColumnName("CARRERA");

                entity.Property(e => e.Cerrado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.CertIni)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.CertTit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Cnro)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CNro")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Codmot).HasColumnName("CODMOT");

                entity.Property(e => e.Desarea).HasColumnName("DESAREA");

                entity.Property(e => e.Descodi).HasColumnName("DESCODI");

                entity.Property(e => e.Desfech)
                    .HasColumnType("datetime")
                    .HasColumnName("DESFECH");

                entity.Property(e => e.Desmot)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DESMOT");

                entity.Property(e => e.Destipo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DESTIPO");

                entity.Property(e => e.Fecexpe)
                    .HasColumnType("datetime")
                    .HasColumnName("FECEXPE");

                entity.Property(e => e.Fecnota)
                    .HasColumnType("datetime")
                    .HasColumnName("FECNOTA");

                entity.Property(e => e.Fecresol)
                    .HasColumnType("datetime")
                    .HasColumnName("FECRESOL");

                entity.Property(e => e.Foja)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Foja7)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Inileg).HasColumnName("INILEG");

                entity.Property(e => e.Initip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("INITIP");

                entity.Property(e => e.N2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nnro)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NNro")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Nocarat).HasColumnName("NOCARAT");

                entity.Property(e => e.Nroexpe)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NROEXPE");

                entity.Property(e => e.Nronota)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NRONOTA");

                entity.Property(e => e.Nroresol)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NRORESOL")
                    .IsFixedLength();

                entity.Property(e => e.Obser1)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("OBSER1");

                entity.Property(e => e.Obser2)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("OBSER2");

                entity.Property(e => e.Paso1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Paso2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Paso3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Paso4)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Paso5)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Paso6)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Paso7)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Umoide).HasColumnName("UMOIDE");
            });

            modelBuilder.Entity<ExpMot>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EXP_MOT");

                entity.Property(e => e.Codmot).HasColumnName("CODMOT");

                entity.Property(e => e.Desmot)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DESMOT");
            });

            modelBuilder.Entity<ExpMov>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EXP_MOV");

                entity.HasIndex(e => e.Nroexpe, "EXPE");

                entity.HasIndex(e => new { e.Nroexpe, e.Nronota }, "EXPNOTA");

                entity.HasIndex(e => e.Id, "ID");

                entity.HasIndex(e => e.Nronota, "NOTA");

                entity.Property(e => e.Coddes).HasColumnName("CODDES");

                entity.Property(e => e.Codent).HasColumnName("CODENT");

                entity.Property(e => e.Fecent)
                    .HasColumnType("datetime")
                    .HasColumnName("FECENT");

                entity.Property(e => e.Fecentr)
                    .HasColumnType("datetime")
                    .HasColumnName("FECENTR");

                entity.Property(e => e.Fecsal)
                    .HasColumnType("datetime")
                    .HasColumnName("FECSAL");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Nroexpe)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NROEXPE");

                entity.Property(e => e.Nronota)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NRONOTA");

                entity.Property(e => e.Observ)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("OBSERV");
            });

            modelBuilder.Entity<ExpPa>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EXP_PAS");

                entity.HasIndex(e => e.Nroexpe, "EXPE");

                entity.HasIndex(e => new { e.Nroexpe, e.Nronota }, "EXPNOTA");

                entity.HasIndex(e => e.Id, "ID");

                entity.HasIndex(e => e.Nronota, "NOTA");

                entity.Property(e => e.Area).HasColumnName("AREA");

                entity.Property(e => e.Coddes).HasColumnName("CODDES");

                entity.Property(e => e.Fecsal)
                    .HasColumnType("datetime")
                    .HasColumnName("FECSAL");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Nroexpe)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NROEXPE");

                entity.Property(e => e.Nronota)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NRONOTA");

                entity.Property(e => e.Observ)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("OBSERV");
            });

            modelBuilder.Entity<ExpRut>(entity =>
            {
                entity.HasKey(e => e.RutIde)
                    .IsClustered(false);

                entity.ToTable("EXP_RUT");

                entity.Property(e => e.RutIde).HasColumnName("RUT_IDE");

                entity.Property(e => e.Rutarea).HasColumnName("RUTAREA");

                entity.Property(e => e.Rutcaas).HasColumnName("RUTCAAS");

                entity.Property(e => e.Rutdest).HasColumnName("RUTDEST");

                entity.Property(e => e.Rutmoti).HasColumnName("RUTMOTI");

                entity.Property(e => e.Rutorde)
                    .HasMaxLength(10)
                    .HasColumnName("RUTORDE");
            });

            modelBuilder.Entity<Folio>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("Folio");

                entity.HasIndex(e => new { e.Resolucion, e.Resano, e.Folio1, e.Libro, e.Materia }, "Folio_MarResLib")
                    .IsClustered();

                entity.HasIndex(e => e.Estado, "IX_Folio_Estado_83");

                entity.HasIndex(e => e.Fecha, "IX_Folio_Fecha_107");

                entity.HasIndex(e => new { e.Folio1, e.Libro, e.Materia }, "IX_Folio_Folio_Libro_Materia_27");

                entity.HasIndex(e => new { e.Folio1, e.Libro, e.Materia }, "IX_Folio_Folio_Libro_Materia_65");

                entity.HasIndex(e => new { e.Folio1, e.Libro, e.Materia, e.Fecha }, "IX_Folio_Folio_Libro_Materia_Fecha_106");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fecha).HasColumnType("smalldatetime");

                entity.Property(e => e.Folio1).HasColumnName("Folio");

                entity.Property(e => e.Tipolibro).HasColumnName("TIPOLIBRO");

                entity.Property(e => e.TxtResolucion)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<GuaLocalidade>(entity =>
            {
                entity.HasKey(e => e.IdLocalidad);

                entity.ToTable("GUA_Localidades");

                entity.HasIndex(e => e.Provincia, "IX_GUA_Localidades");

                entity.Property(e => e.IdLocalidad).ValueGeneratedNever();

                entity.Property(e => e.DptoPartido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Dpto_Partido");

                entity.Property(e => e.Localidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Provincia)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GuaPaise>(entity =>
            {
                entity.HasKey(e => e.PaiCod);

                entity.ToTable("GUA_Paises");

                entity.Property(e => e.PaiCod).ValueGeneratedNever();

                entity.Property(e => e.LugMundo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PaiDes)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IExaman>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("I_EXAMEN");

                entity.HasIndex(e => e.Actanro, "IX_I_EXAMEN_ACTANRO_35");

                entity.HasIndex(e => e.Cuatrimestre, "IX_I_EXAMEN_CUATRIMESTRE_38");

                entity.HasIndex(e => new { e.Cuatrimestre, e.Convenio }, "IX_I_EXAMEN_CUATRIMESTRE_CONVENIO_70");

                entity.HasIndex(e => new { e.Fecha, e.Mesa }, "IX_I_EXAMEN_FECHA_MESA_23");

                entity.HasIndex(e => new { e.Fecha, e.Mesa, e.Todomal }, "IX_I_EXAMEN_FECHA_MESA_TODOMAL_123");

                entity.HasIndex(e => e.Materia, "IX_I_EXAMEN_MATERIA_40");

                entity.HasIndex(e => new { e.Materia, e.Cuatrimestre }, "IX_I_EXAMEN_MATERIA_CUATRIMESTRE_45");

                entity.HasIndex(e => new { e.Legajo, e.Materia, e.Libro, e.Folio }, "I_Examen_LegMatLibFol")
                    .IsClustered();

                entity.Property(e => e.Actanro)
                    .HasMaxLength(8)
                    .HasColumnName("ACTANRO");

                entity.Property(e => e.Actarec)
                    .HasMaxLength(8)
                    .HasColumnName("ACTAREC");

                entity.Property(e => e.Aula)
                    .HasMaxLength(10)
                    .HasColumnName("AULA");

                entity.Property(e => e.Campus)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CAMPUS")
                    .IsFixedLength();

                entity.Property(e => e.Carga)
                    .HasMaxLength(1)
                    .HasColumnName("CARGA");

                entity.Property(e => e.Convenio).HasColumnName("CONVENIO");

                entity.Property(e => e.Cuatrimestre)
                    .HasMaxLength(5)
                    .HasColumnName("CUATRIMESTRE");

                entity.Property(e => e.Cuatritema)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CUATRITEMA")
                    .IsFixedLength();

                entity.Property(e => e.Docente).HasColumnName("DOCENTE");

                entity.Property(e => e.Equivale)
                    .HasMaxLength(1)
                    .HasColumnName("EQUIVALE");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .HasColumnName("ESTADO");

                entity.Property(e => e.Fecha)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FECHA");

                entity.Property(e => e.Firma).HasMaxLength(50);

                entity.Property(e => e.Folio).HasColumnName("FOLIO");

                entity.Property(e => e.Inicio)
                    .HasMaxLength(5)
                    .HasColumnName("INICIO");

                entity.Property(e => e.Legajo).HasColumnName("LEGAJO");

                entity.Property(e => e.Libro).HasColumnName("LIBRO");

                entity.Property(e => e.Materia).HasColumnName("MATERIA");

                entity.Property(e => e.Mesa).HasColumnName("MESA");

                entity.Property(e => e.Mesdoc).HasColumnName("MESDOC");

                entity.Property(e => e.Mestur)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MESTUR")
                    .IsFixedLength();

                entity.Property(e => e.Mesulp).HasColumnName("MESULP");

                entity.Property(e => e.Nota).HasColumnName("NOTA");

                entity.Property(e => e.Origen)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ORIGEN")
                    .IsFixedLength();

                entity.Property(e => e.Pagos)
                    .HasMaxLength(1)
                    .HasColumnName("PAGOS");

                entity.Property(e => e.Presente).HasColumnName("PRESENTE");

                entity.Property(e => e.Reglib)
                    .HasMaxLength(1)
                    .HasColumnName("REGLIB");

                entity.Property(e => e.Regular)
                    .HasMaxLength(1)
                    .HasColumnName("REGULAR");

                entity.Property(e => e.Sede).HasColumnName("SEDE");

                entity.Property(e => e.Semide).HasColumnName("SEMIDE");

                entity.Property(e => e.Tesis)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TESIS")
                    .IsFixedLength();

                entity.Property(e => e.Tipolibro).HasColumnName("TIPOLIBRO");

                entity.Property(e => e.Tiporec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TIPOREC")
                    .IsFixedLength();

                entity.Property(e => e.Todomal)
                    .HasMaxLength(1)
                    .HasColumnName("TODOMAL");

                entity.Property(e => e.Turno).HasColumnName("TURNO");
            });

            modelBuilder.Entity<IMateria>(entity =>
            {
                entity.HasKey(e => e.Ide)
                    .IsClustered(false);

                entity.ToTable("I_MATERIAS");

                entity.HasIndex(e => new { e.Comision, e.Cuatrimestre }, "IX_I_MATERIAS_COMISION_CUATRIMESTRE_33");

                entity.HasIndex(e => new { e.Comision, e.Cuatrimestre }, "IX_I_MATERIAS_COMISION_CUATRIMESTRE_57");

                entity.HasIndex(e => new { e.Comision, e.Cuatrimestre }, "IX_I_MATERIAS_COMISION_CUATRIMESTRE_6");

                entity.HasIndex(e => new { e.Comision, e.Cuatrimestre, e.Materia, e.Verano }, "IX_I_MATERIAS_COMISION_CUATRIMESTRE_MATERIA_VERANO_115");

                entity.HasIndex(e => new { e.Comision, e.Cuatrimestre, e.Verano }, "IX_I_MATERIAS_COMISION_CUATRIMESTRE_VERANO_126");

                entity.HasIndex(e => new { e.Comision, e.Todomal, e.Cuatrimestre, e.Materia, e.Verano }, "IX_I_MATERIAS_COMISION_TODOMAL_CUATRIMESTRE_MATERIA_VERANO_117");

                entity.HasIndex(e => e.Cuatrimestre, "IX_I_MATERIAS_CUATRIMESTRE_58");

                entity.HasIndex(e => e.Cuatrimestre, "IX_I_MATERIAS_CUATRIMESTRE_67");

                entity.HasIndex(e => e.Cuatrimestre, "IX_I_MATERIAS_CUATRIMESTRE_75");

                entity.HasIndex(e => e.Cuatrimestre, "IX_I_MATERIAS_CUATRIMESTRE_87");

                entity.HasIndex(e => new { e.Cuatrimestre, e.Materia, e.Verano }, "IX_I_MATERIAS_CUATRIMESTRE_MATERIA_VERANO_114");

                entity.HasIndex(e => new { e.Cuatrimestre, e.Materia, e.Verano }, "IX_I_MATERIAS_CUATRIMESTRE_MATERIA_VERANO_116");

                entity.HasIndex(e => e.Materia, "IX_I_MATERIAS_MATERIA_4");

                entity.HasIndex(e => new { e.Materia, e.Comision, e.Cuatrimestre }, "IX_I_MATERIAS_MATERIA_COMISION_CUATRIMESTRE_3");

                entity.HasIndex(e => new { e.Materia, e.Comision, e.Cuatrimestre }, "IX_I_MATERIAS_MATERIA_COMISION_CUATRIMESTRE_43");

                entity.HasIndex(e => new { e.Materia, e.Comision, e.Cuatrimestre }, "IX_I_MATERIAS_MATERIA_COMISION_CUATRIMESTRE_44");

                entity.HasIndex(e => new { e.Materia, e.Comision, e.Cuatrimestre }, "IX_I_MATERIAS_MATERIA_COMISION_CUATRIMESTRE_73");

                entity.HasIndex(e => new { e.Materia, e.Comision, e.Cuatrimestre, e.Promedio }, "IX_I_MATERIAS_MATERIA_COMISION_CUATRIMESTRE_PROMEDIO_122");

                entity.HasIndex(e => new { e.Materia, e.Comision, e.Cuatrimestre, e.Verano }, "IX_I_MATERIAS_MATERIA_COMISION_CUATRIMESTRE_VERANO_124");

                entity.HasIndex(e => new { e.Materia, e.Cuatrimestre }, "IX_I_MATERIAS_MATERIA_CUATRIMESTRE_42");

                entity.HasIndex(e => new { e.Materia, e.Cuatrimestre }, "IX_I_MATERIAS_MATERIA_CUATRIMESTRE_46");

                entity.HasIndex(e => new { e.Materia, e.Cuatrimestre }, "IX_I_MATERIAS_MATERIA_CUATRIMESTRE_51");

                entity.HasIndex(e => new { e.Materia, e.Cuatrimestre, e.Verano }, "IX_I_MATERIAS_MATERIA_CUATRIMESTRE_VERANO_125");

                entity.HasIndex(e => new { e.Origen, e.Todomal, e.Cuatrimestre, e.Materia, e.Verano }, "IX_I_MATERIAS_ORIGEN_TODOMAL_CUATRIMESTRE_MATERIA_VERANO_119");

                entity.HasIndex(e => new { e.Todomal, e.Cuatrimestre }, "IX_I_MATERIAS_TODOMAL_CUATRIMESTRE_88");

                entity.HasIndex(e => new { e.Todomal, e.Cuatrimestre, e.Materia }, "IX_I_MATERIAS_TODOMAL_CUATRIMESTRE_MATERIA_112");

                entity.HasIndex(e => new { e.Todomal, e.Cuatrimestre, e.Materia, e.Verano }, "IX_I_MATERIAS_TODOMAL_CUATRIMESTRE_MATERIA_VERANO_118");

                entity.HasIndex(e => new { e.Todomal, e.Cuatrimestre, e.Materia, e.Verano }, "IX_I_MATERIAS_TODOMAL_CUATRIMESTRE_MATERIA_VERANO_120");

                entity.HasIndex(e => new { e.Legajo, e.Materia, e.Comision }, "I_Materias_LegMatCom2")
                    .IsClustered();

                entity.Property(e => e.Ide).HasColumnName("IDE");

                entity.Property(e => e.Actanro).HasColumnName("ACTANRO");

                entity.Property(e => e.Anual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ANUAL")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Aprobo)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("APROBO");

                entity.Property(e => e.Causa)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CAUSA")
                    .IsFixedLength();

                entity.Property(e => e.Comision).HasColumnName("COMISION");

                entity.Property(e => e.Cuatrimestre)
                    .HasMaxLength(5)
                    .HasColumnName("CUATRIMESTRE");

                entity.Property(e => e.Edugru).HasColumnName("EDUGRU");

                entity.Property(e => e.Equivale)
                    .HasMaxLength(1)
                    .HasColumnName("EQUIVALE");

                entity.Property(e => e.Fecins)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FECINS");

                entity.Property(e => e.Ffinal)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FFINAL");

                entity.Property(e => e.Final).HasColumnName("FINAL");

                entity.Property(e => e.Fnota1)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FNOTA1");

                entity.Property(e => e.Fnota2)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FNOTA2");

                entity.Property(e => e.Folio).HasColumnName("FOLIO");

                entity.Property(e => e.Legajo).HasColumnName("LEGAJO");

                entity.Property(e => e.Libro).HasColumnName("LIBRO");

                entity.Property(e => e.Materia).HasColumnName("MATERIA");

                entity.Property(e => e.Nota1)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("NOTA1")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Nota2)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("NOTA2")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Origen)
                    .HasMaxLength(1)
                    .HasColumnName("ORIGEN");

                entity.Property(e => e.Pagos)
                    .HasMaxLength(1)
                    .HasColumnName("PAGOS");

                entity.Property(e => e.Promedio).HasColumnName("PROMEDIO");

                entity.Property(e => e.Reemplaza).HasColumnName("REEMPLAZA");

                entity.Property(e => e.Regular)
                    .HasMaxLength(1)
                    .HasColumnName("REGULAR");

                entity.Property(e => e.Semide).HasColumnName("SEMIDE");

                entity.Property(e => e.Todomal)
                    .HasMaxLength(1)
                    .HasColumnName("TODOMAL");

                entity.Property(e => e.Verano)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VERANO")
                    .IsFixedLength();
            });

            modelBuilder.Entity<KmatCarrera>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("KMat_Carrera");

                entity.Property(e => e.KCarreras).HasColumnName("K_Carreras");

                entity.Property(e => e.Mxcar).HasColumnName("MXCAR");
            });

            modelBuilder.Entity<KmatDetalle>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("KMAT_Detalle");

                entity.Property(e => e.CarreDet).HasMaxLength(80);
            });

            modelBuilder.Entity<KmatHora>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("KMat_Horas");

                entity.Property(e => e.Horas).HasColumnName("HORAS");
            });

            modelBuilder.Entity<Licencia>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LICENCIAS");

                entity.HasIndex(e => e.Id, "Licencias_Id")
                    .IsUnique();

                entity.HasIndex(e => e.Legajo, "Licencias_Legajo")
                    .IsClustered();

                entity.Property(e => e.Carrera).HasColumnName("CARRERA");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Legajo).HasColumnName("LEGAJO");

                entity.Property(e => e.Liccua)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("LICCUA")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Licdes)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("LICDES");

                entity.Property(e => e.Licfec)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("LICFEC");

                entity.Property(e => e.Lichas)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("LICHAS");

                entity.Property(e => e.Licnum)
                    .HasMaxLength(10)
                    .HasColumnName("LICNUM");

                entity.Property(e => e.Licobs)
                    .HasMaxLength(50)
                    .HasColumnName("LICOBS");
            });

            modelBuilder.Entity<MatPro>(entity =>
            {
                entity.HasKey(e => e.Proide)
                    .IsClustered(false);

                entity.ToTable("MAT_PRO");

                entity.Property(e => e.Proide).HasColumnName("PROIDE");

                entity.Property(e => e.Legajo).HasColumnName("LEGAJO");

                entity.Property(e => e.Proano).HasColumnName("PROANO");

                entity.Property(e => e.Procua)
                    .HasMaxLength(5)
                    .HasColumnName("PROCUA");

                entity.Property(e => e.Promat).HasColumnName("PROMAT");

                entity.Property(e => e.Pronro).HasColumnName("PRONRO");
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.HasIndex(e => e.Materias, "Materias_Descrip");

                entity.HasIndex(e => e.Id, "Materias_Id")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Abandono)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ABANDONO")
                    .IsFixedLength();

                entity.Property(e => e.Aclara)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ACLARA")
                    .IsFixedLength();

                entity.Property(e => e.Anual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ANUAL")
                    .IsFixedLength();

                entity.Property(e => e.Espera)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ESPERA")
                    .IsFixedLength();

                entity.Property(e => e.Ingresan)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("INGRESAN")
                    .IsFixedLength();

                entity.Property(e => e.Libre)
                    .HasMaxLength(1)
                    .HasColumnName("LIBRE");

                entity.Property(e => e.Materias).HasMaxLength(150);

                entity.Property(e => e.Observa)
                    .HasMaxLength(50)
                    .HasColumnName("observa");

                entity.Property(e => e.Reemplazo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REEMPLAZO")
                    .IsFixedLength();

                entity.Property(e => e.Tema)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TEMA")
                    .IsFixedLength();

                entity.Property(e => e.Tipo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TIPO")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Notum>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.Id, "Nota_Id")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Nota).HasMaxLength(15);
            });

            modelBuilder.Entity<Parametro>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("PARAMETROS");

                entity.HasIndex(e => e.LegUlt, "IX_PARAMETROS")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "Par_Id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Abandono)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ABANDONO")
                    .IsFixedLength();

                entity.Property(e => e.AnoNota)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("ANO_NOTA")
                    .IsFixedLength();

                entity.Property(e => e.BcoAno)
                    .HasMaxLength(4)
                    .HasColumnName("BCO_ANO")
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.BcoCua)
                    .HasMaxLength(1)
                    .HasColumnName("BCO_CUA")
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.CerReg).HasColumnName("CER_REG");

                entity.Property(e => e.CertFolio).HasColumnName("CERT_FOLIO");

                entity.Property(e => e.CertFolioPos).HasColumnName("CERT_FOLIO_POS");

                entity.Property(e => e.CertLibro).HasColumnName("CERT_LIBRO");

                entity.Property(e => e.CertLibroPos).HasColumnName("CERT_LIBRO_POS");

                entity.Property(e => e.CertNro).HasColumnName("CERT_NRO");

                entity.Property(e => e.CertNroPos).HasColumnName("CERT_NRO_POS");

                entity.Property(e => e.CertTope).HasColumnName("CERT_TOPE");

                entity.Property(e => e.CertTopePos).HasColumnName("CERT_TOPE_POS");

                entity.Property(e => e.CertUso).HasColumnName("CERT_USO");

                entity.Property(e => e.Cotifecha)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("COTIFECHA");

                entity.Property(e => e.Cotizacion).HasColumnName("COTIZACION");

                entity.Property(e => e.EncAct)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ENC_ACT")
                    .IsFixedLength();

                entity.Property(e => e.EncExt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ENC_EXT")
                    .IsFixedLength();

                entity.Property(e => e.Espera)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ESPERA")
                    .IsFixedLength();

                entity.Property(e => e.FecexaUlp)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FECEXA_ULP");

                entity.Property(e => e.Fexadesde)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FEXADESDE");

                entity.Property(e => e.FexadesdeUlp)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FEXADESDE_ULP");

                entity.Property(e => e.Fexahasta)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FEXAHASTA");

                entity.Property(e => e.FexahastaUlp)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FEXAHASTA_ULP");

                entity.Property(e => e.Habilitados)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("HABILITADOS")
                    .IsFixedLength();

                entity.Property(e => e.HisRecibo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HIS_RECIBO")
                    .IsFixedLength();

                entity.Property(e => e.InsAno)
                    .HasMaxLength(4)
                    .HasColumnName("INS_ANO")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.InsCua)
                    .HasMaxLength(1)
                    .HasColumnName("INS_CUA")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.InsDesde)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("INS_DESDE");

                entity.Property(e => e.InsHasta)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("INS_HASTA");

                entity.Property(e => e.IxeFincanti).HasColumnName("IXE_FINCANTI");

                entity.Property(e => e.IxeFindesde)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("IXE_FINDESDE");

                entity.Property(e => e.IxeFinhasta)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("IXE_FINHASTA");

                entity.Property(e => e.LegUlt).HasColumnName("LEG_ULT");

                entity.Property(e => e.LegUltCongreso).HasColumnName("LEG_ULT_CONGRESO");

                entity.Property(e => e.LegUltCongreso2).HasColumnName("LEG_ULT_CONGRESO2");

                entity.Property(e => e.LegUltMaraton).HasColumnName("LEG_ULT_MARATON");

                entity.Property(e => e.MaxComis).HasColumnName("MAX_COMIS");

                entity.Property(e => e.RecFolio).HasColumnName("REC_FOLIO");

                entity.Property(e => e.RecLibro).HasColumnName("REC_LIBRO");

                entity.Property(e => e.RegAno)
                    .HasMaxLength(4)
                    .HasColumnName("REG_ANO");

                entity.Property(e => e.RegAnoUlp)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("REG_ANO_ULP")
                    .IsFixedLength();

                entity.Property(e => e.RegCua)
                    .HasMaxLength(1)
                    .HasColumnName("REG_CUA");

                entity.Property(e => e.RegCuaUlp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REG_CUA_ULP")
                    .IsFixedLength();

                entity.Property(e => e.RegDesde)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("REG_DESDE");

                entity.Property(e => e.RegHasta)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("REG_HASTA");

                entity.Property(e => e.Solbeca).HasColumnName("SOLBECA");

                entity.Property(e => e.Taller)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TALLER")
                    .IsFixedLength();

                entity.Property(e => e.TesFolio).HasColumnName("TES_FOLIO");

                entity.Property(e => e.TesLibro).HasColumnName("TES_LIBRO");

                entity.Property(e => e.TinAno)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("TIN_ANO")
                    .IsFixedLength();

                entity.Property(e => e.TinNro).HasColumnName("TIN_NRO");

                entity.Property(e => e.TurexaUlp)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TUREXA_ULP")
                    .IsFixedLength();

                entity.Property(e => e.UltActa)
                    .HasMaxLength(8)
                    .HasColumnName("ULT_ACTA");

                entity.Property(e => e.UltFolio).HasColumnName("ULT_FOLIO");

                entity.Property(e => e.UltLibro).HasColumnName("ULT_LIBRO");

                entity.Property(e => e.UltNota).HasColumnName("ULT_NOTA");

                entity.Property(e => e.UltRecibo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ULT_RECIBO")
                    .IsFixedLength();

                entity.Property(e => e.Verano)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VERANO")
                    .IsFixedLength();

                entity.Property(e => e.WebAna)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("WEB_ANA")
                    .IsFixedLength();

                entity.Property(e => e.WebCom)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("WEB_COM")
                    .IsFixedLength();

                entity.Property(e => e.WebEnc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("WEB_ENC")
                    .IsFixedLength();

                entity.Property(e => e.WebExa)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("WEB_EXA")
                    .IsFixedLength();

                entity.Property(e => e.WebExaUlp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("WEB_EXA_ULP")
                    .IsFixedLength();

                entity.Property(e => e.WebMat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("WEB_MAT")
                    .IsFixedLength();

                entity.Property(e => e.WebMatUlp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("WEB_MAT_ULP")
                    .IsFixedLength();

                entity.Property(e => e.WebPre)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("WEB_PRE")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");
            });

            modelBuilder.Entity<PdAud>(entity =>
            {
                entity.HasKey(e => e.Audid)
                    .IsClustered(false);

                entity.ToTable("PD_AUD");

                entity.HasIndex(e => new { e.Audleg, e.Auddia }, "IX_PD_AUD_AUDLEG_AUDDIA_96");

                entity.Property(e => e.Audid).HasColumnName("AUDID");

                entity.Property(e => e.Audcod)
                    .HasMaxLength(15)
                    .HasColumnName("AUDCOD");

                entity.Property(e => e.Auddia)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("AUDDIA");

                entity.Property(e => e.Audhor)
                    .HasMaxLength(5)
                    .HasColumnName("AUDHOR");

                entity.Property(e => e.Audleg).HasColumnName("AUDLEG");

                entity.Property(e => e.Audtex).HasColumnName("AUDTEX");

                entity.Property(e => e.Audtip)
                    .HasMaxLength(4)
                    .HasColumnName("AUDTIP");

                entity.Property(e => e.Audusu)
                    .HasMaxLength(15)
                    .HasColumnName("AUDUSU");

                entity.Property(e => e.Usuide).HasColumnName("USUIDE");
            });

            modelBuilder.Entity<PdHi>(entity =>
            {
                entity.HasKey(e => e.HisId);

                entity.ToTable("PD_HIS");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ESTADO")
                    .IsFixedLength();

                entity.Property(e => e.Fechaestado)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FECHAESTADO");

                entity.Property(e => e.Fecmov)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FECMOV");

                entity.Property(e => e.Segnom)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SEGNOM")
                    .IsFixedLength();

                entity.Property(e => e.Segusu).HasColumnName("SEGUSU");
            });

            modelBuilder.Entity<PremioVistum>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PremioVista");

                entity.Property(e => e.AnoIngreso).HasMaxLength(4);

                entity.Property(e => e.Apellido).HasMaxLength(40);

                entity.Property(e => e.Aprobadas).HasColumnName("APROBADAS");

                entity.Property(e => e.CarreraId).HasColumnName("CarreraId_");

                entity.Property(e => e.Ciclo1).HasColumnName("CICLO1");

                entity.Property(e => e.Ciclo2).HasColumnName("CICLO2");

                entity.Property(e => e.Convenio).HasMaxLength(50);

                entity.Property(e => e.Estdes)
                    .HasMaxLength(30)
                    .HasColumnName("ESTDES");

                entity.Property(e => e.Fecha).HasColumnType("smalldatetime");

                entity.Property(e => e.Nombres).HasMaxLength(50);

                entity.Property(e => e.Plaest)
                    .HasMaxLength(15)
                    .HasColumnName("PLAEST");

                entity.Property(e => e.Regular).HasMaxLength(1);

                entity.Property(e => e.Rendidas).HasColumnName("RENDIDAS");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("SEXO");

                entity.Property(e => e.Sumanota).HasColumnName("SUMANOTA");
            });

            modelBuilder.Entity<Presento>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("PRESENTO");

                entity.HasIndex(e => e.Id, "Presento_Id")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Presento1)
                    .HasMaxLength(50)
                    .HasColumnName("PRESENTO");
            });

            modelBuilder.Entity<Reingreso>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("REINGRESOS");

                entity.HasIndex(e => e.Legajo, "REINGRESOS_LEG")
                    .IsClustered();

                entity.Property(e => e.Carrera).HasColumnName("CARRERA");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Legajo).HasColumnName("LEGAJO");

                entity.Property(e => e.Reifec)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("REIFEC");

                entity.Property(e => e.Reinum)
                    .HasMaxLength(10)
                    .HasColumnName("REINUM");

                entity.Property(e => e.Reiobs)
                    .HasMaxLength(50)
                    .HasColumnName("REIOBS");
            });

            modelBuilder.Entity<Sede>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("SEDES");

                entity.HasIndex(e => e.Id, "SEDES_ID")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE")
                    .IsFixedLength();

                entity.Property(e => e.Sedcop)
                    .HasMaxLength(8)
                    .HasColumnName("SEDCOP");

                entity.Property(e => e.Seddir)
                    .HasMaxLength(50)
                    .HasColumnName("SEDDIR");

                entity.Property(e => e.Sede1)
                    .HasMaxLength(50)
                    .HasColumnName("SEDE");

                entity.Property(e => e.Sedhabi)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SEDHABI")
                    .IsFixedLength();

                entity.Property(e => e.Sedloc)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("SEDLOC");

                entity.Property(e => e.Sedmai)
                    .HasMaxLength(80)
                    .HasColumnName("SEDMAI");

                entity.Property(e => e.Sedobs)
                    .HasMaxLength(50)
                    .HasColumnName("SEDOBS");

                entity.Property(e => e.Sedpar)
                    .HasMaxLength(30)
                    .HasColumnName("SEDPAR");

                entity.Property(e => e.Sedpro)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("SEDPRO");

                entity.Property(e => e.Sedsiu).HasColumnName("SEDSIU");

                entity.Property(e => e.Sedsuc)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SEDSUC")
                    .IsFixedLength();

                entity.Property(e => e.Sedtel)
                    .HasMaxLength(80)
                    .HasColumnName("SEDTEL");

                entity.Property(e => e.UltRecibo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ULT_RECIBO")
                    .IsFixedLength();
            });

            modelBuilder.Entity<SedesCar>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SEDES_CAR");

                entity.Property(e => e.Carrera).HasColumnName("CARRERA");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Sedeid).HasColumnName("SEDEID");

                entity.Property(e => e.Vale)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VALE")
                    .IsFixedLength();
            });

            modelBuilder.Entity<SedesConv>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SEDES_CONV");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Idconvenio).HasColumnName("IDCONVENIO");

                entity.Property(e => e.Sedeid).HasColumnName("SEDEID");

                entity.Property(e => e.Vale)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VALE")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Sedtut>(entity =>
            {
                entity.ToTable("SEDTUT");
            });

            modelBuilder.Entity<Sexo>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("SEXO");

                entity.HasIndex(e => e.Id, "SEXO_ID")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Sexo1)
                    .HasMaxLength(18)
                    .HasColumnName("Sexo");
            });

            modelBuilder.Entity<Subformulario>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("subformulario");

                entity.HasIndex(e => new { e.Libro, e.Folio, e.Materia }, "IX_subformulario_Libro_Folio_Materia_61");

                entity.HasIndex(e => new { e.Libro, e.Folio, e.Materia }, "IX_subformulario_Libro_Folio_Materia_64");

                entity.HasIndex(e => new { e.Libro, e.Folio, e.Materia }, "IX_subformulario_Libro_Folio_Materia_68");

                entity.HasIndex(e => new { e.Libro, e.Folio, e.Materia }, "IX_subformulario_Libro_Folio_Materia_69");

                entity.HasIndex(e => new { e.Libro, e.Folio, e.Materia, e.Tipolibro }, "IX_subformulario_Libro_Folio_Materia_TIPOLIBRO_37");

                entity.HasIndex(e => e.Materia, "IX_subformulario_Materia_66");

                entity.HasIndex(e => new { e.Resolucion, e.Resano, e.Materia }, "IX_subformulario_Resolucion_Resano_Materia_20");

                entity.HasIndex(e => new { e.Resolucion, e.Resano, e.Materia }, "IX_subformulario_Resolucion_Resano_Materia_21");

                entity.HasIndex(e => new { e.Legajo, e.Nota }, "Subformulario_LegNota");

                entity.HasIndex(e => e.Legajo, "Subformulario_legajo")
                    .IsClustered();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ciclo).HasColumnName("CICLO");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ESTADO")
                    .IsFixedLength();

                entity.Property(e => e.Semide).HasColumnName("SEMIDE");

                entity.Property(e => e.Tesis)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TESIS")
                    .IsFixedLength();

                entity.Property(e => e.Tipolibro).HasColumnName("TIPOLIBRO");
            });

            modelBuilder.Entity<Subregularidad>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("Subregularidad");

                entity.HasIndex(e => new { e.Cuatrimestre, e.Aprobo }, "IX_Subregularidad_Cuatrimestre_Aprobo_59");

                entity.HasIndex(e => new { e.Legajo, e.Materia, e.Cuatrimestre }, "SubReg_LegMatCua")
                    .IsClustered();

                entity.HasIndex(e => e.Legajo, "SubRegularidad_Leg");

                entity.Property(e => e.Anual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Aprobo).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Cuatrimestre).HasMaxLength(5);

                entity.Property(e => e.Nota1)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Nota2)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.PerCur).HasMaxLength(15);

                entity.Property(e => e.Semide).HasColumnName("SEMIDE");
            });

            modelBuilder.Entity<Turno>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Turno");

                entity.HasIndex(e => e.Id, "Turno_ID")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Turno1)
                    .HasMaxLength(30)
                    .HasColumnName("Turno");
            });

            modelBuilder.Entity<TurnoIn>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.Id, "TurnoIns_Id")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Turno).HasMaxLength(10);
            });

            modelBuilder.Entity<U3fActa>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("U3F_Actas");

                entity.HasIndex(e => e.Actanro, "IX_U3F_Actas_ACTANRO_36");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Actanro)
                    .HasMaxLength(8)
                    .HasColumnName("ACTANRO");

                entity.Property(e => e.Aula)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AULA")
                    .IsFixedLength();

                entity.Property(e => e.Campus)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CAMPUS")
                    .IsFixedLength();

                entity.Property(e => e.Cerrada)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CERRADA")
                    .IsFixedLength();

                entity.Property(e => e.Docente).HasColumnName("DOCENTE");

                entity.Property(e => e.Esta)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("ESTA");

                entity.Property(e => e.Fecha)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FECHA");

                entity.Property(e => e.Folio).HasColumnName("FOLIO");

                entity.Property(e => e.KIns).HasColumnName("K_INS");

                entity.Property(e => e.Libro).HasColumnName("LIBRO");

                entity.Property(e => e.Materia).HasColumnName("MATERIA");

                entity.Property(e => e.Observa)
                    .HasMaxLength(100)
                    .HasColumnName("OBSERVA");

                entity.Property(e => e.Reglib)
                    .HasMaxLength(1)
                    .HasColumnName("REGLIB");

                entity.Property(e => e.Sede).HasColumnName("SEDE");

                entity.Property(e => e.Semide).HasColumnName("SEMIDE");

                entity.Property(e => e.Tipolibro).HasColumnName("TIPOLIBRO");

                entity.Property(e => e.Turno).HasColumnName("TURNO");
            });

            modelBuilder.Entity<U3fAlu>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("U3F_ALU");

                entity.HasIndex(e => e.Legajo, "IX_U3F_ALU");

                entity.HasIndex(e => e.Apellido, "IX_U3F_ALU_Apellido_94");

                entity.HasIndex(e => e.Apellido, "IX_U3F_ALU_Apellido_95");

                entity.HasIndex(e => e.Docuextr, "IX_U3F_ALU_DOCUEXTR_101");

                entity.HasIndex(e => e.Documento, "IX_U3F_ALU_Documento_1");

                entity.HasIndex(e => e.Documento, "IX_U3F_ALU_Documento_102");

                entity.HasIndex(e => e.Documento, "IX_U3F_ALU_Documento_103");

                entity.HasIndex(e => e.Documento, "IX_U3F_ALU_Documento_104");

                entity.HasIndex(e => e.Documento, "IX_U3F_ALU_Documento_105");

                entity.HasIndex(e => e.LugMundo, "IX_U3F_ALU_LugMundo_78");

                entity.HasIndex(e => e.LugMundo, "IX_U3F_ALU_LugMundo_79");

                entity.HasIndex(e => e.LugMundo, "IX_U3F_ALU_LugMundo_80");

                entity.HasIndex(e => e.LugMundo, "IX_U3F_ALU_LugMundo_81");

                entity.HasIndex(e => e.LugMundo, "IX_U3F_ALU_LugMundo_82");

                entity.HasIndex(e => e.Pais, "IX_U3F_ALU_Pais_76");

                entity.HasIndex(e => e.Pais, "IX_U3F_ALU_Pais_77");

                entity.HasIndex(e => e.Visatartipo, "IX_U3F_ALU_VISATARTIPO_49");

                entity.Property(e => e.AnoIngreso).HasMaxLength(4);

                entity.Property(e => e.Apellido).HasMaxLength(40);

                entity.Property(e => e.ApellidoAuto)
                    .HasMaxLength(40)
                    .HasColumnName("APELLIDO_AUTO");

                entity.Property(e => e.ApellidoDni)
                    .HasMaxLength(40)
                    .HasColumnName("APELLIDO_DNI");

                entity.Property(e => e.CarreraId).HasColumnName("CarreraId_");

                entity.Property(e => e.Condiva).HasColumnName("CONDIVA");

                entity.Property(e => e.Convenio).HasMaxLength(1);

                entity.Property(e => e.Cp)
                    .HasMaxLength(8)
                    .HasColumnName("CP");

                entity.Property(e => e.Cuit)
                    .HasMaxLength(25)
                    .HasColumnName("CUIT");

                entity.Property(e => e.Debedni)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DEBEDNI")
                    .IsFixedLength();

                entity.Property(e => e.Debetit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DEBETIT")
                    .IsFixedLength();

                entity.Property(e => e.Direccion).HasMaxLength(160);

                entity.Property(e => e.Dispos25)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DISPOS25")
                    .IsFixedLength();

                entity.Property(e => e.Docuextr)
                    .HasMaxLength(40)
                    .HasColumnName("DOCUEXTR");

                entity.Property(e => e.Documenta)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTA")
                    .IsFixedLength();

                entity.Property(e => e.Eg1)
                    .HasMaxLength(200)
                    .HasColumnName("EG1");

                entity.Property(e => e.Eg1cod).HasColumnName("EG1COD");

                entity.Property(e => e.Eg2)
                    .HasMaxLength(200)
                    .HasColumnName("EG2");

                entity.Property(e => e.Eg2cod).HasColumnName("EG2COD");

                entity.Property(e => e.Extranjero)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EXTRANJERO")
                    .IsFixedLength();

                entity.Property(e => e.FecIns).HasColumnType("smalldatetime");

                entity.Property(e => e.FecNac).HasColumnType("smalldatetime");

                entity.Property(e => e.FecRei).HasColumnType("smalldatetime");

                entity.Property(e => e.FecSec).HasColumnType("smalldatetime");

                entity.Property(e => e.FecUni).HasColumnType("smalldatetime");

                entity.Property(e => e.Feclib)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FECLIB");

                entity.Property(e => e.Fectit)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FECTIT");

                entity.Property(e => e.FinDes).HasColumnType("smalldatetime");

                entity.Property(e => e.FinHas).HasColumnType("smalldatetime");

                entity.Property(e => e.Genero).HasColumnName("GENERO");

                entity.Property(e => e.Guabeca).HasColumnName("GUABECA");

                entity.Property(e => e.Guacuit)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("GUACUIT")
                    .IsFixedLength();

                entity.Property(e => e.Guadate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("GUADATE")
                    .IsFixedLength();

                entity.Property(e => e.Guainma).HasColumnName("GUAINMA");

                entity.Property(e => e.Guainpa).HasColumnName("GUAINPA");

                entity.Property(e => e.Gualoca).HasColumnName("GUALOCA");

                entity.Property(e => e.Guapnac).HasColumnName("GUAPNAC");

                entity.Property(e => e.Guapres).HasColumnName("GUAPRES");

                entity.Property(e => e.Guatrab).HasColumnName("GUATRAB");

                entity.Property(e => e.Intercambio)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("INTERCAMBIO")
                    .IsFixedLength();

                entity.Property(e => e.LetraDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Libreta)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LIBRETA")
                    .IsFixedLength();

                entity.Property(e => e.LocalidadId).HasColumnName("LocalidadId_");

                entity.Property(e => e.LocalidadTxt).HasMaxLength(150);

                entity.Property(e => e.LugMundo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Mail).HasMaxLength(150);

                entity.Property(e => e.Marca)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MARCA")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.MotBaja).HasMaxLength(50);

                entity.Property(e => e.Nacio).HasMaxLength(50);

                entity.Property(e => e.Nombres).HasMaxLength(50);

                entity.Property(e => e.NombresAuto)
                    .HasMaxLength(50)
                    .HasColumnName("NOMBRES_AUTO");

                entity.Property(e => e.NombresDni)
                    .HasMaxLength(50)
                    .HasColumnName("NOMBRES_DNI");

                entity.Property(e => e.Observa)
                    .HasColumnType("text")
                    .HasColumnName("OBSERVA");

                entity.Property(e => e.Orienta).HasMaxLength(1);

                entity.Property(e => e.Pais).HasMaxLength(150);

                entity.Property(e => e.Partido).HasMaxLength(150);

                entity.Property(e => e.Present3).HasColumnName("PRESENT3");

                entity.Property(e => e.Promsec).HasColumnName("PROMSEC");

                entity.Property(e => e.Recibido).HasMaxLength(1);

                entity.Property(e => e.ReguAnt).HasMaxLength(1);

                entity.Property(e => e.Regular).HasMaxLength(1);

                entity.Property(e => e.Residente)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RESIDENTE")
                    .IsFixedLength();

                entity.Property(e => e.SexoDni).HasColumnName("SEXO_DNI");

                entity.Property(e => e.SexoId).HasColumnName("SexoId_");

                entity.Property(e => e.Telefono).HasMaxLength(50);

                entity.Property(e => e.TitSec).HasMaxLength(180);

                entity.Property(e => e.TitTer).HasMaxLength(180);

                entity.Property(e => e.TitUni).HasMaxLength(180);

                entity.Property(e => e.TraHrs).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TraTipo).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Trabaja).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TurnoId).HasColumnName("TurnoId_");

                entity.Property(e => e.Usualu)
                    .HasMaxLength(100)
                    .HasColumnName("USUALU")
                    .IsFixedLength();

                entity.Property(e => e.Usucla)
                    .HasMaxLength(20)
                    .HasColumnName("USUCLA");

                entity.Property(e => e.Usuclacero)
                    .HasMaxLength(20)
                    .HasColumnName("USUCLACERO")
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Usuest)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USUEST")
                    .IsFixedLength();

                entity.Property(e => e.Usufec).HasColumnName("USUFEC");

                entity.Property(e => e.Vencresid).HasColumnName("VENCRESID");

                entity.Property(e => e.Visafecha)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("VISAFECHA");

                entity.Property(e => e.Visatarjeta)
                    .HasMaxLength(16)
                    .HasColumnName("VISATARJETA")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Visatartipo)
                    .HasMaxLength(2)
                    .HasColumnName("VISATARTIPO")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");
            });

            modelBuilder.Entity<U3fAxc>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("U3F_AXC");

                entity.HasIndex(e => e.Legajo, "AXC_LEGAJO")
                    .IsClustered();

                entity.HasIndex(e => new { e.Suspendido, e.Suspproce }, "AXC_SUSP");

                entity.HasIndex(e => new { e.AnoIngreso, e.CarreraId, e.ConvCod }, "IX_U3F_AXC_AnoIngreso_CarreraId__ConvCod_25");

                entity.HasIndex(e => new { e.AnoIngreso, e.CarreraId, e.Regular, e.Legajo }, "IX_U3F_AXC_AnoIngreso_CarreraId__Regular_Legajo_110");

                entity.HasIndex(e => new { e.AnoIngreso, e.FecIns }, "IX_U3F_AXC_AnoIngreso_FecIns_108");

                entity.HasIndex(e => e.CarreraId, "IX_U3F_AXC_CarreraId__34");

                entity.HasIndex(e => e.CarreraId, "IX_U3F_AXC_CarreraId__56");

                entity.HasIndex(e => e.CarreraId, "IX_U3F_AXC_CarreraId__85");

                entity.HasIndex(e => e.CarreraId, "IX_U3F_AXC_CarreraId__86");

                entity.HasIndex(e => e.CarreraId, "IX_U3F_AXC_CarreraId__90");

                entity.HasIndex(e => new { e.CarreraId, e.ConvCod }, "IX_U3F_AXC_CarreraId__ConvCod_60");

                entity.HasIndex(e => new { e.CarreraId, e.CuatrIngreso, e.Curing }, "IX_U3F_AXC_CarreraId__CuatrIngreso_CURING_99");

                entity.HasIndex(e => new { e.CarreraId, e.PlanId }, "IX_U3F_AXC_CarreraId__PlanId_84");

                entity.HasIndex(e => new { e.CarreraId, e.PlanId }, "IX_U3F_AXC_CarreraId__PlanId_89");

                entity.HasIndex(e => new { e.CarreraId, e.Regular }, "IX_U3F_AXC_CarreraId__Regular_50");

                entity.HasIndex(e => new { e.CarreraId, e.Regular }, "IX_U3F_AXC_CarreraId__Regular_92");

                entity.HasIndex(e => new { e.CarreraId, e.Regular }, "IX_U3F_AXC_CarreraId__Regular_93");

                entity.HasIndex(e => new { e.CarreraId, e.Regular, e.ConvCod, e.CuatrIngreso, e.Legajo }, "IX_U3F_AXC_CarreraId__Regular_ConvCod_CuatrIngreso_Legajo_111");

                entity.HasIndex(e => new { e.CarreraId, e.Regular, e.CuatrIngreso }, "IX_U3F_AXC_CarreraId__Regular_CuatrIngreso_5");

                entity.HasIndex(e => new { e.CarreraId, e.Regular, e.CuatrIngreso, e.Legajo }, "IX_U3F_AXC_CarreraId__Regular_CuatrIngreso_Legajo_109");

                entity.HasIndex(e => new { e.CarreraId, e.Regular, e.PlanId }, "IX_U3F_AXC_CarreraId__Regular_PlanId_91");

                entity.HasIndex(e => e.Regular, "IX_U3F_AXC_Regular_71");

                entity.HasIndex(e => new { e.Suspendido, e.ConvCod }, "IX_U3F_AXC_SUSPENDIDO_ConvCod_97");

                entity.HasIndex(e => new { e.Suspendido, e.ConvCod }, "IX_U3F_AXC_SUSPENDIDO_ConvCod_98");

                entity.HasIndex(e => new { e.TurnoId, e.Regular }, "IX_U3F_AXC_TurnoId__Regular_72");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AnoIngreso).HasMaxLength(4);

                entity.Property(e => e.Bcoleg).HasColumnName("BCOLEG");

                entity.Property(e => e.CarreraId).HasColumnName("CarreraId_");

                entity.Property(e => e.Convenio).HasMaxLength(1);

                entity.Property(e => e.CuatrIngreso)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CuotaIngreso)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Cuotacero)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CUOTACERO")
                    .IsFixedLength();

                entity.Property(e => e.Curing)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CURING")
                    .IsFixedLength();

                entity.Property(e => e.FecIns).HasColumnType("smalldatetime");

                entity.Property(e => e.FecRei).HasColumnType("smalldatetime");

                entity.Property(e => e.FinDes).HasColumnType("smalldatetime");

                entity.Property(e => e.FinHas).HasColumnType("smalldatetime");

                entity.Property(e => e.MotBaja).HasMaxLength(50);

                entity.Property(e => e.Orienta).HasMaxLength(1);

                entity.Property(e => e.Recibido).HasMaxLength(1);

                entity.Property(e => e.Recifecha)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("RECIFECHA");

                entity.Property(e => e.ReguAnt).HasMaxLength(1);

                entity.Property(e => e.Regular).HasMaxLength(1);

                entity.Property(e => e.ResAno).HasMaxLength(4);

                entity.Property(e => e.ResFec).HasColumnType("smalldatetime");

                entity.Property(e => e.Suspcuatri)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("SUSPCUATRI")
                    .IsFixedLength();

                entity.Property(e => e.Suspendido)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SUSPENDIDO")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Suspfecha)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("SUSPFECHA");

                entity.Property(e => e.Suspproce).HasColumnName("SUSPPROCE");

                entity.Property(e => e.TurnoId).HasColumnName("TurnoId_");

                entity.Property(e => e.UpcnafiliadoNro).HasColumnName("UPCNAfiliadoNro");

                entity.Property(e => e.UpcnafiliadoTipo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("UPCNAfiliadoTipo")
                    .IsFixedLength();

                entity.Property(e => e.Visacod)
                    .HasMaxLength(8)
                    .HasColumnName("VISACOD")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Visafec)
                    .HasColumnType("date")
                    .HasColumnName("VISAFEC");

                entity.Property(e => e.Visafue)
                    .HasMaxLength(1)
                    .HasColumnName("VISAFUE")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Visapri)
                    .HasMaxLength(1)
                    .HasColumnName("VISAPRI")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");
            });

            modelBuilder.Entity<U3fMesa>(entity =>
            {
                entity.ToTable("U3F_Mesas");

                entity.HasIndex(e => new { e.Mescar, e.Mescua, e.Reglib }, "IX_U3F_Mesas_MESCAR_MESCUA_REGLIB_28");

                entity.HasIndex(e => new { e.Mescar, e.Mesmat, e.Mescon, e.Mescua }, "IX_U3F_Mesas_MESCAR_MESMAT_MESCON_MESCUA_55");

                entity.HasIndex(e => new { e.Mescar, e.Mesmat, e.Mescon, e.Mescua, e.Reglib }, "IX_U3F_Mesas_MESCAR_MESMAT_MESCON_MESCUA_REGLIB_62");

                entity.HasIndex(e => new { e.Mescar, e.Mesmat, e.Mescon, e.Messed, e.Mescua, e.Reglib }, "IX_U3F_Mesas_MESCAR_MESMAT_MESCON_MESSED_MESCUA_REGLIB_54");

                entity.HasIndex(e => new { e.Mescar, e.Mesmat, e.Mescua, e.Reglib }, "IX_U3F_Mesas_MESCAR_MESMAT_MESCUA_REGLIB_53");

                entity.HasIndex(e => new { e.Mescon, e.Mescua, e.Reglib }, "IX_U3F_Mesas_MESCON_MESCUA_REGLIB_24");

                entity.HasIndex(e => new { e.Mescon, e.Messed, e.Mescua }, "IX_U3F_Mesas_MESCON_MESSED_MESCUA_11");

                entity.HasIndex(e => new { e.Mescon, e.Messed, e.Mescua }, "IX_U3F_Mesas_MESCON_MESSED_MESCUA_7");

                entity.HasIndex(e => new { e.Mescon, e.Messed, e.Mescua }, "IX_U3F_Mesas_MESCON_MESSED_MESCUA_9");

                entity.HasIndex(e => new { e.Mescon, e.Messed, e.Mescua, e.Mesdoc }, "IX_U3F_Mesas_MESCON_MESSED_MESCUA_MESDOC_63");

                entity.HasIndex(e => e.Mescua, "IX_U3F_Mesas_MESCUA_10");

                entity.HasIndex(e => e.Mescua, "IX_U3F_Mesas_MESCUA_12");

                entity.HasIndex(e => e.Mescua, "IX_U3F_Mesas_MESCUA_8");

                entity.HasIndex(e => new { e.Mescua, e.Mesdoc }, "IX_U3F_Mesas_MESCUA_MESDOC_13");

                entity.HasIndex(e => new { e.Mescua, e.Mesdoc }, "IX_U3F_Mesas_MESCUA_MESDOC_14");

                entity.HasIndex(e => new { e.Mescua, e.Mesdoc }, "IX_U3F_Mesas_MESCUA_MESDOC_15");

                entity.HasIndex(e => new { e.Mescua, e.Mesdoc }, "IX_U3F_Mesas_MESCUA_MESDOC_16");

                entity.HasIndex(e => new { e.Mescua, e.Mesdoc, e.Reglib }, "IX_U3F_Mesas_MESCUA_MESDOC_REGLIB_47");

                entity.HasIndex(e => new { e.Mescua, e.Reglib }, "IX_U3F_Mesas_MESCUA_REGLIB_26");

                entity.HasIndex(e => new { e.Mesmat, e.Mescon, e.Messed, e.Mescua }, "IX_U3F_Mesas_MESMAT_MESCON_MESSED_MESCUA_52");

                entity.HasIndex(e => new { e.Mesmat, e.Mescua }, "IX_U3F_Mesas_MESMAT_MESCUA_31");

                entity.HasIndex(e => new { e.Mesmat, e.Mescua, e.Mesdoc }, "IX_U3F_Mesas_MESMAT_MESCUA_MESDOC_48");

                entity.HasIndex(e => new { e.Mesmat, e.Mescua, e.Mesdoc, e.Reglib }, "IX_U3F_Mesas_MESMAT_MESCUA_MESDOC_REGLIB_29");

                entity.HasIndex(e => new { e.Mesmat, e.Mescua, e.Reglib }, "IX_U3F_Mesas_MESMAT_MESCUA_REGLIB_32");

                entity.HasIndex(e => new { e.Mesmat, e.Mesdoc }, "IX_U3F_Mesas_MESMAT_MESDOC_30");

                entity.Property(e => e.Campus)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CAMPUS")
                    .IsFixedLength();

                entity.Property(e => e.Doccua)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("DOCCUA")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Mesac1)
                    .HasMaxLength(8)
                    .HasColumnName("MESAC1")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Mesac2)
                    .HasMaxLength(8)
                    .HasColumnName("MESAC2")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Mesac3)
                    .HasMaxLength(8)
                    .HasColumnName("MESAC3")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Mescar).HasColumnName("MESCAR");

                entity.Property(e => e.Mescom).HasColumnName("MESCOM");

                entity.Property(e => e.Mescon).HasColumnName("MESCON");

                entity.Property(e => e.Mescua)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MESCUA")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Mesdoc).HasColumnName("MESDOC");

                entity.Property(e => e.Mesfe1)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("MESFE1");

                entity.Property(e => e.Mesfe2)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("MESFE2");

                entity.Property(e => e.Mesfe3)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("MESFE3");

                entity.Property(e => e.Mesho1)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MESHO1")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Mesho2)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MESHO2")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Mesho3)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MESHO3")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Mesins).HasColumnName("MESINS");

                entity.Property(e => e.Mesmat).HasColumnName("MESMAT");

                entity.Property(e => e.Mesob1)
                    .HasMaxLength(100)
                    .HasColumnName("MESOB1")
                    .IsFixedLength();

                entity.Property(e => e.Mesob2)
                    .HasMaxLength(100)
                    .HasColumnName("MESOB2")
                    .IsFixedLength();

                entity.Property(e => e.Mesob3)
                    .HasMaxLength(100)
                    .HasColumnName("MESOB3")
                    .IsFixedLength();

                entity.Property(e => e.Mesoc1).HasColumnName("MESOC1");

                entity.Property(e => e.Mesoc2).HasColumnName("MESOC2");

                entity.Property(e => e.Mesoc3).HasColumnName("MESOC3");

                entity.Property(e => e.Mesref1)
                    .HasColumnType("date")
                    .HasColumnName("MESREF1");

                entity.Property(e => e.Mesref2)
                    .HasColumnType("date")
                    .HasColumnName("MESREF2");

                entity.Property(e => e.Mesref3)
                    .HasColumnType("date")
                    .HasColumnName("MESREF3");

                entity.Property(e => e.Mesrem1)
                    .HasMaxLength(20)
                    .HasColumnName("MESREM1")
                    .IsFixedLength();

                entity.Property(e => e.Mesrem2)
                    .HasMaxLength(20)
                    .HasColumnName("MESREM2")
                    .IsFixedLength();

                entity.Property(e => e.Mesrem3)
                    .HasMaxLength(20)
                    .HasColumnName("MESREM3")
                    .IsFixedLength();

                entity.Property(e => e.Messed).HasColumnName("MESSED");

                entity.Property(e => e.Messt1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MESST1")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Messt2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MESST2")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Messt3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MESST3")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Messta)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MESSTA")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Mestop).HasColumnName("MESTOP");

                entity.Property(e => e.Reglib)
                    .HasMaxLength(1)
                    .HasColumnName("REGLIB")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");
            });

            modelBuilder.Entity<U3fMesasUlp>(entity =>
            {
                entity.ToTable("U3F_Mesas_ULP");

                entity.Property(e => e.Campus)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CAMPUS")
                    .IsFixedLength();

                entity.Property(e => e.Doccua)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("DOCCUA")
                    .IsFixedLength();

                entity.Property(e => e.Mesac1)
                    .HasMaxLength(8)
                    .HasColumnName("MESAC1")
                    .IsFixedLength();

                entity.Property(e => e.Mesac2)
                    .HasMaxLength(8)
                    .HasColumnName("MESAC2")
                    .IsFixedLength();

                entity.Property(e => e.Mesac3)
                    .HasMaxLength(8)
                    .HasColumnName("MESAC3")
                    .IsFixedLength();

                entity.Property(e => e.Mescar).HasColumnName("MESCAR");

                entity.Property(e => e.Mescom).HasColumnName("MESCOM");

                entity.Property(e => e.Mescon).HasColumnName("MESCON");

                entity.Property(e => e.Mescua)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MESCUA")
                    .IsFixedLength();

                entity.Property(e => e.Mesdoc).HasColumnName("MESDOC");

                entity.Property(e => e.Mesfe1)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("MESFE1");

                entity.Property(e => e.Mesfe2)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("MESFE2");

                entity.Property(e => e.Mesfe3)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("MESFE3");

                entity.Property(e => e.Mesho1)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MESHO1")
                    .IsFixedLength();

                entity.Property(e => e.Mesho2)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MESHO2")
                    .IsFixedLength();

                entity.Property(e => e.Mesho3)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MESHO3")
                    .IsFixedLength();

                entity.Property(e => e.Mesid1).HasColumnName("MESID1");

                entity.Property(e => e.Mesid2).HasColumnName("MESID2");

                entity.Property(e => e.Mesid3).HasColumnName("MESID3");

                entity.Property(e => e.Mesin1).HasColumnName("MESIN1");

                entity.Property(e => e.Mesin2).HasColumnName("MESIN2");

                entity.Property(e => e.Mesin3).HasColumnName("MESIN3");

                entity.Property(e => e.Mesins).HasColumnName("MESINS");

                entity.Property(e => e.Mesmat).HasColumnName("MESMAT");

                entity.Property(e => e.Mesob1)
                    .HasMaxLength(100)
                    .HasColumnName("MESOB1")
                    .IsFixedLength();

                entity.Property(e => e.Mesob2)
                    .HasMaxLength(100)
                    .HasColumnName("MESOB2")
                    .IsFixedLength();

                entity.Property(e => e.Mesob3)
                    .HasMaxLength(100)
                    .HasColumnName("MESOB3")
                    .IsFixedLength();

                entity.Property(e => e.Mesoc1).HasColumnName("MESOC1");

                entity.Property(e => e.Mesoc2).HasColumnName("MESOC2");

                entity.Property(e => e.Mesoc3).HasColumnName("MESOC3");

                entity.Property(e => e.Mesref1)
                    .HasColumnType("date")
                    .HasColumnName("MESREF1");

                entity.Property(e => e.Mesref2)
                    .HasColumnType("date")
                    .HasColumnName("MESREF2");

                entity.Property(e => e.Mesref3)
                    .HasColumnType("date")
                    .HasColumnName("MESREF3");

                entity.Property(e => e.Mesrem1)
                    .HasMaxLength(20)
                    .HasColumnName("MESREM1")
                    .IsFixedLength();

                entity.Property(e => e.Mesrem2)
                    .HasMaxLength(20)
                    .HasColumnName("MESREM2")
                    .IsFixedLength();

                entity.Property(e => e.Mesrem3)
                    .HasMaxLength(20)
                    .HasColumnName("MESREM3")
                    .IsFixedLength();

                entity.Property(e => e.Messed).HasColumnName("MESSED");

                entity.Property(e => e.Messt1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MESST1")
                    .IsFixedLength();

                entity.Property(e => e.Messt2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MESST2")
                    .IsFixedLength();

                entity.Property(e => e.Messt3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MESST3")
                    .IsFixedLength();

                entity.Property(e => e.Messta)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MESSTA")
                    .IsFixedLength();

                entity.Property(e => e.Mestop).HasColumnName("MESTOP");

                entity.Property(e => e.Mestur)
                    .HasMaxLength(15)
                    .HasColumnName("MESTUR")
                    .IsFixedLength();

                entity.Property(e => e.Reglib)
                    .HasMaxLength(1)
                    .HasColumnName("REGLIB")
                    .IsFixedLength();
            });

            modelBuilder.Entity<U3fMod>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("U3F_MOD");

                entity.HasIndex(e => e.Legajo, "IX_U3F_MOD_Legajo_2");

                entity.Property(e => e.AnoIngreso).HasMaxLength(4);

                entity.Property(e => e.Estado).HasMaxLength(1);

                entity.Property(e => e.FecIns).HasColumnType("smalldatetime");

                entity.Property(e => e.FecMod).HasColumnType("smalldatetime");

                entity.Property(e => e.Observ).HasMaxLength(50);

                entity.Property(e => e.Orienta).HasMaxLength(1);

                entity.Property(e => e.ResAno).HasMaxLength(4);

                entity.Property(e => e.ResFec).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<U3fPlane>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("U3F_Planes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ano).HasColumnName("ANO");

                entity.Property(e => e.Ciclo).HasColumnName("CICLO");

                entity.Property(e => e.Cuatrimestre).HasMaxLength(1);

                entity.Property(e => e.HoraSocultaem).HasColumnName("HoraSOCULTAem");

                entity.Property(e => e.Horas).HasColumnName("HORAS");

                entity.Property(e => e.Inscriptos).HasColumnName("INSCRIPTOS");

                entity.Property(e => e.Libre)
                    .HasMaxLength(1)
                    .HasColumnName("LIBRE");

                entity.Property(e => e.Limite).HasColumnName("LIMITE");

                entity.Property(e => e.Oculta)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OCULTA")
                    .IsFixedLength();

                entity.Property(e => e.Orientacion).HasColumnName("ORIENTACION");

                entity.Property(e => e.PlanId).HasColumnName("PlanID");

                entity.Property(e => e.Tipo).HasMaxLength(1);
            });

            modelBuilder.Entity<UlpConvsedetut>(entity =>
            {
                entity.ToTable("ULP_CONVSEDETUT");

                entity.Property(e => e.InsCar)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InsExa)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InsMat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<UlpSede>(entity =>
            {
                entity.ToTable("ULP_SEDES");

                entity.Property(e => e.UsedCapc).HasColumnName("USED_CAPC");

                entity.Property(e => e.UsedDire)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USED_DIRE")
                    .IsFixedLength();

                entity.Property(e => e.UsedDpto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USED_DPTO")
                    .IsFixedLength();

                entity.Property(e => e.UsedHabi)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USED_HABI")
                    .IsFixedLength();

                entity.Property(e => e.UsedJu)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USED_JU")
                    .IsFixedLength();

                entity.Property(e => e.UsedLoca)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USED_LOCA")
                    .IsFixedLength();

                entity.Property(e => e.UsedLu)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USED_LU")
                    .IsFixedLength();

                entity.Property(e => e.UsedMa)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USED_MA")
                    .IsFixedLength();

                entity.Property(e => e.UsedMi)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USED_MI")
                    .IsFixedLength();

                entity.Property(e => e.UsedPers)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("USED_PERS")
                    .IsFixedLength();

                entity.Property(e => e.UsedSa)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USED_SA")
                    .IsFixedLength();

                entity.Property(e => e.UsedVi)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USED_VI")
                    .IsFixedLength();
            });

            modelBuilder.Entity<UlpSedesTurno>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ULP_SEDES_TURNO");

                entity.Property(e => e.UsedHorad)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("USED_HORAD")
                    .IsFixedLength();

                entity.Property(e => e.UsedHorah)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("USED_HORAH")
                    .IsFixedLength();

                entity.Property(e => e.UsedTurno)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("USED_TURNO")
                    .IsFixedLength();
            });

            modelBuilder.Entity<UtfAluxRen>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("UTF_AluxRen");

                entity.Property(e => e.AnoIngreso).HasMaxLength(4);

                entity.Property(e => e.Apellido).HasMaxLength(40);

                entity.Property(e => e.Aprobadas).HasColumnName("APROBADAS");

                entity.Property(e => e.CarreraId).HasColumnName("CarreraId_");

                entity.Property(e => e.Ciclo1).HasColumnName("CICLO1");

                entity.Property(e => e.Ciclo2).HasColumnName("CICLO2");

                entity.Property(e => e.Convenio).HasMaxLength(50);

                entity.Property(e => e.Estdes)
                    .HasMaxLength(30)
                    .HasColumnName("ESTDES");

                entity.Property(e => e.Nombres).HasMaxLength(50);

                entity.Property(e => e.Plaest)
                    .HasMaxLength(15)
                    .HasColumnName("PLAEST");

                entity.Property(e => e.Regular).HasMaxLength(1);

                entity.Property(e => e.Rendidas).HasColumnName("RENDIDAS");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("SEXO");

                entity.Property(e => e.Sumanota).HasColumnName("SUMANOTA");
            });

            modelBuilder.Entity<UvCod>(entity =>
            {
                entity.HasKey(e => e.Codcod);

                entity.ToTable("UV_COD");

                entity.Property(e => e.Codcod)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CODCOD")
                    .IsFixedLength();

                entity.Property(e => e.Codcue)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CODCUE")
                    .IsFixedLength();

                entity.Property(e => e.Coddes)
                    .HasMaxLength(50)
                    .HasColumnName("CODDES");

                entity.Property(e => e.Coddoh)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CODDOH")
                    .IsFixedLength();

                entity.Property(e => e.Codgrc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("CODGRC")
                    .IsFixedLength();

                entity.Property(e => e.Codide)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CODIDE");

                entity.Property(e => e.Codimp)
                    .HasColumnType("money")
                    .HasColumnName("CODIMP");

                entity.Property(e => e.Codint)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CODINT")
                    .IsFixedLength();

                entity.Property(e => e.Codiva)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CODIVA")
                    .IsFixedLength();

                entity.Property(e => e.Codtco).HasColumnName("CODTCO");

                entity.Property(e => e.Codtim)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CODTIM")
                    .IsFixedLength();
            });

            modelBuilder.Entity<UvFecha>(entity =>
            {
                entity.ToTable("UV_Fechas");

                entity.Property(e => e.Feccod)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("FECCOD")
                    .IsFixedLength();

                entity.Property(e => e.Fecvt1)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FECVT1");

                entity.Property(e => e.Fecvt2)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FECVT2");

                entity.Property(e => e.Montoidioma).HasColumnName("MONTOIDIOMA");
            });

            modelBuilder.Entity<UvMov>(entity =>
            {
                entity.HasKey(e => e.Movide);

                entity.ToTable("UV_MOV");

                entity.HasIndex(e => e.Movbar, "IX_UV_MOV_MOVBAR_18");

                entity.HasIndex(e => new { e.Movcar, e.Movope, e.Movfec }, "IX_UV_MOV_MOVCAR_MOVOPE_MOVFEC_121");

                entity.HasIndex(e => new { e.Movfec, e.Movope }, "IX_UV_MOV_MOVFEC_MOVOPE_22");

                entity.HasIndex(e => e.Movope, "IX_UV_MOV_MOVOPE_19");

                entity.HasIndex(e => e.Npsord, "IX_UV_MOV_NPSORD_41");

                entity.HasIndex(e => e.Movleg, "MOVLEG");

                entity.Property(e => e.Movide).HasColumnName("MOVIDE");

                entity.Property(e => e.Cotifecha)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("COTIFECHA");

                entity.Property(e => e.Cotizacion).HasColumnName("COTIZACION");

                entity.Property(e => e.Facerr).HasColumnName("FACERR");

                entity.Property(e => e.Facide)
                    .HasMaxLength(15)
                    .HasColumnName("FACIDE")
                    .IsFixedLength();

                entity.Property(e => e.Facpdf)
                    .HasMaxLength(50)
                    .HasColumnName("FACPDF");

                entity.Property(e => e.Mov2fe)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("MOV2FE");

                entity.Property(e => e.Mov2im)
                    .HasColumnType("money")
                    .HasColumnName("MOV2IM");

                entity.Property(e => e.Movbar)
                    .HasMaxLength(40)
                    .HasColumnName("MOVBAR");

                entity.Property(e => e.Movcar).HasColumnName("MOVCAR");

                entity.Property(e => e.Movcre)
                    .HasColumnType("money")
                    .HasColumnName("MOVCRE");

                entity.Property(e => e.Movcredol)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("MOVCREDOL");

                entity.Property(e => e.Movcuo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("MOVCUO")
                    .IsFixedLength();

                entity.Property(e => e.Movdeb)
                    .HasColumnType("money")
                    .HasColumnName("MOVDEB");

                entity.Property(e => e.Movdebdol)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("MOVDEBDOL");

                entity.Property(e => e.Movfec)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("MOVFEC");

                entity.Property(e => e.Movleg).HasColumnName("MOVLEG");

                entity.Property(e => e.Movley)
                    .HasMaxLength(100)
                    .HasColumnName("MOVLEY");

                entity.Property(e => e.Movope)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("MOVOPE")
                    .IsFixedLength();

                entity.Property(e => e.Movopi).HasColumnName("MOVOPI");

                entity.Property(e => e.Movper)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("MOVPER")
                    .IsFixedLength();

                entity.Property(e => e.Movpro)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("MOVPRO");

                entity.Property(e => e.Movsal)
                    .HasColumnType("money")
                    .HasColumnName("MOVSAL");

                entity.Property(e => e.Movsam)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MOVSAM")
                    .IsFixedLength();

                entity.Property(e => e.Npsord)
                    .HasMaxLength(25)
                    .HasColumnName("NPSORD")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Npsres)
                    .HasMaxLength(50)
                    .HasColumnName("NPSRES")
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Npssta)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("NPSSTA")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Npstar)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("NPSTAR")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Npstra)
                    .HasMaxLength(25)
                    .HasColumnName("NPSTRA")
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Pagfpa)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("PAGFPA");

                entity.Property(e => e.Pagide).HasColumnName("PAGIDE");

                entity.Property(e => e.Pagomicta)
                    .HasMaxLength(10)
                    .HasColumnName("PAGOMICTA")
                    .IsFixedLength();

                entity.Property(e => e.Pagopor).HasColumnName("PAGOPOR");

                entity.Property(e => e.Visadeb)
                    .HasMaxLength(8)
                    .HasColumnName("VISADEB")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Visafec)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("VISAFEC");

                entity.Property(e => e.Visafue)
                    .HasMaxLength(1)
                    .HasColumnName("VISAFUE")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Visaope)
                    .HasMaxLength(1)
                    .HasColumnName("VISAOPE")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Visapun)
                    .HasMaxLength(8)
                    .HasColumnName("VISAPUN")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Visatarjeta)
                    .HasMaxLength(16)
                    .HasColumnName("VISATARJETA")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Visatartipo)
                    .HasMaxLength(1)
                    .HasColumnName("VISATARTIPO")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");
            });

            modelBuilder.Entity<UvPag>(entity =>
            {
                entity.HasKey(e => e.Pagide);

                entity.ToTable("UV_PAG");

                entity.HasIndex(e => e.Pagfpa, "IX_UV_PAG_PAGFPA_17");

                entity.Property(e => e.Pagide).HasColumnName("PAGIDE");

                entity.Property(e => e.Pagbar)
                    .HasMaxLength(40)
                    .HasColumnName("PAGBAR");

                entity.Property(e => e.Pagcta)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PAGCTA")
                    .IsFixedLength();

                entity.Property(e => e.Pagdeb).HasColumnName("PAGDEB");

                entity.Property(e => e.Pagfpa)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("PAGFPA");

                entity.Property(e => e.Pagfpr)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("PAGFPR");

                entity.Property(e => e.Pagfre)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("PAGFRE");

                entity.Property(e => e.Paghor).HasColumnName("PAGHOR");

                entity.Property(e => e.Pagimp)
                    .HasColumnType("money")
                    .HasColumnName("PAGIMP");

                entity.Property(e => e.Pagleg).HasColumnName("PAGLEG");

                entity.Property(e => e.Pagper)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("PAGPER")
                    .IsFixedLength();

                entity.Property(e => e.Pagpro)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("PAGPRO");

                entity.Property(e => e.Pagter)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("PAGTER")
                    .IsFixedLength();

                entity.Property(e => e.Pagvto)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("PAGVTO");
            });

            modelBuilder.Entity<UvPagomiscuenta>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UV_PAGOMISCUENTAS");

                entity.Property(e => e.Pagbar)
                    .HasMaxLength(40)
                    .HasColumnName("PAGBAR");

                entity.Property(e => e.Pagcta)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PAGCTA")
                    .IsFixedLength();

                entity.Property(e => e.Pagdeb).HasColumnName("PAGDEB");

                entity.Property(e => e.Pagfpa)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("PAGFPA");

                entity.Property(e => e.Pagfpr)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("PAGFPR");

                entity.Property(e => e.Pagfre)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("PAGFRE");

                entity.Property(e => e.Paghor).HasColumnName("PAGHOR");

                entity.Property(e => e.Pagide)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PAGIDE");

                entity.Property(e => e.Pagimp)
                    .HasColumnType("money")
                    .HasColumnName("PAGIMP");

                entity.Property(e => e.Pagleg).HasColumnName("PAGLEG");

                entity.Property(e => e.Pagper)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("PAGPER")
                    .IsFixedLength();

                entity.Property(e => e.Pagpro)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("PAGPRO");

                entity.Property(e => e.Pagter)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("PAGTER")
                    .IsFixedLength();

                entity.Property(e => e.Pagvto)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("PAGVTO");
            });

            modelBuilder.Entity<UvPagosnps1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UV_PAGOSNPS1");

                entity.Property(e => e.Codautorizacion).HasColumnName("CODAUTORIZACION");

                entity.Property(e => e.Estadolote)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ESTADOLOTE")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("FECHA");

                entity.Property(e => e.Fecpro)
                    .HasColumnType("date")
                    .HasColumnName("FECPRO");

                entity.Property(e => e.Folio)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("FOLIO")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ide).ValueGeneratedOnAdd();

                entity.Property(e => e.Importe)
                    .HasColumnType("money")
                    .HasColumnName("IMPORTE");

                entity.Property(e => e.Lote).HasColumnName("LOTE");

                entity.Property(e => e.Pagcta)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PAGCTA")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Pagdeb).HasColumnName("PAGDEB");

                entity.Property(e => e.Producto)
                    .HasMaxLength(10)
                    .HasColumnName("PRODUCTO")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Respuesta)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("RESPUESTA")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");
            });

            modelBuilder.Entity<UvPlatot>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UV_PLATOT");

                entity.Property(e => e.Carrera)
                    .HasMaxLength(120)
                    .IsFixedLength();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.PlanEst)
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.PlanRes)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.PlanVig).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<UvVisapag>(entity =>
            {
                entity.ToTable("UV_VISAPAG");

                entity.Property(e => e.Carrera).HasColumnName("CARRERA");

                entity.Property(e => e.Cuenta)
                    .HasMaxLength(10)
                    .HasColumnName("CUENTA")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Estado)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("ESTADO")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Fechaori)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FECHAORI");

                entity.Property(e => e.Fechapago)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FECHAPAGO");

                entity.Property(e => e.Fechaproc)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FECHAPROC");

                entity.Property(e => e.Importe)
                    .HasColumnType("money")
                    .HasColumnName("IMPORTE");

                entity.Property(e => e.Legajo).HasColumnName("LEGAJO");

                entity.Property(e => e.Pagcta)
                    .HasMaxLength(1)
                    .HasColumnName("PAGCTA")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Pagdeb).HasColumnName("PAGDEB");

                entity.Property(e => e.Pagopor).HasColumnName("PAGOPOR");

                entity.Property(e => e.Rechazo)
                    .HasMaxLength(62)
                    .HasColumnName("RECHAZO")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Tarjeta)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("TARJETA")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Tartipo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TARTIPO")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");
            });

            modelBuilder.Entity<ViSede>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VI_SEDE");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Localidad).HasMaxLength(60);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE")
                    .IsFixedLength();

                entity.Property(e => e.Provden)
                    .HasMaxLength(20)
                    .HasColumnName("PROVDEN");

                entity.Property(e => e.Sedcop)
                    .HasMaxLength(8)
                    .HasColumnName("SEDCOP");

                entity.Property(e => e.Seddir)
                    .HasMaxLength(50)
                    .HasColumnName("SEDDIR");

                entity.Property(e => e.Sede)
                    .HasMaxLength(50)
                    .HasColumnName("SEDE");

                entity.Property(e => e.Sedloc)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("SEDLOC");

                entity.Property(e => e.Sedmai)
                    .HasMaxLength(50)
                    .HasColumnName("SEDMAI");

                entity.Property(e => e.Sedobs)
                    .HasMaxLength(50)
                    .HasColumnName("SEDOBS");

                entity.Property(e => e.Sedpar)
                    .HasMaxLength(30)
                    .HasColumnName("SEDPAR");

                entity.Property(e => e.Sedpro)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("SEDPRO");

                entity.Property(e => e.Sedsuc)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SEDSUC")
                    .IsFixedLength();

                entity.Property(e => e.Sedtel)
                    .HasMaxLength(40)
                    .HasColumnName("SEDTEL");

                entity.Property(e => e.UltRecibo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ULT_RECIBO")
                    .IsFixedLength();
            });



          

            modelBuilder.Entity<VisExaCur>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIS_EXA_CUR");

                entity.Property(e => e.Abr)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ABR")
                    .IsFixedLength();

                entity.Property(e => e.Actanro)
                    .HasMaxLength(8)
                    .HasColumnName("ACTANRO");

                entity.Property(e => e.AnoIngreso).HasMaxLength(4);

                entity.Property(e => e.Apellido).HasMaxLength(40);

                entity.Property(e => e.Aula)
                    .HasMaxLength(10)
                    .HasColumnName("AULA");

                entity.Property(e => e.Bcoleg).HasColumnName("BCOLEG");

                entity.Property(e => e.Campus)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CAMPUS")
                    .IsFixedLength();

                entity.Property(e => e.CarreId).HasColumnName("CARRE_ID");

                entity.Property(e => e.Carrera).HasMaxLength(120);

                entity.Property(e => e.Convenio).HasMaxLength(50);

                entity.Property(e => e.Cuatrimestre)
                    .HasMaxLength(5)
                    .HasColumnName("CUATRIMESTRE");

                entity.Property(e => e.Docente)
                    .HasMaxLength(50)
                    .HasColumnName("docente");

                entity.Property(e => e.Equivale)
                    .HasMaxLength(1)
                    .HasColumnName("EQUIVALE");

                entity.Property(e => e.Estdes)
                    .HasMaxLength(30)
                    .HasColumnName("ESTDES");

                entity.Property(e => e.Fecha)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FECHA");

                entity.Property(e => e.Fue)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("FUE");

                entity.Property(e => e.Inicio)
                    .HasMaxLength(5)
                    .HasColumnName("INICIO");

                entity.Property(e => e.Legajo).HasColumnName("LEGAJO");

                entity.Property(e => e.Mail).HasMaxLength(150);

                entity.Property(e => e.Materia).HasColumnName("MATERIA");

                entity.Property(e => e.Materias)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("materias");

                entity.Property(e => e.Mesa).HasColumnName("MESA");

                entity.Property(e => e.Mescom).HasColumnName("MESCOM");

                entity.Property(e => e.Mesdoc).HasColumnName("MESDOC");

                entity.Property(e => e.Messed).HasColumnName("MESSED");

                entity.Property(e => e.Nombres).HasMaxLength(50);

                entity.Property(e => e.Nota).HasColumnName("NOTA");

                entity.Property(e => e.Pagos)
                    .HasMaxLength(1)
                    .HasColumnName("PAGOS");

                entity.Property(e => e.Reglib)
                    .HasMaxLength(1)
                    .HasColumnName("REGLIB");

                entity.Property(e => e.Regular)
                    .HasMaxLength(1)
                    .HasColumnName("REGULAR");

                entity.Property(e => e.Sede)
                    .HasMaxLength(50)
                    .HasColumnName("SEDE");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("SEXO");

                entity.Property(e => e.Telefono).HasMaxLength(50);

                entity.Property(e => e.Todomal)
                    .HasMaxLength(1)
                    .HasColumnName("TODOMAL");

                entity.Property(e => e.Turno).HasColumnName("TURNO");

                entity.Property(e => e.VisId).HasColumnName("VIS_ID");
            });

            modelBuilder.Entity<VisExaCurUlp>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIS_EXA_CUR_ULP");

                entity.Property(e => e.Abr)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ABR")
                    .IsFixedLength();

                entity.Property(e => e.Actanro)
                    .HasMaxLength(8)
                    .HasColumnName("ACTANRO");

                entity.Property(e => e.AnoIngreso).HasMaxLength(4);

                entity.Property(e => e.Apellido).HasMaxLength(40);

                entity.Property(e => e.Aula)
                    .HasMaxLength(10)
                    .HasColumnName("AULA");

                entity.Property(e => e.Campus)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CAMPUS")
                    .IsFixedLength();

                entity.Property(e => e.CarreId).HasColumnName("CARRE_ID");

                entity.Property(e => e.Carrera).HasMaxLength(120);

                entity.Property(e => e.Convenio).HasMaxLength(50);

                entity.Property(e => e.Cuatrimestre)
                    .HasMaxLength(5)
                    .HasColumnName("CUATRIMESTRE");

                entity.Property(e => e.Docente)
                    .HasMaxLength(50)
                    .HasColumnName("docente");

                entity.Property(e => e.Equivale)
                    .HasMaxLength(1)
                    .HasColumnName("EQUIVALE");

                entity.Property(e => e.Estdes)
                    .HasMaxLength(30)
                    .HasColumnName("ESTDES");

                entity.Property(e => e.Fecha)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FECHA");

                entity.Property(e => e.Fue)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("FUE");

                entity.Property(e => e.Inicio)
                    .HasMaxLength(5)
                    .HasColumnName("INICIO");

                entity.Property(e => e.Legajo).HasColumnName("LEGAJO");

                entity.Property(e => e.Mail).HasMaxLength(150);

                entity.Property(e => e.Materia).HasColumnName("MATERIA");

                entity.Property(e => e.Materias)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("materias");

                entity.Property(e => e.Mesa).HasColumnName("MESA");

                entity.Property(e => e.Mescom).HasColumnName("MESCOM");

                entity.Property(e => e.Mesdoc).HasColumnName("MESDOC");

                entity.Property(e => e.Messed).HasColumnName("MESSED");

                entity.Property(e => e.Mestur)
                    .HasMaxLength(15)
                    .HasColumnName("MESTUR")
                    .IsFixedLength();

                entity.Property(e => e.Mesturexa)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MESTUREXA")
                    .IsFixedLength();

                entity.Property(e => e.Nombres).HasMaxLength(50);

                entity.Property(e => e.Nota).HasColumnName("NOTA");

                entity.Property(e => e.Pagos)
                    .HasMaxLength(1)
                    .HasColumnName("PAGOS");

                entity.Property(e => e.Reglib)
                    .HasMaxLength(1)
                    .HasColumnName("REGLIB");

                entity.Property(e => e.Regular)
                    .HasMaxLength(1)
                    .HasColumnName("REGULAR");

                entity.Property(e => e.Sede)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SEDE")
                    .IsFixedLength();

                entity.Property(e => e.Sexo)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("SEXO");

                entity.Property(e => e.Telefono).HasMaxLength(50);

                entity.Property(e => e.Todomal)
                    .HasMaxLength(1)
                    .HasColumnName("TODOMAL");

                entity.Property(e => e.VisId).HasColumnName("VIS_ID");
            });

            modelBuilder.Entity<VisExaCuring>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIS_EXA_CURING");

                entity.Property(e => e.Abr)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ABR")
                    .IsFixedLength();

                entity.Property(e => e.Actanro)
                    .HasMaxLength(8)
                    .HasColumnName("ACTANRO");

                entity.Property(e => e.AnoIngreso).HasMaxLength(4);

                entity.Property(e => e.Apellido).HasMaxLength(40);

                entity.Property(e => e.Aula)
                    .HasMaxLength(10)
                    .HasColumnName("AULA");

                entity.Property(e => e.Bcoleg).HasColumnName("BCOLEG");

                entity.Property(e => e.CarreId).HasColumnName("CARRE_ID");

                entity.Property(e => e.Carrera).HasMaxLength(120);

                entity.Property(e => e.Convenio).HasMaxLength(50);

                entity.Property(e => e.Cuatrimestre)
                    .HasMaxLength(5)
                    .HasColumnName("CUATRIMESTRE");

                entity.Property(e => e.Docente)
                    .HasMaxLength(50)
                    .HasColumnName("docente");

                entity.Property(e => e.Equivale)
                    .HasMaxLength(1)
                    .HasColumnName("EQUIVALE");

                entity.Property(e => e.Estdes)
                    .HasMaxLength(30)
                    .HasColumnName("ESTDES");

                entity.Property(e => e.Fecha)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FECHA");

                entity.Property(e => e.Fue)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("FUE");

                entity.Property(e => e.IdConv).ValueGeneratedOnAdd();

                entity.Property(e => e.Inicio)
                    .HasMaxLength(5)
                    .HasColumnName("INICIO");

                entity.Property(e => e.Legajo).HasColumnName("LEGAJO");

                entity.Property(e => e.Mail).HasMaxLength(50);

                entity.Property(e => e.Materia).HasColumnName("MATERIA");

                entity.Property(e => e.Materias)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("materias");

                entity.Property(e => e.Mesa).HasColumnName("MESA");

                entity.Property(e => e.Mescom).HasColumnName("MESCOM");

                entity.Property(e => e.Messed).HasColumnName("MESSED");

                entity.Property(e => e.Nombres).HasMaxLength(50);

                entity.Property(e => e.Nota).HasColumnName("NOTA");

                entity.Property(e => e.Pagos)
                    .HasMaxLength(1)
                    .HasColumnName("PAGOS");

                entity.Property(e => e.Reglib)
                    .HasMaxLength(1)
                    .HasColumnName("REGLIB");

                entity.Property(e => e.Regular)
                    .HasMaxLength(1)
                    .HasColumnName("REGULAR");

                entity.Property(e => e.Sede)
                    .HasMaxLength(50)
                    .HasColumnName("SEDE");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("SEXO");

                entity.Property(e => e.Telefono).HasMaxLength(25);

                entity.Property(e => e.Todomal)
                    .HasMaxLength(1)
                    .HasColumnName("TODOMAL");

                entity.Property(e => e.Turno).HasColumnName("TURNO");

                entity.Property(e => e.VisId).HasColumnName("VIS_ID");
            });

            modelBuilder.Entity<VisIn>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIS_INS");

                entity.Property(e => e.Abr)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ABR")
                    .IsFixedLength();

                entity.Property(e => e.AnoIngreso).HasMaxLength(4);

                entity.Property(e => e.Apellido).HasMaxLength(40);

                entity.Property(e => e.Bcoleg).HasColumnName("BCOLEG");

                entity.Property(e => e.Carrera).HasMaxLength(120);

                entity.Property(e => e.CarreraId).HasColumnName("CarreraId_");

                entity.Property(e => e.Convenio).HasMaxLength(50);

                entity.Property(e => e.Cp)
                    .HasMaxLength(8)
                    .HasColumnName("CP");

                entity.Property(e => e.CuatrIngreso)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CuotaIngreso)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Cuotacero)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CUOTACERO")
                    .IsFixedLength();

                entity.Property(e => e.Cuotaextr).HasColumnName("CUOTAEXTR");

                entity.Property(e => e.Curing)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CURING")
                    .IsFixedLength();

                entity.Property(e => e.Direccion).HasMaxLength(160);

                entity.Property(e => e.Dispos25)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DISPOS25")
                    .IsFixedLength();

                entity.Property(e => e.Docdes)
                    .HasMaxLength(5)
                    .HasColumnName("DOCDES");

                entity.Property(e => e.Docuextr)
                    .HasMaxLength(40)
                    .HasColumnName("DOCUEXTR");

                entity.Property(e => e.Documenta)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTA")
                    .IsFixedLength();

                entity.Property(e => e.Eg1)
                    .HasMaxLength(200)
                    .HasColumnName("EG1");

                entity.Property(e => e.Eg1cod).HasColumnName("EG1COD");

                entity.Property(e => e.Eg2)
                    .HasMaxLength(200)
                    .HasColumnName("EG2");

                entity.Property(e => e.Eg2cod).HasColumnName("EG2COD");

                entity.Property(e => e.Estcivil)
                    .HasMaxLength(20)
                    .HasColumnName("ESTCIVIL");

                entity.Property(e => e.Extranjero)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EXTRANJERO")
                    .IsFixedLength();

                entity.Property(e => e.FecIns).HasColumnType("smalldatetime");

                entity.Property(e => e.FecNac).HasColumnType("smalldatetime");

                entity.Property(e => e.FecRei).HasColumnType("smalldatetime");

                entity.Property(e => e.FecSec).HasColumnType("smalldatetime");

                entity.Property(e => e.Feclib)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FECLIB");

                entity.Property(e => e.Fectit)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FECTIT");

                entity.Property(e => e.FinDes).HasColumnType("smalldatetime");

                entity.Property(e => e.FinHas).HasColumnType("smalldatetime");

                entity.Property(e => e.Guabeca).HasColumnName("GUABECA");

                entity.Property(e => e.Guacuit)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("GUACUIT")
                    .IsFixedLength();

                entity.Property(e => e.Guadate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("GUADATE")
                    .IsFixedLength();

                entity.Property(e => e.Guainma).HasColumnName("GUAINMA");

                entity.Property(e => e.Guainpa).HasColumnName("GUAINPA");

                entity.Property(e => e.Gualoca).HasColumnName("GUALOCA");

                entity.Property(e => e.Guapnac).HasColumnName("GUAPNAC");

                entity.Property(e => e.Guapres).HasColumnName("GUAPRES");

                entity.Property(e => e.Guatrab).HasColumnName("GUATRAB");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Intercambio)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("INTERCAMBIO")
                    .IsFixedLength();

                entity.Property(e => e.LetraDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Libreta)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LIBRETA")
                    .IsFixedLength();

                entity.Property(e => e.LocalidadId).HasColumnName("LocalidadId_");

                entity.Property(e => e.LocalidadTxt).HasMaxLength(150);

                entity.Property(e => e.LugMundo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Mail).HasMaxLength(150);

                entity.Property(e => e.Meddes)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("MEDDES")
                    .IsFixedLength();

                entity.Property(e => e.MotBaja).HasMaxLength(50);

                entity.Property(e => e.Nacio).HasMaxLength(50);

                entity.Property(e => e.Nombres).HasMaxLength(50);

                entity.Property(e => e.Orienta).HasMaxLength(1);

                entity.Property(e => e.Pais).HasMaxLength(150);

                entity.Property(e => e.Partido).HasMaxLength(150);

                entity.Property(e => e.Present3).HasColumnName("PRESENT3");

                entity.Property(e => e.Promsec).HasColumnName("PROMSEC");

                entity.Property(e => e.Provden)
                    .HasMaxLength(20)
                    .HasColumnName("PROVDEN");

                entity.Property(e => e.Recibido).HasMaxLength(1);

                entity.Property(e => e.ReguAnt).HasMaxLength(1);

                entity.Property(e => e.Regular).HasMaxLength(1);

                entity.Property(e => e.ResAno).HasMaxLength(4);

                entity.Property(e => e.ResFec).HasColumnType("smalldatetime");

                entity.Property(e => e.Residente)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RESIDENTE")
                    .IsFixedLength();

                entity.Property(e => e.Sede)
                    .HasMaxLength(50)
                    .HasColumnName("SEDE");

                entity.Property(e => e.Sedhabi)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SEDHABI")
                    .IsFixedLength();

                entity.Property(e => e.Sexo).HasMaxLength(10);

                entity.Property(e => e.SexoId).HasColumnName("SexoId_");

                entity.Property(e => e.Suspcuatri)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("SUSPCUATRI")
                    .IsFixedLength();

                entity.Property(e => e.Suspendido)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SUSPENDIDO")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Suspfecha)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("SUSPFECHA");

                entity.Property(e => e.Suspproce).HasColumnName("SUSPPROCE");

                entity.Property(e => e.TarNom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Telefono).HasMaxLength(50);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(1)
                    .HasColumnName("TIPO");

                entity.Property(e => e.Tipodes)
                    .HasMaxLength(50)
                    .HasColumnName("TIPODES");

                entity.Property(e => e.TitSec).HasMaxLength(180);

                entity.Property(e => e.TitTer).HasMaxLength(180);

                entity.Property(e => e.TitUni).HasMaxLength(180);

                entity.Property(e => e.TraHrs).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TraTipo).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Trabaja).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TurnoId).HasColumnName("TurnoId_");

                entity.Property(e => e.UpcnafiliadoNro).HasColumnName("UPCNAfiliadoNro");

                entity.Property(e => e.UpcnafiliadoTipo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("UPCNAfiliadoTipo")
                    .IsFixedLength();

                entity.Property(e => e.Vencresid).HasColumnName("VENCRESID");

                entity.Property(e => e.Visacod)
                    .HasMaxLength(8)
                    .HasColumnName("VISACOD")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Visapri)
                    .HasMaxLength(1)
                    .HasColumnName("VISAPRI")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Visatarjeta)
                    .HasMaxLength(16)
                    .HasColumnName("VISATARJETA")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Visatartipo)
                    .HasMaxLength(2)
                    .HasColumnName("VISATARTIPO")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");
            });

            modelBuilder.Entity<VisMat>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIS_MAT");

                entity.Property(e => e.Abandono)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ABANDONO")
                    .IsFixedLength();

                entity.Property(e => e.Aclara)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ACLARA")
                    .IsFixedLength();

                entity.Property(e => e.Anual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ANUAL")
                    .IsFixedLength();

                entity.Property(e => e.Espera)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ESPERA")
                    .IsFixedLength();

                entity.Property(e => e.Ingresan)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("INGRESAN")
                    .IsFixedLength();

                entity.Property(e => e.Libre)
                    .HasMaxLength(1)
                    .HasColumnName("LIBRE");

                entity.Property(e => e.Materias).HasMaxLength(208);

                entity.Property(e => e.Observa)
                    .HasMaxLength(50)
                    .HasColumnName("observa");

                entity.Property(e => e.Reemplazo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REEMPLAZO")
                    .IsFixedLength();

                entity.Property(e => e.Semcua)
                    .HasMaxLength(5)
                    .HasColumnName("SEMCUA");

                entity.Property(e => e.Semide).HasColumnName("SEMIDE");

                entity.Property(e => e.Temdes)
                    .HasMaxLength(50)
                    .HasColumnName("TEMDES");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TIPO")
                    .IsFixedLength();
            });

            modelBuilder.Entity<VisMatCur>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIS_MAT_CUR");

                entity.Property(e => e.Abr)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ABR")
                    .IsFixedLength();

                entity.Property(e => e.AnoIngreso).HasMaxLength(4);

                entity.Property(e => e.Anual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ANUAL")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Apellido).HasMaxLength(40);

                entity.Property(e => e.Bcoleg).HasColumnName("BCOLEG");

                entity.Property(e => e.CarreId).HasColumnName("CARRE_ID");

                entity.Property(e => e.Carrera).HasMaxLength(120);

                entity.Property(e => e.Causa)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CAUSA")
                    .IsFixedLength();

                entity.Property(e => e.Coming).HasColumnName("COMING");

                entity.Property(e => e.Comision).HasColumnName("COMISION");

                entity.Property(e => e.Convenio).HasMaxLength(50);

                entity.Property(e => e.Corresponde).HasColumnName("CORRESPONDE");

                entity.Property(e => e.Cp)
                    .HasMaxLength(8)
                    .HasColumnName("CP");

                entity.Property(e => e.CuatrIngreso)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Cuatrimestre)
                    .HasMaxLength(5)
                    .HasColumnName("CUATRIMESTRE");

                entity.Property(e => e.Diaju)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("DIAJU");

                entity.Property(e => e.Dialu)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("DIALU");

                entity.Property(e => e.Diama)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("DIAMA");

                entity.Property(e => e.Diami)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("DIAMI");

                entity.Property(e => e.Diasa)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("DIASA");

                entity.Property(e => e.Diavi)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("DIAVI");

                entity.Property(e => e.Direccion).HasMaxLength(160);

                entity.Property(e => e.Docente)
                    .HasMaxLength(50)
                    .HasColumnName("docente");

                entity.Property(e => e.Docid).HasColumnName("DOCID");

                entity.Property(e => e.Documenta)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTA")
                    .IsFixedLength();

                entity.Property(e => e.Edugru).HasColumnName("EDUGRU");

                entity.Property(e => e.Equivale)
                    .HasMaxLength(1)
                    .HasColumnName("EQUIVALE");

                entity.Property(e => e.Estdes)
                    .HasMaxLength(30)
                    .HasColumnName("ESTDES");

                entity.Property(e => e.FecNac).HasColumnType("smalldatetime");

                entity.Property(e => e.Fecins)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FECINS");

                entity.Property(e => e.Legajo).HasColumnName("LEGAJO");

                entity.Property(e => e.Localidad)
                    .HasMaxLength(150)
                    .HasColumnName("LOCALIDAD");

                entity.Property(e => e.Mail).HasMaxLength(150);

                entity.Property(e => e.Materia).HasColumnName("MATERIA");

                entity.Property(e => e.Materias)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("materias");

                entity.Property(e => e.Nombres).HasMaxLength(50);

                entity.Property(e => e.Nota1).HasColumnName("NOTA1");

                entity.Property(e => e.Nota2).HasColumnName("NOTA2");

                entity.Property(e => e.Origen)
                    .HasMaxLength(1)
                    .HasColumnName("ORIGEN");

                entity.Property(e => e.Pagos)
                    .HasMaxLength(1)
                    .HasColumnName("PAGOS");

                entity.Property(e => e.Partido).HasMaxLength(150);

                entity.Property(e => e.Promedio).HasColumnName("PROMEDIO");

                entity.Property(e => e.Provincia)
                    .HasMaxLength(20)
                    .HasColumnName("PROVINCIA");

                entity.Property(e => e.Regualu)
                    .HasMaxLength(1)
                    .HasColumnName("REGUALU");

                entity.Property(e => e.Regular)
                    .HasMaxLength(1)
                    .HasColumnName("REGULAR");

                entity.Property(e => e.Sede)
                    .HasMaxLength(50)
                    .HasColumnName("SEDE");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("SEXO");

                entity.Property(e => e.Telefono).HasMaxLength(50);

                entity.Property(e => e.Todomal)
                    .HasMaxLength(1)
                    .HasColumnName("TODOMAL");

                entity.Property(e => e.Tur)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TUR");

                entity.Property(e => e.Verano)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VERANO")
                    .IsFixedLength();

                entity.Property(e => e.VisId).HasColumnName("VIS_ID");
            });

            modelBuilder.Entity<VisTu1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIS_TU1");

                entity.Property(e => e.Campus)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CAMPUS")
                    .IsFixedLength();

                entity.Property(e => e.Convenio).HasMaxLength(50);

                entity.Property(e => e.Insfe1).HasColumnName("INSFE1");

                entity.Property(e => e.Insfe2).HasColumnName("INSFE2");

                entity.Property(e => e.Insfe3).HasColumnName("INSFE3");

                entity.Property(e => e.Materias).HasMaxLength(150);

                entity.Property(e => e.Mescar).HasColumnName("MESCAR");

                entity.Property(e => e.Mescom).HasColumnName("MESCOM");

                entity.Property(e => e.Mescua)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MESCUA")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Mesfe1)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("MESFE1");

                entity.Property(e => e.Mesfe2)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("MESFE2");

                entity.Property(e => e.Mesfe3)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("MESFE3");

                entity.Property(e => e.Mesins).HasColumnName("MESINS");

                entity.Property(e => e.Mesmat).HasColumnName("MESMAT");

                entity.Property(e => e.Mesref1)
                    .HasColumnType("date")
                    .HasColumnName("MESREF1");

                entity.Property(e => e.Mesref2)
                    .HasColumnType("date")
                    .HasColumnName("MESREF2");

                entity.Property(e => e.Mesref3)
                    .HasColumnType("date")
                    .HasColumnName("MESREF3");

                entity.Property(e => e.Mesrem1)
                    .HasMaxLength(20)
                    .HasColumnName("MESREM1")
                    .IsFixedLength();

                entity.Property(e => e.Mesrem2)
                    .HasMaxLength(20)
                    .HasColumnName("MESREM2")
                    .IsFixedLength();

                entity.Property(e => e.Mesrem3)
                    .HasMaxLength(20)
                    .HasColumnName("MESREM3")
                    .IsFixedLength();

                entity.Property(e => e.Messt1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MESST1")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Messt2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MESST2")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Messt3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MESST3")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Prefe1).HasColumnName("PREFE1");

                entity.Property(e => e.Prefe2).HasColumnName("PREFE2");

                entity.Property(e => e.Prefe3).HasColumnName("PREFE3");

                entity.Property(e => e.Sede)
                    .HasMaxLength(50)
                    .HasColumnName("SEDE");
            });

            modelBuilder.Entity<VisWeb>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIS_WEB");

                entity.Property(e => e.Abr)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ABR")
                    .IsFixedLength();

                entity.Property(e => e.AnoIngreso).HasMaxLength(4);

                entity.Property(e => e.Apellido).HasMaxLength(40);

                entity.Property(e => e.Bcoleg).HasColumnName("BCOLEG");

                entity.Property(e => e.CarreraId).HasColumnName("CarreraId_");

                entity.Property(e => e.ConvDes).HasMaxLength(50);

                entity.Property(e => e.Convenio).HasMaxLength(1);

                entity.Property(e => e.Cp)
                    .HasMaxLength(8)
                    .HasColumnName("CP");

                entity.Property(e => e.CuatrIngreso)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CuotaIngreso)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Cuotacero)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CUOTACERO")
                    .IsFixedLength();

                entity.Property(e => e.Cuotaextr).HasColumnName("CUOTAEXTR");

                entity.Property(e => e.Curing)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CURING")
                    .IsFixedLength();

                entity.Property(e => e.Direccion).HasMaxLength(60);

                entity.Property(e => e.Dispos25)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DISPOS25")
                    .IsFixedLength();

                entity.Property(e => e.Docdes)
                    .HasMaxLength(5)
                    .HasColumnName("DOCDES");

                entity.Property(e => e.Docuextr)
                    .HasMaxLength(20)
                    .HasColumnName("DOCUEXTR");

                entity.Property(e => e.Documenta)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTA")
                    .IsFixedLength();

                entity.Property(e => e.Eg1)
                    .HasMaxLength(100)
                    .HasColumnName("EG1");

                entity.Property(e => e.Eg1cod).HasColumnName("EG1COD");

                entity.Property(e => e.Eg2)
                    .HasMaxLength(100)
                    .HasColumnName("EG2");

                entity.Property(e => e.Eg2cod).HasColumnName("EG2COD");

                entity.Property(e => e.Estdes)
                    .HasMaxLength(30)
                    .HasColumnName("ESTDES");

                entity.Property(e => e.Extranjero)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EXTRANJERO")
                    .IsFixedLength();

                entity.Property(e => e.FecIns).HasColumnType("smalldatetime");

                entity.Property(e => e.FecNac).HasColumnType("smalldatetime");

                entity.Property(e => e.FecRei).HasColumnType("smalldatetime");

                entity.Property(e => e.FecSec).HasColumnType("smalldatetime");

                entity.Property(e => e.Feclib)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FECLIB");

                entity.Property(e => e.Fectit)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FECTIT");

                entity.Property(e => e.FinDes).HasColumnType("smalldatetime");

                entity.Property(e => e.FinHas).HasColumnType("smalldatetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Intercambio)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("INTERCAMBIO")
                    .IsFixedLength();

                entity.Property(e => e.LetraDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Libreta)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LIBRETA")
                    .IsFixedLength();

                entity.Property(e => e.LocalidadId).HasColumnName("LocalidadId_");

                entity.Property(e => e.LocalidadTxt).HasMaxLength(50);

                entity.Property(e => e.LugMundo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Mail).HasMaxLength(50);

                entity.Property(e => e.MotBaja).HasMaxLength(50);

                entity.Property(e => e.Nacio).HasMaxLength(50);

                entity.Property(e => e.Nombres).HasMaxLength(50);

                entity.Property(e => e.Observa)
                    .HasColumnType("text")
                    .HasColumnName("OBSERVA");

                entity.Property(e => e.Orienta).HasMaxLength(1);

                entity.Property(e => e.Pais).HasMaxLength(50);

                entity.Property(e => e.Partido).HasMaxLength(50);

                entity.Property(e => e.Plaest)
                    .HasMaxLength(15)
                    .HasColumnName("PLAEST");

                entity.Property(e => e.Present3).HasColumnName("PRESENT3");

                entity.Property(e => e.Promsec).HasColumnName("PROMSEC");

                entity.Property(e => e.Recibido).HasMaxLength(1);

                entity.Property(e => e.ReguAnt).HasMaxLength(1);

                entity.Property(e => e.Regular).HasMaxLength(1);

                entity.Property(e => e.ResAno).HasMaxLength(4);

                entity.Property(e => e.ResFec).HasColumnType("smalldatetime");

                entity.Property(e => e.Residente)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RESIDENTE")
                    .IsFixedLength();

                entity.Property(e => e.Sexo).HasMaxLength(10);

                entity.Property(e => e.SexoId).HasColumnName("SexoId_");

                entity.Property(e => e.Suspcuatri)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("SUSPCUATRI")
                    .IsFixedLength();

                entity.Property(e => e.Suspendido)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SUSPENDIDO")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Suspfecha)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("SUSPFECHA");

                entity.Property(e => e.Suspproce).HasColumnName("SUSPPROCE");

                entity.Property(e => e.Telefono).HasMaxLength(25);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(1)
                    .HasColumnName("TIPO");

                entity.Property(e => e.TitSec).HasMaxLength(110);

                entity.Property(e => e.TitTer).HasMaxLength(110);

                entity.Property(e => e.TitUni).HasMaxLength(110);

                entity.Property(e => e.TraHrs).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TraTipo).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Trabaja).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TurnoId).HasColumnName("TurnoId_");

                entity.Property(e => e.Usualu)
                    .HasMaxLength(100)
                    .HasColumnName("USUALU")
                    .IsFixedLength();

                entity.Property(e => e.Usucla)
                    .HasMaxLength(20)
                    .HasColumnName("USUCLA");

                entity.Property(e => e.Vencresid).HasColumnName("VENCRESID");

                entity.Property(e => e.Visacod)
                    .HasMaxLength(8)
                    .HasColumnName("VISACOD")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Visapri)
                    .HasMaxLength(1)
                    .HasColumnName("VISAPRI")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Visatarjeta)
                    .HasMaxLength(16)
                    .HasColumnName("VISATARJETA")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Visatartipo)
                    .HasMaxLength(2)
                    .HasColumnName("VISATARTIPO")
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");
            });

            modelBuilder.Entity<WebAprobaronCiclo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("WEB_AprobaronCiclo");

                entity.Property(e => e.Apellido).HasMaxLength(40);

                entity.Property(e => e.C1C).HasColumnName("C1_C");

                entity.Property(e => e.C1I).HasColumnName("C1_I");

                entity.Property(e => e.C1O).HasColumnName("C1_O");

                entity.Property(e => e.C1S).HasColumnName("C1_S");

                entity.Property(e => e.C2C).HasColumnName("C2_C");

                entity.Property(e => e.C2I).HasColumnName("C2_I");

                entity.Property(e => e.C2O).HasColumnName("C2_O");

                entity.Property(e => e.C2S).HasColumnName("C2_S");

                entity.Property(e => e.Carrera).HasMaxLength(120);

                entity.Property(e => e.Estdes)
                    .HasMaxLength(30)
                    .HasColumnName("ESTDES");

                entity.Property(e => e.Nombres).HasMaxLength(50);

                entity.Property(e => e.Placi1).HasColumnName("PLACI1");

                entity.Property(e => e.Placi1idio).HasColumnName("PLACI1IDIO");

                entity.Property(e => e.Placi1opta).HasColumnName("PLACI1OPTA");

                entity.Property(e => e.Placi1semi).HasColumnName("PLACI1SEMI");

                entity.Property(e => e.Placi2).HasColumnName("PLACI2");

                entity.Property(e => e.Placi2idio).HasColumnName("PLACI2IDIO");

                entity.Property(e => e.Placi2opta).HasColumnName("PLACI2OPTA");

                entity.Property(e => e.Placi2semi).HasColumnName("PLACI2SEMI");

                entity.Property(e => e.Plaest)
                    .HasMaxLength(15)
                    .HasColumnName("PLAEST");

                entity.Property(e => e.Recibido).HasMaxLength(1);

                entity.Property(e => e.Regular).HasMaxLength(1);

                entity.Property(e => e.Sexo).HasMaxLength(10);

                entity.Property(e => e.SexoId).HasColumnName("SexoId_");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(1)
                    .HasColumnName("TIPO");
            });

            modelBuilder.Entity<WebCubo01>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("WEB_Cubo01");

                entity.Property(e => e.AñoIngreso)
                    .HasMaxLength(4)
                    .HasColumnName("Año_Ingreso");

                entity.Property(e => e.Carrera).HasMaxLength(120);

                entity.Property(e => e.CodPostal).HasMaxLength(8);

                entity.Property(e => e.Convenio).HasMaxLength(50);

                entity.Property(e => e.CuatriSuspendido)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Cuatri_Suspendido")
                    .IsFixedLength();

                entity.Property(e => e.CuatrimestreIngeso)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Cuatrimestre_Ingeso")
                    .IsFixedLength();

                entity.Property(e => e.CursoIngreso)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion).HasMaxLength(60);

                entity.Property(e => e.EgresóSec)
                    .HasMaxLength(100)
                    .HasColumnName("Egresó_Sec");

                entity.Property(e => e.EgresóUniv)
                    .HasMaxLength(100)
                    .HasColumnName("Egresó_Univ");

                entity.Property(e => e.Estado).HasMaxLength(1);

                entity.Property(e => e.EstadoAmpliado).HasMaxLength(30);

                entity.Property(e => e.Extranjero)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EXTRANJERO")
                    .IsFixedLength();

                entity.Property(e => e.FecLibreta)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("Fec_Libreta");

                entity.Property(e => e.FechaInscripto)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("Fecha_Inscripto");

                entity.Property(e => e.FechaNac)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("Fecha_Nac");

                entity.Property(e => e.FechaSuspendido)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("Fecha_Suspendido");

                entity.Property(e => e.FechaTitSec)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("Fecha_Tit_Sec");

                entity.Property(e => e.FechaTitUniv)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("Fecha_TitUniv");

                entity.Property(e => e.Intercambio)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("INTERCAMBIO")
                    .IsFixedLength();

                entity.Property(e => e.Libreta)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LIBRETA")
                    .IsFixedLength();

                entity.Property(e => e.Localidad).HasMaxLength(60);

                entity.Property(e => e.LugMundo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Mail).HasMaxLength(50);

                entity.Property(e => e.MedioDePago)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Medio_de_Pago")
                    .IsFixedLength();

                entity.Property(e => e.Nacionalidad).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(91);

                entity.Property(e => e.Orientacion).HasMaxLength(50);

                entity.Property(e => e.PagóMatricula)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Pagó_Matricula")
                    .IsFixedLength();

                entity.Property(e => e.Pais).HasMaxLength(50);

                entity.Property(e => e.Partido).HasMaxLength(50);

                entity.Property(e => e.PlanEstudio)
                    .HasMaxLength(15)
                    .HasColumnName("Plan_Estudio");

                entity.Property(e => e.PresentóDocumentación)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Presentó_Documentación")
                    .IsFixedLength();

                entity.Property(e => e.PresentóTitSec).HasColumnName("Presentó_TitSec");

                entity.Property(e => e.PresentóTitUniv).HasColumnName("Presentó_Tit_Univ");

                entity.Property(e => e.PromedioSec).HasColumnName("Promedio_Sec");

                entity.Property(e => e.Provincia).HasMaxLength(20);

                entity.Property(e => e.Recibido).HasMaxLength(1);

                entity.Property(e => e.Residente)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RESIDENTE")
                    .IsFixedLength();

                entity.Property(e => e.Sede)
                    .HasMaxLength(50)
                    .HasColumnName("SEDE");

                entity.Property(e => e.Sexo).HasMaxLength(10);

                entity.Property(e => e.Suspendido)
                    .HasMaxLength(19)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono).HasMaxLength(25);

                entity.Property(e => e.TipoTarjeta)
                    .HasMaxLength(2)
                    .IsFixedLength()
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.TitSecundario)
                    .HasMaxLength(110)
                    .HasColumnName("Tit_Secundario");

                entity.Property(e => e.TitTerciario)
                    .HasMaxLength(110)
                    .HasColumnName("Tit_Terciario");

                entity.Property(e => e.TitUniversitario)
                    .HasMaxLength(110)
                    .HasColumnName("Tit_Universitario");

                entity.Property(e => e.XIdCarrera).HasColumnName("X_IdCarrera");

                entity.Property(e => e.XIdConv).HasColumnName("X_IdConv");

                entity.Property(e => e.XIdLocalidad).HasColumnName("X_IdLocalidad");

                entity.Property(e => e.XIdMedioPago).HasColumnName("X_IdMedioPago");

                entity.Property(e => e.XIdPais).HasColumnName("X_IdPais");

                entity.Property(e => e.XIdPlan).HasColumnName("X_IdPlan");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
