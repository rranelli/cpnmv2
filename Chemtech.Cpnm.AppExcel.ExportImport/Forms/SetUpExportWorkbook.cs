//using System.Collections.Generic;
//using System.Linq;
//using System.Windows.Forms;
//using Chemtech.CPNM.Data.Repositories;
//using Chemtech.CPNM.Model.Domain;
//
//namespace Chemtech.Cpnm.AppExcel.ExportImport.Forms
//{
//    public interface ISetUpExportWorkbook
//    {
//    }
//
//    public partial class SetUpExportWorkbook : ISetUpExportWorkbook
//    {
//        public ICollection<ItemType> SelectedItemTypes;
//        public ICollection<Property> SelectedProperties;
//        public bool FetchAllItems;
//        public SubArea SelectedSubArea;
//
//        private readonly IPropertyGroupRepository _propertyGroupRepository;
//        private readonly IItemTypeRepository _itemTypeRepository;
//        private readonly IItemTypeGroupRepository _itemTypeGroupRepository;
//
//        public SetUpExportWorkbook(IPropertyGroupRepository propertyGroupRepository, IItemTypeRepository itemTypeRepository, IItemTypeGroupRepository itemTypeGroupRepository)
//        {
//            _propertyGroupRepository = propertyGroupRepository;
//            _itemTypeRepository = itemTypeRepository;
//            _itemTypeGroupRepository = itemTypeGroupRepository;
//            InitializeComponent();
//
//            var itemtypegroups = _itemTypeGroupRepository.GetAll();
//
//            itemtypegroups.ToList().ForEach(itg => cmbItemTypeGroup.Items.Add(itg));
//            _propertyGroupRepository.GetAll().ToList().ForEach(pg => cmbPropGroup.Items.Add(pg));
//            _itemTypeRepository.GetAll().ToList().ForEach(it => ltbItemType.Items.Add(it));
//        }
//
//        private void cmbItemTypeGroup_SelectedIndexChanged(object sender, System.EventArgs e)
//        {
//            ltbItemType.Items.Clear();
//            if (cmbItemTypeGroup.SelectedItem != null)
//            {
//                _itemTypeRepository.GetByGroup((ItemTypeGroup)cmbItemTypeGroup.SelectedItem).ToList().ToList().
//                    ForEach(it => ltbItemType.Items.Add(it));
//            }
//            else
//            {
//                _itemTypeRepository.GetAll().ToList().ForEach(it => ltbItemType.Items.Add(it));
//            }
//        }
//
//        private void ltbItemType_SelectedIndexChanged(object sender, System.EventArgs e)
//        {
//            clbProperties.Items.Clear();
//            if (ltbItemType.SelectedItems.Count == 0) return;
//
//            var intersectedList = (from ItemType it in ltbItemType.SelectedItems select it.ValidProperties.ToList()).
//                Aggregate((current, next) => current.Intersect(next).ToList());
//            intersectedList.ForEach(prop => clbProperties.Items.Add(prop));
//        }
//
//        private void btnRedefWorksheet_Click(object sender, System.EventArgs e)
//        {
//            if(ltbItemType.SelectedItems.Count > 0 && (clbProperties.SelectedItems.Count>0 || ckbFetchAllProperties.Checked))
//            {
//                SelectedSubArea = (SubArea)cmbSubArea.SelectedItem;
//                SelectedItemTypes = ltbItemType.SelectedItems.Cast<ItemType>().ToList();
//                FetchAllItems = ckbFetchAllItems.Checked;
//                
//                if (ckbFetchAllProperties.Checked)
//                    SelectedProperties = clbProperties.Items.Cast<Property>().ToList();
//                else
//                    SelectedProperties = clbProperties.SelectedItems.Cast<Property>().ToList();
//
//                DialogResult = DialogResult.OK;
//                Close();
//            }
//            else
//            {
//                MessageBox.Show("Selecione ao menos um tipo de item e uma propriedade");
//            }
//        }
//    }
//}
