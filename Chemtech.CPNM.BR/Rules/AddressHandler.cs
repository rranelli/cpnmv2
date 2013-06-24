// AddressHandler.cs
// Projeto: Chemtech.CPNM.BR
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 17/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using System;
using System.Linq;
using System.Text.RegularExpressions;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;

namespace Chemtech.CPNM.BR.Rules
{
    public class AddressHandler
    {
        private const char RouterChar = '/';
        private const string RegexCriteria = @"\/([\w-]*)";
        private const string RegexValidationCriteria = @"^CPNM_(\w*):";
        private const string CpnmAddressPreffix = "CPNM_#:";

        private static readonly Regex BreakerRegex = new Regex(RegexCriteria);
        private static readonly Regex ValidationRegex = new Regex(RegexValidationCriteria);

        public enum AddressType
        {
            ValueRef,
            PropNameRef,
            ItemNameRef,
            ItemTypeNameRef,
            AreaRef,
            SubAreaRef,
            ProjectRef
        }

        public PropValue PropValue { get; set; }
        public Item Item { get; set; }
        public Property Property { get; set; }
        public PropValue.FormatType FormatType { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public AddressType ThisAddressType { get; set; }

        private string _address;

        public AddressHandler(string address)
        {
            _address = address;
            ParseAddress();
        }

        public AddressHandler() { }

        public static bool IsCpnmAddress(string candidate)
        {
            return CheckIfIsAddress(candidate);
        }

        public string Address
        {
            get
            {
                SetAddress();
                return _address;
            }
            set
            {
                _address = value;
                ParseAddress();
            }
        }

        public string GetFormatedValue()
        {
            string result;

            if (PropValue == null && _address != null) ParseAddress();
            switch (ThisAddressType)
            {
                case AddressType.ValueRef:
                    if (PropValue == null)
                        throw new Exception("PropValue n'ao pode ser nulo para gerar um valor formatado. Checar parseaddress");
                    result = PropValue.FormatedValue(UnitOfMeasure, FormatType);
                    break;
                default:
                    if (PropValue == null)
                        throw new Exception("PropValue n'ao pode ser nulo para gerar um valor formatado. Checar parseaddress");
                    result = PropValue.FormatedValue(UnitOfMeasure, FormatType);
                    break;

                case AddressType.PropNameRef:
                    throw new NotImplementedException();
                case AddressType.ItemNameRef:
                    result = Item.Name;
                    break;
                case AddressType.ItemTypeNameRef:
                    result = Item.ItemType.Name;
                    break;
                case AddressType.AreaRef:
                    throw new NotImplementedException();
                case AddressType.SubAreaRef:
                    throw new NotImplementedException();
                case AddressType.ProjectRef:
                    result = Item.Project.Name;
                    break;
            }

            return result;
        }

        private static bool CheckIfIsAddress(string candidate)
        {
            return ValidationRegex.IsMatch(candidate);
        }

        private void SetAddress()
        {
            switch (ThisAddressType)
            {
                case AddressType.ValueRef:
                    if (PropValue == null) throw new Exception("Nao ha propvalue para gerar endereco");
                    SetPropValRefAddress();
                    break;
                default:
                    if (PropValue == null) throw new Exception("Nao ha propvalue para gerar endereco");
                    ThisAddressType = AddressType.ValueRef;
                    SetPropValRefAddress();
                    break;
                case AddressType.PropNameRef:
                    if (Property == null) throw new Exception("Nao ha propriedade para gerar endereco");
                    _address = GetPreffix() + RouterChar + Property.Id;
                    break;
                case AddressType.ItemNameRef:
                    if (Item == null) throw new Exception("Nao ha item para gerar endereco");
                    _address = GetPreffix() + RouterChar + Item.Id;
                    break;
                case AddressType.ItemTypeNameRef:
                    if (Item == null) throw new Exception("Nao ha item para gerar endereco");
                    _address = GetPreffix() + RouterChar + Item.Id;
                    break;
                case AddressType.AreaRef:
                    if (Item == null) throw new Exception("Nao ha item para gerar endereco");
                    _address = GetPreffix() + RouterChar + Item.Id;
                    break;
                case AddressType.SubAreaRef:
                    if (Item == null) throw new Exception("Nao ha item para gerar endereco");
                    throw new NotImplementedException();
                case AddressType.ProjectRef:
                    if (Item == null) throw new Exception("Nao ha item para gerar endereco");
                    _address = GetPreffix() + RouterChar + Item.Id;
                    break;
            }
        }

        private void SetPropValRefAddress()
        {
            _address = GetPreffix() + RouterChar + PropValue.ItemId.ToString() + RouterChar +
                       PropValue.GetProperty.Id + RouterChar +
                       (UnitOfMeasure != null
                            ? UnitOfMeasure.Id.ToString()
                            : PropValue.GetProperty.DefaultUnit.Id.ToString()) + RouterChar +
                       FormatType;
        }

        private string GetPreffix()
        {
            return CpnmAddressPreffix.Replace("#", ThisAddressType.ToString());
        }

        private void ParseAddress()
        //jesus, eu sou muito desatento. Gastei 2 horas por que nao percebi que estava com a regex (\/[\w-]*) ao inves de \/([\w-]*)
        {
            if (_address == null) throw new Exception("No address to parse!");
            GetAddressType();
            var ids = GetAddressParts();

            switch (ThisAddressType)
            {
                case AddressType.ValueRef:
                    ParsePropValAddress();
                    break;
                default:
                    SetPropValRefAddress();
                    break;

                case AddressType.PropNameRef:
                    Property = new PropertyRepository().GetById(new Guid(ids[0]));
                    break;
                case AddressType.ItemNameRef:
                    Item = new ItemRepository().GetById(new Guid(ids[0]));
                    break;
                case AddressType.ItemTypeNameRef:
                    Item = new ItemRepository().GetById(new Guid(ids[0]));
                    break;
                case AddressType.AreaRef:
                    Item = new ItemRepository().GetById(new Guid(ids[0]));
                    break;
                case AddressType.SubAreaRef:
                    Item = new ItemRepository().GetById(new Guid(ids[0]));
                    break;
                case AddressType.ProjectRef:
                    Item = new ItemRepository().GetById(new Guid(ids[0]));
                    break;
            }
        }

        private void ParsePropValAddress()
        {
            var ids = GetAddressParts();

            var itemIdString = ids[0];
            var propIdString = ids[1];
            var unitIdString = ids[2];
            var formatTypeString = ids[3];

            var itemId = new Guid(itemIdString);
            var propId = new Guid(propIdString);

            Item = new ItemRepository().GetById(itemId);
            Property = new PropertyRepository().GetById(propId);
            PropValue = new PropValueRepository().GetByItemAndPropId(itemId, propId);

            UnitOfMeasure = unitIdString != ""
                                ? new GeneralRepository<UnitOfMeasure>().GetById(new Guid(unitIdString))
                                : PropValue.GetProperty.DefaultUnit;

            FormatType = (PropValue.FormatType)Enum.Parse(typeof(PropValue.FormatType), formatTypeString);
        }

        private void GetAddressType()
        {
            MatchCollection matches = ValidationRegex.Matches(_address);
            ThisAddressType = (AddressType)Enum.Parse(typeof(AddressType), matches[0].Groups[1].Value);
        }

        private string[] GetAddressParts()
        {
            if (_address == null)
                throw new Exception("Nao ha endereco de propval para parsear");
            if (!CheckIfIsAddress(_address) || BreakerRegex.Matches(_address).Count == 0)
                throw new Exception("Endereco invalido.");

            MatchCollection matches = BreakerRegex.Matches(_address);

            return (from Match match in matches
                    select match.Groups[1].Value).ToArray();
        }
    }
}