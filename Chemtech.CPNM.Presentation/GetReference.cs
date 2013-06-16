using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Chemtech.CPNM.Presentation
{
    public partial class GetReference : Form
    {
        public PropValue SelectedPropValue;
        private ICollection<Item> _allItems;
        private ItemRepository _itemRepository;

        public GetReference()
        {
            InitializeComponent();

            var fixish = new fix();
            fixish.TestFixtureSetUp();
            fixish.SetUp();

            _itemRepository = new ItemRepository();
            _allItems = _itemRepository.GetAll();
            
            foreach(var item in _allItems)
                ltbItem.Items.Add(item);
        }

        private void btnFinishSelection_Click(object sender, System.EventArgs e)
        {
            SelectedPropValue = new PropValue {Value = "123"};
            this.Hide();
        }
    }

    public class fix
    {
        private Configuration _configuration;

        public void TestFixtureSetUp()
        {
            _configuration = new Configuration();
            _configuration.Configure();
            _configuration.AddAssembly(typeof(DimensionRepository).Assembly);
            _configuration.AddAssembly(typeof(UnitOfMeasure).Assembly);
        }

        public void SetUp()
        {
            new SchemaExport(_configuration).Execute(false, true, false);

            var unitsOfMeasure = new[]
                                         {
                                             new UnitOfMeasure()
                                                 {ConvFactor = 1, OffsetFactor = 0, Symbol = "K"},
                                             new UnitOfMeasure()
                                                 {ConvFactor = 2, OffsetFactor = 0, Symbol = "C"},
                                             new UnitOfMeasure()
                                                 {ConvFactor = 3, OffsetFactor = 1, Symbol = "T"}
                                         };

            var dimension = new Dimension() { Units = unitsOfMeasure, Name = "dummyDim" };

            var prop1 = new Property() { Name = "Prop1", Description = "desc1" };
            var prop2 = new Property() { Name = "Prop2" };
            var prop3 = new Property()
                            {
                                Name = "Prop3",
                                Dimension = dimension,
                                DefaultUnit = unitsOfMeasure[0]
                            };

            var propRepo = new PropertyRepository();
            propRepo.Add(prop1);
            propRepo.Add(prop2);
            propRepo.Add(prop3);

            var newItemType = new ItemType()
                                  {
                                      Name = "NovoTipo",
                                      ValidXrefs = new[]
                                                           {
                                                               new Xref() {Property = prop1},
                                                               new Xref() {Property = prop2},
                                                               new Xref() {Property = prop3}
                                                           }
                                  };

            var itemtyperepo = new ItemTypeRepository();
            itemtyperepo.Add(newItemType);

            var items = new[]
                                {
                                    new Item {Name = "P-101", UniqueName = "P-101"},
                                    new Item
                                        {
                                            Name = "Complex",
                                            UniqueName = "Complex",
                                            IsActive = true,
                                            ItemType = newItemType
                                        }
                                };

            addItems(items);
        }

        private void addItems(IEnumerable<Item> itemTypes)
        {
            var repository = new ItemRepository();
            foreach (var thisItem in itemTypes)
            {
                repository.Add(thisItem);
            }
        }
    }


}