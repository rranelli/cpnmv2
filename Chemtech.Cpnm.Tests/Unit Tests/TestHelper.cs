using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;


namespace Chemtech.CPNM.Tests.UnitTests
{
    public class TestHelper
    {
        public void AddGroups<T1>(IEnumerable<T1> ents) where T1 : Entity
        {
            var repository = new GeneralRepository<T1>();
            foreach (T1 thisEnt in ents)
            {
                repository.Add(thisEnt);
            }
        }

        public Configuration MakeConfiguration()
        {
            var config = new Configuration();
            config.Configure();
            config.AddAssembly(typeof(ItemTypeGroup).Assembly);
            config.AddAssembly(typeof(ItemTypeGroupRepository).Assembly);

            return config;
        }

        public void TestTearDown(Configuration configuration)
        {
            new SchemaExport(configuration).Drop(false, true);
        }

        public void SetUpDatabaseTestData(Configuration configuration)
        {
            //TODO: Descobrir se eh possivel mockar o nhibernate helper inteiro para gerar uma session factory que opera em um banco local
            // criando o schema
            new SchemaExport(configuration).Execute(false, true, false);

            // criando in-memory data.
            var unitsOfMeasure = new[]
                                     {
                                         new UnitOfMeasure {ConvFactor = 1, OffsetFactor = 0, Symbol = "K"},
                                         new UnitOfMeasure {ConvFactor = 2, OffsetFactor = 0, Symbol = "C"},
                                         new UnitOfMeasure {ConvFactor = 3, OffsetFactor = 1, Symbol = "T"},
                                         new UnitOfMeasure {ConvFactor = 3, OffsetFactor = 1, Symbol = "Unit1"},
                                         new UnitOfMeasure {ConvFactor = 2, Symbol = "Unit2"},
                                         new UnitOfMeasure {ConvFactor = 0.3, OffsetFactor = 1, Symbol = "Unit3"},
                                     };

            var dimensions = new[]
                                 {
                                     new Dimension {Name = "Vazao", Units = unitsOfMeasure},
                                     new Dimension {Name = "Pressao"},
                                     new Dimension {Name = "Potencia"},
                                     new Dimension {Name = "Tensao"},
                                     new Dimension {Name = "Ovo"},
                                 };

            var disciplines = new[]
                                  {
                                      new Discipline {Name = "Eletrica"},
                                      new Discipline {Name = "Processo"},
                                      new Discipline {Name = "Tubulacao"},
                                      new Discipline {Name = "Metalica"},
                                      new Discipline {Name = "Civil"}
                                  };

            var propGroups = new[]
                                 {
                                     new PropertyGroup {Name = "Dados de Processo", Description = "desc1"},
                                     new PropertyGroup {Name = "Dados de Fornecedor", Description = "123"},
                                     new PropertyGroup {Name = "Dados de Catalogo", Description = "123"},
                                     new PropertyGroup {Name = "Dados Tecnicos", Description = "123"},
                                     new PropertyGroup {Name = "Tagueamento e rastreabilidade", Description = "123"},
                                     new PropertyGroup {Name = "Materiais", Description = "123"},
                                     new PropertyGroup {Name = "Dados EAP", Description = "123"},
                                 };

            var prop1 = new Property { Name = "Prop1", Description = "desc1", PropertyGroup = propGroups[1] };
            var prop2 = new Property { Name = "Prop2", PropertyGroup = propGroups[0] };
            var prop3 = new Property
                            {
                                Name = "Prop3",
                                Dimension = dimensions[0],
                                DefaultUnit = unitsOfMeasure[0]
                            };

            var properties = new[] { prop1, prop2, prop3 };

            var newItemTypeGroup = new ItemTypeGroup { Name = "Estaticos" };
            var itemTypeGroups = new[]
                                     {
                                         new ItemTypeGroup {Name = "Instrumentos", Description = "desc1"},
                                         new ItemTypeGroup {Name = "Caldeiraria", Description = "123"},
                                         new ItemTypeGroup {Name = "Rotativos", Description = "123"},
                                         new ItemTypeGroup {Name = "Documentos", Description = "123"},
                                         new ItemTypeGroup {Name = "Eletrica", Description = "123"},
                                         new ItemTypeGroup {Name = "Metalica", Description = "123"},
                                         new ItemTypeGroup {Name = "Tubulacao", Description = "123"},
                                         newItemTypeGroup
                                     };

            var xrefs = new[]
                            {
                                new Xref {Property = prop1},
                                new Xref {Property = prop2},
                                new Xref {Property = prop3}
                            };

            var newItemType = new ItemType
                                  {
                                      Name = "NovoTipo",
                                      ValidXrefs = xrefs,
                                      ItemTypeGroup = newItemTypeGroup,
                                  };

            var itemTypes = new[]
                                {
                                    new ItemType
                                        {Name = "Tanque", Description = "desc1", ItemTypeGroup = newItemTypeGroup},
                                    new ItemType
                                        {Name = "Transmissor", Description = "123", ItemTypeGroup = newItemTypeGroup},
                                    new ItemType
                                        {Name = "Bomba", Description = "123", ItemTypeGroup = newItemTypeGroup},
                                    new ItemType
                                        {Name = "Linha", Description = "123", ItemTypeGroup = newItemTypeGroup},
                                    new ItemType
                                        {Name = "Cantoneira", Description = "123", ItemTypeGroup = newItemTypeGroup, 
                                            ValidXrefs = new []{new Xref() {Property = prop2} }},
                                    newItemType
                                };

            var aProject = new Project() { Name = "NewProject" };
            var projects = new[] { aProject };
            var aSubArea = new SubArea() {Name = "NovaSubArea", Project = aProject};
            var subAreas = new[] {aSubArea};

            var items = new[]
                            {
                                new Item {Name = "P-101", UniqueName = "P-101", ItemType = newItemType, SubArea = aSubArea},
                                new Item
                                    {Name = "Complex", UniqueName = "Complex", IsActive = true, ItemType = newItemType, SubArea = aSubArea},
                                new Item
                                    {
                                        Name = "Complex2",
                                        UniqueName = "Complex2",
                                        IsActive = true,
                                        ItemType = newItemType,
                                        SubArea = aSubArea
                                    }
                            };

            //#############################
            // upload dos objetos in-memory
            var allData = new Entity[][]
                              {
                                  projects, subAreas, unitsOfMeasure, dimensions, disciplines, propGroups, properties, itemTypeGroups,
                                  itemTypes, items
                              };
            allData.ToList().ForEach(ent => AddGroups(ent));

            PropValue propval1 = new ItemRepository().
                GetByName("Complex").
                GetNewPropValue(prop3);
            propval1.Value = "115.3";

            PropValue propval2 = new ItemRepository().
                GetByName("Complex2").
                GetNewPropValue(prop3);
            propval2.Value = "215.3";

            var propValues = new[] { propval1, propval2 };
            AddGroups(propValues);
        }
    }
}
